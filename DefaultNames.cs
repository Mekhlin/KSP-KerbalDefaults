namespace KerbalDefaults
{
    internal static class DefaultNames
    {
        public static void ApplyName(ProtoCrewMember kerbal)
        {
            if (Settings.preserveOriginalNames || kerbal.veteran == false)
            {
                return;
            }

            if (RenameKerbal(kerbal, "Jebediah Kerman", "Jebediah")) return;
            if (RenameKerbal(kerbal, "Bill Kerman", "Bill")) return;
            if (RenameKerbal(kerbal, "Bob Kerman", "Bob")) return;
            RenameKerbal(kerbal, "Valentina Kerman", "Valentina");
        }

        private static bool RenameKerbal(ProtoCrewMember kerbal, string name, string key)
        {
            if (kerbal.name != name || Settings.kerbalNames.ContainsKey(key) == false) return false;
            return kerbal.ChangeName(Settings.kerbalNames[key]);
        }
    }
}
