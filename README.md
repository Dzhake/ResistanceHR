#		Resistance HR
Congratulations on your new position in the Human Resources Department! We are reasonably excited to work with you! 

Below is the Recruit Assessment Worksheet, which will outline the procedures and regulations to follow during your employment.

Please note that you are not eligible for health coverage until you have been employed for 90 days. Try not to get mauled to death by a gorilla!

No, seriously. **Stay away from the West Garage.**

#		Resistance Chip Configuration
Our IT team has added some compliance measures to the Resistance Chip. Make sure you configure the chip before jamming it into the applicant's skull.

##			Compliance Settings
Ensure that your new recruits make the Resistance look good. We're the good guys, or we'll die covering things up to look that way!

|Mutator							|Notes	|
|:----------------------------------|:------|
|Alarm Avoider						|- Agent explodes if they set off an alarm.
|Conscience Configurator			|- Agent is subject to XP maluses for killing and stealing from innocents.
|Diligence Detector					|- Agent explodes if they fail their Big Quest.
|Discovery Disincentivizer			|- Agent explodes if they anger a quest chunk NPC.
|Retaliation Reducer				|- Agent explodes if they neutralize a quest chunk NPC.

#		Applicant Scoring
Analyze the traits of your prospective recruit according to the rubrics below. The Resistance has graded each of these traits with a Point Inference Value (PIV) that will help assess the Applicant's aptitude.

N.b.: Generally, "+" traits are not available to applicants and must be designated through the course of their tenure in the Resistance. They are still listed here in order to project Upgrade Machine costs. 

##			Inventory Management
An applicant's general handling of money and other assets will be a good clue as to their reliability. Generally, you can quickly assess how poor someone is by seeing if you can smell them when they walk in the door.

###				Asset Management

|Trait								|PIV	|Notes	|
|:----------------------------------|------:|:------|
|Liquidator							|	5	|- Agent sells 20% of their inventory between each level.<br>- Price factor 75%
|Liduidator +						|	10	|- Agent sells 40% of their inventory between each level.<br>- Price factor 100%
|Luggage Loser						|	-12	|- Agent loses their entire inventory between each level.
|Spendthrift						|	-4	|- Agent buys 1-3 items between each level.<br>- Price factor 100%<br>- Shortfall is added to Debt.
|Spendthrift +						|	8	|- Agent buys 2-4 items between each level.<br>- Price factor 80%<br>- Shortfall is added to Debt.

###				Financial Acumen

|Trait								|PIV	|Notes	|
|:----------------------------------|------:|:------|
|Index Funder						|	3	|- Agent's money accrues from 3% to 8% interest between each level.
|Lifestyle Creeper					|	-10	|- Agent loses 50% of their money in between each level.
|Lock & Loadout						|	16	|- Agent receives another Item Loadout between each level.
|Pocket Changer						|	-6	|- Agent loses $100 between each level.<br>- Shortfall is added to Debt.
|Venture Capitalist					|	7	|- Agent's money accrues from -100% to 100% interest between each level.
|Wastrel							|	-12	|- Agent loses all their money between each level.

##			Combat Skills
We hate to say it, but KILL KILL KILL! Combat skills are essential for most recruits not clever enough to think of other ways of doing things.

###				Enchanted Hands
Per new regulations: If the applicant's hands are glowing, do not shake their hand. Do an elbow-bump or something. If you get a demon haunting your hands, it can wreak all kinds of SHIT FUCK KILL MURDER MURDER SHIT MURDER mischief.

|Trait								|PIV	|Notes	|
|:----------------------------------|------:|:------|
|Cursed Fist						|      3|- Unarmed attacks can hit Ghosts<br>- Unarmed damage to all Mundane agents increased by 25%
|Cursed Fist +						|      5|- Unarmed & Melee attacks can hit Ghosts<br>- Unarmed & Melee damage to all Mundane agents increased by 50%<br>- Applies Unlucky status effect to non-Supernatural agents
|Spectral Palm						|	   3|- Unarmed attacks can hit Ghosts<br>- Unarmed damage to all Supernatural agents increased by 50%
|Spectral Palm +					|	   5|- Unarmed & Melee attacks can hit Ghosts<br>- Unarmed & Melee damage to all Supernatural agents increased by 100%

###				Ranged Combat
This section designates an applicant as "Extra-Shooty."

####				Firearm Modification
Guns are cool! Pew pew!

|Trait								|PIV	|Damage	|Distance	|Penetration	|Speed	|
|:----------------------------------|------:|------:|----------:|--------------:|------:|
|Dum-Dum Bum						|	   4| + 15 %|     - 25 %|         - 10 %| - 10 %|
|Dum-Dum Bum +						|      8| + 30 %|     - 50 %|         - 20 %| - 20 %|
|Powder Packer						|      4| - 10 %|     + 20 %|		  + 50 %| + 10 %|
|Powder Packer +					|	   8| - 15 %|     + 40 %|        + 100 %| + 20 %|

###				Skills
|Sniper								|      4|- Past a certain distance, Revolver hits deal massive damage<br>- Minimum range for a sniper hit is lower on unaware targets
|Sniper +							|      8|- Using a silent ranged weapon from behind a Bush or other object will not remove you from concealment
|Wetworker							|      8|- Bullet attacks from behind within melee range do 2x damage. 10x if you're invisible or hidden.

##			Special Accommodations
When issuing equipment to an applicant, please take note of their personal restrictions and preferences. If they check any of the following boxes, note that the applicant is gonna be a real pain in the ass to deal with.

|Trait								|PIV	|Effects|
|:----------------------------------|------:|:------|
|Afraid of Loud Noises				|	 - 4|- Can't use Loud
|Carnivore							|	 - 1|- Can't use Vegetarian
|DAREdevil							|    - 3|- Can't use Drugs
|Draw No Blood						|    - 5|- Can't use Piercing
|Fat Head							|    - 1|- Can't use Headgear
|Friend of Bill						|    - 1|- Can't use Alcohol
|Surgical Striker					|    - 3|- Can't use Blunt
|Sweaty Fingers						|    - 3|- Can't use Melee
|Teetotaller						|    - 4|- Can't use Alcohol or Drugs
|Vegetarian							|    - 1|- Can't use Non-Vegetarian
|Weak Wrists						|    - 4|- Can't use Heavy

> Use the following lists when filling out equipment allocations:
>	- [Item Categories](ResistanceHR/Localization/VItem.cs#L191)
>	- [Item Types](ResistanceHR/Localization/VItemType.cs)

##			Luck
In the Resistance, we don't believe in luck! We believe in preparation. Now do your preparation by assessing the recruit's luck with a few games of craps.

|Trait								|PIV	|Luck Bonus	|
|:----------------------------------|------:|----------:|
|Charmed							|	3	|5
|Charmed +							|	5	|10
|Cursed								|	-1	|- 25 %

##			Psychometrics
Use your Resistance-issued calipers to assess the shape of your applicant's skull. There's no minimum IQ to join, it's just fun!

|Trait								|PIV	|XP Gain Rate	|
|:----------------------------------|------:|--------------:|
|Brainiac							|	  40|400 %
|Dim Bulb							|	 -10|75 %
|Moron the Merrier					|	 -20|50 %
|Numskulled							|    -30|25 %
|Smooth-Brained						|	 -40|0 %


###				Ethical Alignment

|Trait								|PIV	|Effects	|
|:----------------------------------|------:|----------:|
|Conscientious						|	 - 6|- Agent is subject to XP maluses for wronging the innocent.

###				Learning Aptitude

##			Social

###				Reputation

####				Class-Based Reputations
Do some research to assess the applicant's reputation around town. 

*N.B.: The NPC Reputations Mutator adds these classes to NPCs and gives them relationships with other NPCs.*

|Trait								|PIV	|Notes
|:----------------------------------|------:|
|Badass								|		|- Badasses Friendly<br>- Lameasses Annoyed
|Badass +							|		|- Badasses Loyal<br>- Lameasses Hostile<br>- Bonus XP for neutralizing Lameasses
|Deadass							|		|- Deadasses Friendly<br>- Werewolves Annoyed
|Deadass +							|		|- Deadasses Loyal<br>- Werewolves Hostile<br>- Bonus XP for neutralizing Werewolves
|Dumbass							|		|- Dumbasses Friendly<br>- Smartasses Annoyed
|Dumbass +							|		|- Dumbasses Loyal<br>- Smartasses Hostile<br>- Bonus XP for neutralizing Smartasses
|Hardass							|		|- Slaves Submissive<br>- Slavemasters Friendly<br>- Bonus XP for neutralizing Slavemasters
|Hardass +							|		|- Slaves Submissive<br>- Slavemasters Hostile<br>- Bonus XP for neutralizing Slaves & Slavemasters
|Kissass							|		|- Law Enforcers Friendly<br>- Punkasses Annoyed
|Kissass +							|		|- Law Enforcers Loyal<br>- Slavemasters Friendly<br>- Punkasses Hostile<br>- Bonus XP for neutralizing Affiliated Punkasses
|Lameass							|		|- Lameasses Friendly<br>- Badasses Annoyed
|Lameass +							|		|- Lameasses Loyal<br>- Badasses Hostile<br>- Bonus XP for neutralizing Badasses
|Punkass							|		|- Punkasses Friendly<br>- Law Enforcers Annoyed
|Punkass +							|		|- Unaffiliated Punkasses Loyal<br>- Affiliated Punkasses Friendly<br>- Law Enforcers Hostile<br>- Bonus XP for neutralizing Law Enforcers
|Smartass							|		|- Smartasses Friendly<br>- Dumbasses Annoyed
|Smartass +							|		|- Smartasses Loyal<br>- Dumbasses Hostile<br>- Bonus XP for neutralizing Dumbasses
|Underclass							|		|- Underclass Friendly<br>- Upperclass Annoyed
|Underclass +						|		|- Underclass Loyal<br>- Upperclass Hostile<br>- Bonus XP for neutralizing Upperclass
|Upperclass							|		|- Upperclass Friendly<br>- Underclass Annoyed
|Upperclass +						|		|- Upperclass Loyal<br>- Law Enforcers Friendly<br>- Underclass Hostile<br>- Bonux XP for neutralizing Underclass
|Xenophile							|		|- Non-Humans Friendly
|Xenophile +						|		|- Non-Humans Loyal<br>- Humans Annoyed<br>- Bonus XP for neutralizing Humans
|Xenophobe							|		|- Non-Humans Hostile<br>- Bonus XP for neutralizing Non-Humans

|Agent Group						|Member Classes		|
|:----------------------------------|:------------------|
|Badass								|
|Deadass							|
|Dumbass							|Gorilla, Jock, Soldier, Wrestler
|Lameass
|Punkass(Affiliated)				|Blahd, Crepe, Mobster
|Punkass (Unaffiliated)				|Drug Dealer, Thief
|Smartass							|Comedian, Hacker, Office Drone, Scientist
|Underclass							|Office Drone, Slave, Slum Dweller, Worker
|Upperclass							|Doctor, Investment Banker, Shopkeeper, Slavemaster, Upper Cruster

|Drones								|Courier, Clerk, Office Drone, Worker
|Law Enforcers						|Cop, Cop Bot, Supercop
|Non-Humans							|Alien, CopBot, Ghost, Gorilla, Robot, Shapeshifter, Vampire, Werewolf, Zombie

####				General Reputations

|Combative
|Combative +
|Polarizing
|Polarizing +

##			Spawns

###				Bodyguards
The applicant has brought his friends to the interview. You can tell them to leave, but I'm not gonna.

|Trait								|PIV	|Class		|Spawns	|
|:----------------------------------|------:|:----------|------:|
|Backed by the Blue					|12		|Cop		|1
|Backed by the Blue +				|20		|Supercop	|1
|Friend of Monke					|12		|Gorilla	|1
|Friend of Monke +					|20		|Gorilla	|2
|Gooned Up							|7		|Goon		|1
|Gooned Up +						|10		|Supergoon	|1
|Mobbed Up							|10		|Mobster	|1
|Mobbed Up +						|16		|Mobster	|2
|Rollin' Deep						|7		|Crepe		|1
|Rollin' Deep +						|12		|Crepe		|2
|Thicker than Water					|7		|Blahd		|1
|Thicker Than Water +				|12		|Blahd		|2

###				Roamers
The applicant has made special friends around the city.

CL = Current Level (Normally, 1 - 15)

CD = Current District (0 = Slums, 5 = Mayor Village)

|Trait								|PIV	|Class			|Spawns			|Relationship	|Notes
|:----------------------------------|------:|:--------------|--------------:|:--------------|
|Guild Network						|7		|Thief			|3				|Friendly
|Guild Network +					|12		|Thief			|3				|Loyal
|Hacker Network						|7		|Hacker			|3				|Friendly
|Hacker Network +					|12		|Hacker			|3				|Loyal
|Haunted							|-6		|Ghost			|CL + 1			|Hostile		|Speed boost
|Hitlisted							|-6		|Assassin		|(CL > 5)		|Hostile		|Invisible
|Loansharked						|-8		|Mobster		|(CL > 5) * 1.5 |Hostile
|Mook Masher						|-8		|Goon			|CL * 2			|Hostile
|Most Wanted						|-12	|Task Force		|(CD + 1) * 3	|Hostile		|A Task Force is 1 Supercop + 2 Cops.
|Reinforced							|5		|Res. Leader	|CL / 2			|Aligned
|Reinforced +						|10		|Res. Leader	|CL / 2			|Aligned		|Improves equipment
|Return to Eneme					|-10	|Gorilla		|(CD + 1) * 3	|Hostile
|Robait								|-10	|Killer Robot	|1				|Hostile
|Robotnip							|-16	|Killer Robot	|3				|Hostile

##			Visual Acuity
|Trait								|PIV	|Notes	|
|:----------------------------------|------:|:------|
|Eagle Eyes							|      3|- Visual range increased
|Eagle Eyes +						|      6|- Visual range greatly increased
|Myopic								|    - 6|- Visual range reduced
|Myopic +							|   - 12|- Visual range greatly reduced