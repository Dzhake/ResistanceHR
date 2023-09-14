using RogueLibsCore;

namespace ResistanceHR.Localization
{
    public static class CNameDialogue
    {
        [RLSetup]
        public static void Setup()
        {
            string t = VNameType.Dialogue;
            RogueLibs.CreateCustomName(CantUseAlcohol1, t, new CustomNameInfo("Today, I choose not to drink."));
            RogueLibs.CreateCustomName(CantUseAlcohol2, t, new CustomNameInfo("I think I need to call my sponsor."));
            RogueLibs.CreateCustomName(CantUseAlcohol3, t, new CustomNameInfo("Thinkin' 'bout drinkin'... nah."));
            RogueLibs.CreateCustomName(CantUseArmor, t, new CustomNameInfo("I'm too fuckin' fat to wear this!"));
            RogueLibs.CreateCustomName(CantUseBlunt, t, new CustomNameInfo("Precise work requires a sharp tool."));
            RogueLibs.CreateCustomName(CantUseDrugs, t, new CustomNameInfo("Drugs are for bugs!"));
            RogueLibs.CreateCustomName(CantUseHeadgear, t, new CustomNameInfo("Owie! This is too tight for my big, fat, stupid, ugly head!"));
            RogueLibs.CreateCustomName(CantUseHeavy, t, new CustomNameInfo("With my dainty wrists? I don't think so."));
            RogueLibs.CreateCustomName(CantUseLoud, t, new CustomNameInfo("I can't use that! It's too loooooud.")); // Hardcoded to 1 choice in T_ItemRestrictions.CanUseItem
            RogueLibs.CreateCustomName(CantUseMelee, t, new CustomNameInfo("Oof, ah, um, yeah, heh. Not my thing. Sorry."));
            RogueLibs.CreateCustomName(CantUseMeat1, t, new CustomNameInfo("Meat is murder!"));
            RogueLibs.CreateCustomName(CantUseMeat2, t, new CustomNameInfo("Just... need... protein. So hungry."));
            RogueLibs.CreateCustomName(CantUseMeat3, t, new CustomNameInfo("I'm perfectly fine with just a salad. *Stomach grumbles*"));
            RogueLibs.CreateCustomName(CantUseNonAlcohol1, t, new CustomNameInfo("My hands are shakin'. I need some sauce in me!"));
            RogueLibs.CreateCustomName(CantUseNonAlcohol2, t, new CustomNameInfo("Nah, this hangover won't let me keep anything down."));
            RogueLibs.CreateCustomName(CantUseNonVegetarian, t, new CustomNameInfo("No! Me want meat!"));
            RogueLibs.CreateCustomName(CantUsePiercing1, t, new CustomNameInfo("Mommy says I can't use sharp things!"));
            RogueLibs.CreateCustomName(CantUsePiercing2, t, new CustomNameInfo("I swore to draw no blood... unless I remove this trait first."));
            RogueLibs.CreateCustomName(CantUseTeetotaller, t, new CustomNameInfo("Nope, my body is a temple!"));
        }

        public const string
            CantUseAlcohol1 = "CantUseAlcohol1",
            CantUseAlcohol2 = "CantUseAlcohol2",
            CantUseAlcohol3 = "CantUseAlcohol3",
            CantUseArmor = "CantUseArmor",
            CantUseBlunt = "CantUseBlunt",
            CantUseDrugs = "CantUseDrugs",
            CantUseHeadgear = "CantUseHeadgear",
            CantUseHeavy = "CantUseHeavy",
            CantUseLoud = "CantUseLoud",
            CantUseMelee = "CantUseMelee",
            CantUseMeat1 = "CantUseMeat1",
            CantUseMeat2 = "CantUseMeat2",
            CantUseMeat3 = "CantUseMeat3",
            CantUseNonAlcohol1 = "CantUseNonAlcohol1",
            CantUseNonAlcohol2 = "CantUseNonAlcohol2",
            CantUseNonVegetarian = "CantUseNonVegetarian",
            CantUsePiercing1 = "CantUsePiercing1",
            CantUsePiercing2 = "CantUsePiercing2",
            CantUseTeetotaller = "CantUseTeetotaller",
            CantUseVegetarian = "CantUseVegetarian",


            NoMoreSemicolon = "";
    }
}
