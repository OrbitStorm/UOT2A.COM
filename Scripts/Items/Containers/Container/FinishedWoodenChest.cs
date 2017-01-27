namespace Server.Items
{
    [Furniture]
    [Flipable( 0x2813, 0x2814 )]
    public class FinishedWoodenChest : LockableContainer
    {
        [Constructable]
        public FinishedWoodenChest() : base( 0x2813 )
        {
        }

        public FinishedWoodenChest( Serial serial ) : base( serial )
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