namespace Server.Items
{
    [Furniture]
    [Flipable( 0x280D, 0x280E )]
    public class OrnateWoodenChest : LockableContainer
    {
        [Constructable]
        public OrnateWoodenChest() : base( 0x280D )
        {
        }

        public OrnateWoodenChest( Serial serial ) : base( serial )
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