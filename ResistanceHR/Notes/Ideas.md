#		Idea Dump
##			Loadout limitation
Agent can only use weapons included in:
- Their loadout (Extreme?)
- Thematically curated sets:
  - Cop stuff
  - Soldier stuff
  - etc.
  - These could also be used in Smuggler traits, and possibly other sets.
##			Rubber Bullet
Occasional Dizzy/Knockdown + Neutral/Annoyed instead of knockout
##			Angel Investor
Spawns an aligned chunk with a Goon mission on each level.
+ version of trait will increase security level of spawned chunks.
##			Loansharking
Interact with various NPCs to loan money.
* Owing NPCs will appear on the next level.Use an existing spawn, or make a roamer.
* Loan cap and vig might be based on class and amount of property.
* Owing NPCs will:
		 *	- Panic and avoid
		 *	- Submissive on sight(Intimidation roll)
		 *	- Go hostile
		 *	- Be neutral until interaction, then roll Intimidation and do any of the above depending on result
		 *	- If they're in mortal terror, they may flee to the Up elevator. They'll appear in subsequent levels.They may show up in hospitals or hotels.
* You MIGHT be able to track loan status with InDebt1-3 Status Effects, if they don't do anything to NPCs normally.
##			Always be Closing
Good chance to improve relationship by knocking on doors
##			Job: Ignite
More expert jobs would be nice.
Assassin: Backstab
Athlete: Charge
Bartender: Chat, Serve Drink
Bouncer: Oust (Makes targeted NPCS annoy owners)
Cannibal: Do you even have to tell them?
Doctor: Revive
Firefighter: Ignite
Office Drone: Chat (Ruckus-length distraction directed at a single NPC. Chatted NPCs have reduced hearing)
Thief: Pickpocket
Worker: Tamper
##			Guilty Hires?
If you're a cop and hire a thief to do something illegal, does he turn guilty if you watch him do it?
##			Medical Professional +
You can consume a medkit to revive someone. Medkits are excluded from Quick-Health, so quickslot them.
##			Chase Scenes
Foot chases are a great action/heist movie trope. But they're kind of just a pain in the ass in SOR. NPCs are too easy to tether, and chasing a thief or shapeshifter is usually more annoying than interesting.

Pressing interact while approaching a fence, hole, trap, or obstacle will cause you to jump it or otherwise bypass it at the cost of some speed. If you catch up with someone climbing a fence, they are knocked off and tripped. 

Interacting with objects while moving triggers an "Implicit action" to borrow the term used in RogueLibs. You can interact with a trashcan, person or a cliche fruit cart without slowing down to tip them over and create an obstacle. Various obstacles can trip, snag, deal damage, etc. Interact with a follower to ask them to stay behind and fight... you asshole.

Fleeing NPCs will comply to arrest, enslavement, mugging, etc. at a similar health threshold to Extortion. Chasing NPCs will give up the chase if you manage to put enough distance between you. This would create an effective tether that feels like it has a reason rather than "I ran 2 chunks away again."

Trait: Parkour! - More running quick actions are available. Dive through windows, vault taller fences, etc.
Trait: Parkour! + - Gain a short burst of speed after bypassing an obstacle. Longer leap distance.
Trait: Bullheaded - You can simply charge through some obstacles, wooden doors, etc. at the cost of some health.
Trait: Slick - You can grab an item from containers while moving. 
##			Loanshark
Loan money to various NPC types.
They appear on the next level. Some will have the money, others won't. You basically have the Extortion dynamic to get your money plus a percentage. 
Some will panic and run when they see you.
##			Tactician Trait
Tactician (3?): If a hireable has same-class allies in the chunk, they have an option to "Hire Gang." Cost = (Base hire cost * Number of gang members * 0.9 bulk discount only for you my friend, special deal). When you hire them, the allies in the chunk become the followers of the hire, in total only occupying one of your follower slots. So they'll follow the orders you give to the gang leader, although I guess you can command them individually if you want(?). The suggested cost for this is really low because it'll be pretty expensive just to execute. 
Anyway, this would imply the possibility of campaigns designed around RTS-style group control. Maybe gang leaders have a longer tether than normal followers?
Tactician +: When a gang leader is killed, the gang normally disperses [This seems too harsh, ideas?]. With the + trait, their followers become yours. 
All non-leader followers ("second-tier followers?") have an option "Assign to Squad." Select it and click on any follower or leader NPC to make them join that squad. 
##			Ability Items
Handcuffs
Chloroform
Sticky Glove
Laptop w/ Mods
##			Old Dog
You can't remove traits
##			Loadout Syringe pack
- 3 randoms
- Full spread
##			Unarmed traits
Long Punge (long lunge for punch)
Three attacks in a row ends with a lunge attack
##			Random Reverence
Streets of Cheese:
	Connections traits, functions like Random Reverence but only for certain classes
	Underworld Connections: Thieves, Cannibals, Gangsters, Mobsters, Ghosts (ha ha)
	Official Connections: Cops, Supercops, Mobsters
	Wealthy Connections: Bankers, Upper-Crusters, Doctors
	Supernatural Connections: Vampires, Zombies, Werewolves, Shapeshifters, Ghosts, anyone with Zombiism trait (?)
	Low-Ranking Connections: Clerks, Office Drones, Slum Dwellers
	Combat Connections: Jocks, Gangsters, Soldiers, Gorillae
	Guard Connections: Goons, Supergoons, Bouncers
	Utility Connections: Hackers, Thieves, Workers
##			Blends in Poorly
New
##			By Any Means Necessary But Nothing Crazy
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
|Always Baton Red +					|Police Baton	|		|- Attack Speed +
|Axe-Pert							|Axe			|		|- Destroy Trees in one hit (maybe make trees harder to break normally)<br>- Wall Walloper effect for Hedge Walls
|Axe-Pert +							|Axe			|		|- Destroy Doors in one hit<br>- Swing arc size +<br>- Wall Walloper effect for Wooden walls
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