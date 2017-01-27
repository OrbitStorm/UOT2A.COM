namespace Server.Items
{
    [Furniture]
    [Flipable( 0xB57, 0xB56, 0xB59, 0xB58 )]
    public class WoodenChair : Item
    {
        [Constructable]
        public WoodenChair() : base(0xB57)
        {
            Weight = 20.0;
        }

        public WoodenChair(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if ( Weight == 6.0 )
                Weight = 20.0;
        }
    }
}