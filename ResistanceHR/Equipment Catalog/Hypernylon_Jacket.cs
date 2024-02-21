using RogueLibsCore;
using BunnyLibs;
using System.Collections.Generic;

namespace ResistanceHR.EquipmentCatalog
{
	[ItemCategories(RogueCategories.Defense, RogueCategories.Stealth)]
	internal class Hypernylon_Jacket : I_RHR
	{
		// Reduces view distance like Blends In Nicely
		// Small Bullet Resistance
		public override void SetupDetails()
		{
			Item.itemType = VItemType.Wearable;
			Item.isArmor = true;
			Item.hierarchy = 16f; // Bulletproof Vest's value + 1. Treat it as an outer coat, not meant to take a beating.
			Item.itemValue = 140;
			Item.initCount = 100;
			Item.rewardCount = 200;
			Item.stackable = false;
			Item.throwDamage = 0;
			Item.armorDepletionType = "Bullet";
			Item.shadowOffset = 20; // Insane value, just to see where it shows up. Might be a way to set it at an interesting height.
			
			if (!Item.contents.Contains(VStatusEffect.ResistBulletsSmall))
				Item.contents.Add(VStatusEffect.ResistBulletsSmall);

			
		}
		
	}

	// BulletproofVest si 

	//	playfieldObject.hardToSeeFromDistance
	//	ctor		1.0f
	//	BIN			1.7f
	//	BIN +		2.5f
	//	postfix StatusEffects.AddTrait & .RemoveTrait
	//	postfix Agent.SetupAgentStats
	//	OnAdded hopefully
}