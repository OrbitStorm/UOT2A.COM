namespace Server.Items
{
    [Furniture]
    [Flipable( 0xE3D, 0xE3C )]
    public class LargeCrate : LockableContainer
    {
        [Constructable]
        public LargeCrate() : base( 0xE3D )
        {
            Weight = 1.0;
        }

        public LargeCrate( Serial serial ) : base( serial )
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

            if ( Weight == 8.0 )
                Weight = 1.0;
        }
    }
}