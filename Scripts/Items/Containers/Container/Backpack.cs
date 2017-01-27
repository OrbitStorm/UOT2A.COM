namespace Server.Items
{
    public class Backpack : BaseContainer, IDyable
    {
        [Constructable]
        public Backpack() : base( 0xE75 )
        {
            Layer = Layer.Backpack;
            Weight = 3.0;
        }

        public override int DefaultMaxWeight {
            get {
                if ( Core.ML ) {
                    Mobile m = ParentEntity as Mobile;
                    if ( m != null && m.Player && m.Backpack == this ) {
                        return 550;
                    } else {
                        return base.DefaultMaxWeight;
                    }
                } else {
                    return base.DefaultMaxWeight;
                }
            }
        }

        public Backpack( Serial serial ) : base( serial )
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

            writer.Write( (int) 1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if ( version == 0 && ItemID == 0x9B2 )
                ItemID = 0xE75;
        }
    }
}