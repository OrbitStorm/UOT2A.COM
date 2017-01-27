using System;
using Server.Gumps;
using Server.Multis;
using Server.Network;

namespace Server.Items
{
    public class WreathAddon : Item, IDyable, IAddon
	{
		[Constructable]
		public WreathAddon() : this( Utility.RandomDyedHue() )
		{
		}

		[Constructable]
		public WreathAddon( int hue ) : base( 0x232C )
		{
			Hue = hue;
			Movable = false;
		}

		public WreathAddon( Serial serial ) : base( serial )
		{
		}

		public bool CouldFit( IPoint3D p, Map map )
		{
			if ( !map.CanFit( p.X, p.Y, p.Z, this.ItemData.Height ) )
				return false;

			if ( this.ItemID == 0x232C )
				return BaseAddon.IsWall( p.X, p.Y - 1, p.Z, map ); // North wall
			else
				return BaseAddon.IsWall( p.X - 1, p.Y, p.Z, map ); // West wall
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

			Timer.DelayCall( TimeSpan.Zero, new TimerCallback( FixMovingCrate ) );
		}

		private void FixMovingCrate()
		{
			if ( this.Deleted )
				return;

			if ( this.Movable || this.IsLockedDown )
			{
				Item deed = this.Deed;

				if ( this.Parent is Item )
				{
					((Item)this.Parent).AddItem( deed );
					deed.Location = this.Location;
				}
				else
				{
					deed.MoveToWorld( this.Location, this.Map );
				}

				Delete();
			}
		}

		public Item Deed
		{
			get{ return new WreathDeed( this.Hue ); }
		}

		public override void OnDoubleClick( Mobile from )
		{
			BaseHouse house = BaseHouse.FindHouseAt( this );

			if ( house != null && house.IsCoOwner( from ) )
			{
				if ( from.InRange( this.GetWorldLocation(), 3 ) )
				{
					from.CloseGump( typeof( WreathAddonGump ) );
					from.SendGump( new WreathAddonGump( from, this ) );
				}
				else
				{
					from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
				}
			}
		}

		public virtual bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			BaseHouse house = BaseHouse.FindHouseAt( this );

			if ( house != null && house.IsCoOwner( from ) )
			{
				if ( from.InRange( GetWorldLocation(), 1 ) )
				{
					Hue = sender.DyedHue;
					return true;
				}
				else
				{
					from.SendLocalizedMessage( 500295 ); // You are too far away to do that.
					return false;
				}
			}
			else 
			{
				return false;
			}
		}

		private class WreathAddonGump : Gump
		{
			private Mobile m_From;
			private WreathAddon m_Addon;

			public WreathAddonGump( Mobile from, WreathAddon addon ) : base( 150, 50 )
			{
				m_From = from;
				m_Addon = addon;

				AddPage( 0 );

				AddBackground( 0, 0, 220, 170, 0x13BE );
				AddBackground( 10, 10, 200, 150, 0xBB8 );
				AddHtmlLocalized( 20, 30, 180, 60, 1062839, false, false ); // Do you wish to re-deed this decoration?
				AddHtmlLocalized( 55, 100, 160, 25, 1011011, false, false ); // CONTINUE
				AddButton( 20, 100, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0 );
				AddHtmlLocalized( 55, 125, 160, 25, 1011012, false, false ); // CANCEL
				AddButton( 20, 125, 0xFA5, 0xFA7, 0, GumpButtonType.Reply, 0 );
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( m_Addon.Deleted )
					return;

				if ( info.ButtonID == 1 )
				{
					if ( m_From.InRange( m_Addon.GetWorldLocation(), 3 ) )
					{
						m_From.AddToBackpack( m_Addon.Deed );
						m_Addon.Delete();
					}
					else
					{
						m_From.SendLocalizedMessage( 500295 ); // You are too far away to do that.
					}
				}
			}
		}
	}
}