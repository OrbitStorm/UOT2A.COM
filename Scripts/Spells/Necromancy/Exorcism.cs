using System;

namespace Server.Spells.Necromancy
{
    public class ExorcismSpell : NecromancerSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Exorcism", "Ort Corp Grav",
				203,
				9031,
				Reagent.NoxCrystal,
				Reagent.GraveDust
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.0 ); } }

		public override double RequiredSkill { get { return 80.0; } }
		public override int RequiredMana { get { return 40; } }

		public ExorcismSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if( Caster.Skills.SpiritSpeak.Value < 100.0 )
			{
				Caster.SendLocalizedMessage( 1072112 ); // You must have GM Spirit Speak to use this spell
				return false;
			}

			return base.CheckCast();
		}


		public override bool DelayedDamage { get { return false; } }

		private static readonly int Range = (Core.ML ? 48 : 18);

		public override int ComputeKarmaAward()
		{
			return 0;	//no karma lost from this spell!
		}

		public override void OnCast()
		{
			Caster.SendLocalizedMessage( 1072111 ); // You are not in a valid exorcism region.
			FinishSequence();
		}
	}
}