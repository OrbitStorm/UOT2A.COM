namespace Server.Items
{
    public class Bag : BaseContainer, IDyable
    {
        [Constructable]
        public Bag() : base( 0xE76 )
        {
            Weight = 2.0;
        }

        public Bag( Serial serial ) : base( serial )
        {
        }

        public bool Dye( Mobile from, DyeTub sender )
        {
            if ( Deleted ) return false;

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