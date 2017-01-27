namespace Server.Items
{
    [Furniture]
	[Flipable( 0xB4F, 0xB4E, 0xB50, 0xB51 )]
	public class FancyWoodenChairCushion : Item
	{
		[Constructable]
		public FancyWoodenChairCushion() : base(0xB4F)
		{
			Weight = 20.0;
		}

		public FancyWoodenChairCushion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 6.0 )
				Weight = 20.0;
		}
	}
}