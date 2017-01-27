namespace Server.Items
{
    [Furniture]
    [Flipable(0xB90,0xB7D)]
    public class LargeTable : Item
    {
        [Constructable]
        public LargeTable() : base(0xB90)
        {
            Weight = 1.0;
        }

        public LargeTable(Serial serial) : base(serial)
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

            if ( Weight == 4.0 )
                Weight = 1.0;
        }
    }
}