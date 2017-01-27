namespace Server.Items
{
    [Furniture]
    [Flipable( 0xa97, 0xa99, 0xa98, 0xa9a, 0xa9b, 0xa9c )]
    public class FullBookcase : BaseContainer
    {
        [Constructable]
        public FullBookcase() : base( 0xA97 )
        {
            Weight = 1.0;
        }

        public FullBookcase( Serial serial ) : base( serial )
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