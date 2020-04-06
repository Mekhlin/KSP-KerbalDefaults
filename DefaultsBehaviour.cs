// ReSharper disable UnusedMember.Global
using UnityEngine;

namespace KerbalDefaults
{
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    internal class DefaultsBehaviour : MonoBehaviour
    {
        public void Start()
        {
            GameEvents.onKerbalAdded.Remove(OnKerbalAdded);
            GameEvents.onKerbalAdded.Add(OnKerbalAdded);
        }

        public void Destroy()
        {
            GameEvents.onKerbalAdded.Remove(OnKerbalAdded);
        }

        private void OnKerbalAdded(ProtoCrewMember kerbal)
        {
            if (Settings.preserveOriginalNames == false)
            {
                DefaultNames.ApplyName(kerbal);
            }
            DefaultSuit.ApplySuit(kerbal);
        }
    }
}
