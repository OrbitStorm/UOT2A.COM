namespace Server.Items
{
    public class IcicleLargeSouth : Item
	{
		[Constructable]
		public IcicleLargeSouth()
			: base(0x4572)
		{
		}

		public IcicleLargeSouth(Serial serial)
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