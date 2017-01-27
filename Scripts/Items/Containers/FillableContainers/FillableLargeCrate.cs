namespace Server.Items
{
    [Flipable( 0xE3D, 0xE3C )]
    public class FillableLargeCrate : FillableContainer
    {
        [Constructable]
        public FillableLargeCrate()
            : base( 0xE3D )
        {
            Weight = 1.0;
        }

        public FillableLargeCrate( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( (int)0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}