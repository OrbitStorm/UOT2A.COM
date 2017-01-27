namespace Server.Items
{
    [Flipable( 0x4578, 0x4579 )]
    public class SnowStatueSeahorse : Item
    {
        public override bool ForceShowProperties { get { return ObjectPropertyList.Enabled; } }

        [Constructable]
        public SnowStatueSeahorse()
            : base( 0x4578 )
        {
        }

        public SnowStatueSeahorse( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}