namespace Server.Items
{
    public class GiftBoxCube : BaseContainer
    {
        public override int DefaultGumpID { get { return 0x11B; } }

        [Constructable]
        public GiftBoxCube()
            : base(0x46A2)
        {
            Hue = GiftBoxHues.RandomGiftBoxHue;
        }

        public GiftBoxCube(Serial serial)
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