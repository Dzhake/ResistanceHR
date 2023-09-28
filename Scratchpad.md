#		How to read this
If you wandered in here out of curiosity, this is my working notes file, and completed/planned feature list. It's in Markdown, but best viewed in raw form since a lot of its organization has to do with text characters' alignment.

Listed in order of Parent tier summary symbol priority:
	C, T = Code this, Test this
	H = Hold, usually pending resolution of a separate or grouped issue
	√e = Fully implemented feature or group of features
#		Bugs
You didn't take notes! July was nuts.
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
#		Scope
##		C	Favorite tools
Weapons accrued lifelong damage counters, and level up intermittently. Generally the 1st level up should make the item last forever as its own item type. Using the item on 0 durability rolls to break the item.

|Name								|Type	|Tier	|Notes	|
|:----------------------------------|:------|:-----:|:------|
|Lead Pipe							|Bat	|	2	|- Slower attack, more damage
|Katana								|Sword	|	2	|- More criticals
|Kil-Bar							|Knife	|	2	|- Backstabber effect
|Kukri								|Sword	|	2	|- Rapid fire
|Machete							|Sword	|	2	|- More critical damage
|Sap								|Bat	|	2	|- Backstabber effect, knocks out
|Shining Axe						|Axe	|	2	|- A kill gives you a temporary boost to stats
|Stiletto							|Knife	|	2	|- Rapid fire, high attack rate and armor penetration
|Stun Baton							|Baton	|	3	|- Momentarily electrocutes hit enemies and deals electrical damage
##		C	Trusted Employer
Agents who:
  - You hired
  - Survived better than Neutral
  - Stayed on the level you're leaving
Will generate as Roamers on the next level.
Alternatively, they level up at 1, 3 and 7 completed jobs. Leveled up agents follow to the next floor. Leveled agents may spawn anew, rarely.
Agents gain a trait and a stat on level up:
	Thief: Modern Warfarer, Nimble Fingers, Blends in Nicely, Sneaky Fingers
	Hacker: Modern Warfarer, Nimble Fingers, Cyber Nuke
	Soldier; Modern Warfarer, 
##		C	Mutator: Skipping Town
Many actions generate Notoriety: anything done to faction agents, leaving many physical evidence traces, and leaving witnesses to crimes.

Depending on your heat level, you skip town a different way.
Call the Movers: Keep everything. Vanilla behavior.
Pack Light, Go Far: Keep half your inventory, preferring the most valuable items.
Pack Fast, Go, Fuck, Why Are You Still Reading This: Keep 5 items, randomly determined.

|Type								|HeatLevel	|InvToKeep	|SortBy		|Notes	|
|:----------------------------------|----------:|----------:|:----------|:------|
|Call the Movers					|0			|100%		|N/A		|
|Pack Light, Go Far					|25			|75%		|Value		|	
|Ride or Die						|50			|50%		|Value		|
|
|Pack Fast, Fuck, Now, Seriously	|80-100		|5			|Random		|
|From the Jaws						|80-100		|1-3		|Random		|- Applies if you left while in danger

###			C	Notoriety Disasters
If you cap out at 100 Notoriety, any of variouos disasters happen. Could be Supercop task force, etc. with other factions based on whichever hates you the most.

|Disaster							|Effect	|
|:----------------------------------|:------|
|Task Force							|- Duos of Supercops track you through the level, investigating properties. Maybe this could be forced by spawning noises in the chunk.
|
##		C	Spawns
###			C	Removeable traits
ScrollingMenu.GetTraitsRemoveTrait
###			C	Roamers
###			T	Bodyguarded
Sent to Discord for test
##			Reputations
Check RandomReverence (RandomPeopleAligned) for vanilla gates to avoid weird edge cases.
The reason for ordered execution:
- Do agent-based changes
- Then do randoms, like Polarizing, Unpleasant, Domineering
Each unlocks XP bonuses and maluses
Their marks are tracked on character sheet text live, and they upgrade on their own as you do their bonused/malused activities
You can remove a Reputation, but you will need to pick a new one when you exit to the next level. The options will be the three that match your behavior most.
###				Council Elder
Bonuses:
- Raise dead, drink blood, kill Werewolf, etc
Turns into Council Master, Enemy, etc. based on conduct
##		C	Trait QA
Fill out trait Categories, upgrade info, etc. rebalance to vanilla CCPV#s
Use vanilla trait values if:
	- IsAvaiable
	- CanSwap
	- Otherwise, feel free to use any number for CCPV
##		C	Moods
These are not chosen in character creation, and not gained on level up. They are gained and lost immediately according to their specific conditions. They have their own section on the character sheet.
I guess they could be added to the character creator, but with a warning that they are loseable. This will help familiarize them with the various triggers.
###		C	Karma
Karma is the summation of your positive and negative deeds. Every time you go up an elevator, unless your Karma is at 100 or -100, it moves by 25% towards zero.

|Event									|Karma	|
|:--------------------------------------|------:|
|Bought Slave							|-5
|Enslaved								|-5
|Extorted								|-3
|Gave Item								|+1
|Freed Prisoner							|+2
|Freed Slave							|+5
|Killed									|-3
|Killed Innocent						|-5
|Knocked Out							|-1
|Hire Died								|-3
|Hire Survived							|+2
|Inflicted Negative Status Nonhostile	|-1
|Inflicted Positive Status				|+1
|Leave Town (Ask/Bribe)					|+4
|Leave Town (Threaten)					|+3
|Mugged									|-2

####				C	Ascended
Karma == 100 (Capped)
+15% XP Gain
More XP rewards for altruistic acts.
Rarely, someone will be Aligned to you.
####				C	Benign
Karma >= 66
+10% XP Gain
Rarely, someone who would be Hostile is instead Friendly.
####				C	Clean Conscience
Karma >= 33
+5% XP Gain
Rarely, someone will be Friendly to you.
####				C	Firmly Neutral
Karma == 0
+40% XP Gain
####				C	Guilty Conscience
Karma <= -33
-5% XP Gain
Rarely, someone will be Annoyed or Untrusting to you.
####				C	Nihilist
Karma <= -66
-10% XP Gain
Prevents all XP penalties
Rarely, someone will be Hostile to or Scared of you.
#####					C	Wrongdoer
Karma == -100 (Capped)
-15% XP Gain
New XP rewards for sadistic acts
All Friendly and Aligned are converted to Loyal
Rarely, someone will be Submissive to you.
###		C	Skill
Skill points are accrued by the use of fine motor skills.

Event										Marks
Elevator Up									-5
	Graceful								+1
	Jack of Extra Trades/+					+1/+2
	Medical Professional					+1
	Nimble Fingers							+3
	Poor Hand-Eye Coordination				-5
	Sausage Fingers							-5
	Sneaky Fingers							+3
	Speed Coder								+1
	Stubby Fingers							-3
	Studious/+								+1/+2
	Tech Expert								+1
Intrusion Artist Triggered					+1
Level Up									-5
Use Crowbar									+1
Use Hacking Device							+2
Use Lockpick								+3
Use Safecracker								+3
Use Window Cutter							+2
Use Wrench									+1

####		C	Practiced Hands
Skill > 25
Chance to randomly instant-complete an Operating bar action, with SFX
+50% XP from operating bar actions that involve manual dexterity
+50% effect when giving healing items
####		C	Clumsy Hands
Skill < -25
When doing an Operating Bar action, add 5% critical failure chance to do one of the following:
	- Break the tool
	- Fail out of interaction without losing durability/item
	- Make noise while operating, proportional to tool type
###		C	Crookedness
Crook Mark system. Your record of committing theft, extortion and intrusion without witnesses. 

Your actions can directly moderate your Crook Marks:

Event										Marks
Bribe Cops									-10
Bribe Mafia									-5
Elevator up									-5
	Blends in Nicely/+						-3/-5
	Charismatic / Perfumorous				-3
	Suspicious								+3
	Upper Crusty							-5
	Wanted									+10
Level up									-5
Offer Motivation							-1
Sabotage Case Records						-5
	1/floor: Tech Expert + Computer in Police Station
Shop Purchase								-1

If you're caught doing something crooked, a more complex system kicks in that combines values from every victim and witness of the crime.

Note that multiple of these may contribute to the Mark calculation. E.g., Caught Stealing By and Caught Stealing From will generally accompany each other if the witness and victim are different people. It's classism time!

→ Target of Crime						CoolCannibal		CommonFolk		GangAffiliated	Guilty		HonorableThief	Innocent	Law Enforcer	Scumbag	 Upper Cruster
↓ Event
Caught bribing
Caught bribing by
Caught stealing by							+0					-1				+0			+0			+0				-2				-5			 +0			-5
Caught stealing from						+0					-1				+0			+0			-5				-3				-10			 +0			-10
Caught extorting (Bribe=Loanshark)
Caught extorting (Bribe=Loanshark) by
Caught extorting (Threat)
Caught extorting (Threat) by
Caught extorting (Violence)
Caught extorting (Violence) by
Caught mugging
Caught mugging by
Caught trespassing by
Caught trespassing on

####				C	Known Crook
Crook marks > 25.
People with property become Annoyed or False-Friendly. 
	False-Friendly: Appears Friendly. They follow you around their property closely waiting for you to do something that will piss them off.
Law enforcers can see you from further away and do Supercop-level investigation into noises you make.
You're too hot to handle:
	- Honorable Thieves are annoyed 
	- Counteracts Honor Among Thieves effect
	- Fences will not buy from you
####				C	Slick Crook
Crook Marks < -25.
Sticky Glove hitbox is faster
Operating bars have a chance to interrupt with immediate success of the action
+20% XP Gain for successful Crooked actions
Honorable Thieves give you a discount
####		C	Lawfulness
Lawfulness is a mark-based hidden variable. It represents your reputation regarding the law, *as believed by surviving witnesses* to the actions. It is modified by the social and legal statuses of the target of the action.

→ Target of Crime				CoolCannibal		CommonFolk		GangAffiliated	Guilty		HonorableThief	Innocent	Law Enforcer	Scumbag	 Upper Cruster
↓ Event
Seen Killing Directly
Seen Killing Directly by
Seen Killing Indirectly
Seen Killing Indirectly by																										-10
####			 C	E'er-Do-Well
Lawfulness == 100 (Capped)
####			 C	Law-Abiding
Lawfulness >= 66
####			 C	
Lawfulness >= 33
####			 C	Scofflaw
Lawfulness <= -33
Has Suspicious effect from Law Enforcers anytime you're on owned property
####			 C	Outlaw
Lawfulness <= -66. This cap increases by 5 per character level.
Maybe a parallel to the Known Crook system
####			 C	Villain
Lawfulness == 100 (Capped)
###		C	Misc traits without parent system yet
####			 C	Post-Traumatic Stress
Witness 25 people dying.
-5% XP Gain
Cumulative
####			 C	Hardened
Take or deal a total of 1000 damage. 
Count diminishes by 20% per Elevator Up.
All XP% penalties are halved
####			 C	Killer Instinct
Kill 25 people in melee or close combat.
+Floats Like Butterfly effect
####			 C	Comfortable Distance
Kill 25 people indirectly through sabotage, traps, hacks, and employees.
Every relationship change has a 25% chance to be canceled.
####			 C	Guilt-Ridden
Losing enough followers makes you unwilling to take on new ones, unless your Karma is really bad.
backstabs
####			 C	Pyromaniac
#		Traits
Dissociated: HP bar always says ??/??, damage you take is hidden
No Taste: Half healing from consumables
No Smell: Status effects are always unknown, reduces Rogue Vision cone slightly
##		C	Debt
###			C	Bank Debt 250
Standard boring shitty Assassins
###			C	Blahd/Crepe Debt 250
Try getting both to be in the middle of a gang war
###			H	Cannibal Debt 15 Organs
I have organ mod notes somewhere
###			C	Cop Debt 250
Cobs
###			C	Drug Dealer Debt 10 Sugar
You stole a very important suitcase.
Enforcers are swarms of Slum Dwellers each using a drug effect, to include negative effects to nerf a bit.
###			C	Mob Debt 250
Guns
###			C	Monke Mob Debt 15 bananas
Could be good
##		C	Close Combat
###			C	Enchanted Hands
####			C	Cursed Fist / +
#####				C	Unlucky on Hit
Gate to Fist
Limit text callout
#####				C	Lose at gambling
#####				C	Fail at disarm object + %
#####				C	Hit luck 0
Kneecapper, etc.
#####				√	Hit Ghosts
#####				√	Bonus damage to non-supernatural
####			C	Flaming Hand / +
#####				C	Cook Fud on pickup
#####				C	Ignite on hit
#####				C	Ignite on object interact
#####				C	Flaming wooden weapons
#####				C	1 damage everytime you use your pockets
####			C	Icy Grip
#####				C	Short freeze on hit
#####				C	Minifridge effect
#####				C	Brainfreeze when eating (Slow)
####			C	Lightnin' Fingers / +
#####				C	Short stun on hit
#####				C	Mess with electronics
#####				C	Electrified metal weapons
#####				C	Faster Operating Speed
####			C	Spectral Palm / +
#####				C	Something to do with Gravestones?
#####				√	Hit Ghosts
#####				√	Bonus damage to supernatural
####			C	Stone Paw / +
#####				C	Slower swing
#####				C	Bigger hand sprite
#####				C	More damage in general
#####				C	Fumble small weapons
#####				C	Lockpicks ain't happening
####			C	Venomous Claw / +
#####				C	Poison Food
#####				C	Poison on hit
#####				C	Chloroform kills
##		C	Experience
Possible rewrite:
Path of Ashes - Burn things
Path of no Particular Direction - Do crimes & pranks
Path of the Spooky Skellington Head - Bad stuff & killing
Path of the Coin - Earning & Spending, buying & selling, hiring and working
Path of Life - Good stuff & healing
Path of the Scepter - Law, friendly things
Path of Shadows - Stealth
Path of Storms - Electricity
Path of the Deep - Water
###			C	Guilty Conscience
Enable Cop mali
###			C	Flagellant
Enable new mali including Cop ones (full extension of guilty conscience)
Double all mali
##		C	Item Restrictions
###			C!	00 CC Items not spawning in inventory
Banana didn't appear in inv with Carnivore, loud stuff with Afraid.
ChooseWeapon_FilterItemList is the culprit.
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
New features listed in description
###			T	Friend of Bill
###			T	Teetotaller
###			T	Vegetarian
##		C	Unfriend Network (Roamers)
###		 C	Haunted
###		 C	Redball Case
A pair of cops are assigned to follow you at all times, looking for an excuse to beat you down. Killing the existing ones will spawn more, but buy you time.
##		C	Quests
###		C	Quest Rewards
Do not make them compatible, the logic will be a mess.
Can make a Prize Bag one later on if you feel like it, to randomly select one.
####			C!	00 Banana Count 0 Item Rewards
Banana peel, count 0
####			H	Double-Ply Rewards
Item only
####			H	Lump Sum
#####			H	Double money
Pending 00 Item Rewards above
#####			C	No XP
####			H	Monkey Rewards
Reward banaan
HR made a typo
####			H	Unpaid Internship
#####			C	Double XP
#####			H	No Money
Pending 00 Item Rewards above
###			√	Quest Count
####			√	Rushin' Revolution
####			√	Single-Minded
####			√	Workhorse
##		C	Ranged Combat
###			C	00 BM Importation
This doesn't need to mean the new code works, only that you've got what you need out of the old stuff.
Bullet.
	SetupBullet			√
	LateUpdateBullet	√
BulletHitbox.
	HasLOSBullet		√
	HitObject			C	(Sniper + Shot past cover)
PlayfieldObject.
	FindDamage			C	
###			C	Sniper
####			C	Damage
####			C	Range
###			C	Sniper +
####			C	Bypass Cover Object
BulletHitbox.HitObject
This was NOT working yet in BM
I've deleted that old method since salvaging it would be more work than it's worth.
No currently activated attempt yet.
#####				C	00 BM Notes
- Attempted with BulletHitbox.OnTriggerEnter2D
	- DW, but see what logs are saying before deletion
- Check out vTrait.BulletsPassThroughObjects. It's in BulletHitBox.HitObject
- Consider Bullet.RayHit
- Model this one on Penetrating Bullets: BulletHitbox.HitObject
	- Attempted 
	- (If this doesn't work, try with eliminating BulletHitBox.OnTriggerEnter2d patch next)
- PFO.bulletsCanPass may determine raycast end of bullet
- Give some visual indicator, either as a SPecial Indicator over NPCs, or a color change on the aiming reticle, when you are able to do a headshot
- Ability Indicator at Range
	- May need to trigger StatusEffects.SpecialAbilityInterfaceCheck as if adding a Special Ability. Not sure this will be doable with a trait.
	- Call it in AddTrait.
	- Attempted
	- StatusEffect.AddTrait
	- StatusEffects.SpecialAbilityInterfaceCheck
	- Used placeholder Chloroform sprite
	- Used placeholder range without 2f range mod from hiding
####			C	Sprite Target Indicator
Agent.SpecialAbilityInterfaceCheck2
###			C	Wetworker
####			C	Damage
####			C	Range
####			C	Helmet Damage Reduction
This should be the "oh shit" snag for a Wetworker. 
##		C	Relationships
###			C	Rivalry Traits
####			C	Bad for Business
Shopkeepers and Bartenders are hostile and give bonus XP
####			C	Disincorporator
Office drones are hostile and give bonus XP
####			C	Robot Recycler (-4)
Robots are hostile and give bonus XP
####			C	Slaver Slayer (-2)
Slavers are hostile and give bonus XP
####			C	Foe of the Common Folk
Slum Dwellers are hostile and give bonus XP
####			C	Esprit de Corpses
Soldiers are hostile and give bonus XP
##		C	Senses
###			C	No Taste
###			C	No Touch
###			C	No Smell
##			C	Social
Move Bootlicker and Priors back in here
###			 C	The Law - Precincts
####				C	Undercover

####				C	Sweeper
In any Police Station, one cop is turned into a Sergeant. Interact with the Sergeant to open up the item-selling menu, except you are paid Big Quest marks. The Sergeant buys any contraband.
####				C	Cyber Division
Hackers are guilty, may have robot bodyguards in later levels
Killer Robot is more likely
####				C	Southern Precinct
Random darker-skinned and Foreign-speaking NPCs have "Probably Guilty" status, except if they have Upper Crusty.
Apprehending them gives normal arrest XP rewards, but has negative reactions on anyone witnessing it.
Riot disaster is more likely to occur if you use this too frequently.
###			 C	Language Crossover traits
Most of these are pretty superfluous. 
####				C	Alien Buddy
Applies: Some Alien traits. Cannot be removed. Hackers will work for you permanently and for free.
####				C	Robot Sidekick
Applies all the effects of Diminutive, Electronic, Vocally Challenged and Speaks Binary. Cannot be removed. Hackers will work for you permanently and for free.
####				C	Elder Vampire
Applies: Vampirism, Vocally Challenged and Speaks Chthonic. Vampires will give you one of a random set of benefits on sight. Join, free blood bag, etc. God that's lame
####				C	Brainful One
Applies: Zombiism, Vocally Challenged and Speaks Chthonic. Zombies will join you on sight or interaction and become intelligent when under your command.
####				C	Feral Werewolf
Applies: Werewolf Transformation, Vocally Challenged and Speaks Werewelsh. Werewolves are hireable for Bacon Cheeseburgers or money.
####				C	Fresh off the Intercity Supersubway
Applies: Vocally Challenged & Speaks Foreign. Random people will be annoyed with you, and scumbags may occasionally go hostile. Other Foreign speakers are Friendly by default.
####				C	Gigamonke
Applies: Some gorilla traits. Gorillas may join you or challenge you to fight them to join. They occasionally mutiny, but not en masse.
####				C	
###			 C	Odoriferous
Everyone's Annoyed.
Using Cologne returns them to normal.
Using it again on the same level makes them Friendly. 
Only one layer wears off, so remember to apply it liberally because everyone forced to be near you really appreciates it. 
##		C	Vision Range
###			C	Agent Activation
###			C	Object Activation
###			C	Imported BM Notes
- View range Agent & Object activation
	- ObjectRealOnCamera
	- Attempted
	- BrainUpdate.RogueVisionChecks()
	- BrainUpdate.DoObjectChecks()
	- Agent.AgentOnCamera()
	- This worked, but now they don't animate. They walk around statically, often tilted or upside down.
		- Attempted, Agent.Start
	- Agent.onCamera
	- Agent.wasOnCamera
	- PlayerAgent.agentCamera.ZoomFactor
	- PlayerControl.myCamera.zoomLevel
	- CameraScript.RealAwake
###			C	Eagle Eyes / + 
###			√	Myopic / +
##		C	Voting
###		 C	Fragile Egomaniac
Voting increases are doubled
But voting decreases are tripled
People get Annoyed or Hostile at you a bit easier
###		 C	Campaign Donations
Gain $ for each vote at end of level
Counts for negatives too, don't fuck it up!
###		 C	Milquetoast
Can't lose votes, but gain at half rate
People get angry at you slower
##		√	Experience Rate
###			√	Brainiac
###			√	Dim Bulb
###			√	Moron the Merrier
#		Feature Dump
Trait where loadout is replenished per level
Trait where inventory is cleared per level
	Might leave five randoms, so sell off if you can
Cache Stasher
	Forces choosing a chunk with a crate on every level
	The crate contains your item loadout
#	By Any Means Necessary But Nothing Crazy
Mandatory Election win
Could do other mandatory win styles

#	BunnyMod Notes Import
## Traits
### Gold Traits

|Base Trait			 |Gold Trait					 |CCP |Effects|
|:----------------------|:------------------------------|---:|:------|
|Bite					|Infernal Master				|	|- Bite victim may join your party and Align<br>- Chance is inverse to their remaining health %
|Cannibalism			|He Knows						|	|- You can eat Fud now
|Chaaaaarge!			|Heavy Tackle					|	|- Enemies hit by Charge are tripped
|Camouflage			 |Stealth Master				 |	|- Ability is now toggled at will<br> - Recharges when inactive
|Cannibalize			|Waste not, want not			|	|- You can eat Gibs for 1HP each
|Chloroform Hankie		|Doctor's Orders				|	|- You can subdue people from any direction, even if their back is against a wall
|Chloroform Hankie		|Hypocritical Oath				|	|- No longer annoys people
|Chloroform Hankie		|Giggle Fumes					|	|- No longer knocks out, but gives Super Dizzy<br>- When they recover, they are Friendly
|Cry Profusely			|Cry Even More Profusely		|	|- Crying is 80% louder<br>- 60% saltier tears
|Enslave				|Armored Helmets				|	|- Slaves have damage resistance
|Enslave				|Stockholm's Curse				|	|- Slaves may be Loyal after freeing
|Handcuffs				|Crime Does Pay, Just Not You	|	|- You get paid for arresting guilty
|Joke					|Chekov's Pun					|	|- Jokes do damage to Hostiles or people who would be made Hostile
|Joke					|Society is a Punchline		 |	|- Jokes will occasionally turn people into Rioters
|Joke					|Actually Pretty Mean-Spirited	|	|- Jokes will Enrage Hostiles or people who would be made Hostile
|Joke					|Divisive Humor				 |	|- Audience may split into two hostile groups
|Laptop				 |Remote Operation				|	|- Manual Control option when hacking Robots, Security Cams & Turrets
|Laser Cannon			|Heavy Laser					|	|- Hold to Charge<br>- Release for a powerful laser that can destroy minor walls
|Laser Cannon			|Riot Gun						|	|- Cannon now has scattershot<br>- Considered Non-lethal (Except by Geneva Convention)
|Laser Cannon			|Tesla Cannon					|	|- Cannon now stuns like Taser<br>- Charge cap is lowered
|Laser Cannon			|Inferno Cannon				 |	|- Cannon now shoots flaming oil<br>- Mech is fireproofed
|Laser Cannon			|Stasis Ray					 |	|- Cannon now shoots Freeze Ray
|Laser Cannon			|Minigun						|	|- Cannon now shoots bullets with ridiculous ROF<br>- Recharge deactivated<br>- Activate Minigun item in inventory to refill with ammo from other guns<br>- Can also refill at Ammo Dispenser
|Mind Control			|Brainwash						|	|- Chance of NPC not becoming Hostile after MC wears off
|Mind Control			|Extreme Pathokinesis			|	|- Chance of NPC going Enraged after MC wears off
|Mind Control			|Hive Mind						|	|- MCed NPCs may spread MC via melee
|Possess				|Astral Projection				|	|- Now target ability with cursor instead of needing to be behind someone. Visual range.
|Power Sap				|Sap Zap						|	|- Stuns NPCs hit by ability
|Primal Lunge			|Primaler Lunge				 |	|- Replace with Sharp Lunge (no warmup)
|Sticky Glove			|Lovable Scamp					|	|- Cops Annoyed when they catch you pickpocketing
|Stomp					|Rumblechungus					|	|- Targets hit by Stomp are knocked down
|Toss					|Toss +						 |	|- Can now toss *all* Objects
|Water Cannon			|Hot Water						|	|- Water damages NPCs eventually
|Water Cannon			|All-Purpose Hardware			|	|- You can fill the cannon with Oil at a Stove if you want
|Werewolf Transformation|Chimpout						|	|- Change into Giant Gorilla instead<br>- Monke gooder
|Zombie Phlegm			|Darth Salivator				|	|- Can infect people through A/C & Gas Vents<br>- Can infect people through Water Pump<br>- Can Lick Doorknob to infect the next person who uses it

* Friendship Ended With Werfworf, Now Monke Is Best Friend
### Weapon Specializations
All 1st level traits: durability decreases 25% slower
2nd: durability decreases 50% slower

|Trait								|Type			|CCP	|Effects|
|:----------------------------------|:--------------|------:|:------|
|Always Baton Red					|Police Baton	|		|- Damage to Guilty +<br>- Non-lethal knockout (Good for Doctor quest or The Law)
|Always Baton Red +				 |Police Baton	|		|- Attack Speed +
|Axe-Pert							|Axe			|		|- Destroy Trees in one hit (maybe make trees harder to break normally)<br>- Wall Walloper effect for Hedge Walls
|Axe-Pert +						 |Axe			|		|- Destroy Doors in one hit<br>- Swing arc size +<br>- Wall Walloper effect for Wooden walls
|Crowbartender						|Crowbar		|		|- Sneaky Fingers effect when tampering<br>- Floats like Butterfly effect
|Crowbartender +					|Crowbar		|		|- Backstabber effect<br>- Tamper tantrum effect
|King Hammer-abi					|Sledgehammer	|		|- Long lunge effect<br>- Kneecapper effect
|King Hammer-abi +					|Sledgehammer	|		|- Can break down Steel Doors<br>- Damage +
|Mr. Knife Guy						|Knife			|		|- Attack Speed +
|Mr. Knife Guy +					|Knife			|		|- Full auto<br>- Block breaker effect
|One Man Unarmed-y					|Unarmed		|		|- Attack Speed +<br>- Butterfinger-er Effect
|One Man Unarmed-y +				|Unarmed		|		|- Attack Lunge +<br>- Can block attacks without attacking
|Switch Hitter						|Baseball Bat	|		|- Knockback +<br>- Swing Arc +
|Switch Hitter +					|Baseball Bat	|		|- Knockback gibs enemies if they hit a strong wall
|Sword of a Big Deal				|Sword			|		|- Attack speed +<br>- Butterfinger-er Effect<br>- Alternate Stab & Swing
|Sword of a Big Deal +				|Sword			|		|- Attack speed +<br>- Melee Mobility effect
|Huevos Wrencheros					|Wrench		 |		|- Clumsiness Forgiven & Tamper Tantrum effects<br>- Damage +
|Huevos Wrencheros +				|Wrench		 |		|- Backstab effect

|Akimbo Slice						|Pistol		 |		|- Becomes dual pistols
|Akimbo Slice +					 |Pistol		 |		|- Full Auto
|Dessert Beagle					 |Pistol		 |		|- Massive damage, recoil, kills gib
|Dessert Beagle +					|Pistol		 |		|- Dual-wield
|Extra Shooty						|Machine Gun	|		|- Single click to shoot a 3-round burst with stacking chance to crit
etc. etc., these aren't as interesting because all you can do with guns is shoot people, so... you get the idea. Weapon mod system through traits.
|Boomstick, 1.0ff.					|Shotgun		|		|- Double damage to Undead
|Boomstick, 2.0ff.					|Shotgun		|		|- Damage and knockback boosted
|Boomstick, 0.5ff.					|Shotgun		|		|- Spread +, Range -, Damage/Crit + by range
### Zero-CCP Traits (OR Near-Zero)
Traits with minor enough benefits that their only cost is a Trait slot.

|Trait								|CCP	|Effects|
|:----------------------------------|------:|:------|
|Banana Splitter					|0		|- Get 2 banana peels from eating a banana
|Polyglot							|0		|- Counts as having Translator
|Long Fingers						|0		|- Operating bar is slower, but stays active further away (1.5 tiles?)
|Long Distance Runner				|0		|- +1 Speed but you accelerate slowly
|Spinmaster						 |0		|- Always succeed at Turntables
|Swimmer							|0		|- Movement speed increased in water
### Combat 
|Trait								|CCP	|Effects|
|:----------------------------------|------:|:------|
|Adrenaline Rush					|4		|- Gain strength for 5s after a kill<br>- Stackable
|Ammodrenaline Rush				 |6		|- Chance to not use ammo when firing at low health
|Akimbo							 |4		|- Your guns shoot two times at once
|Ambusher							|		|- Attacking from Hiding or Camo gives bonus damage
|Arthritis							|		|- Move & attack rate are slower
|Blaster Expander					|		|- Increase explosion radius
|Blaster Igniter					|		|- Your explosions drop flaming oil
|Bloodbather						|		|- Gibbing NPCs gives you temporary boosts to speed, damage and DR
|Bonkist							|		|- Backstabbing with a blunt weapon gives the target Crazy Dizzy
|Bonkist +							|		|- Backstabbing with a blunt weapon knocks the target out, nonlethal
|Bullet Grabber					 |		|- When you get shot, chance to refill your guns
|Eye Poker							|		|- Unarmed attack has a chance to blind enemies
|Fatass [SHELVED]					|		|- Slower movement<br>- Can't wear armor<br>- Stomp damage
|Flat-footed						|		|- Shorter lunge range
|Good Arm							|		|- Increased Throwing range & damage
|Hard-Headed						|		|- Chance to lose XP instead of HP
|Hemophiliac						|		|- Gain the Bleeding effect when hit with piercing weapon
|Hit-and-run						|		|- Gain speed after a kill
|Homing Bullets					 |		|
|Masochist							|		|- Gain the Bored status if you go 60s without taking damage. Bored drains your XP.
|Observational Learner				|		|- Indirect kills give you direct kill XP
|Running Start						|		|- Damage boosted by speed<br>- Recommended: Roller Skates
|Shield of Hope					 |		|- Gain DR at low health
|Surprise Assault					|		|- If you hit a non-hostile NPC, all your chance-related traits trigger (Kneecapper, Butterfingerer, etc.)
|The Bug							|-6	 |- Lose health when over 20HP
|Trigger Happy						|		|- All weapons have auto-fire
|Whiffist							|		|- Small chance for attacks to bypass you completely & keep traveling (too close to Un-Crits)
|Wild West Duelist					|		|- If you have a Revolver, you can challenge people to duels. They get a revolver too.<br>- During a duel, revolver does increased damage.
### Consumption
|Trait								|CCP	|Effects|
|:----------------------------------|------:|:------|
|Alcoholic							|		|- Analogous to Addict but with Alcohol
|Banana Lover ++					|		|- Can only eat bananas<br>- Do a little dance when you eat them<br>- $1200
|Bioavailable						|		|- More healing from food & alcohol
|Chemical Resistance				|		|- Immune to most status effects
|Fast Metabolism					|		|- Less healing from food & alcohol<br>- Shorter Status effects
|Filling the Void					|		|- Addict, but with all consumables
|Food Addict						|		|- Addict, but with food
|Hematic Converter					|		|- Requires: Electronic<br>- Can now consume BLOOOOOD<br>- Allows combination of Bite & Electronic
|Panic Eater						|		|- If you would die, automatically consume food/healing items to offset the damage
|Tarrare							|		|- Can activate some organic objects (Chair, Table, Bush) to eat them for health
|Unsaveable						 |-16	|- Can't heal, even from levelups<br>- Cancels: Medical professional, strict cannibal, jugalarious, addict, [insert anything that heals you here.]
### Environmental & Movement
|Trait								|CCP	|Effects|
|:----------------------------------|------:|:------|
|Aquaphobia						 |		|- Take damage while in water
|Botanist							|		|- Smashing a Plant has a small chance to drop a random medicine<br>- Destroying a Bush has a small chance to drop a Banana (they're berries, okay??)
|Door Kicker						|		|- Activate a door to kick it down. Door is destroyed, and anyone inside within a radius is stunned momentarily
|Muscle Spasms						|	- 7|- At random intervals, your character will spasm:<br>	- Move in a random direction<br>	- Attack in a random direction<br>	- Have a seizure (Taser effect)
|Ranger							 |		|- Killer plants don't attack you<br>- See enemies hidden in Bushes<br>- You can walk through Hedge walls, slowly<br>- Axe deals high damage to trees, and can destroy Hedge Walls
|Roadrunner						 |		|- Slower movement indoors<br>- Faster movement outdoors
|Vapor Form						 |		|- Activate a closed door to bypass it without opening it<br>- No damage from moving through broken windows<br>- Activate A/C or Gas Vent to exit any of same connected objects
### Finders & Keepers
|Trait								|CCP	|Effects|
|:----------------------------------|------:|:------|
|Ammo Mule							|		|- Increase all max ammo by 50%
|Banana Rewards					 |-84N4N4|- Bananas as quest rewards
|Cache Crasher						|8		|- Chests & Safes have 1 more item than normal
|Dumpster Diva						|		|- Find better items in trash<br>- Base chances nerfed a bit
|Durable Fashion					|4		|- Durabilitacious but for wearables
|Fine Tuner						 |		|- Reduces Item Charge use (Maybe combine with Tamper Tantrum?)
|Mixologist						 |1		|- All Cocktails are identified
|Pocket Stuffer					 |		|- Increases inventory slots by 5
|Pocket Stuffer +					|		|- Increases inventory slots by 10
|Smash-n-Grabber					|		|- You can punch unaware NPCs to make them drop a non-equipped item in their inventory<br>- Streets of Cheese suggested no unaware requirement<br>- If they're Fleeing, they drop everything, which adds synergy to disturbing facial expressions
|Travels Light						|		|- You are slowed very slightly for every object in your inventory
### Object Interactions
|Trait								|CCP	|Effects|
|:----------------------------------|------:|:------|
|Chunky							 |		|- Move very slowly through doorways<br>- Can't crawl through windows<br>- Can't hide behind objects<br>- Reduced Knockback<br>- Possibly combine with Fatass
|Machine Shaker					 |3		|- Chance of a free transaction when using a Vending Machine-<br>- On success, cops will go hostile if they see it.
|One Happy Tamper					|		|- Tamper without angering Owner (or just extend this into Clumsiness Forgiven)
|Primitive							|-4	 |- Can't use ANY technology
|Techno-Cursed						|		|- Anytime you operate a machine, there's a ~5% chance it'll do something awful.
|Trapper Keeper					 |		|- All invisible floor traps are visible<br>- You can interact with traps to disarm them and add to inventory<br>- 100% success with Door Detonators
### Social 
|Trait								|CCP	|Effects|
|:----------------------------------|------:|:------|
|Animal Whisperer					|		|- Gorillas and Werewolves are Loyal
|Arrogant							|		|- People get mad at you a lot more easily<br>- I think this means whenever they'd be Annoyed, they go straight to Hostile
|Banned From Literally Everywhere	|		|- ALL property owners are annoyed<br>- Cops go hostile if they see you in a building
|Beggar							 |		|- Mugger with lower stakes
|Commissioner						|		|- Requires The Law<br>- Spawns two Cop followers per level<br>- Other perks?
|Commissioner +					 |		|- Spawns two Supercop followers per level
|People Person						|		|- Sell Slaves to Slavemasters, Scientists, Upper Crusters, etc.
|Professional Network				|		|- Hackers & Thieves have a map marker<br>- Hackers & Thieves spawn on all levels
|Professional Network +			 |		|- Gangbangers, Soldiers, Doctors & Gorillas have a map marker<br>- All spawn on all levels
|Excited by Crowds					|		|- Speed bonus by number of followers
|Freedom Fighter					|		|- Bonus XP for freeing Slaves & killing Slavemasters<br>- All Slave owners are annoyed at you<br>- Slave Helmet Remover is silent
|Freedom Fighter +					|		|- Slaves are Aligned and may join your party when you free them<br>- Slave Masters are Hostile<br>- Slave Helmet Remover is instant & silent
|Inspiring Presence				 |		|- All followers get Un-Crits
|Oath of Vengeance					|		|- Triggers when a Follower is killed<br>- You and all surviving followers get a temporary speed & damage boost
|Resting Bitch Personality			|		|- Better % with coercive interactions<br>- Can talk to Annoyed<br>- Everyone Annoyed
|Separation Anxiety				 |		|- If you have no Followers, all your stats are lowered
|Social Parasite / Retail Therapy	|		|- Heals for a small amount every time you do a social transaction
|The Blood Guy						|		|- Recommended: Blood Transfusion Device<br>- Offer NPCs a small fee for them to donate blood, affected by Shrewd Negotiator<br>- NPCs at low health will pay for a blood transfusion (might be too imbalanced, you could grind this)<br>- Vampires will always buy blood packs from you<br>- Vampires won't bite you and are Loyal
|Shoplifter						 |6		|- All Vendors have an additional button, "Shoplift."<br>- When pressed, shows the shop menu. Instead of prices, the items show a % chance of success.<br>- Failure means the Vendor	goes hostile with his followers.
|Solicit Bribe						|		|- Similar to Mugger, but requires The Law. If paid, gives NPC Above The Law.
|The Blood Guy						|		|- Recommended: Blood Transfusion Device<br>- Offer NPCs a small fee for them to donate blood, affected by Shrewd Negotiator<br>- NPCs at low health will pay for a blood transfusion (might be too imbalanced, you could grind this)<br>- Vampires will always buy blood packs from you<br>- Vampires won't bite you and are Friendly
|Trusted Leadership				 |		|- Followers never question orders<br>- 1 extra use per hire
|Undying Loyalty					|		|- Followers never quit at low health
|Undying Loyalty +					|		|- All followers get Resurrection when hired, and stay Loyal
|Unthreatening						|		|- Short delay for NPCs to go hostile, depending on distance
|Zombie Whisperer					|		|- Zombies not hostile
### Others
|Trait								|CCP	|Effects|
|:----------------------------------|------:|:------|
|Bad Blood							|		|- Leaks Slime Puddle whenever hit or killed<br>- Immunity to Poison<br>- Antidote acts as Cyanide
|Bad Habits						 |		|- Gain a negative trait in addition to a positive, when you level up
|Bad To Worse						|		|- Gain only a negative trait on level-up
|Benjamin Button Syndrome			|		|- Immediately level up to 12 at beginning of game<br>- Lose a level every floor
|Code Whisperer					 |		|- Robots are friendly<br>- Get access to hacking options simply by interacting
|Dead Raiser						|		|- Instead of Ghosts when you bash a gravestone, you get Zombies<br>- Keep in mind it's a luck roll and you need *bad* luck to roll an Undead rather than money
|EMP Aura							|		|- Electronics temporarily deactivate when you're near<br>- Robots take damage around you<br>- Immune to Taser
|Fingerless						 |		|- Can't open doors<br>- Can't equip anything<br>- Can't operate most objects
|Golden Boy						 |		|- Double mission rewards
|Gunpoint Negotiator				|		|- Shop prices are improved according to your Threat
|Learns the Hard Way				|		|- Gain XP everytime you take damage
|Literally Brainless				|		|- 0% XP gain<br>- Can't do a *lot* of things or talk to people<br>- Zombies ignore you<br>- Immune to headshots
|Luck +++							|	 32|- Always pass<br>- Alt name "Plot Armored"
|Luck ---							|	 -8|- Always fail
|Machine Negotiator				 |		|- Better prices (buy & sell) at Vending Machines<br>- Can Bribe Cop Bots
|Needy								|		|- You have needs like the musician:<br>	- Use Toilet<br>	- Use ATM<br>	- Etc.<br>- Failure to fulfill a need will do *something* negative, not sure what yet.
|Not a Doctor, Damn it				|		|- All Health bars except yours are invisible<br>- Awful results when trying to use healing items
|Revolution F						|		|- Elevator is open, even if you haven't completed your quests
|Steady Hands						|		|- When filling Operating Bar:<br>	- Damage Resistance +<br>	- Near-zero Knockback<br>	- Hits will slow but not stop operation<br>- Can't get disarmed by Butterfinger-er
|Toxic Avenger						|		|- Poison & Slime heal you<br>- Most healing items hurt or poison you
|[Name]							 |		|- Many XP rewards converted into Money rewards

</details>
### Hands traits

|Trait								|CCP	|Effects|
|:----------------------------------|------:|:------|
|Hands of Darkness					|		|- Unarmed & Knife may blind enemies<br>- You are harder to see<br>- Activates Rogue Vision
|Hands of Darkness +				|		|- Enemies glow in the dark<br>- Invisible to cameras and lasers
|Hands of Fire						|		|- Unarmed & Axe may burn enemies<br>- Fud is cooked automatically<br>- Oil ignites under you<br>- Water hurts you
|Hands of Fire +					|		|- Immune to fire damage
|Hands of Ice						|		|- Unarmed & Sword may freeze enemies<br>- Mini-Fridge effect<br>- Can't grill Fud<br>- Immune to fire
|Hands of Light					 |		|- Unarmed & Baton deal additional damage to Undead<br>- Heal followers up to half health for free<br>- You're less stealthy<br>- You can't use poisons
|Hands of Light +					|		|- Poison Immunity<br>- Heal followers up to full health for free<br>- Undead fear you
|Hands of Lightning				 |		|- Unarmed & Sledgehammer may stun enemies, deal additional damage in water<br>- Small chance to break machines when using<br>- Taser & Stun-gun recharge faster
|Hands of Lightning +				|		|- Unarmed & Sledgehammer throw taser projectile<br>- Immune to Taser, Stun-gun & Stun Baton
|Hands of Stone					 |		|- Unarmed attack slower, increased damage, larger hitbox<br>- At high strength, can punch down weaker walls<br>- Won't burn hands cooking on Flaming Barrel
|Hands of Stone +					|		|- Unarmed attack further improved<br>- Block attacks if you're pointed right at them and not punching
|Hands of The Viper				 |		|- Unarmed & Knife may poison enemies<br>- Poisons unpackaged food<br>- Yes, Vipers have hands, duh
## AAAA (Able At Any Ability) Mod
Listen, Sweaty. SOR has no representation of the disabled, and this is problematic. We need to normalize otherly-abled fxlx in vxdxx gxmxng, and it starts here.

|Disability				 |CCPV	|Effects|
|:--------------------------|------:|:------|
|Age Against the Machine	|-24	|- All attributes capped at 1<br>- Everyone starts out Friendly<br>- Anyone Neutral or better will help you in a fight<br>- Chance to drown in water<br>- Climbing through windows is slow and nearly kills you<br>- Eating sugary stuff will give you a withdrawal<br>- Have to buy meds from a Doctor every 2 floors
|Blind Over Matter			|-96	|- You are blind. But maybe... it's *everyone else* who is truly blind? 
|Hear No Evil				|-24	|- You are deaf. You can only see what's in your vision cone. Most sound effects are completely muted, but you can hear deeply-pitched sounds or stuff touching you.
|Incontinence Under Pressure|-12	|- Sometimes you do a pee-pee everywhere. Owners get pretty annoyed, as do non-owners. You get Malodorous until you use a Bathtub.
|Legless (Not an Elf)		|-48	|- You can't move normally. You have to do it with punching, or getting hit. This is actually empowering.
|Nothing Wheelie Matters	|-24	|- Rollerskates + Legless, can build up a decent speed but brakes might trip you
|Perfectly Armless			|-24	|- You can't do anything that requires arms. You can headbutt stuff, and if anyone says that's ineffective, they're reinforcing prejudice.
|Severely Retarded			|-96	|- You cannot control your character. They are automated and will wander aimlessly regardless of what they see. Or just stare at walls.
|Unipod						 |-24	|- You can only move by hopping, and cannot participate in Sockhop Races, which are an oppressive construct anyway. The shared sock in the race between two legs represents the MALE PHALLUS, reeeeeee
|Zero Significant Digits	|-48	|- You can't hold things or use doorknobs. But people will open doors for you, because you're absolutely pathetic.

TODO: Better.

- Trait: Capitalism Breeds Innovation
	- You have to use Insulin every floor, or else you start experiencing major negative effects and then death. They're very expensive and can only be bought from a doctor.
- Trait: A Lifetime of Grudges
	- Attacked by tons of old people with various disabilities

golden traits for each of the traits that replaces the negative trait with a superpower
Robo-Eyes: You can see now. You can see the relationships between people and a crosshair in front of them showing where they will move next via mousing over. If you don't have a right click ability, you get the mech's laser gun.
Robo-Legs: If you don't have a right click ability, you can now use SSA Stomp. Your speed is now 6.
Robo-Arms: Lasers like robo-eyes, your melee is now 5, you have nimble and sneaky fingers.
Savant: I think this is already a trait in bunnymod
We Are Leg-ion: You have a lot of legs. Slow and Paralyze don't affect you, your speed is increased by 2.
Deadly Digits of Doom: Operating bars take no time, people dont notice you operating stuff, punches do a lot more damage and take weapons out of people's hands

Wheelchair as right-click to speed up, not sure about brake but could trip you and you have to crawl back in
Oiled Wheels - No Friction.
Titanium Armored Chair - Wheelchair loses less durability when damaged.
Faster Faster Faster! - On right click, the propulsion from the ability is doubled.
Basically, use Wheelchair as Mech-type vehicle

Echolocate special ability for the Blind, temp deafens people and gives you a second of sight
Cane item you can swing, people forgive a few hits. Gives you one square of sight.