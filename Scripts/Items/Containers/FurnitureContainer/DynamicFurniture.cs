using System.Collections.Generic;

namespace Server.Items
{
    public class DynamicFurniture
    {
        private static Dictionary<Container, Timer> m_Table = new Dictionary<Container, Timer>();

        public static bool Open( Container c, Mobile m )
        {
            if ( m_Table.ContainsKey( c ) )
            {
                c.SendRemovePacket();
                Close( c );
                c.Delta( ItemDelta.Update );
                c.ProcessDelta();
                return false;
            }

            if ( c is Armoire || c is FancyArmoire )
            {
                Timer t = new FurnitureTimer( c, m );
                t.Start();
                m_Table[c] = t;

                switch ( c.ItemID )
                {
                    case 0xA4D: c.ItemID = 0xA4C; break;
                    case 0xA4F: c.ItemID = 0xA4E; break;
                    case 0xA51: c.ItemID = 0xA50; break;
                    case 0xA53: c.ItemID = 0xA52; break;
                }
            }

            return true;
        }

        public static void Close( Container c )
        {
            Timer t = null;

            m_Table.TryGetValue( c, out t );

            if ( t != null )
            {
                t.Stop();
                m_Table.Remove( c );
            }

            if ( c is Armoire || c is FancyArmoire )
            {
                switch ( c.ItemID )
                {
                    case 0xA4C: c.ItemID = 0xA4D; break;
                    case 0xA4E: c.ItemID = 0xA4F; break;
                    case 0xA50: c.ItemID = 0xA51; break;
                    case 0xA52: c.ItemID = 0xA53; break;
                }
            }
        }
    }
}