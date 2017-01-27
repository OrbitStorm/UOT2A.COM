namespace Server.Items
{
    public class LightWoodGate : BaseDoor
    {
        [Constructable]
        public LightWoodGate( DoorFacing facing ) : base( 0x839 + (2 * (int)facing), 0x83A + (2 * (int)facing), 0xEB, 0xF2, BaseDoor.GetOffset( facing ) )
        {
        }

        public LightWoodGate( Serial serial ) : base( serial )
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