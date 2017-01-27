namespace Server.Items
{
    public class GenericHouseDoor : BaseHouseDoor
    {
        [Constructable]
        public GenericHouseDoor( DoorFacing facing, int baseItemID, int openedSound, int closedSound ) : this( facing, baseItemID, openedSound, closedSound, true )
        {
        }

        [Constructable]
        public GenericHouseDoor( DoorFacing facing, int baseItemID, int openedSound, int closedSound, bool autoAdjust )
            : base( facing, baseItemID + (autoAdjust ? (2 * (int)facing) : 0), baseItemID + 1 + (autoAdjust ? (2 * (int)facing) : 0), openedSound, closedSound, BaseDoor.GetOffset( facing ) )
        {
        }

        public GenericHouseDoor( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer ) // Default Serialize method
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader ) // Default Deserialize method
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}