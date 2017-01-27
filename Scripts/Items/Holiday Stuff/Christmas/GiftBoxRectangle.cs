namespace Server.Items
{
    [Flipable(0x46A5, 0x46A6)]
    public class GiftBoxRectangle  : BaseContainer
    {
        public override int DefaultGumpID { get { return 0x11E; } }

        [Constructable]
        public GiftBoxRectangle()
            : base(Utility.RandomBool() ? 0x46A5 : 0x46A6)
        {
            Hue = GiftBoxHues.RandomGiftBoxHue;
        }

        public GiftBoxRectangle(Serial serial)
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