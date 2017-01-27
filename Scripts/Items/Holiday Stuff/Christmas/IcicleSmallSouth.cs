namespace Server.Items
{
    public class IcicleSmallSouth : Item
    {
        [Constructable]
        public IcicleSmallSouth ()
            : base(0x4574)
        {
        }

        public IcicleSmallSouth (Serial serial)
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