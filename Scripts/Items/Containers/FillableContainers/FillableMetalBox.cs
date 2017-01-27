namespace Server.Items
{
    [Flipable( 0x9A8, 0xE80 )]
    public class FillableMetalBox : FillableContainer
    {
        [Constructable]
        public FillableMetalBox()
            : base( 0x9A8 )
        {
        }

        public FillableMetalBox( Serial serial )
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

            if( version == 0 && Weight == 3 )
                Weight = -1;
        }
    }
}