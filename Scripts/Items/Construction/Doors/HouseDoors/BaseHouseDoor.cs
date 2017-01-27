using System;
using Server.Gumps;
using Server.Multis;

namespace Server.Items
{
    public abstract class BaseHouseDoor : BaseDoor, ISecurable
    {
        private DoorFacing m_Facing;
        private SecureLevel m_Level;

        [CommandProperty( AccessLevel.GameMaster )]
        public DoorFacing Facing
        {
            get{ return m_Facing; }
            set{ m_Facing = value; }
        }

        [CommandProperty( AccessLevel.GameMaster )]
        public SecureLevel Level
        {
            get{ return m_Level; }
            set{ m_Level = value; }
        }

        public BaseHouseDoor( DoorFacing facing, int closedID, int openedID, int openedSound, int closedSound, Point3D offset ) : base( closedID, openedID, openedSound, closedSound, offset )
        {
            m_Facing = facing;
            m_Level = SecureLevel.Anyone;
        }

        public BaseHouse FindHouse()
        {
            Point3D loc;

            if ( Open )
                loc = new Point3D( X - Offset.X, Y - Offset.Y, Z - Offset.Z );
            else
                loc = this.Location;

            return BaseHouse.FindHouseAt( loc, Map, 20 );
        }

        public bool CheckAccess( Mobile m )
        {
            BaseHouse house = FindHouse();

            if ( house == null )
                return false;

            if ( !house.IsAosRules )
                return true;

            if ( house.Public ? house.IsBanned( m ) : !house.HasAccess( m ) )
                return false;

            return house.HasSecureAccess( m, m_Level );
        }

        public override void OnOpened( Mobile from )
        {
            BaseHouse house = FindHouse();

            if ( house != null && house.IsFriend( from ) && from.AccessLevel == AccessLevel.Player && house.RefreshDecay() )
                from.SendLocalizedMessage( 1043293 ); // Your house's age and contents have been refreshed.

            if ( house != null && house.Public && !house.IsFriend( from ) )
                house.Visits++;
        }

        public override bool UseLocks()
        {
            BaseHouse house = FindHouse();

            return ( house == null || !house.IsAosRules );
        }

        public override void Use( Mobile from )
        {
            if ( !CheckAccess( from ) )
                from.SendLocalizedMessage( 1061637 ); // You are not allowed to access this.
            else
                base.Use( from );
        }

        public BaseHouseDoor( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 ); // version

            writer.Write( (int) m_Level );

            writer.Write( (int) m_Facing );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            switch ( version )
            {
                case 1:
                {
                    m_Level = (SecureLevel)reader.ReadInt();
                    goto case 0;
                }
                case 0:
                {
                    if ( version < 1 )
                        m_Level = SecureLevel.Anyone;

                    m_Facing = (DoorFacing)reader.ReadInt();
                    break;
                }
            }
        }

        public override bool IsInside( Mobile from )
        {
            int x,y,w,h;

            const int r = 2;
            const int bs = r*2+1;
            const int ss = r+1;

            switch ( m_Facing )
            {
                case DoorFacing.WestCW:
                case DoorFacing.EastCCW: x = -r; y = -r; w = bs; h = ss; break;

                case DoorFacing.EastCW: 
                case DoorFacing.WestCCW: x = -r; y = 0; w = bs; h = ss; break;

                case DoorFacing.SouthCW:
                case DoorFacing.NorthCCW: x = -r; y = -r; w = ss; h = bs; break;

                case DoorFacing.NorthCW:
                case DoorFacing.SouthCCW: x = 0; y = -r; w = ss; h = bs; break;

                //No way to test the 'insideness' of SE Sliding doors on OSI, so leaving them default to false until furthur information gained

                default: return false;
            }

            int rx = from.X - X;
            int ry = from.Y - Y;
            int az = Math.Abs( from.Z - Z );

            return ( rx >= x && rx < (x+w) && ry >= y && ry < (y+h) && az <= 4 );
        }
    }
}