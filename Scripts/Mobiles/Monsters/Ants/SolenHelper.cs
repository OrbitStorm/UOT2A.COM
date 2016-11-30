using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	public class SolenHelper
	{
		public static void PackPicnicBasket( BaseCreature solen )
		{
			if ( 1 > Utility.Random( 100 ) )
			{
				PicnicBasket basket = new PicnicBasket();

				basket.DropItem( new BeverageBottle( BeverageType.Wine ) );
				basket.DropItem( new CheeseWedge() );

				solen.PackItem( basket );
			}
		}

		public static void OnRedDamage( Mobile from )
		{
			if ( from is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)from;

				if ( bc.Controlled && bc.ControlMaster is PlayerMobile )
					OnRedDamage( bc.ControlMaster );
				else if ( bc.Summoned && bc.SummonMaster is PlayerMobile )
					OnRedDamage( bc.SummonMaster );
			}
		}

		public static void OnBlackDamage( Mobile from )
		{
			if ( from is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)from;

				if ( bc.Controlled && bc.ControlMaster is PlayerMobile )
					OnBlackDamage( bc.ControlMaster );
				else if ( bc.Summoned && bc.SummonMaster is PlayerMobile )
					OnBlackDamage( bc.SummonMaster );
			}
		}
	}
}