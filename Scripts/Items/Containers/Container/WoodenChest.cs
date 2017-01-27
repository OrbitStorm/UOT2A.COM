namespace Server.Items
{
    [Furniture]
    [Flipable( 0xe43, 0xe42 )]
    public class WoodenChest : LockableContainer
    {
        [Constructable]
        public WoodenChest() : base( 0xe43 )
        {
            Weight = 2.0;
        }

        public WoodenChest( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if ( Weight == 15.0 )
                Weight = 2.0;
        }
    }
}