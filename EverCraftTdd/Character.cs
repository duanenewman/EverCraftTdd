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
		public int ArmorClass { get => BaseArmorClass + GetModifier(Dexterity) + Class.GetArmorClassBonusModifier(this); }
		public int MaxHitPoints { get => Level * Math.Max(Class.BaseHitPoints + GetModifier(Constitution), 1); }
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

		private int SetAttribute(int val)
		{
			if (val > 20) return 20;
			if (val < 1) return 1;
			return val;
		}

		public bool Attack(Character opponent, int attackRoll)
		{
			int attackModifier = GetModifier(Class.GetAttackAttribute(this));
			var levelModifier = Class.GetLevelModifier(Level);
			var attackBonus = Class.GetHitBonus(opponent);
			var toHit = attackRoll + levelModifier + attackModifier + attackBonus;
			var dexACMod = Class.IgnoresDexterityArmorClassModifier ? Math.Max(GetModifier(opponent.Dexterity), 0) : 0;
			var wasHit = toHit >= opponent.ArmorClass - dexACMod;
			if (wasHit)
			{
				var damageBonus = Class.GetDamageBonus(opponent);
				var baseDamage = Class.BaseAttackDamage + attackModifier + damageBonus;
				var wasCrit = attackRoll == 20;
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
	}
}
