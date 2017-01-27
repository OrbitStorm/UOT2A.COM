namespace Server.Items
{
    public class SecretStoneDoor1 : BaseDoor
	{
		[Constructable]
		public SecretStoneDoor1( DoorFacing facing ) : base( 0xE8 + (2 * (int)facing), 0xE9 + (2 * (int)facing), 0xED, 0xF4, BaseDoor.GetOffset( facing ) )
		{
		}

		public SecretStoneDoor1( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer ) // Default Serialize method
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader ) // Default Deserialize method
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}