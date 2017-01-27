namespace Server.Items
{
    public class GiftBoxHues
	{
		public static int RandomGiftBoxHue{ get { return m_NormalHues[Utility.Random(m_NormalHues.Length)]; }}
		public static int RandomNeonBoxHue{ get { return m_NeonHues[Utility.Random(m_NeonHues.Length)]; }}

		/* there's possibly a couple more, but this is what we could verify on OSI */

		private static readonly int[] m_NormalHues =
		{
			0x672,
			0x454,
			0x507,
			0x4ac,
			0x504,
			0x84b,
			0x495,
			0x97c,
			0x493,
			0x4a8,
			0x494,
			0x4aa,
			0xb8b,
			0x84f,
			0x491,
			0x851,
			0x503,
			0xb8c,
			0x4ab,
			0x84B
		};
		private static readonly int[] m_NeonHues =
		{
			0x438,
			0x424,
			0x433,
			0x445,
			0x42b,
			0x448
		};
	}
}