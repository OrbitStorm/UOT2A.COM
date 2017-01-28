using System;
using System.Collections.Generic;

namespace Server.Items
{
	public abstract class FillableContainer : LockableContainer
	{
		public virtual int MinRespawnMinutes { get { return 60; } }
		public virtual int MaxRespawnMinutes { get { return 90; } }

		public virtual bool IsLockable { get { return true; } }
		public virtual bool IsTrapable { get { return IsLockable; } }

		public virtual int SpawnThreshold { get { return 2; } }

		protected FillableContent m_Content;

		protected DateTime m_NextRespawnTime;
		protected Timer m_RespawnTimer;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime NextRespawnTime { get { return m_NextRespawnTime; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public FillableContentType ContentType
		{
			get { return FillableContent.Lookup( m_Content ); }
			set { Content = FillableContent.Lookup( value ); }
		}

		public FillableContent Content
		{
			get { return m_Content; }
			set
			{
				if( m_Content == value )
					return;

				m_Content = value;

				for( int i = Items.Count - 1; i >= 0; --i )
				{
					if( i < Items.Count )
						Items[ i ].Delete();
				}

				Respawn();
			}
		}

		public FillableContainer( int itemID )
			: base( itemID )
		{
			Movable = false;
		}

		public override void OnMapChange()
		{
			base.OnMapChange();
			AcquireContent();
		}

		public override void OnLocationChange( Point3D oldLocation )
		{
			base.OnLocationChange( oldLocation );
			AcquireContent();
		}

		public virtual void AcquireContent()
		{
			if( m_Content != null )
				return;

			m_Content = FillableContent.Acquire( this.GetWorldLocation(), this.Map );

			if( m_Content != null )
				Respawn();
		}

		public override void OnItemRemoved( Item item )
		{
			CheckRespawn();
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if( m_RespawnTimer != null )
			{
				m_RespawnTimer.Stop();
				m_RespawnTimer = null;
			}
		}

		public int GetItemsCount()
		{
			int count = 0;

			foreach( Item item in this.Items )
			{
				count += item.Amount;
			}

			return count;
		}

		public void CheckRespawn()
		{
			bool canSpawn = ( m_Content != null && !Deleted && GetItemsCount() <= SpawnThreshold && !Movable && Parent == null && !IsLockedDown && !IsSecure );

			if( canSpawn )
			{
				if( m_RespawnTimer == null )
				{
					int mins = Utility.RandomMinMax( this.MinRespawnMinutes, this.MaxRespawnMinutes );
					TimeSpan delay = TimeSpan.FromMinutes( mins );

					m_NextRespawnTime = DateTime.UtcNow + delay;
					m_RespawnTimer = Timer.DelayCall( delay, new TimerCallback( Respawn ) );
				}
			}
			else if( m_RespawnTimer != null )
			{
				m_RespawnTimer.Stop();
				m_RespawnTimer = null;
			}
		}

		public void Respawn()
		{
			if( m_RespawnTimer != null )
			{
				m_RespawnTimer.Stop();
				m_RespawnTimer = null;
			}

			if( m_Content == null || Deleted )
				return;

			GenerateContent();

			if( IsLockable )
			{
				Locked = true;

				int difficulty = ( m_Content.Level - 1 ) * 30;

				LockLevel = difficulty - 10;
				MaxLockLevel = difficulty + 30;
				RequiredSkill = difficulty;
			}

			if( IsTrapable && ( m_Content.Level > 1 || 4 > Utility.Random( 5 ) ) )
			{
				if( m_Content.Level > Utility.Random( 5 ) )
					TrapType = TrapType.PoisonTrap;
				else
					TrapType = TrapType.ExplosionTrap;

				TrapPower = m_Content.Level * Utility.RandomMinMax( 10, 30 );
				TrapLevel = m_Content.Level;
			}
			else
			{
				TrapType = TrapType.None;
				TrapPower = 0;
				TrapLevel = 0;
			}

			CheckRespawn();
		}

		protected virtual int GetSpawnCount()
		{
			int itemsCount = GetItemsCount();

			if( itemsCount > SpawnThreshold )
				return 0;

			int maxSpawnCount = ( 1 + SpawnThreshold - itemsCount ) * 2;

			return Utility.RandomMinMax( 0, maxSpawnCount );
		}

		public virtual void GenerateContent()
		{
			if( m_Content == null || Deleted )
				return;

			int toSpawn = GetSpawnCount();

			for( int i = 0; i < toSpawn; ++i )
			{
				Item item = m_Content.Construct();

				if( item != null )
				{
					List<Item> list = this.Items;

					for( int j = 0; j < list.Count; ++j )
					{
						Item subItem = list[ j ];

						if( !( subItem is Container ) && subItem.StackWith( null, item, false ) )
							break;
					}

					if( item != null && !item.Deleted )
						DropItem( item );
				}
			}
		}

		public FillableContainer( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 1 ); // version

			writer.Write( (int)ContentType );

			if( m_RespawnTimer != null )
			{
				writer.Write( true );
				writer.WriteDeltaTime( (DateTime)m_NextRespawnTime );
			}
			else
			{
				writer.Write( false );
			}
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			switch( version )
			{
				case 1:
					{
						m_Content = FillableContent.Lookup( (FillableContentType)reader.ReadInt() );
						goto case 0;
					}
				case 0:
					{
						if( reader.ReadBool() )
						{
							m_NextRespawnTime = reader.ReadDeltaTime();

							TimeSpan delay = m_NextRespawnTime - DateTime.UtcNow;
							m_RespawnTimer = Timer.DelayCall( delay > TimeSpan.Zero ? delay : TimeSpan.Zero, new TimerCallback( Respawn ) );
						}
						else
						{
							CheckRespawn();
						}

						break;
					}
			}
		}
	}
}