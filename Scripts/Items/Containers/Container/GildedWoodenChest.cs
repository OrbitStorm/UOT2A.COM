namespace Server.Items
{
    [Furniture]
    [Flipable( 0x280F, 0x2810 )]
    public class GildedWoodenChest : LockableContainer
    {
        [Constructable]
        public GildedWoodenChest() : base( 0x280F )
        {
        }

        public GildedWoodenChest( Serial serial ) : base( serial )
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