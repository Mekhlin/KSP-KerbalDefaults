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
                if (string.IsNullOrEmpty(Settings.SuitName) || Settings.SuitName == "Default") return;
                if (SuitNames.Contains(Settings.SuitName) == false) return;

                var kerbalSuit = (ProtoCrewMember.KerbalSuit)Enum.Parse(typeof(ProtoCrewMember.KerbalSuit), Settings.SuitName);
                kerbal.suit = kerbalSuit;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[KerbalDefaults] Failed to set suit on new Kerbal. SuitName:{Settings.SuitName} - StackTrace:{ex.StackTrace}");
            }
        }
    }
}
