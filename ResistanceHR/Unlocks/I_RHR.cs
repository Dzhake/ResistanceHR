using BepInEx.Logging;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class I_RHR : CustomItem
{
	public static readonly ManualLogSource logger = BLLogger.GetLogger();
	public static GameController GC => GameController.gameController;

	public override void SetupDetails() { }
}