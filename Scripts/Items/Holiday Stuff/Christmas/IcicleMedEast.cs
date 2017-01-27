namespace Server.Items
{
    public class  IcicleMedEast : Item
    {
        [Constructable]
        public IcicleMedEast ()
            : base(0x4576)
        {
        }

        public IcicleMedEast (Serial serial)
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