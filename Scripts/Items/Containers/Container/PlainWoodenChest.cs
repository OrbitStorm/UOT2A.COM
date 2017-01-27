namespace Server.Items
{
    [Furniture]
    [Flipable( 0x280B, 0x280C )]
    public class PlainWoodenChest : LockableContainer
    {
        [Constructable]
        public PlainWoodenChest() : base( 0x280B )
        {
        }

        public PlainWoodenChest( Serial serial ) : base( serial )
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

            if ( version == 0 && Weight == 15 )
                Weight = -1;
        }
    }
}