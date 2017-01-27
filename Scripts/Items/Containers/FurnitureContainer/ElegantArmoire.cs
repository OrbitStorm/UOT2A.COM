namespace Server.Items
{
    [Furniture]
    [Flipable( 0x2859, 0x285A )]
    public class ElegantArmoire : BaseContainer
    {
        [Constructable]
        public ElegantArmoire() : base( 0x2859 )
        {
            Weight = 1.0;
        }

        public ElegantArmoire( Serial serial ) : base( serial )
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