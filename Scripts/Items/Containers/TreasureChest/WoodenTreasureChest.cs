namespace Server.Items
{
    [FlipableAttribute( 0xe43, 0xe42 )] 
	public class WoodenTreasureChest : BaseTreasureChest 
	{ 
		[Constructable] 
		public WoodenTreasureChest() : base( 0xE43 ) 
		{ 
		} 

		public WoodenTreasureChest( Serial serial ) : base( serial ) 
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