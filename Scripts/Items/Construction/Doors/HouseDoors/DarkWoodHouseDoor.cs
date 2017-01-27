namespace Server.Items
{
    public class DarkWoodHouseDoor : BaseHouseDoor
    {
        [Constructable]
        public DarkWoodHouseDoor( DoorFacing facing ) : base( facing, 0x6A5 + (2 * (int)facing), 0x6A6 + (2 * (int)facing), 0xEA, 0xF1, BaseDoor.GetOffset( facing ) )
        {
        }

        public DarkWoodHouseDoor( Serial serial ) : base( serial )
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