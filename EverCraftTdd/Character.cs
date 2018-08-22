using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraftTdd
{
	public class Character
	{
		private int _strength = 10;
		private int _dexterity = 10;
		private int _constitution = 10;
		private int _wisdom = 10;
		private int _intelligence = 10;
		private int _charisma = 10;
		private int _hitPoints = 0;
		private CharacterAlignment _alignment;

		public string Name { get; set; } = "Player 1";
		public CharacterAlignment Alignment
		{
			get => _alignment;
			set => _alignment = Class.ValidateAlignment(value);
		}
		public int BaseArmorClass { get; set; } = 10;
		public int ArmorClass { get => BaseArmorClass + GetDexterityModifier() + Class.GetArmorClassBonusModifier(this) + Race.GetArmorClassBonusModifier(this);  }
		public int MaxHitPoints { get => Level * Math.Max(Class.BaseHitPoints + GetConstitutionModifier(), 1) + Race.GetBonusHitPoints(this); }
		public int HitPoints
		{
			get => _hitPoints + MaxHitPoints;
			set => _hitPoints = value - MaxHitPoints;
		}
		public bool IsAlive => HitPoints > 0;
		public int Experience { get; set; }

		public int Strength { get => _strength; set => _strength = SetAttribute(value); }
		public int Dexterity { get => _dexterity; set => _dexterity = SetAttribute(value); }

		public int Constitution { get => _constitution; set => _constitution = SetAttribute(value); }
		public int Wisdom { get => _wisdom; set => _wisdom = SetAttribute(value); }
		public int Intelligence { get => _intelligence; set => _intelligence = SetAttribute(value); }
		public int Charisma { get => _charisma; set => _charisma = SetAttribute(value); }
		public int Level { get => 1 + Experience / 1000; }
		public CharacterClass Class { get; set; } = CharacterClass.Default;
		public CharacterRace Race { get; set; } = CharacterRace.Human;

		private int SetAttribute(int val)
		{
			if (val > 20) return 20;
			if (val < 1) return 1;
			return val;
		}

		public bool Attack(Character opponent, int attackRoll)
		{
			int attackModifier = Class.GetAttackModifier(this);
			var levelModifier = Class.GetLevelModifier(Level);
			var attackBonus = Class.GetHitBonus(opponent) + Race.GetHitBonus(opponent);
			var toHit = attackRoll + levelModifier + attackModifier + attackBonus;
			var dexACMod = Class.IgnoresDexterityArmorClassModifier ? Math.Max(opponent.GetDexterityModifier(), 0) : 0;
			var wasHit = toHit >= opponent.ArmorClass - dexACMod;
			if (wasHit)
			{
				var damageBonus = Class.GetDamageBonus(opponent) + Race.GetDamageBonus(opponent);
				var baseDamage = Class.BaseAttackDamage + attackModifier + damageBonus;
				var wasCrit = attackRoll == 20 - Race.CritRollReduction;
				var damage = wasCrit ? baseDamage * Class.GetCritMultiplier(opponent) : baseDamage;
				opponent.HitPoints -= Math.Max(damage, 1);
				Experience += 10;
			}

			return wasHit;
		}

		public static int GetModifier(int value)
		{
			if (value < 10)
			{
				return (value - 11) / 2;
			}
			return (value - 10) / 2;
		}

		public int GetIntelligenceModifier()
		{
			var baseMod = GetModifier(Intelligence);

			return baseMod + Race.IntelligenceModifierBonus;
		}

		public int GetStrengthModifier()
		{
			var baseMod = GetModifier(Strength);
			return baseMod + Race.StrengthModifierBonus;
		}

		public int GetDexterityModifier()
		{
			var baseMod = GetModifier(Dexterity);
			return baseMod + Race.DexterityModifierBonus;
		}

		public int GetWisdomModifier()
		{
			var baseMod = GetModifier(Wisdom);
			return baseMod + Race.WisdomModifierBonus;
		}

		public int GetCharismaModifier()
		{
			var baseMod = GetModifier(Charisma);
			return baseMod + Race.CharismaModifierBonus;
		}

		public int GetConstitutionModifier()
		{
			var baseMod = GetModifier(Constitution);
			return baseMod + Race.ConstitutionModifierBonus;
		}
	}
}
