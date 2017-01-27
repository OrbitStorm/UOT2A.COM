using System;

namespace Server.Items
{
    [Flipable( 0xA97, 0xA99, 0xA98, 0xA9A, 0xA9B, 0xA9C )]
    public class LibraryBookcase : FillableContainer
    {
        public override bool IsLockable { get { return false; } }
        public override int SpawnThreshold { get { return 5; } }

        protected override int GetSpawnCount()
        {
            return ( 5 - GetItemsCount() );
        }

        public override void AcquireContent()
        {
            if( m_Content != null )
                return;

            m_Content = FillableContent.Library;

            if( m_Content != null )
                Respawn();
        }

        [Constructable]
        public LibraryBookcase()
            : base( 0xA97 )
        {
            Weight = 1.0;
        }

        public LibraryBookcase( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( (int)1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();

            if( version == 0 && m_Content == null )
                Timer.DelayCall( TimeSpan.Zero, new TimerCallback( AcquireContent ) );
        }
    }
}