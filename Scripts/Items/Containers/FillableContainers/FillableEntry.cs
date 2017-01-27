using System;

namespace Server.Items
{
    public class FillableEntry
    {
        protected Type[] m_Types;
        protected int m_Weight;
        protected int m_itemId;

        public Type[] Types { get { return m_Types; } }
        public int Weight { get { return m_Weight; } }
        public int ItemID { get { return m_itemId; } }

        public FillableEntry( Type type )
            : this( 1, new Type[] { type } )
        {
        }

        public FillableEntry( int weight, Type type ) : this( weight, new Type[] { type } )
        {
        }

        public FillableEntry( Type[] types ) : this( 1, types )
        {
        }

        public FillableEntry( int weight, Type[] types )
        {
            m_Weight = weight;
            m_Types = types;
        }

        public FillableEntry(int weight, Type type, int itemId)
        {
            m_Weight = weight;
            m_Types = new[]{ type };
            m_itemId = itemId;
        }

        public FillableEntry( int weight, Type[] types, int offset, int count )
        {
            m_Weight = weight;
            m_Types = new Type[ count ];

            for( int i = 0; i < m_Types.Length; ++i )
                m_Types[ i ] = types[ offset + i ];
        }

        public virtual Item Construct()
        {
            Item item = Loot.Construct( m_Types );

            if( item is Key )
                ( (Key)item ).ItemID = Utility.RandomList( (int)KeyType.Copper, (int)KeyType.Gold, (int)KeyType.Iron, (int)KeyType.Rusty );
            else if( item is Arrow || item is Bolt )
                item.Amount = Utility.RandomMinMax( 2, 6 );
            else if( item is Bandage || item is Lockpick )
                item.Amount = Utility.RandomMinMax( 1, 3 );
            else if (item is Static)
                item.ItemID = m_itemId;

            return item;
        }
    }
}