namespace Server.Items
{
    public class IcicleMedSouth : Item
    {
        [Constructable]
        public IcicleMedSouth ()
            : base(0x4573)
        {
        }

        public IcicleMedSouth (Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}