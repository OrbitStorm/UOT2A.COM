using System;
using System.Collections.Generic;
using Server.Accounting;

namespace Server.Misc
{
    public class GiftGiving
	{
		private static List<GiftGiver> m_Givers = new List<GiftGiver>();

		public static void Register( GiftGiver giver )
		{
			m_Givers.Add( giver );
		}

		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( EventSink_Login );
		}

		private static void EventSink_Login( LoginEventArgs e )
		{
			Account acct = e.Mobile.Account as Account;

			if ( acct == null )
				return;

			DateTime now = DateTime.Now;

			for ( int i = 0; i < m_Givers.Count; ++i )
			{
				GiftGiver giver = m_Givers[i];

				if ( now < giver.Start || now >= giver.Finish )
					continue; // not in the correct timefream

				if ( acct.Created > (giver.Start - giver.MinimumAge) )
					continue; // newly created account

				if ( acct.LastLogin >= giver.Start )
					continue; // already got one

				giver.DelayGiveGift( TimeSpan.FromSeconds( 5.0 ), e.Mobile );
			}

			acct.LastLogin = now;
		}
	}
}