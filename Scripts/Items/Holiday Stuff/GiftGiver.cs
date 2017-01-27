using System;

namespace Server.Misc
{
    public abstract class GiftGiver
    {
        public virtual TimeSpan MinimumAge{ get{ return TimeSpan.FromDays( 30.0 ); } }

        public abstract DateTime Start{ get; }
        public abstract DateTime Finish{ get; }
        public abstract void GiveGift( Mobile mob );

        public virtual void DelayGiveGift( TimeSpan delay, Mobile mob )
        {
            Timer.DelayCall( delay, new TimerStateCallback( DelayGiveGift_Callback ), mob );
        }

        protected virtual void DelayGiveGift_Callback( object state )
        {
            GiveGift( (Mobile) state );
        }

        public virtual GiftResult GiveGift( Mobile mob, Item item )
        {
            if ( mob.PlaceInBackpack( item ) )
            {
                if ( !WeightOverloading.IsOverloaded( mob ) )
                    return GiftResult.Backpack;
            }

            mob.BankBox.DropItem( item );
            return GiftResult.BankBox;
        }
    }
}