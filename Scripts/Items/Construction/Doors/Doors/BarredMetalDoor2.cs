namespace Server.Items
{
    public class BarredMetalDoor2 : BaseDoor
    {
        [Constructable]
        public BarredMetalDoor2( DoorFacing facing ) : base( 0x1FED + (2 * (int)facing), 0x1FEE + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset( facing ) )
        {
        }

        public BarredMetalDoor2( Serial serial ) : base( serial )
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