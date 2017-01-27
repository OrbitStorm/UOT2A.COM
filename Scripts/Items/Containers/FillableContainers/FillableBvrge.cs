using System;

namespace Server.Items
{
    public class FillableBvrge : FillableEntry
    {
        private BeverageType m_Content;

        public BeverageType Content { get { return m_Content; } }

        public FillableBvrge( Type type, BeverageType content ) : this( 1, type, content )
        {
        }

        public FillableBvrge( int weight, Type type, BeverageType content ) : base( weight, type )
        {
            m_Content = content;
        }

        public override Item Construct()
        {
            Item item;

            int index = Utility.Random( m_Types.Length );

            if( m_Types[ index ] == typeof( BeverageBottle ) )
            {
                item = new BeverageBottle( m_Content );
            }
            else if( m_Types[ index ] == typeof( Jug ) )
            {
                item = new Jug( m_Content );
            }
            else
            {
                item = base.Construct();

                if( item is BaseBeverage )
                {
                    BaseBeverage bev = (BaseBeverage)item;

                    bev.Content = m_Content;
                    bev.Quantity = bev.MaxQuantity;
                }
            }

            return item;
        }
    }
}