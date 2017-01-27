namespace Server.Items
{
    [Furniture]
    [Flipable( 0xa30, 0xa38 )]
    public class FancyDrawer : BaseContainer
    {
        [Constructable]
        public FancyDrawer() : base( 0xA30 )
        {
            Weight = 1.0;
        }

        public FancyDrawer( Serial serial ) : base( serial )
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