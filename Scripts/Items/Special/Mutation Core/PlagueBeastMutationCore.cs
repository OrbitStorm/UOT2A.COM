using System;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
    public class PlagueBeastMutationCore : Item, IScissorable
	{
		private bool m_Cut;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Cut
		{
			get { return m_Cut; }
			set { m_Cut = value; }
		}

		[Constructable]
		public PlagueBeastMutationCore() : base( 0x1CF0 )
		{
			m_Cut = true;

			Name = "a plague beast mutation core";
			Weight = 1.0;
			Hue = 0x480;
		}

		public virtual bool Scissor( Mobile from, Scissors scissors )
		{
			return false;
		}

		public PlagueBeastMutationCore( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version

			writer.Write( (bool) m_Cut );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_Cut = reader.ReadBool();
		}
	}
}
