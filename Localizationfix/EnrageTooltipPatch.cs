namespace PolaritiesCNplus.TooltipPatch
{
    public delegate void orig_EditEnrageTooltips(Item item, List<TooltipLine> tooltips);
    [JITWhenModsEnabled("InfernumMode")]
    public class EnrageTooltipPatch : ModSystem
    {
        public static Dictionary<int, LocalizedText> EnrageTooltipReplacements => new()
        {
            //白天狂暴
            [ItemID.MechanicalEye] = null,
            [ItemID.MechanicalSkull] = null,
            [ItemID.MechanicalWorm] = null,
            [ItemID.ClothierVoodooDoll] = null,
            //环境狂暴
            [ItemID.WormFood] = Utilities.GetLocalization("UI.EnrageTooltipReplacements.WormFood"),
            [ItemID.BloodySpine] = Utilities.GetLocalization("UI.EnrageTooltipReplacements.BloodySpine"),
            [ModContent.ItemType<DecapoditaSprout>()] = Utilities.GetLocalization("UI.EnrageTooltipReplacements.DecapoditaSprout"),
            [ModContent.ItemType<Teratoma>()] = Utilities.GetLocalization("UI.EnrageTooltipReplacements.Teratoma"),
            [ModContent.ItemType<BloodyWormFood>()] = Utilities.GetLocalization("UI.EnrageTooltipReplacements.BloodyWormFood"),
            [ModContent.ItemType<Seafood>()] = Utilities.GetLocalization("UI.EnrageTooltipReplacements.Seafood"),
            [ModContent.ItemType<Abombination>()] = Utilities.GetLocalization("UI.EnrageTooltipReplacements.Abombination"),
            [ModContent.ItemType<ExoticPheromones>()] = null,
            [ModContent.ItemType<NecroplasmicBeacon>()] = Utilities.GetLocalization("UI.EnrageTooltipReplacements.NecroplasmicBeacon")
        };
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("InfernumMode");
        }

        private static Type _tooltipType;
        private static MethodInfo _enragetooltipMethod;
        public override void Load()
        {
            if (!ModLoader.TryGetMod("InfernumMode", out Mod infer)) return;
            _tooltipType = infer.Code.GetType("InfernumMode.Core.GlobalInstances.GlobalItems.TooltipChangeGlobalItem");

            if (_tooltipType is null) return;
            _enragetooltipMethod = _tooltipType.GetMethod("EditEnrageTooltips", BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            if (_enragetooltipMethod is null) return;

            MonoModHooks.Add(_enragetooltipMethod, On_EditEnrageTooltips);

        }

        private static void On_EditEnrageTooltips(orig_EditEnrageTooltips orig, Item item, List<TooltipLine> tooltips)
        {
            if (!EnrageTooltipReplacements.TryGetValue(item.type, out var tooltipReplacement))
                return;

            string localizedEnrageText = Utilities.GetLocalization("Items.EnrageTooltip").Value.ToLower();
            var enrageTooltip = tooltips.FirstOrDefault(x => x.Text.Contains(localizedEnrageText, StringComparison.OrdinalIgnoreCase));
            if (enrageTooltip is null)
                return;

            int enrageTextEnd = enrageTooltip.Text.IndexOf(localizedEnrageText, StringComparison.OrdinalIgnoreCase) + localizedEnrageText.Length;
            int enrageTextStart = enrageTextEnd - 1;

            while (enrageTextStart > 0 && enrageTooltip.Text[enrageTextStart] != '\n')
                enrageTextStart--;

            //额外处理世吞和克脑
            if (item.type == ItemID.WormFood || item.type == ItemID.BloodySpine)
                enrageTextStart++;

            enrageTooltip.Text = enrageTooltip.Text.Remove(enrageTextStart, Math.Min(enrageTextEnd - enrageTextStart, enrageTooltip.Text.Length + 1));

            if (tooltipReplacement is not null)
                enrageTooltip.Text = enrageTooltip.Text.Insert(enrageTextStart, tooltipReplacement.Value);
            else
                enrageTooltip.Text = enrageTooltip.Text.Replace("\n\n", "\n");
        }
    }
}
