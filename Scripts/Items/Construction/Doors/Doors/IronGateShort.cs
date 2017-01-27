namespace Server.Items
{
    public class IronGateShort : BaseDoor
	{
		[Constructable]
		public IronGateShort( DoorFacing facing ) : base( 0x84c + (2 * (int)facing), 0x84d + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset( facing ) )
		{
		}

		public IronGateShort( Serial serial ) : base( serial )
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