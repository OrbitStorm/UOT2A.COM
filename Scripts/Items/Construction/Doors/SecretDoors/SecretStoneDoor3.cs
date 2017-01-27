namespace Server.Items
{
    public class SecretStoneDoor3 : BaseDoor
    {
        [Constructable]
        public SecretStoneDoor3( DoorFacing facing ) : base( 0x354 + (2 * (int)facing), 0x355 + (2 * (int)facing), 0xED, 0xF4, BaseDoor.GetOffset( facing ) )
        {
        }

        public SecretStoneDoor3( Serial serial ) : base( serial )
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