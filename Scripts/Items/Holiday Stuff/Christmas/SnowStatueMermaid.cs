namespace Server.Items
{
    [Flipable( 0x457A, 0x457B )]
    public class SnowStatueMermaid : Item
    {
        public override bool ForceShowProperties { get { return ObjectPropertyList.Enabled; } }

        [Constructable]
        public SnowStatueMermaid()
            : base( 0x457A )
        {
        }

        public SnowStatueMermaid( Serial serial )
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