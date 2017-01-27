namespace Server.Items
{
    [Furniture]
    [Flipable( 0x9A9, 0xE7E )]
    public class SmallCrate : LockableContainer
    {
        [Constructable]
        public SmallCrate() : base( 0x9A9 )
        {
            Weight = 2.0;
        }

        public SmallCrate( Serial serial ) : base( serial )
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

            if ( Weight == 4.0 )
                Weight = 2.0;
        }
    }
}