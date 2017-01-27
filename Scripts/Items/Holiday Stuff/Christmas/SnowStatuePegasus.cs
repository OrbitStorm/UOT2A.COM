namespace Server.Items
{
    [Flipable( 0x456E, 0x456F )]
	public class SnowStatuePegasus : Item
	{
		public override bool ForceShowProperties { get { return ObjectPropertyList.Enabled; } }

		[Constructable]
		public SnowStatuePegasus()
			: base( 0x456E )
		{
		}

		public SnowStatuePegasus( Serial serial )
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
