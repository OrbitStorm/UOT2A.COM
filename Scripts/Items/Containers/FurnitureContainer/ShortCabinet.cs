namespace Server.Items
{
    [Furniture]
    [Flipable( 0x2817, 0x2818 )]
    public class ShortCabinet : BaseContainer
    {
        [Constructable]
        public ShortCabinet() : base( 0x2817 )
        {
            Weight = 1.0;
        }

        public ShortCabinet( Serial serial ) : base( serial )
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