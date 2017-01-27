namespace Server.Items
{
    public class CreatureBackpack : Backpack	//Used on BaseCreature
    {
        [Constructable]
        public CreatureBackpack( string name )
        {
            Name = name;
            Layer = Layer.Backpack;
            Hue = 5;
            Weight = 3.0;
        }

        public override void AddNameProperty( ObjectPropertyList list )
        {
            if ( Name != null )
                list.Add( 1075257, Name ); // Contents of ~1_PETNAME~'s pack.
            else
                base.AddNameProperty( list );
        }

        public override void OnItemRemoved( Item item )
        {
            if ( Items.Count == 0 )
                this.Delete();

            base.OnItemRemoved( item );
        }

        public override bool OnDragLift( Mobile from )
        {
            if ( from.AccessLevel > AccessLevel.Player )
                return true;

            from.SendLocalizedMessage( 500169 ); // You cannot pick that up.
            return false;
        }

        public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
        {
            return false;
        }

        public override bool TryDropItem( Mobile from, Item dropped, bool sendFullMessage )
        {
            return false;
        }

        public CreatureBackpack( Serial serial ) : base( serial )
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