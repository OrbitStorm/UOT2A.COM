namespace Server.Items
{
    [DynamicFliping]
    [Flipable( 0x9A8, 0xE80 )]
    public class MetalBox : LockableContainer
    {
        [Constructable]
        public MetalBox() : base( 0x9A8 )
        {
        }

        public MetalBox( Serial serial ) : base( serial )
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

            if ( version == 0 && Weight == 3 )
                Weight = -1;
        }
    }
}