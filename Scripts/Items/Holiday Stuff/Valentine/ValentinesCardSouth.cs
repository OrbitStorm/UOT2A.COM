namespace Server.Items
{
    public class ValentinesCardSouth : ValentinesCard
    {
        [Constructable]
        public ValentinesCardSouth()
            : base(0x0EBD)
        {
        }

        public ValentinesCardSouth(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}