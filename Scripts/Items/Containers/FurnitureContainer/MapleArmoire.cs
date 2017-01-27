namespace Server.Items
{
    [Furniture]
    [Flipable( 0x285B, 0x285C )]
    public class MapleArmoire : BaseContainer
    {
        [Constructable]
        public MapleArmoire() : base( 0x285B )
        {
            Weight = 1.0;
        }

        public MapleArmoire( Serial serial ) : base( serial )
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
    }
}