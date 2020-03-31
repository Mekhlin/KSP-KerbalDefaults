// ReSharper disable UnusedMember.Global

using System;
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
            if (Settings.suitName == "Default") return;

            var kerbalSuit = (ProtoCrewMember.KerbalSuit) Enum.Parse(typeof(ProtoCrewMember.KerbalSuit), Settings.suitName);
            kerbal.suit = kerbalSuit;

            Debug.Log($"[KerbalDefaults] suitName = {Settings.suitName}");
        }
    }
}
