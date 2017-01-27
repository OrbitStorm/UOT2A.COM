namespace Server.Items
{
    [Flipable( 0x9A9, 0xE7E )]
    public class FillableSmallCrate : FillableContainer
    {
        [Constructable]
        public FillableSmallCrate()
            : base( 0x9A9 )
        {
            Weight = 1.0;
        }

        public FillableSmallCrate( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( (int)0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}