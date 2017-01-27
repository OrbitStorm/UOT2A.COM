namespace Server.Items
{
    public class IcicleLargeEast : Item
    {
        [Constructable]
        public IcicleLargeEast ()
            : base(0x4575)
        {
        }

        public IcicleLargeEast (Serial serial)
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