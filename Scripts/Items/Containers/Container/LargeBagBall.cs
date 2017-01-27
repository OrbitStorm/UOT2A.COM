namespace Server.Items
{
    public class LargeBagBall : BaseBagBall
    {
        [Constructable]
        public LargeBagBall() : base( 0x2257 )
        {
        }

        public LargeBagBall( Serial serial ) : base( serial )
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