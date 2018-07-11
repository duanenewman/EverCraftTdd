using System;

namespace EverCraftTdd
{
	public class CharacterClass
	{
		public string Name { get; set; }
		public int BaseHitPoints { get; set; } = 5;
		public Func<int, int> GetLevelModifier = (lvl) => lvl / 2;
		public Func<Character, int> GetAttackAttribute = c => c.Strength;
		public Func<Character, int> GetCritMultiplier = o => 2;
		public bool IgnoresDexterityArmorClassModifier = false;
		public Func<CharacterAlignment, CharacterAlignment> ValidateAlignment = a => a;
		public int BaseAttackDamage = 1;
		public Func<Character, int> GetArmorClassBonusModifier = c => 0;
		public Func<Character, int> GetHitBonus = opponent => 0;
		public Func<Character, int> GetDamageBonus = opponent => 0;

		public static CharacterClass Default = new CharacterClass()
		{
			Name = "None",
		};

		public static CharacterClass Fighter = new CharacterClass()
		{
			Name = "Fighter",
			BaseHitPoints = 10,
			GetLevelModifier = (lvl) => lvl / 1,
		};

		public static CharacterClass Rogue = new CharacterClass()
		{
			Name = "Rogue",
			GetCritMultiplier = o => 3,
			IgnoresDexterityArmorClassModifier = true,
			GetAttackAttribute = c => c.Dexterity,
			ValidateAlignment = a => a != CharacterAlignment.Good ? a : CharacterAlignment.Neutral,
		};

		public static CharacterClass Monk = new CharacterClass()
		{
			Name = "Monk",
			BaseHitPoints = 6,
			BaseAttackDamage = 3,
			GetArmorClassBonusModifier = c => Math.Max(Character.GetModifier(c.Wisdom), 0),
			GetLevelModifier = (lvl) => lvl * 2 / 3,
		};

		public static CharacterClass Paladin = new CharacterClass()
		{
			Name = "Paladin",
			BaseHitPoints = 8,
			GetHitBonus = o => o.Alignment == CharacterAlignment.Evil ? 2 : 0,
			GetDamageBonus = o => o.Alignment == CharacterAlignment.Evil ? 2 : 0,
			GetCritMultiplier = o => o.Alignment == CharacterAlignment.Evil ? 3 : 2,
			GetLevelModifier = (lvl) => lvl / 1,
			ValidateAlignment = a => CharacterAlignment.Good,
		};
	}
}
