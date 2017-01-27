namespace Server.Items
{
    [Furniture]
    [Flipable(0xB8F,0xB7C)]
    public class YewWoodTable : Item
    {
        [Constructable]
        public YewWoodTable() : base(0xB8F)
        {
            Weight = 1.0;
        }

        public YewWoodTable(Serial serial) : base(serial)
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