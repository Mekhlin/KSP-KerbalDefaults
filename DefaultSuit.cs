using System;
using System.Linq;
using UnityEngine;

namespace KerbalDefaults
{
    internal static class DefaultSuit
    {
        private static readonly string[] SuitNames = { "Default", "Vintage", "Future" };

        public static void ApplySuit(ProtoCrewMember kerbal)
        {
            try
            {
                if (string.IsNullOrEmpty(Settings.suitName) || Settings.suitName == "Default") return;
                if (SuitNames.Contains(Settings.suitName) == false) return;

                var kerbalSuit = (ProtoCrewMember.KerbalSuit)Enum.Parse(typeof(ProtoCrewMember.KerbalSuit), Settings.suitName);
                kerbal.suit = kerbalSuit;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[KerbalDefaults] Failed to set suit on new Kerbal. SuitName:{Settings.suitName} - StackTrace:{ex.StackTrace}");
            }
        }
    }
}
