namespace Server.Items
{
    [Furniture]
    [Flipable( 0x9AA, 0xE7D )]
    public class WoodenBox : LockableContainer
    {
        [Constructable]
        public WoodenBox() : base( 0x9AA )
        {
            Weight = 4.0;
        }

        public WoodenBox( Serial serial ) : base( serial )
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
        }
    }
}