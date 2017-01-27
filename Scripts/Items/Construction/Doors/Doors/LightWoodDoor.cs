namespace Server.Items
{
    public class LightWoodDoor : BaseDoor
    {
        [Constructable]
        public LightWoodDoor( DoorFacing facing ) : base( 0x6D5 + (2 * (int)facing), 0x6D6 + (2 * (int)facing), 0xEA, 0xF1, BaseDoor.GetOffset( facing ) )
        {
        }

        public LightWoodDoor( Serial serial ) : base( serial )
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