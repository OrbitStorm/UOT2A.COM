namespace Server.Items
{
    public abstract class BaseBagBall : BaseContainer, IDyable
    {
        public BaseBagBall( int itemID ) : base( itemID )
        {
            Weight = 1.0;
        }

        public BaseBagBall( Serial serial ) : base( serial )
        {
        }

        public bool Dye( Mobile from, DyeTub sender )
        {
            if ( Deleted )
                return false;

            Hue = sender.DyedHue;

            return true;
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