using System.Linq;
using UnityEngine;

namespace KerbalDefaults
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    internal class UserSettings : MonoBehaviour
    {
        static string nodeName = "KERBAL_DEFAULTS";

        internal static ConfigNode ConfigNode => GameDatabase.Instance?.GetConfigs(nodeName)?.FirstOrDefault()?.config;
    }
}
