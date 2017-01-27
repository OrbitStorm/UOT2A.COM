namespace Server.Items
{
    public class BarredMetalDoor : BaseDoor
    {
        [Constructable]
        public BarredMetalDoor( DoorFacing facing ) : base( 0x685 + (2 * (int)facing), 0x686 + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset( facing ) )
        {
        }

        public BarredMetalDoor( Serial serial ) : base( serial )
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