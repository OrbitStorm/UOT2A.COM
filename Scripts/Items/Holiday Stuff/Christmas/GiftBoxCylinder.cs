namespace Server.Items
{
    public class GiftBoxCylinder : BaseContainer
    {
        public override int DefaultGumpID { get { return 0x11C; } }

        [Constructable]
        public GiftBoxCylinder()
            : base(0x46A3)
        {
            Hue = GiftBoxHues.RandomGiftBoxHue;
        }

        public GiftBoxCylinder(Serial serial)
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