namespace Server.Items
{
    public class SecretWoodenDoor : BaseDoor
    {
        [Constructable]
        public SecretWoodenDoor( DoorFacing facing ) : base( 0x334 + (2 * (int)facing), 0x335 + (2 * (int)facing), 0xED, 0xF4, BaseDoor.GetOffset( facing ) )
        {
        }

        public SecretWoodenDoor( Serial serial ) : base( serial )
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