using Server.Network;

namespace Server
{
    public class CurrentExpansion
	{
		private static readonly Expansion Expansion = Expansion.T2A;

		public static void Configure()
		{
			Core.Expansion = Expansion;

			ObjectPropertyList.Enabled = false;
			Mobile.VisibleDamageType = VisibleDamageType.None;
			Mobile.GuildClickMessage = true;
			Mobile.AsciiClickMessage = true;

			// OSI-style action delay
			//Mobile.ActionDelay = TimeSpan.FromSeconds( 1.0 );
		}
	}
}
