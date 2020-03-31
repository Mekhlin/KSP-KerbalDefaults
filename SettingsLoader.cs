using UnityEngine;

namespace KerbalDefaults
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    internal class SettingsLoader : MonoBehaviour
    {
        void OnDestroy()
        {
            var data = UserSettings.ConfigNode;
            Settings.suitName = data.GetValue("suitName");
        }
    }
}
