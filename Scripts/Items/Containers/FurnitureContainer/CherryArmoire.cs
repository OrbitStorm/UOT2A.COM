namespace Server.Items
{
    [Furniture]
    [Flipable( 0x285D, 0x285E )]
    public class CherryArmoire : BaseContainer
    {
        [Constructable]
        public CherryArmoire() : base( 0x285D )
        {
            Weight = 1.0;
        }

        public CherryArmoire( Serial serial ) : base( serial )
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