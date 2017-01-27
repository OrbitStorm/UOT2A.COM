namespace Server.Items
{
    [Furniture]
    [Flipable( 0x2857, 0x2858 )]
    public class RedArmoire : BaseContainer
    {
        [Constructable]
        public RedArmoire() : base( 0x2857 )
        {
            Weight = 1.0;
        }

        public RedArmoire( Serial serial ) : base( serial )
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