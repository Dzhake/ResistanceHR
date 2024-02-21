using RogueLibsCore;

namespace RHR.Systems.Equipment_Certifications.Objects
{
	public class Container_RemoveImplicitWhenEmpty
	{
		//[RLSetup]
		public static void Setup()
		{
			RogueInteractions.CreateProvider(h =>
			{
				if (h.Object is ObjectReal && h.Object.hasSpecialInvDatabase && !h.Helper.interactingFar && h.Object.specialInvDatabase.isEmpty() && h.HasButton("ContainerOpen"))
				{ 
					h.RemoveButton("ContainerOpen");
				}
			});
		}
	}
}