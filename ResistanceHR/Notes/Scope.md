
#		Scope
##		C	Chronic Incredibly Painful Agony Disease
Trait, lose 1 max hp every minute, permanently.
This would force you to finish within 1 hour-ish, unless you take an Endurance Up trait pick.
Another version with 2 max HP lost would force a speedrun pace.
I wouldn't play these myself but a lot of people would.
##		C	Cortex Bomb
Pay $1500 to someone with the Heal interaction to remove it. It detonates in 20 minutes.
##		C	Permanent Status Effects
These are oldish notes from CCU, but new enough to work with

|Trait												|CCPV	|Effect													|
|:--------------------------------------------------|------:|:------------------------------------------------------|
|Above the Laws										|32		|- Above the Law
|Bulletproofish										|8		|- Resist Bullets<br>- Bullet damage divided by 1.25
|Conductive											|10		|- Electro Touch
|Critter Hitter										|16		|- Always Crit
|Desecondive										|-32	|- Shrunken
|Dying												|-32	|- Poisoned
|Enfastened											|10		|- Fast
|Enstrongened										|16		|- Strength
|Even Shootier										|4		|- Accuracy<br>
|Gigantic											|100	|- Giant
|Invisibility Enjoyer								|100	|- Invisible
|Killer Throwerer									|32		|- Killer Thrower
|Lucky Duck											|7		|- Feelin' Lucky
|LyCANthrope										|32		|- Werewolf
|Ragestart											|-32	|- Enraged
|Regenerationist									|32		|- Regeneration
|Slothful											|-6		|- Slow
|Strong Immune System								|16		|- Stable System
|The Invincibility Gambit							|100	|- Invincible
|Thick Skin											|12		|- Resist Damage (Small)<br>- Damage divided by 1.25
|Thicker Skin										|24		|- Resist Damage (Medium)<br>- Damage divided by 1.5
|Thickest Skin										|36		|- Resist Damage (Large)<br>- Damage divided by 2
|Thickester Skin									|48		|- Numb to Pain<br>- Damage divided by 3
|Undying											|100	|- Resurrection
|Unlucky Duck										|-1		|- Feelin' Unlucky
####			C	General Issues
#####				C	Clone didn't keep SE
Elevator level transition
Clone Machine, Friend Phone and Loneliness Killer all lose Invisibility on moving to next level.
Trait list is fully intact
I think the trail is pointing to HireUnofficially, which spawns to party without party limit.
#####				C   Antidote
Left Gigantic intact at least, but verify there's not a limited list it can work on
#####				C   Toilet
Left Gigantic intact at least, but verify there's not a limited list it can work on
#####				C   Block UseItem Effects
Gigantizer if you're giant, e.g.
	This one in particular just wastes it. I'd like to prevent wasting the item.
#####				C   Opposite Effects
Shrinker if you're giant, e.g. Untested
####			C	Above the Laws
#####				C	Block Bribe Interaction
Might be automatic
####			C   Bulletproofish
Works I guess
#####				C	Block Equip Bulletproof Vest
Might be automatic
####			C   Conductive
New
####			C   Critter Hitter
Rename Literally Critler
####			C   Dying
Says Poisoned in SE, does that matter?
####			C   Enfastened
Works
####			C   Enstrongened
Works, but what's the cap?
####			C	Invisibility Enjoyer
E_ text in char sheet
####			C   Killer Throwerer
Works
####			C   Lucky Duck
Verify numerically
####			C   LyCANthrope
Doesn't transform
Just puts a number 2 above head
####			C   Popular
DW, you wanted to make a trait group anyway so just remove it
####			C   Ragestart
Might need to tell to attack neutrals, although this version is pretty interesting
####			C   Regenerationistest
E_RegenerateHealthFaster
Remove
####			C   Shrunk
Works
####			C   Slothful
Works, find caps
####			C   Stablemaster
Yeah I don't care to test this one
####			C   Invincibility Strategy
Sure yeah fine
####			C   Thick Skin
Test
####			C   Thicker Skin
Test
####			C   Thickest Skin
Seems to work
####			C   Unlucky Duck
Verify numerically
##		C	Pull Hydrosensitive from CCU
Player Traits/Passive?
##		C	replaceCopWithGangbanger
Already in the code, just vary it up. Might be better for SORCE.
##		C	Time to do Superclass
The reason: You need a hook to track a "true agent name" for trait interfacing:
- Allows Class Solidarity to actually matter for custom characters
- option Unique: Friend Phone and Loneliness Killer spawns are the subclass instead of your custom class. E.g., you're the Police Chief so it'd make sense to get a Cop instead of a second Chief.
- option French Vanilla Agent: Agent occasionally replaces vanilla spawns of the subclass type. I'm gonna put bright red disclaimers in here: This should ONLY be used for agents who are broadly-applicable enough to replace ALL spawns of the vanilla agent type. So an Evidence Tech is a type of cop, but they wouldn't make sense walking a street patrol beat. I could get all crazy with a trait list for chunk type and default behavior filters, but I think the interface is pretty unweildy already.
- Tactician/Subcontractor system
- Automatic Prisoner join
  - CL: And I'm pretty sure the only auto-joining prisoners are kidnap quests and faction allies like gangsters and gorillas. Don't think it's universal to all factions either, like soldiers and mobsters wouldn't join up as far as I can remember, so it probably is hardcoded to the NPCs that can actually spawn in vanilla prisons.
- From uwuMac: 
  - Subclass Residency traits: by default a subclass can spawn in any enviroment. but will only spawn in these enviroments if one or more Subclasss Residency category traits are selected. EG: a char with SCR | Bar and SCR | Arena can only spawn in bars and arenas but on every floor, but SCR | Bar and SCR | Park allows them to only spawn on bars in park.
    - [Chunk Descriptor or Chunk Special]: character can only spawn in these chunks.
    - [District]: character can only spawn in these districts.
    - [Default Goal]: character can only spawn if the NPC has this default goal.
  - Subclass Owning traits: these follow the same "additive" principal as residency traits.
    - Ownful: character can only spawn if they are an owner and not a guard.
    - Ownless: character can only spawn if they don't own anything.
    - Apprentice Owner: character can only spawn as a guard.
    - Master Owner: character can only spawn if they are the chunk owner.
  - Misc traits:
    - Disastrous: character can only spawn on floors with disasters.
    - Deep District Dweller: character can only spawn on floors x-2 or x-3.
    - Groupie: replace every class of the type this character spawned as in a chunk as long as they meet the restrictions.
    - Special Delivery: character can replace agents summoned after the level loads (eg: supercop booth, summoning ghosts by breaking gravestones)
##		C	Vanilla upgrades
Nimbler Fingers: Instant operation
Medical Expert: Unlimited heals for companions
##		C	Powder Packer
Use "BulletsPassThroughObjects" to make this one more interesting.
Call it FMJ instead or something
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
Sociopath (-6): Your lack of empathy makes your gestures come off as lizardlike. You can't form Loyal or Friendly relationships.
Sociopath + (48?): As above, but Annoyed goes straight to Hostile. Boosts XP for murderhoboing, because that playstyle isn't too easy already. So this would have to be a really expensive upgrade. 
Trait where lighter becomes an equippable mini flamethrower. The flame particles are tiny, slow, come out one at a time, and don't go far. Each click has a chance not to fire, because it's a shitty lighter. Makes a little bit of noise either way.
	Picking up lighters now stacks into it, but each one has a random count from 0 to the max capacity, 100. Deals 1 damage. 
	Also lets you combine the lighter with armor/melee durability spray to make it work like a normal flamethrower for 50 shots
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