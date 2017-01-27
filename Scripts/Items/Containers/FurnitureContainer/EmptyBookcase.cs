namespace Server.Items
{
    [Furniture]
    [Flipable( 0xa9d, 0xa9e )]
    public class EmptyBookcase : BaseContainer
    {
        [Constructable]
        public EmptyBookcase() : base( 0xA9D )
        {
        }

        public EmptyBookcase( Serial serial ) : base( serial )
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

            if ( version == 0 && Weight == 1.0 )
                Weight = -1;
        }
    }
}