namespace Server.Items
{
    public class MetalDoor2 : BaseDoor
    {
        [Constructable]
        public MetalDoor2( DoorFacing facing ) : base( 0x6C5 + (2 * (int)facing), 0x6C6 + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset( facing ) )
        {
        }

        public MetalDoor2( Serial serial ) : base( serial )
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