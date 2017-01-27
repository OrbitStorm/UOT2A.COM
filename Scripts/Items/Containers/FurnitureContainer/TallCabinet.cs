namespace Server.Items
{
    [Furniture]
	[Flipable( 0x2815, 0x2816 )]
	public class TallCabinet : BaseContainer
	{
		[Constructable]
		public TallCabinet() : base( 0x2815 )
		{
			Weight = 1.0;
		}

		public TallCabinet( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}