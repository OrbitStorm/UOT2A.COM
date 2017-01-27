namespace Server.Items
{
    public class FillableBarrel : FillableContainer
    {
        public override bool IsLockable { get { return false; } }

        [Constructable]
        public FillableBarrel()
            : base( 0xE77 )
        {
        }

        public FillableBarrel( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( (int)1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();

            if( version == 0 && Weight == 25 )
                Weight = -1;
        }
    }
}