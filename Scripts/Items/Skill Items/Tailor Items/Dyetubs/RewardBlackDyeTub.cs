namespace Server.Items
{
    public class RewardBlackDyeTub : DyeTub
	{
		public override int LabelNumber{ get{ return 1006008; } } // Black Dye Tub

		[Constructable]
		public RewardBlackDyeTub()
		{
			Hue = DyedHue = 0x0001;
			Redyable = false;
			LootType = LootType.Blessed;
		}

		public RewardBlackDyeTub( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}