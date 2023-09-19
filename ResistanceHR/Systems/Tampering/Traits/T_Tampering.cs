using Google2u;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace ResistanceHR.Tampering
{
	internal abstract class T_Tampering : T_RHR
	{
		public override void OnAdded() { }
		public override void OnRemoved() { }

		[RLSetup]
		internal static void Start()
		{
			InitializeNames();
		}
		internal static void InitializeNames()
		{
			string t = VNameType.Dialogue;
			RogueLibs.CreateCustomName(FlamingBarrelCookDamage, t, new CustomNameInfo("Ow! Fuck!"));
			RogueLibs.CreateCustomName(FlamingBarrelCookNoDamage, t, new CustomNameInfo("Mmmm, toasty. Just like the burning flesh on my fingers!"));
			RogueLibs.CreateCustomName(MachineBusy, t, new CustomNameInfo("It's busy doing... machine things."));
			RogueLibs.CreateCustomName(SlotMachineJackpot_1, t, new CustomNameInfo("Chauvelin Automated Vice, Inc. presents: Jackpot!"));
			RogueLibs.CreateCustomName(SlotMachineJackpot_2, t, new CustomNameInfo("Winner Winner, Chicken Dinner!"));
			RogueLibs.CreateCustomName(SlotMachineJackpot_3, t, new CustomNameInfo("NOTE: You are not actually winning a Chicken Dinner, it's an expression."));
			RogueLibs.CreateCustomName(SlotMachineJackpot_4, t, new CustomNameInfo("Yep... still going."));
			RogueLibs.CreateCustomName(SlotMachineJackpot_5, t, new CustomNameInfo("Jackpot. Happy for ya."));

			t = VNameType.Interface;
			RogueLibs.CreateCustomName(DispenseIce, t, new CustomNameInfo("Dispense ice"));
			RogueLibs.CreateCustomName(HideInContainer, t, new CustomNameInfo("Hide inside"));
			RogueLibs.CreateCustomName(OpenContainer, t, new CustomNameInfo("Open container"));
			RogueLibs.CreateCustomName(SlotMachineHackJackpot, t, new CustomNameInfo("Penny-Slot Jackpot Promotion"));
			RogueLibs.CreateCustomName(SlotMachinePlay1, t, new CustomNameInfo("Play"));
			RogueLibs.CreateCustomName(SlotMachinePlay100, t, new CustomNameInfo("Play"));
		}

		public const string
			// Dialogue
			FlamingBarrelCookDamage = "FlamingBarrelCookDamage",
			FlamingBarrelCookNoDamage = "FlamingBarrelCookNoDamage",
			MachineBusy = "MachineBusy",
			SlotMachineJackpot_ = "SlotMachineJackpot_", // For concatenation into following
				SlotMachineJackpot_1 = "SlotMachineJackpot_1",
				SlotMachineJackpot_2 = "SlotMachineJackpot_2",
				SlotMachineJackpot_3 = "SlotMachineJackpot_3",
				SlotMachineJackpot_4 = "SlotMachineJackpot_4",
				SlotMachineJackpot_5 = "SlotMachineJackpot_5",

			// Interface
			DispenseIce = "DispenseIce",
			GrillFudPaid = "GrillFudPaid",
			HideInContainer = "HideInContainer",
			OpenContainer = "OpenContainer",
			SlotMachineHackJackpot = "SlotMachineHackJackpot",
			SlotMachinePlay1 = "Play1",
			SlotMachinePlay100 = "Play100",

			z = "";

		internal static readonly List<string> AxeTamperButtonNames = new List<string>()
		{
			// Weak walls: Wood, Hedge
		};
		internal static readonly List<string> CrowbarTamperButtonNames = new List<string>()
		{
			nameof(InterfaceNameDB.rowIds.UseCrowbar),
		};
		internal static readonly List<string> PowerDrillTamperButtonNames = new List<string>()
		{
			// Drill holes to drain oil (Generators, NOT stove)
		};
		internal static readonly List<string> PowerSawTamperButtonNames = new List<string>()
		{
			// Weak walls: Wood, Hedge
			// Wooden doors
		};
		internal static readonly List<string> SledgehammerTamperButtonNames = new List<string>()
		{
			// Weak walls: Most
			// Metal doors
		};
		internal static readonly List<string> WireCutterTamperButtonNames = new List<string>()
		{
			// Security Cam
			// Barbed Wire
		};
		internal static readonly List<string> WrenchTamperButtonNames = new List<string>()
		{
			nameof(InterfaceNameDB.rowIds.RemoveHelmetWrench),
			nameof(InterfaceNameDB.rowIds.UseWrenchToAdjustSatellite),
			nameof(InterfaceNameDB.rowIds.UseWrenchToDeactivate),
			nameof(InterfaceNameDB.rowIds.UseWrenchToDetonate),
		};

		internal static readonly List<string> AllTamperButtonNames = 
			AxeTamperButtonNames
			.Concat(CrowbarTamperButtonNames)
			.Concat(PowerDrillTamperButtonNames)
			.Concat(PowerSawTamperButtonNames)
			.Concat(SledgehammerTamperButtonNames)
			.Concat(WireCutterTamperButtonNames)
			.Concat(WrenchTamperButtonNames)
			.ToList();
	}
}