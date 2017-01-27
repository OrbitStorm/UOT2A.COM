namespace Server.Items
{
    [Flipable( 0xE41, 0xE40 )]
    public class FillableMetalGoldenChest : FillableContainer
    {
        [Constructable]
        public FillableMetalGoldenChest()
            : base( 0xE41 )
        {
        }

        public FillableMetalGoldenChest( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if( version == 0 && Weight == 25 )
                Weight = -1;
        }
    }
}