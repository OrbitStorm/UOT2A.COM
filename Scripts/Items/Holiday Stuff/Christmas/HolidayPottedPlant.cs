namespace Server.Items
{
    public class HolidayPottedPlant : Item
	{
		public override bool ForceShowProperties { get { return ObjectPropertyList.Enabled; } }

		[Constructable]
		public HolidayPottedPlant()
			: this( Utility.RandomMinMax( 0x11C8, 0x11CC ) )
		{
		}

		[Constructable]
		public HolidayPottedPlant( int itemID )
			: base( itemID )
		{
		}

		public HolidayPottedPlant( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
