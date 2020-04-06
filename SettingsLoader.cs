// ReSharper disable UnusedMember.Global
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
            data.TryGetValue("suitName", ref Settings.suitName);

            var names = data.GetNode("Names");
            if (names is object)
            {
                names.TryGetValue("preserveOriginalNames", ref Settings.preserveOriginalNames);
                var veteranNames = names.GetNode("VETERANS");

                if (veteranNames is null) return;
                var jebediah = veteranNames.GetValue("Jebediah");
                var bill = veteranNames.GetValue("Bill");
                var bob = veteranNames.GetValue("Bob");
                var valentina = veteranNames.GetValue("Valentina");

                if (string.IsNullOrEmpty(jebediah) == false)
                    Settings.kerbalNames.Add("Jebediah", jebediah);
                if (string.IsNullOrEmpty(bill) == false)
                    Settings.kerbalNames.Add("Bill", bill);
                if (string.IsNullOrEmpty(bob) == false)
                    Settings.kerbalNames.Add("Bob", bob);
                if (string.IsNullOrEmpty(valentina) == false)
                    Settings.kerbalNames.Add("Valentina", valentina);
            }
        }
    }
}
