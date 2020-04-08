using UnityEngine;
// ReSharper disable UnusedMember.Global

namespace KerbalDefaults
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    internal class SettingsLoader : MonoBehaviour
    {
        public void OnDestroy()
        {
            var data = UserSettings.ConfigNode;
            Settings.SuitName = data.GetValue("suitName");
            data.TryGetValue("suitName", ref Settings.SuitName);

            var names = data.GetNode("Names");
            if (names is object)
            {
                if( names.HasValue("preserveOriginalNames"))
                {
                    names.TryGetValue("preserveOriginalNames", ref Settings.PreserveOriginalNames);
                }
                var veteranNames = names.GetNode("VETERANS");
                if (veteranNames is null) return;

                var jebediah = veteranNames.GetValue("Jebediah");
                var bill = veteranNames.GetValue("Bill");
                var bob = veteranNames.GetValue("Bob");
                var valentina = veteranNames.GetValue("Valentina");

                if (string.IsNullOrEmpty(jebediah) == false)
                    Settings.KerbalNames.Add("Jebediah", jebediah);
                if (string.IsNullOrEmpty(bill) == false)
                    Settings.KerbalNames.Add("Bill", bill);
                if (string.IsNullOrEmpty(bob) == false)
                    Settings.KerbalNames.Add("Bob", bob);
                if (string.IsNullOrEmpty(valentina) == false)
                    Settings.KerbalNames.Add("Valentina", valentina);
            }
        }
    }
}
