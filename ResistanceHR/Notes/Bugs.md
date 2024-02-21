
#		Bugs
Except crickets. Crickets are fine.
##		C	Light Packer
Simply didn't trigger, enterign Industrial 1
##		C	Sergeant Contractor
BunnyLibs
Added E_upgradeTrait with E_upgradeTrait as description too
For all Social +, add a shop for Keyholder NPCs. Cops sell equipment, Cop Clerks sell contraband, etc. for other traits
##		C	Smoker Schmoozer
Hired cop
Tried to give, made noise but said needs a light. I have a light
They also need to consume the cigs, not keep in inventory
##		C	Subcontracting
Certain NPC types have an extra-limited follower menu:
	Slavemaster: Purchase slave, give item, dismiss, done
##		C	Custom agent matching
Since you're doing things like Physique which implicitly deprecate AgentRealName as a UID, and agentName is not useful for Custom Characters, you'll need a new way to verify that an agent is of the same class. Try accessing savecharacterdata's name instead.
##		C	Stove Grill
Exempt Anger for Friendly or better
##		C	Carnivorous Plant 
On bite player:
	[Debug  :BL_P_PlayfieldObject_DamageReceived] === GetDamageReceived: Miller - VANILLA: 10
	[Debug  :BL_P_PlayfieldObject_DamageReceived]   Caught isObjectReal
	[Debug  :BL_P_PlayfieldObject_DamageReceived]   NET DAMAGE: 10 / 1 = 10
	[Error  : Unity Log] NullReferenceException: Object reference not set to an instance of an object
	Stack trace:
	RHR.Combat_Ranged.P_PlayfieldObject_CombatRanged.CustomMethod (System.Single penetration, Agent shooter) (at <42b12b872af14bcf84205de65e0da326>:0)
	PlayfieldObject.FindDamage (PlayfieldObject damagerObject, System.Boolean generic, System.Boolean testOnly, System.Boolean fromClient) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	PlayfieldObject.FindDamage (PlayfieldObject damagerObject, System.Boolean generic, System.Boolean fromClient) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	Agent.Damage (PlayfieldObject damagerObject, System.Boolean fromClient) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	Agent.Damage (PlayfieldObject damagerObject) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	KillerPlant.MyCollision (PlayfieldObject collidingObject) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	KillerPlant.ObjectCollideStay (PlayfieldObject collidingObject, System.Boolean isTrigger) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ObjectReal.CollisionStay (UnityEngine.Collider2D collider2D, System.Boolean isTrigger) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ObjectColliderChild.OnTriggerStay2D (UnityEngine.Collider2D other) (at <c91d003c54a541caabaa8c305d5e31e5>:0)

##		C	Loadout Smuggler
Smuggles all items into crate, including Sunglasses.
##		C	FlamingBarrel Grill Fud
- Interrupted operation
- Made cop Hostile
- 
	[Debug  :CCU_P_PlayfieldObject_OperatingVolume] Operating Volume (Roy McRoy) : 0.5
	[Debug  :CCU_P_PlayfieldObject_OperatingVolume] RHR.Body.Tall_Physique effect: 0
	[Debug  :CCU_P_PlayfieldObject_OperatingVolume] --- Net Operating noise: 0
	[Debug  :CCU_P_PlayfieldObject_OperatingVolume] Operating Volume (Roy McRoy) : 0.5
	[Debug  :CCU_P_PlayfieldObject_OperatingVolume] RHR.Body.Tall_Physique effect: 0
	[Debug  :CCU_P_PlayfieldObject_OperatingVolume] --- Net Operating noise: 0
	[Error  : Unity Log] Operating Bar Error 2
##		C	Physique
###			C	Random add
Broken again
But that's a good thing.
###			C	Copied to Mech
Disable
###			C	Copy to Zombies?
New
###			T	Average-sized Shapeshifters
Added to Exclusion list
###			T	Test Mech Pilot
StatusEffects
	.MechTransform
	.MechTransformBack
###			T	Test Werewolf
StatusEffects
	.WerewolfTransform
	.WerewolfTransformBack
###			T	Test Shapeshifter
StatusEffects
	.Possess
	.Depossess
##		C	Spark of Insight
- OwnCheck on unowned items
- Can use on used furniture, check for sit/sleep
##		C	Followers rerolled physique on next level
Average Bouncer
Next level named Huge, but still has Average trait
##		C	Verify all special spawns apply to Physique
New
##		C	Supply Crates not owned
New
##		C	Excessive Crates (SORCE)
New
##		T	Zombie relationships
Zombies had Annoyed, Friendly, etc.
Had Polarizing
##		T	Zombies Reroll Physique
Might be kinda cool tho
##		C	Unknown
Threatened Bank Clerk for Key/Combo, went hostile without closing interaction menu

	[Info   : Unity Log] SETRELHATE: Clerk (1224) (Agent) - Playerr (Agent)A
	[Debug  :CCU_H_AgentCachedStats] Applying bonus (RHR.Body.Wide_Physique): 1
	[Error  : Unity Log] NotImplementedException: The method or operation is not implemented.
	Stack trace:
	RHR.Body.Wide_Physique.SetMobility () (at <5b0aadf611424da6b1a4da3b0f00e64e>:0)
	BunnyLibs.P_Melee_IModMeleeAttack+<>c.<ApplyMobility>b__3_0 (BunnyLibs.IModMeleeAttack t) (at C:/Users/Owner/source/repos/SOR/BunnyLibs/MyAwesomeMod/Interfaces/IModMeleeAttack.cs:107)
	System.Linq.Enumerable.Any[TSource] (System.Collections.Generic.IEnumerable`1[T] source, System.Func`2[T,TResult] predicate) (at <55b3683038794c198a24e8a1362bfc61>:0)
	BunnyLibs.P_Melee_IModMeleeAttack.ApplyMobility (Melee __instance) (at C:/Users/Owner/source/repos/SOR/BunnyLibs/MyAwesomeMod/Interfaces/IModMeleeAttack.cs:107)
	Melee.Attack (System.Boolean specialAbility) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	Melee.CheckAttack (System.Boolean specialAbility) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	Melee.Attack (PlayfieldObject myAttackObject) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	AgentInteractions.ThreatenKeyAndSafeCombination (Agent agent, Agent interactingAgent) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	AgentInteractions.PressedButton (Agent agent, Agent interactingAgent, System.String buttonText, System.Int32 buttonPrice) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	RogueLibsCore.VanillaInteractions+<>c__DisplayClass10_2.<Patch_Agent>b__3 (RogueLibsCore.InteractionModel`1[T] m) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.SimpleInteraction`1[T].OnPressed () (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.InteractionModel.OnPressedButton2 (System.String buttonName, System.Int32 buttonPrice) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.InteractionModel.OnPressedButton (System.String buttonName, System.Int32 buttonPrice) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.RogueLibsPlugin.PressedButtonHook2 (PlayfieldObject __instance, System.String buttonText, System.Int32 buttonPrice) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	Agent.PressedButton (System.String buttonText, System.Int32 buttonPrice) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	Agent.PressedButton (System.String buttonText) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	WorldSpaceGUI.PressedButton (System.Int32 buttonNum) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ButtonHelper.PushButton () (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ButtonHelper.DoUpdate (System.Boolean onlySetImages) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ButtonHelper.Update () (at <c91d003c54a541caabaa8c305d5e31e5>:0)
##		C	Annoyed Prisoners
Polarizing
Make them Neutral at least, or Friendly
##		C	Ignite in Hideout
Gave a goon cigs to make friendly. Snuck into back of hideout and pressed Ignite on Bookshelves:
	[Error  : Unity Log] NullReferenceException: Object reference not set to an instance of an object
	Stack trace:
	Relationships.OwnCheck (Agent otherAgent, UnityEngine.GameObject affectedGameObject, System.Int32 tagType, System.String ownCheckType, System.Boolean extraSprite, System.Int32 strikes, Fire fire) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	GameController.OwnCheck (Agent otherAgent, UnityEngine.GameObject affectedGameObject, System.String ownCheckType, System.Int32 strikes, Fire fire) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	GameController.OwnCheck (Agent otherAgent, UnityEngine.GameObject affectedGameObject, System.String ownCheckType, System.Int32 strikes) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ResistanceHR.Tampering.Spark_of_Insight+<>c__DisplayClass3_0.<Setup>b__1 (RogueLibsCore.InteractionModel m) (at <7a6205b4a6e943b1b9f402bae16898d7>:0)
	RogueLibsCore.SimpleInteraction.OnPressed () (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.InteractionModel.OnPressedButton2 (System.String buttonName, System.Int32 buttonPrice) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.InteractionModel.OnPressedButton (System.String buttonName, System.Int32 buttonPrice) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.RogueLibsPlugin.PressedButtonHook2 (PlayfieldObject __instance, System.String buttonText, System.Int32 buttonPrice) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	ObjectReal.PressedButton (System.String buttonText, System.Int32 buttonPrice) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ObjectReal.PressedButton (System.String buttonText) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	WorldSpaceGUI.PressedButton (System.Int32 buttonNum) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ButtonHelper.PushButton () (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ButtonHelper.DoUpdate (System.Boolean onlySetImages) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ButtonHelper.Update () (at <c91d003c54a541caabaa8c305d5e31e5>:0)
##		C	Weak Wrists can't use bulletproof vest

##		C	Weapon Scroll broken only for mousewheel down
When ammo is broken, plays "Ammo out" sound and doesn't switch
##		C	Give Item
Can't give melee weapons to followers when you have Sweaty Fingerss
##		C	Supply Dropper
Add one that's paid at ATM or Resistance Leader. Trait is just automatic.
Also drops watergun with E_HatRed
##		C	Smoker awards XP without lighter
Should be easy check
##		C	Light Packer
Left 4 items, lost my lighter :(
##		C	Burning Aspirations
Can't offer to cops on Industrial
##		C	Ignite with object in completed chunk
Chunk quest completed/chest robbed already, trying to ignite object. May be related to security on-sight check error under same chunk-completed circumstances.
	[Error  : Unity Log] NullReferenceException: Object reference not set to an instance of an object
	Stack trace:
	Relationships.OwnCheck (Agent otherAgent, UnityEngine.GameObject affectedGameObject, System.Int32 tagType, System.String ownCheckType, System.Boolean extraSprite, System.Int32 strikes, Fire fire) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	GameController.OwnCheck (Agent otherAgent, UnityEngine.GameObject affectedGameObject, System.String ownCheckType, System.Int32 strikes, Fire fire) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	GameController.OwnCheck (Agent otherAgent, UnityEngine.GameObject affectedGameObject, System.String ownCheckType, System.Int32 strikes) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ResistanceHR.Conduct.Pyrokinetic_Learning_Style+<>c.<Setup>b__10_1 (RogueLibsCore.InteractionModel m) (at <289ed0f988774ed6983a60fca755d15a>:0)
	RogueLibsCore.SimpleInteraction.OnPressed () (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.InteractionModel.OnPressedButton2 (System.String buttonName, System.Int32 buttonPrice) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.InteractionModel.OnPressedButton (System.String buttonName, System.Int32 buttonPrice) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	RogueLibsCore.RogueLibsPlugin.PressedButtonHook1 (PlayfieldObject __instance, System.String buttonText) (at <a3d3f875b99344cba12c5f8ead40c647>:0)
	Bed.PressedButton (System.String buttonText) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	WorldSpaceGUI.PressedButton (System.Int32 buttonNum) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ButtonHelper.PushButton () (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ButtonHelper.DoUpdate (System.Boolean onlySetImages) (at <c91d003c54a541caabaa8c305d5e31e5>:0)
	ButtonHelper.Update () (at <c91d003c54a541caabaa8c305d5e31e5>:0)
##		C	Hidden Bombs not on map
Explored all chunks too. I THINK it's Loadout Smuggler.
##		C	Sweaty Palms
Causes issues when there are no ranged weapons to switch to. Still shows a fist but malfunctions. Make sure that one's allowed in all trait configs.
##		C	Dum Dum Bum +
Makes bullets almost zero-slow. Might be applied multiple times, which I assume is squaring some ratio in an interface property by patching bullet update rather than bullet start