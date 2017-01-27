namespace Server.Items
{
    [Furniture]
    [Flipable( 0xa4d, 0xa51 )]
    public class FancyArmoire : BaseContainer
    {
        [Constructable]
        public FancyArmoire() : base( 0xA4D )
        {
            Weight = 1.0;
        }

        public override void DisplayTo( Mobile m )
        {
            if ( DynamicFurniture.Open( this, m ) )
                base.DisplayTo( m );
        }

        public FancyArmoire( Serial serial ) : base( serial )
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

            DynamicFurniture.Close( this );
        }
    }
}