using RHR;
using RogueLibsCore;

namespace RHR.Body
{
	public class Body_Size_Variation_Visual : M_RHR
	{
		public Body_Size_Variation_Visual() : base(nameof(Body_Size_Variation_Visual), true) { }

		[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new Body_Size_Variation_Visual())
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Vanilla agents generate with body size variations, but does not apply the gameplay effects that accompany them.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Body_Size_Variation_Visual)),
				});
		}
	}
}