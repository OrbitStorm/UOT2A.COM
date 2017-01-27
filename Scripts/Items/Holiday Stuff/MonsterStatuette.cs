using Server.Multis;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
    public class MonsterStatuette : Item
	{
		private MonsterStatuetteType m_Type;
		private bool m_TurnedOn;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool TurnedOn
		{
			get{ return m_TurnedOn; }
			set{ m_TurnedOn = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public MonsterStatuetteType Type
		{
			get{ return m_Type; }
			set
			{
				m_Type = value;
				ItemID = MonsterStatuetteInfo.GetInfo( m_Type ).ItemID;

				if( m_Type == MonsterStatuetteType.Slime )
					Hue = Utility.RandomSlimeHue();
				else if( m_Type == MonsterStatuetteType.RedDeath )
					Hue = 0x21;
				else if( m_Type == MonsterStatuetteType.HalloweenGhoul )
					Hue = 0xF4;
				else
					Hue = 0;

				InvalidateProperties();
			}
		}

		public override int LabelNumber
		{
			get{ return MonsterStatuetteInfo.GetInfo( m_Type ).LabelNumber; }
		}

		public override double DefaultWeight
		{
			get { return 1.0; }
		}

		[Constructable]
		public MonsterStatuette() : this( MonsterStatuetteType.Crocodile )
		{
		}

		[Constructable]
		public MonsterStatuette( MonsterStatuetteType type ) : base( MonsterStatuetteInfo.GetInfo( type ).ItemID )
		{
			LootType = LootType.Blessed;

			m_Type = type;

			if( m_Type == MonsterStatuetteType.Slime )
				Hue = Utility.RandomSlimeHue();
			else if( m_Type == MonsterStatuetteType.RedDeath )
				Hue = 0x21;
			else if( m_Type == MonsterStatuetteType.HalloweenGhoul )
				Hue = 0xF4;
		}

		public override bool HandlesOnMovement{ get{ return m_TurnedOn && IsLockedDown; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m_TurnedOn && IsLockedDown && (!m.Hidden || m.AccessLevel == AccessLevel.Player) && Utility.InRange( m.Location, this.Location, 2 ) && !Utility.InRange( oldLocation, this.Location, 2 ) )
			{
				int[] sounds = MonsterStatuetteInfo.GetInfo( m_Type ).Sounds;

				if( sounds.Length > 0 )
					Effects.PlaySound( this.Location, this.Map, sounds[Utility.Random( sounds.Length )] );
			}

			base.OnMovement( m, oldLocation );
		}

		public MonsterStatuette( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_TurnedOn )
				list.Add( 502695 ); // turned on
			else
				list.Add( 502696 ); // turned off
		}

		public bool IsOwner( Mobile mob )
		{
			BaseHouse house = BaseHouse.FindHouseAt( this );

			return ( house != null && house.IsOwner( mob ) );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsOwner( from ) )
			{
				OnOffGump onOffGump = new OnOffGump( this );
				from.SendGump( onOffGump );
			}
			else
			{
				from.SendLocalizedMessage( 502691 ); // You must be the owner to use this.
			}
		}

		private class OnOffGump : Gump
		{
			private MonsterStatuette m_Statuette;

			public OnOffGump( MonsterStatuette statuette ) : base( 150, 200 )
			{
				m_Statuette = statuette;

				AddBackground( 0, 0, 300, 150, 0xA28 );

				AddHtmlLocalized( 45, 20, 300, 35, statuette.TurnedOn ? 1011035 : 1011034, false, false ); // [De]Activate this item

				AddButton( 40, 53, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0 );
				AddHtmlLocalized( 80, 55, 65, 35, 1011036, false, false ); // OKAY

				AddButton( 150, 53, 0xFA5, 0xFA7, 0, GumpButtonType.Reply, 0 );
				AddHtmlLocalized( 190, 55, 100, 35, 1011012, false, false ); // CANCEL
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				Mobile from = sender.Mobile;

				if ( info.ButtonID == 1 )
				{
					bool newValue = !m_Statuette.TurnedOn;
					m_Statuette.TurnedOn = newValue;

					if ( newValue && !m_Statuette.IsLockedDown )
						from.SendLocalizedMessage( 502693 ); // Remember, this only works when locked down.
				}
				else
				{
					from.SendLocalizedMessage( 502694 ); // Cancelled action.
				}
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.WriteEncodedInt( (int) m_Type );
			writer.Write( (bool) m_TurnedOn );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Type = (MonsterStatuetteType)reader.ReadEncodedInt();
					m_TurnedOn = reader.ReadBool();
					break;
				}
			}
		}
	}
}