namespace Server.Items
{
    [DynamicFliping]
    [Flipable( 0x9AB, 0xE7C )]
    public class MetalChest : LockableContainer
    {
        [Constructable]
        public MetalChest() : base( 0x9AB )
        {
        }

        public MetalChest( Serial serial ) : base( serial )
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