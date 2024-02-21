using RogueLibsCore;

namespace RHR.Body
{
	public class Body_Size_Variation : M_RHR
	{
		public Body_Size_Variation(string name, bool unlockedFromStart) : base(name, unlockedFromStart) { }

		[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new Body_Size_Variation(nameof(Body_Size_Variation), true))
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Vanilla agents generate with body size variations.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Body_Size_Variation)),
				});
		}
	}
}
