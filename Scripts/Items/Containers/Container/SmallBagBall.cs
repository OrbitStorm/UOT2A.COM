namespace Server.Items
{
    public class SmallBagBall : BaseBagBall
    {
        [Constructable]
        public SmallBagBall() : base( 0x2256 )
        {
        }

        public SmallBagBall( Serial serial ) : base( serial )
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