using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using BunnyLibs;
using Google2u;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace RHR.Tampering
{
	public class Tampering
	{
		[RLSetup]
		public static void Start()
		{
			InitializeNames();
		}
		public static void InitializeNames()
		{
			string t = NameTypes.Dialogue;
			RogueLibs.CreateCustomName(FlamingBarrel_CookDamage, t, new CustomNameInfo {
				[LanguageCode.English] = "Ow! Fuck!",
			});
			RogueLibs.CreateCustomName(FlamingBarrel_CookNoDamage, t, new CustomNameInfo {
				[LanguageCode.English] = "Mmmm, toasty. Just like the burning flesh on my fingers!",
			});

			t = NameTypes.Interface;
			//	Button Text
			RogueLibs.CreateCustomName(ObjectReal_HideInContainer, t, new CustomNameInfo {
				[LanguageCode.English] = "Hide inside",
			});
			RogueLibs.CreateCustomName(ObjectReal_OpenContainer, t, new CustomNameInfo {
				[LanguageCode.English] = "Open container",
			});
		}

		public const string
			//	Dialogue
			FlamingBarrel_CookDamage = "FlamingBarrel_CookDamage",
			FlamingBarrel_CookNoDamage = "FlamingBarrel_CookNoDamage",
			FlamingBarrel_GrillFud = "FlamingBarrel_GrillFud",

			//	Interface
			//		Button Text
			ObjectReal_HideInContainer = "HideInContainer",
			ObjectReal_OpenContainer = "OpenContainer",
			//		Operating Text
			FlamingBarrel_GrillingFud = "FlamingBarrel_GrillingFud",
			TamperingText = "Tampering",

			z = "";

		public static readonly List<string> AxeTamperButtonNames = new List<string>()
		{
			// Weak walls: Wood, Hedge
		};
		public static readonly List<string> CrowbarTamperButtonNames = new List<string>()
		{
			nameof(InterfaceNameDB.rowIds.UseCrowbar),
		};
		public static readonly List<string> PowerDrillTamperButtonNames = new List<string>()
		{
			// Drill holes to drain oil (Generators, NOT stove)
		};
		public static readonly List<string> PowerSawTamperButtonNames = new List<string>()
		{
			// Weak walls: Wood, Hedge
			// Wooden doors
		};
		public static readonly List<string> SledgehammerTamperButtonNames = new List<string>()
		{
			// Weak walls: Most
			// Metal doors
		};
		public static readonly List<string> WireCutterTamperButtonNames = new List<string>()
		{
			// Security Cam
			// Barbed Wire
		};
		public static readonly List<string> WrenchTamperButtonNames = new List<string>()
		{
			nameof(InterfaceNameDB.rowIds.RemoveHelmetWrench),
			nameof(InterfaceNameDB.rowIds.UseWrenchToAdjustSatellite),
			nameof(InterfaceNameDB.rowIds.UseWrenchToDeactivate),
			nameof(InterfaceNameDB.rowIds.UseWrenchToDetonate),
		};

		public static readonly List<string> AllTamperButtonNames =
			AxeTamperButtonNames
			.Concat(CrowbarTamperButtonNames)
			.Concat(PowerDrillTamperButtonNames)
			.Concat(PowerSawTamperButtonNames)
			.Concat(SledgehammerTamperButtonNames)
			.Concat(WireCutterTamperButtonNames)
			.Concat(WrenchTamperButtonNames)
			.ToList();
	}

	[HarmonyPatch(typeof(ObjectReal))]
	public static class P_ObjectReal_TamperObject
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(ObjectReal.DetermineButtons))]
		private static void DetermineButtons(ObjectReal __instance)
		{
			string newLabel = "";
			T_ToolCost trait = __instance.interactingAgent?.GetTraits<T_ToolCost>().FirstOrDefault() ?? null; // Hopefully eliminates an NRE

			if (!(trait is null))
			{
				foreach (string buttonLabel in __instance.buttonsExtra)
				{
					if (buttonLabel.EndsWith("-30"))
						newLabel = buttonLabel.Replace("-30", "-" + trait.NewToolCost(30));
					else if (buttonLabel.EndsWith("-20"))
						newLabel = buttonLabel.Replace("-20", "-" + trait.NewToolCost(20));
					// Use in their own postfixes.
					//else if (buttonLabel == " - 15HP")
					//	newLabel = buttonLabel.Replace(" - 15HP", " - " + BMTraitController.HealthCost(objectReal.interactingAgent, 15, DamageType.brokenWindow));
					//else if (buttonLabel.EndsWith("(Burn hands for 10 damage)"))
					//	newLabel = buttonLabel.Replace("(Burn hands for 10 damage)",
					//			"(Burn hands for " + BMTraitController.HealthCost(objectReal.interactingAgent, 10, DamageType.burnedFingers) + " damage)");
					else
						continue;

					__instance.buttonsExtra[__instance.buttonsExtra.FindIndex(i => i == buttonLabel)] = newLabel;
					break;
				}
			}
		}

		[HarmonyTranspiler, HarmonyPatch(nameof(ObjectReal.FinishedOperating))]
		private static IEnumerable<CodeInstruction> FinishOperating(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo interactingAgent = AccessTools.DeclaredField(typeof(PlayfieldObject), nameof(PlayfieldObject.interactingAgent));
			MethodInfo customMethod = AccessTools.DeclaredMethod(typeof(P_ObjectReal_TamperObject), nameof(P_ObjectReal_TamperObject.FinishedOperating));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Call, customMethod),
				},
				postfixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, interactingAgent)
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
		public static void FinishedOperating(ObjectReal objectReal)
		{
			switch (objectReal.operatingBarType)
			{
				case GrillFud.GrillingFud:
					GrillFud.FinishedOperating((Stove)objectReal);
					break;
			}

			//objectReal.interactingAgent.StopInteraction();
			//objectReal.StopInteraction();
			//objectReal.interactingAgent.FinishedOperating();
			//objectReal.FinishedOperating();
		}
	}
}
