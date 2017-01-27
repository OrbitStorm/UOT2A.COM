using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
    [Flipable( 0x14F0, 0x14EF )]
    public class WreathDeed : Item
    {
        public override int LabelNumber{ get{ return 1062837; } } // holiday wreath deed

        [Constructable]
        public WreathDeed() : this( Utility.RandomDyedHue() )
        {
        }

        [Constructable]
        public WreathDeed( int hue ) : base( 0x14F0 )
        {
            Weight = 1.0;
            Hue = hue;
            LootType = LootType.Blessed;
        }

        public WreathDeed( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }

        public override void OnDoubleClick( Mobile from )
        {
            if ( IsChildOf( from.Backpack ) )
            {
                BaseHouse house = BaseHouse.FindHouseAt( from );

                if ( house != null && house.IsCoOwner( from ) )
                {
                    from.SendLocalizedMessage( 1062838 ); // Where would you like to place this decoration?
                    from.BeginTarget( -1, true, TargetFlags.None, new TargetStateCallback( Placement_OnTarget ), null );
                }
                else
                {
                    from.SendLocalizedMessage( 502092 ); // You must be in your house to do this.
                }
            }
            else
            {
                from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
            }
        }

        public void Placement_OnTarget( Mobile from, object targeted, object state )
        {
            IPoint3D p = targeted as IPoint3D;

            if ( p == null )
                return;

            Point3D loc = new Point3D( p );

            BaseHouse house = BaseHouse.FindHouseAt( loc, from.Map, 16 );

            if ( house != null && house.IsCoOwner( from ) )
            {
                bool northWall = BaseAddon.IsWall( loc.X, loc.Y - 1, loc.Z, from.Map );
                bool westWall = BaseAddon.IsWall( loc.X - 1, loc.Y, loc.Z, from.Map );

                if ( northWall && westWall )
                    from.SendGump( new WreathDeedGump( from, loc, this ) );
                else
                    PlaceAddon( from, loc, northWall, westWall );
            }
            else
            {
                from.SendLocalizedMessage( 1042036 ); // That location is not in your house.
            }
        }

        private void PlaceAddon( Mobile from, Point3D loc, bool northWall, bool westWall )
        {
            if ( Deleted )
                return;

            BaseHouse house = BaseHouse.FindHouseAt( loc, from.Map, 16 );

            if ( house == null || !house.IsCoOwner( from ) )
            {
                from.SendLocalizedMessage( 1042036 ); // That location is not in your house.
                return;
            }

            int itemID = 0;

            if ( northWall )
                itemID = 0x232C;
            else if ( westWall )
                itemID = 0x232D;
            else
                from.SendLocalizedMessage( 1062840 ); // The decoration must be placed next to a wall.

            if ( itemID > 0 )
            {
                Item addon = new WreathAddon( this.Hue );

                addon.ItemID = itemID;
                addon.MoveToWorld( loc, from.Map );

                house.Addons.Add( addon );
                Delete();
            }
        }

        private class WreathDeedGump : Gump
        {
            private Mobile m_From;
            private Point3D m_Loc;
            private WreathDeed m_Deed;

            public WreathDeedGump( Mobile from, Point3D loc, WreathDeed deed ) : base( 150, 50 )
            {
                m_From = from;
                m_Loc = loc;
                m_Deed = deed;

                AddBackground( 0, 0, 300, 150, 0xA28 );

                AddPage( 0 );

                AddItem( 90, 30, 0x232D );
                AddItem( 180, 30, 0x232C );
                AddButton( 50, 35, 0x868, 0x869, 1, GumpButtonType.Reply, 0 );
                AddButton( 145, 35, 0x868, 0x869, 2, GumpButtonType.Reply, 0 );
            }

            public override void OnResponse( NetState sender, RelayInfo info )
            {
                if ( m_Deed.Deleted )
                    return;

                switch( info.ButtonID )
                {
                    case 1:
                        m_Deed.PlaceAddon( m_From, m_Loc, false, true );
                        break;
                    case 2:
                        m_Deed.PlaceAddon( m_From, m_Loc, true, false );
                        break;
                }
            }
        }
    }
}