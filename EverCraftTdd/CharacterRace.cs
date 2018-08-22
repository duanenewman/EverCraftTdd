using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraftTdd
{
	public class CharacterRace
	{
		public string Name { get; private set; }
		public int StrengthModifierBonus { get; private set; }
		public int IntelligenceModifierBonus { get; private set; }
		public int WisdomModifierBonus { get; private set; }
		public int CharismaModifierBonus { get; private set; }
		public int ConstitutionModifierBonus { get; private set; }
		public int DexterityModifierBonus { get; private set; }
		public int CritRollReduction { get; private set; }
		public Func<Character, int> GetArmorClassBonusModifier = c => 0;
		public Func<Character, int> GetBonusHitPoints = c => 0;
		public Func<Character, int> GetHitBonus = o => 0;
		public Func<Character, int> GetDamageBonus = o => 0;

		public static CharacterRace Human = new CharacterRace()
		{
			Name = "Human",
		};

		public static CharacterRace Orc = new CharacterRace()
		{
			Name = "Orc",
			StrengthModifierBonus = 2,
			IntelligenceModifierBonus = -1,
			WisdomModifierBonus = -1,
			CharismaModifierBonus = -1,
			GetArmorClassBonusModifier = c => 2,
		};

		public static CharacterRace Dwarf = new CharacterRace()
		{
			Name = "Dwarf",
			ConstitutionModifierBonus = 1,
			CharismaModifierBonus = -1,
			GetBonusHitPoints = c => Math.Max(c.Level * c.GetConstitutionModifier(), 0),
			GetHitBonus = o => o.Race.Name == Orc.Name ? 2 : 0,
			GetDamageBonus = o => o.Race.Name == Orc.Name ? 2 : 0,
		};

		public static CharacterRace Elf = new CharacterRace()
		{
			Name = "Elf",
			DexterityModifierBonus = 1,
			ConstitutionModifierBonus = -1,
			CritRollReduction = 1,
		};
	}
}
