#		How to read this
If you wandered in here out of curiosity, this is my working notes file, and completed/planned feature list. It's in Markdown, but best viewed in raw form since a lot of its organization has to do with text characters' alignment.

Listed in order of Parent tier summary symbol priority:
	C, T = Code this, Test this
	H = Hold, usually pending resolution of a separate or grouped issue
	√ = Fully implemented feature or group of features
#       Bugs
##          C   Freeze on 37%
shrug
#		Scope
#		Traits
Dissociated: HP bar always says ??/??, damage you take is hidden
No Taste: Half healing from consumables
No Smell: Status effects are always unknown, reduces Rogue Vision cone slightly
##		C	Close Combat
###			C	Enchanted Hands
####			C	Monkey Paws / +
#####               C   Unlucky on Hit
#####               C   Lose at gambling
#####               C   Fail at disarm
#####               C   Hit luck 0
Kneecapper, etc.
#####               C   Extra healing from bananas
#####               C   Banana Peels turn into explosives?
#####               √   Hit Ghosts
#####               √   Bonus damage to non-supernatural
####			C	Flaming Hands / +
#####               C   Cook Fud on pickup
#####               C   Ignite on hit
#####               C   Ignite on object interact
#####               C   Flaming wooden weapons
#####               C   1 damage everytime you use your pockets
####            C   Icy Wrists
I ran out of hand stuff! Lay off!
#####               C   Short freeze on hit
#####               C   Minifridge effect
#####               C   Brainfreeze when eating (Slow)
####            C   Lightnin' Fingers / +
#####               C   Short stun on hit
#####               C   Mess with electronics
#####               C   Electrified metal weapons
####			C	Spectral Palms / +
#####               C   Something to do with Gravestones?
#####               √   Hit Ghosts
#####               √   Bonus damage to supernatural
####            C   Stone Fists / +
#####               C   Slower swing
#####               C   Bigger hand sprite
#####               C   More damage in general
#####               C   Fumble small weapons
#####               C   Lockpicks ain't happening
####			C	Venomous Claws / +
#####               C   Poison Food
#####               C   Poison on hit
#####               C   Chloroform kills
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
##          C   Social
###             C   Odoriferous
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
###			T	Myopic / +
##      C   Voting
###         C   Fragile Egomaniac
Voting increases are doubled
But voting decreases are tripled
People get Annoyed or Hostile at you a bit easier
###         C   Campaign Donations
Gain $ for each vote at end of level
Counts for negatives too, don't fuck it up!
###         C   Milquetoast
Can't lose votes, but gain at half rate
People get angry at you slower
##		√	Experience Rate
###			√	Brainiac
###			√	Dim Bulb
###			√	Moron the Merrier
###			√	Smooth-Brained