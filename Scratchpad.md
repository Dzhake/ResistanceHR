#		How to read this
If you wandered in here out of curiosity, this is my working notes file, and completed/planned feature list. It's in Markdown, but best viewed in raw form since a lot of its organization has to do with text characters' alignment.

Listed in order of Parent tier summary symbol priority:
	C, T = Code this, Test this
	H = Hold, usually pending resolution of a separate or grouped issue
	√ = Fully implemented feature or group of features
#		General
Fatass has a few new features listed in description
##		C	Manual Loader
16 PIV
All wasted ammo (from pickups or Ammunizer) is converted into XP at the rate of 1 per bullet
#		Traits
##		C	Combat Melee
###			C	Blessed Strikes / +
Import
###			C	Cursed Strikes / +
Import
###			C	Infernal Strikes / +
New
###			C	Venomous Strikes / +
New
##		C	Combat Ranged
###			C	Sniper / +
Import
###			C	Wetworker
Import
##		C	Item Restrictions
###			C!	00 CC Items not spawning in inventory
Banana didn't appear in inv with Carnivore, loud stuff with Afraid.
###			T	Test with NPCs
P_InvDatabase.ChooseWeapon_FilterItemList
Didn't seem to work on player character. Might be for NPCs only.
InvDatabase.UpdateWeaponList2 seems to be the NPC version of InvDatabase.ChooseWeapon()
###			C	Restrict Usables
Time Bomb, etc.
###			T	Afraid of Loud Noises
###			T	Carnivore
###			T	DAREdevil
###			T	Draw No Blood
###			T	Fat Head
###			T	Fatass
New features, add here
###			T	Friend of Bill
###			T	Teetotaller
###			T	Vegetarian
##		C	Vision Range
WorldToViewPointPort does have *some* effect.
PlayerControl.Update works fine
###			√	Eagle Eyes / +
###			√	Myopic / +