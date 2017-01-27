using System;

namespace Server.Items
{
    public class FurnitureTimer : Timer
    {
        private Container m_Container;
        private Mobile m_Mobile;

        public FurnitureTimer( Container c, Mobile m ) : base( TimeSpan.FromSeconds( 0.5 ), TimeSpan.FromSeconds( 0.5 ) )
        {
            Priority = TimerPriority.TwoFiftyMS;

            m_Container = c;
            m_Mobile = m;
        }

        protected override void OnTick()
        {
            if ( m_Mobile.Map != m_Container.Map || !m_Mobile.InRange( m_Container.GetWorldLocation(), 3 ) )
                DynamicFurniture.Close( m_Container );
        }
    }
}