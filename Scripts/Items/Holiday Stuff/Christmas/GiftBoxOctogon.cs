namespace Server.Items
{
    public class GiftBoxOctogon : BaseContainer
    {
        public override int DefaultGumpID { get { return 0x11D; } }

        [Constructable]
        public GiftBoxOctogon()
            : base(0x46A4)
        {
            Hue = GiftBoxHues.RandomGiftBoxHue;
        }

        public GiftBoxOctogon(Serial serial)
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