using System;

namespace Server.Items
{
    public class SlayerEntry
	{
		private SlayerGroup m_Group;
		private SlayerName m_Name;
		private Type[] m_Types;

		public SlayerGroup Group{ get{ return m_Group; } set{ m_Group = value; } }
		public SlayerName Name{ get{ return m_Name; } }
		public Type[] Types{ get{ return m_Types; } }

		private static int[] m_OldTitles = new int[]
			{
				1017384, // Silver
				1017385, // Orc Slaying
				1017386, // Troll Slaughter
				1017387, // Ogre Thrashing
				1017388, // Repond
				1017389, // Dragon Slaying
				1017390, // Terathan
				1017391, // Snake's Bane
				1017392, // Lizardman Slaughter
				1017393, // Reptilian Death
				1017394, // Daemon Dismissal
				1017395, // Gargoyle's Foe
				1017396, // Balron Damnation
				1017397, // Exorcism
				1017398, // Ophidian
				1017399, // Spider's Death
				1017400, // Scorpion's Bane
				1017401, // Arachnid Doom
				1017402, // Flame Dousing
				1017403, // Water Dissipation
				1017404, // Vacuum
				1017405, // Elemental Health
				1017406, // Earth Shatter
				1017407, // Blood Drinking
				1017408, // Summer Wind
				1017409, // Elemental Ban
				1070855  // fey slayer
			};

		public int Title
		{
			get
			{
				int[] titles = ( m_OldTitles );

				return titles[(int)m_Name - 1];
			}
		}

		public SlayerEntry( SlayerName name, params Type[] types )
		{
			m_Name = name;
			m_Types = types;
		}

		public bool Slays( Mobile m )
		{
			Type t = m.GetType();

			for ( int i = 0; i < m_Types.Length; ++i )
			{
				if ( m_Types[i].IsAssignableFrom( t ) )
					return true;
			}

			return false;
		}
	}
}