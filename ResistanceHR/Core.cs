using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ResistanceHR
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]
    public class Core : BaseUnityPlugin
    {
        public const string PluginGuid = "freiling87.streetsofrogue.resistancehr";
        public const string PluginName = "Resistance HR";
        public const string PluginVersion = "0.1.0";

        public const bool DebugMode = true;

        public static readonly ManualLogSource logger = RHRLogger.GetLogger();
        public static GameController GC => GameController.gameController;

        public void Awake()
        {
            LogMethodCall();

            new Harmony(PluginGuid).PatchAll();
            RogueLibs.LoadFromAssembly();
        }
        public static void LogCheckpoint(string note, [CallerMemberName] string callerName = "") =>
            logger.LogInfo(callerName + ": " + note);
        public static void LogMethodCall([CallerMemberName] string callerName = "") =>
            logger.LogInfo(callerName + ": Method Call");
    }

    public static class RHRLogger
    {
        private static string GetLoggerName(Type containingClass)
        {
            return $"RHR_{containingClass.Name}";
        }

        public static ManualLogSource GetLogger()
        {
            Type containingClass = new StackFrame(1, false).GetMethod().ReflectedType;
            return Logger.CreateLogSource(GetLoggerName(containingClass));
        }
    }
}
