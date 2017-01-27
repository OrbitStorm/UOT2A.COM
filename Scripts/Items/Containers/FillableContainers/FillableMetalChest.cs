namespace Server.Items
{
    [Flipable( 0x9AB, 0xE7C )]
    public class FillableMetalChest : FillableContainer
    {
        [Constructable]
        public FillableMetalChest()
            : base( 0x9AB )
        {
        }

        public FillableMetalChest( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 ); // version
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