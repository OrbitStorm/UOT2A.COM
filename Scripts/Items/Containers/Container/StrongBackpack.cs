using Server.Mobiles;

namespace Server.Items
{
    public class StrongBackpack : Backpack	//Used on Pack animals
    {
        [Constructable]
        public StrongBackpack()
        {
            Layer = Layer.Backpack;
            Weight = 13.0;
        }

        public override bool CheckHold( Mobile m, Item item, bool message, bool checkItems, int plusItems, int plusWeight )
        {
            return base.CheckHold( m, item, false, checkItems, plusItems, plusWeight );
        }

        public override int DefaultMaxWeight{ get{ return 1600; } }

        public override bool CheckContentDisplay( Mobile from )
        {
            object root = this.RootParent;

            if ( root is BaseCreature && ((BaseCreature)root).Controlled && ((BaseCreature)root).ControlMaster == from )
                return true;

            return base.CheckContentDisplay( from );
        }

        public StrongBackpack( Serial serial ) : base( serial )
        {
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

            if ( version == 0 )
                Weight = 13.0;
        }
    }
}