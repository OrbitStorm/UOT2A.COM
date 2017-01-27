namespace Server.Items
{
    public class IcicleSmallEast : Item
    {
        [Constructable]
        public IcicleSmallEast ()
            : base(0x4577)
        {
        }

        public IcicleSmallEast(Serial serial)
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