using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraftTdd.Tests
{
	[TestFixture]
	public class CharacterTests
	{
		[Test]
		public void CanGetNameOfCharacter()
		{
			var character = new Character();
			var name = character.Name;
			Assert.AreEqual("Player 1", name);
		}

		[Test]
		public void CanSetNameOfCharacter()
		{
			var character = new Character
			{
				Name = "Bob"
			};
			Assert.AreEqual("Bob", character.Name);
		}

		[Test]
		public void CanGetAlignment()
		{
			var character = new Character();
			Assert.AreEqual(CharacterAlignment.Good, character.Alignment);
		}

		[Test]
		public void CanSetAlignmentToGood()
		{
			var character = new Character
			{
				Alignment = CharacterAlignment.Good
			};
			Assert.AreEqual(CharacterAlignment.Good, character.Alignment);
		}

		[Test]
		public void CanSetAlignmentToEvil()
		{
			var character = new Character
			{
				Alignment = CharacterAlignment.Evil
			};
			Assert.AreEqual(CharacterAlignment.Evil, character.Alignment);
		}

		[Test]
		public void CanSetAlignmentToNeutral()
		{
			var character = new Character
			{
				Alignment = CharacterAlignment.Neutral
			};
			Assert.AreEqual(CharacterAlignment.Neutral, character.Alignment);
		}

		[Test]
		public void ArmorClassDefaultsTo10()
		{
			var character = new Character();
			Assert.AreEqual(10, character.ArmorClass);
		}

		[Test]
		public void HitPointsDefaultsTo5()
		{
			var character = new Character();
			Assert.AreEqual(5, character.HitPoints);
		}

		[Test]
		public void CharacterAttackHitsOpponent()
		{
			var character = new Character();
			var opponent = new Character();
			var wasHit = character.Attack(opponent, 20);
			Assert.IsTrue(wasHit);
		}

		[Test]
		public void CharacterAttackMissesOpponent()
		{
			var character = new Character();
			var opponent = new Character();
			var wasHit = character.Attack(opponent, 6);
			Assert.IsFalse(wasHit);
		}

		[Test]
		public void OpponentTakesDamageWhenHit()
		{
			var character = new Character();
			var opponent = new Character();
			var wasHit = character.Attack(opponent, 10);
			Assert.AreEqual(4, opponent.HitPoints);
		}

		[Test]
		public void OpponentTakesDoubleDamageOnCrit()
		{
			var character = new Character();
			var opponent = new Character();
			var wasHit = character.Attack(opponent, 20);
			Assert.AreEqual(3, opponent.HitPoints);
		}

		[Test]
		public void CharacterIsDeadWhenHealthReaches0()
		{
			var character = new Character
			{
				HitPoints = 0
			};
			Assert.AreEqual(false, character.IsAlive);
		}

		[Test]
		public void OpponentIsDeadWhenHealthReaches0()
		{
			var character = new Character();
			var opponent = new Character
			{
				HitPoints = 2
			};
			character.Attack(opponent, 20);
			Assert.AreEqual(false, opponent.IsAlive);
		}

		[Test]
		public void CharacterStrengthDefaultsTo10()
		{
			var character = new Character();
			Assert.AreEqual(10, character.Strength);
		}

		[Test]
		public void CharacterDexterityDefaultsTo10()
		{
			var character = new Character();
			Assert.AreEqual(10, character.Dexterity);
		}

		[Test]
		public void CharacterConstitutionDefaultsTo10()
		{
			var character = new Character();
			Assert.AreEqual(10, character.Constitution);
		}

		[Test]
		public void CharacterWisdomDefaultsTo10()
		{
			var character = new Character();
			Assert.AreEqual(10, character.Wisdom);
		}

		[Test]
		public void CharacterIntelligenceDefaultsTo10()
		{
			var character = new Character();
			Assert.AreEqual(10, character.Intelligence);
		}

		[Test]
		public void CharacterCharismaDefaultsTo10()
		{
			var character = new Character();
			Assert.AreEqual(10, character.Charisma);
		}






		[Test]
		public void CharacterStrengthCeilingIs20()
		{
			var character = new Character
			{
				Strength = 21
			};
			Assert.AreEqual(20, character.Strength);
		}

		[Test]
		public void CharacterDexterityCeilingIs20()
		{
			var character = new Character()
			{
				Dexterity = 21
			};
			Assert.AreEqual(20, character.Dexterity);
		}

		[Test]
		public void CharacterConstitutionCeilingIs20()
		{
			var character = new Character()
			{
				Constitution = 21
			};
			Assert.AreEqual(20, character.Constitution);
		}

		[Test]
		public void CharacterWisdomCeilingIs20()
		{
			var character = new Character()
			{
				Wisdom = 21
			};
			Assert.AreEqual(20, character.Wisdom);
		}

		[Test]
		public void CharacterIntelligenceCeilingIs20()
		{
			var character = new Character()
			{
				Intelligence = 21
			};
			Assert.AreEqual(20, character.Intelligence);
		}

		[Test]
		public void CharacterCharismaCeilingIs20()
		{
			var character = new Character()
			{
				Charisma = 21
			};
			Assert.AreEqual(20, character.Charisma);
		}

		[Test]
		public void CharacterStrengthFloorIs1()
		{
			var character = new Character
			{
				Strength = 0
			};
			Assert.AreEqual(1, character.Strength);
		}

		[Test]
		public void CharacterDexterityFloorIs1()
		{
			var character = new Character()
			{
				Dexterity = 0
			};
			Assert.AreEqual(1, character.Dexterity);
		}

		[Test]
		public void CharacterConstitutionFloorIs1()
		{
			var character = new Character()
			{
				Constitution = 0
			};
			Assert.AreEqual(1, character.Constitution);
		}

		[Test]
		public void CharacterWisdomFloorIs1()
		{
			var character = new Character()
			{
				Wisdom = 0
			};
			Assert.AreEqual(1, character.Wisdom);
		}

		[Test]
		public void CharacterIntelligenceFloorIs1()
		{
			var character = new Character()
			{
				Intelligence = 0
			};
			Assert.AreEqual(1, character.Intelligence);
		}

		[Test]
		public void CharacterCharismaFloorIs1()
		{
			var character = new Character()
			{
				Charisma = 0
			};
			Assert.AreEqual(1, character.Charisma);
		}

		[TestCase(1, ExpectedResult = -5)]
		[TestCase(2, ExpectedResult = -4)]
		[TestCase(3, ExpectedResult = -4)]
		[TestCase(4, ExpectedResult = -3)]
		[TestCase(5, ExpectedResult = -3)]
		[TestCase(6, ExpectedResult = -2)]
		[TestCase(7, ExpectedResult = -2)]
		[TestCase(8, ExpectedResult = -1)]
		[TestCase(9, ExpectedResult = -1)]
		[TestCase(10, ExpectedResult = 0)]
		[TestCase(11, ExpectedResult = 0)]
		[TestCase(12, ExpectedResult = 1)]
		[TestCase(13, ExpectedResult = 1)]
		[TestCase(14, ExpectedResult = 2)]
		[TestCase(15, ExpectedResult = 2)]
		[TestCase(16, ExpectedResult = 3)]
		[TestCase(17, ExpectedResult = 3)]
		[TestCase(18, ExpectedResult = 4)]
		[TestCase(19, ExpectedResult = 4)]
		[TestCase(20, ExpectedResult = 5)]
		public int CharacterAttributesAffectModifier(int value)
		{
			var character = new Character();
			return Character.GetModifier(value);
		}

		[TestCase(10, 1, ExpectedResult = false)]
		[TestCase(10, 3, ExpectedResult = false)]
		[TestCase(10, 5, ExpectedResult = false)]
		[TestCase(10, 7, ExpectedResult = false)]
		[TestCase(10, 9, ExpectedResult = false)]
		[TestCase(10, 10, ExpectedResult = true)]
		[TestCase(10, 11, ExpectedResult = true)]
		[TestCase(9, 12, ExpectedResult = true)]
		[TestCase(9, 14, ExpectedResult = true)]
		[TestCase(9, 16, ExpectedResult = true)]
		[TestCase(9, 18, ExpectedResult = true)]
		[TestCase(9, 20, ExpectedResult = true)]
		public bool StrengthModifiesAttackRoll(int roll, int strength)
		{
			var character = new Character()
			{
				Strength = strength
			};
			var opponent = new Character();
			return character.Attack(opponent, roll);
		}

		[TestCase(1, ExpectedResult = 10)]
		[TestCase(5, ExpectedResult = 10)]
		[TestCase(10, ExpectedResult = 9)]
		[TestCase(15, ExpectedResult = 7)]
		public int StrengthModifiesDamage(int strength)
		{
			var character = new Character
			{
				Strength = strength
			};
			var opponent = new Character
			{
				HitPoints = 10
			};
			character.Attack(opponent, 10);
			return opponent.HitPoints;
		}

		[Test]
		public void CriticalHitDoubleStrengthModifierForDamage()
		{
			var character = new Character
			{
				Strength = 15
			};
			var opponent = new Character
			{
				HitPoints = 10
			};
			character.Attack(opponent, 20);
			Assert.AreEqual(4, opponent.HitPoints);
		}

		[Test]
		public void MinimumDamageOnHitIs1()
		{
			var character = new Character
			{
				Strength = 5
			};
			var opponent = new Character
			{
				HitPoints = 10,
				BaseArmorClass = 5
			};
			character.Attack(opponent, 8);
			Assert.AreEqual(9, opponent.HitPoints);
		}

		[TestCase(1, ExpectedResult = 5)]
		[TestCase(5, ExpectedResult = 7)]
		[TestCase(10, ExpectedResult = 10)]
		[TestCase(16, ExpectedResult = 13)]
		[TestCase(20, ExpectedResult = 15)]
		public int DexterityModifiesArmorClass(int dexterity)
		{
			var character = new Character
			{
				Dexterity = dexterity
			};

			return character.ArmorClass;
		}

		[TestCase(1, ExpectedResult = 1)]
		[TestCase(5, ExpectedResult = 2)]
		[TestCase(10, ExpectedResult = 5)]
		[TestCase(16, ExpectedResult = 8)]
		[TestCase(20, ExpectedResult = 10)]
		public int ConstitutionModifiesHitPoints(int constitution)
		{
			var character = new Character
			{
				//HitPoints = 10,
				Constitution = constitution
			};

			return character.HitPoints;
		}

		[Test]
		public void CharacterGainExperienceOnSuccessfulAttack()
		{
			var character = new Character();
			var opponent = new Character();

			character.Attack(opponent, 20);

			Assert.AreEqual(10, character.Experience);
		}

		[Test]
		public void CharacterHasDefaultLevelOf1()
		{
			var character = new Character();
			Assert.AreEqual(1, character.Level);
		}

		[TestCase(0, ExpectedResult = 1)]
		[TestCase(900, ExpectedResult = 1)]
		[TestCase(1000, ExpectedResult = 2)]
		[TestCase(2000, ExpectedResult = 3)]
		[TestCase(3000, ExpectedResult = 4)]
		[TestCase(4000, ExpectedResult = 5)]
		public int CharacterLevelsUpEvery1000Experience(int experience)
		{
			var character = new Character();
			character.Experience = experience;
			return character.Level;
		}

		[TestCase(0, 10, ExpectedResult = 5)]
		[TestCase(1000, 10, ExpectedResult = 10)]
		[TestCase(1000, 14, ExpectedResult = 14)]
		[TestCase(4000, 10, ExpectedResult = 25)]
		[TestCase(4000, 8, ExpectedResult = 20)]
		public int CharacterHealthIncreasesWithLevel(int experience, int constitution)
		{
			var character = new Character
			{
				Experience = experience,
				Constitution = constitution
			};
			return character.HitPoints;
		}


		[TestCase(0, 9, ExpectedResult = false)]
		[TestCase(1000, 9, ExpectedResult = true)]
		[TestCase(2000, 9, ExpectedResult = true)]
		[TestCase(2000, 8, ExpectedResult = false)]
		[TestCase(3000, 8, ExpectedResult = true)]
		[TestCase(4000, 8, ExpectedResult = true)]
		[TestCase(5000, 7, ExpectedResult = true)]
		[TestCase(6000, 7, ExpectedResult = true)]
		[TestCase(6000, 6, ExpectedResult = false)]
		[TestCase(7000, 6, ExpectedResult = true)]
		public bool CharacterDamageIncreasesBy1PerEvenLevel(int experience, int roll)
		{
			var character = new Character
			{
				Experience = experience
			};
			var opponent = new Character();
			return character.Attack(opponent, roll);
		}

		[TestCase(0, 9, ExpectedResult = true)]
		[TestCase(1000, 8, ExpectedResult = true)]
		[TestCase(2000, 7, ExpectedResult = true)]
		[TestCase(3000, 6, ExpectedResult = true)]
		[TestCase(4000, 5, ExpectedResult = true)]
		[TestCase(5000, 4, ExpectedResult = true)]
		[TestCase(6000, 3, ExpectedResult = true)]
		[TestCase(7000, 2, ExpectedResult = true)]
		public bool FighterClassHasIncreasedAttackEveryLevel(int experience, int roll)
		{
			var character = new Character
			{
				Experience = experience,
				Class = CharacterClass.Fighter
			};
			var opponent = new Character();
			return character.Attack(opponent, roll);
		}

		[TestCase(0, 10, ExpectedResult = 10)]
		[TestCase(1000, 10, ExpectedResult = 20)]
		[TestCase(1000, 14, ExpectedResult = 24)]
		[TestCase(4000, 10, ExpectedResult = 50)]
		[TestCase(4000, 8, ExpectedResult = 45)]
		public int FighterClassHealthIncreasesBy10PerLevel(int experience, int constitution)
		{
			var character = new Character
			{
				Class = CharacterClass.Fighter,
				Experience = experience,
				Constitution = constitution
			};
			return character.HitPoints;
		}

		[Test]
		public void RogueClassDoesTripleDamageOnCrit()
		{

			var character = new Character
			{
				Class = CharacterClass.Rogue
			};
			var opponent = new Character();
			character.Attack(opponent, 20);
			Assert.AreEqual(2, opponent.HitPoints);
		}

		[TestCase(4, 7, ExpectedResult = true)]
		[TestCase(10, 10, ExpectedResult = true)]
		[TestCase(18, 10, ExpectedResult = true)]
		public bool RogueClassIgnoresPositiveDexterityModifierOnAttack(int dexterity, int attack)
		{
			var character = new Character
			{
				Class = CharacterClass.Rogue,
			};
			var opponent = new Character
			{
				Dexterity = dexterity,
			};
			return character.Attack(opponent, attack);
		}


		[TestCase(8, 10, ExpectedResult = false)]
		[TestCase(10, 10, ExpectedResult = true)]
		[TestCase(18, 6, ExpectedResult = true)]
		public bool RogueClassAddsDexterityModifierToAttacksInsteadOfStrength(int dexterity, int attack)
		{
			var character = new Character
			{
				Class = CharacterClass.Rogue,
				Dexterity = dexterity,
			};
			var opponent = new Character
			{
			};
			return character.Attack(opponent, attack);
		}

		[Test]
		public void RogueClassCannotHaveGoodAlignment()
		{
			var character = new Character
			{
				Class = CharacterClass.Rogue,
				Alignment = CharacterAlignment.Good,
			};

			Assert.AreNotEqual(CharacterAlignment.Good, character.Alignment);
		}


		[TestCase(0, 10, ExpectedResult = 6)]
		[TestCase(1000, 10, ExpectedResult = 12)]
		[TestCase(1000, 14, ExpectedResult = 16)]
		[TestCase(4000, 10, ExpectedResult = 30)]
		[TestCase(4000, 8, ExpectedResult = 25)]
		public int MonkClassHealthIncreasesBy6PerLevel(int experience, int constitution)
		{
			var character = new Character
			{
				Class = CharacterClass.Monk,
				Experience = experience,
				Constitution = constitution
			};
			return character.HitPoints;
		}

		[TestCase(10, ExpectedResult = 7)]
		[TestCase(20, ExpectedResult = 4)]
		public int MonkClassDeals3DamagePerLevelInsteadOf1(int attackRoll)
		{
			var character = new Character
			{
				Class = CharacterClass.Monk,
			};
			var opponent = new Character
			{
				HitPoints = 10,
			};
			character.Attack(opponent, attackRoll);
			return opponent.HitPoints;
		}


		[TestCase(8, ExpectedResult = 10)]
		[TestCase(10, ExpectedResult = 10)]
		[TestCase(12, ExpectedResult = 11)]
		public int MonkClassAddsPositiveWisdomToArmorClass(int wisdom)
		{
			var character = new Character
			{
				Class = CharacterClass.Monk,
				Wisdom = wisdom,
			};
			return character.ArmorClass;
		}

		[TestCase(0, 10, ExpectedResult = true)]
		[TestCase(1000, 9, ExpectedResult = true)]
		[TestCase(2000, 8, ExpectedResult = true)]
		[TestCase(3000, 8, ExpectedResult = true)]
		[TestCase(3000, 7, ExpectedResult = false)]
		[TestCase(4000, 7, ExpectedResult = true)]
		[TestCase(5000, 6, ExpectedResult = true)]
		[TestCase(6000, 6, ExpectedResult = true)]
		[TestCase(6000, 5, ExpectedResult = false)]
		[TestCase(7000, 5, ExpectedResult = true)]
		[TestCase(8000, 4, ExpectedResult = true)]
		[TestCase(9000, 4, ExpectedResult = true)]
		[TestCase(9000, 3, ExpectedResult = false)]
		public bool MonkClassAdds1ToAttackRollEvery2ndAnd3rdLevel(int experience, int attackRoll)
		{
			var character = new Character
			{
				Class = CharacterClass.Monk,
				Experience = experience,
			};
			var opponent = new Character
			{
				HitPoints = 10,
			};
			return character.Attack(opponent, attackRoll);
		}

		[TestCase(0, 10, ExpectedResult = 8)]
		[TestCase(1000, 10, ExpectedResult = 16)]
		[TestCase(1000, 14, ExpectedResult = 20)]
		[TestCase(4000, 10, ExpectedResult = 40)]
		[TestCase(4000, 8, ExpectedResult = 35)]
		public int PaladinClassHealthIncreasesBy8PerLevel(int experience, int constitution)
		{
			var character = new Character
			{
				Class = CharacterClass.Paladin,
				Experience = experience,
				Constitution = constitution
			};
			return character.HitPoints;
		}

		[TestCase(CharacterAlignment.Neutral, 7, ExpectedResult = false)]
		[TestCase(CharacterAlignment.Neutral, 9, ExpectedResult = true)]
		[TestCase(CharacterAlignment.Good, 7, ExpectedResult = false)]
		[TestCase(CharacterAlignment.Good, 9, ExpectedResult = true)]
		[TestCase(CharacterAlignment.Evil, 7, ExpectedResult = true)]
		[TestCase(CharacterAlignment.Evil, 6, ExpectedResult = false)]
		public bool PaladinClassHasPlus2AttackWhenAttackingEvilCreatures(CharacterAlignment alignemnt, int roll)
		{
			var character = new Character
			{
				Class = CharacterClass.Paladin
			};
			var opponent = new Character
			{
				Alignment = alignemnt
			};
			return character.Attack(opponent, roll);
		}

		[TestCase(CharacterAlignment.Neutral, 10, ExpectedResult = 9)]
		[TestCase(CharacterAlignment.Good, 10, ExpectedResult = 9)]
		[TestCase(CharacterAlignment.Evil, 10, ExpectedResult = 7)]
		public int PaladinClassHasPlus2DamageWhenAttackingEvilCreatures(CharacterAlignment alignemnt, int roll)
		{
			var character = new Character
			{
				Class = CharacterClass.Paladin
			};
			var opponent = new Character
			{
				Alignment = alignemnt,
				HitPoints = 10
			};
			character.Attack(opponent, roll);
			return opponent.HitPoints;
		}

		[TestCase(CharacterAlignment.Neutral, ExpectedResult = 8)]
		[TestCase(CharacterAlignment.Good, ExpectedResult = 8)]
		[TestCase(CharacterAlignment.Evil, ExpectedResult = 1)]
		public int PaladinClassDealsTripleCritDamageToEvilCreatures(CharacterAlignment alignemnt)
		{
			var character = new Character
			{
				Class = CharacterClass.Paladin
			};
			var opponent = new Character
			{
				Alignment = alignemnt,
				HitPoints = 10
			};
			character.Attack(opponent, 20);
			return opponent.HitPoints;
		}


		[TestCase(0, 9, ExpectedResult = true)]
		[TestCase(1000, 8, ExpectedResult = true)]
		[TestCase(2000, 7, ExpectedResult = true)]
		[TestCase(3000, 6, ExpectedResult = true)]
		[TestCase(4000, 5, ExpectedResult = true)]
		[TestCase(5000, 4, ExpectedResult = true)]
		[TestCase(6000, 3, ExpectedResult = true)]
		[TestCase(7000, 2, ExpectedResult = true)]
		public bool PaladinClassHasIncreasedAttackEveryLevel(int experience, int roll)
		{
			var character = new Character
			{
				Experience = experience,
				Class = CharacterClass.Paladin
			};
			var opponent = new Character();
			return character.Attack(opponent, roll);
		}

		[TestCase(CharacterAlignment.Neutral, ExpectedResult = CharacterAlignment.Good)]
		[TestCase(CharacterAlignment.Good, ExpectedResult = CharacterAlignment.Good)]
		[TestCase(CharacterAlignment.Evil, ExpectedResult = CharacterAlignment.Good)]
		public CharacterAlignment PaladinClassCanOnlyHaveGoodAlignment(CharacterAlignment alignment)
		{
			var character = new Character
			{
				Class = CharacterClass.Paladin,
				Alignment = alignment,
			};

			return character.Alignment;
		}
	}
}
