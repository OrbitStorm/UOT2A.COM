namespace Server.Items
{
    [Furniture]
    public class FootStool : Item
    {
        [Constructable]
        public FootStool() : base( 0xB5E )
        {
            Weight = 6.0;
        }

        public FootStool(Serial serial) : base(serial)
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
                Weight = 10.0;
        }
    }
}