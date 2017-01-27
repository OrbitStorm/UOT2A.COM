namespace Server.Items
{
    [Furniture]
    [Flipable( 0xa2c, 0xa34 )]
    public class Drawer : BaseContainer
    {
        [Constructable]
        public Drawer() : base( 0xA2C )
        {
            Weight = 1.0;
        }

        public Drawer( Serial serial ) : base( serial )
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