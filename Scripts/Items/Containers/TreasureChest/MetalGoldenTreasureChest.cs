namespace Server.Items
{
    [Flipable( 0xe41, 0xe40 )] 
    public class MetalGoldenTreasureChest : BaseTreasureChest 
    {
        [Constructable] 
        public MetalGoldenTreasureChest() : base( 0xE41 ) 
        { 
        } 

        public MetalGoldenTreasureChest( Serial serial ) : base( serial ) 
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