namespace Server.Items
{
    [Furniture]
    [Flipable( 0xE3F, 0xE3E )]
    public class MediumCrate : LockableContainer
    {
        [Constructable]
        public MediumCrate() : base( 0xE3F )
        {
            Weight = 2.0;
        }

        public MediumCrate( Serial serial ) : base( serial )
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

            if ( Weight == 6.0 )
                Weight = 2.0;
        }
    }
}