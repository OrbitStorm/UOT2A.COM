namespace Server.Items
{
    [DynamicFliping]
    [Flipable( 0xE41, 0xE40 )]
    public class MetalGoldenChest : LockableContainer
    {
        [Constructable]
        public MetalGoldenChest() : base( 0xE41 )
        {
        }

        public MetalGoldenChest( Serial serial ) : base( serial )
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

            if ( version == 0 && Weight == 25 )
                Weight = -1;
        }
    }
}