namespace Server.Items
{
    [Flipable(0x232A, 0x232B)]
    public class GiftBoxNeon : BaseContainer
    {
        [Constructable]
        public GiftBoxNeon()
            : base(Utility.RandomBool() ? 0x232A : 0x232B)
        {
            Hue = GiftBoxHues.RandomNeonBoxHue;
        }

        public GiftBoxNeon(Serial serial)
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