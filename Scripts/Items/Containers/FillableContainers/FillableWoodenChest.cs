namespace Server.Items
{
    [Flipable( 0xE43, 0xE42 )]
    public class FillableWoodenChest : FillableContainer
    {
        [Constructable]
        public FillableWoodenChest()
            : base( 0xE43 )
        {
        }

        public FillableWoodenChest( Serial serial )
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

            if( version == 0 && Weight == 2 )
                Weight = -1;
        }
    }
}