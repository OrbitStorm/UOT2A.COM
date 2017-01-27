namespace Server.Items
{
    [Flipable( 0x457C, 0x457D )]
    public class SnowStatueGriffon : Item
    {
        public override bool ForceShowProperties { get { return ObjectPropertyList.Enabled; } }

        [Constructable]
        public SnowStatueGriffon()
            : base( 0x457C )
        {
        }

        public SnowStatueGriffon( Serial serial )
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