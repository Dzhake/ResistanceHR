using RogueLibsCore;

namespace ResistanceHR.Interaction
{
	internal class T_Interaction : T_RHR
	{
		public override void OnAdded() { }
		public override void OnRemoved() { }

		internal const string SnitchOnSomeone = "SnitchOnSomeone";
		internal static Agent informee;

		[RLSetup]
		private static void Setup()
		{
			RogueLibs.CreateCustomName(SnitchOnSomeone, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Snitch",
			});

			RogueInteractions.CreateProvider<Agent>(h =>
			{
				informee = h.Object;
				Agent interactingAgent = h.Agent;

				if (interactingAgent.HasTrait<Snitch>() || interactingAgent.HasTrait<Snitch_Plus>())
				{
					h.AddButton(SnitchOnSomeone, m =>
					{
						informee.Say("Great job pressing a button!");
						informee.commander = interactingAgent;
						informee.commander.target.targetType = SnitchOnSomeone;
						interactingAgent.mainGUI.invInterface.ShowTarget(informee, SnitchOnSomeone);
					});
				}
			});
		}
	}
}