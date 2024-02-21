using BepInEx.Logging;
using BunnyLibs;
using RHR.Loot;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ResistanceHR.Documentation
{
	internal class DocGen
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		private static readonly List<Type> TraitGroups = new List<Type>()
		{
			typeof(T_Smuggler),
		};

		//[RLSetup]
		private static void GenerateDocTables()
		{
			GenerateMutatorTables();
			GenerateTraitTables();
		}

		private static void GenerateMutatorTables()
		{

		}

		private static void GenerateTraitTables()
		{
			string table = "";

			foreach (Type traitGroup in TraitGroups)
			{
				foreach (Type trait in InterfaceHelper.TypesImplementingInterface(traitGroup))
				{
					if (trait.IsAbstract || trait.IsInterface)
						continue;

					object traitInstance = Activator.CreateInstance(trait);
					var metadata = CustomTraitMetadata.Get(trait);
					TraitUnlock traitUnlock = RogueLibs.GetUnlock<TraitUnlock>(metadata.Name);

					string displayName = traitUnlock.GetName();
					int ccpv = traitUnlock.Unlock.cost3;
					string notes = traitUnlock.GetDescription();
					
				}
			}

			logger.LogInfo(table);
		}
	}
}
