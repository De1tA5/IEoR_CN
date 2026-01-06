using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix
{
    //增加正式契约文本
    [JITWhenModsEnabled("SOTSBardHealer", "InfernalEclipseAPI")]
    public class SealedContract_Fix : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            ModItem item;
            return ModCross.ThoriumRework.TryFind<ModItem>("SealedContract", out item) && (item.Type == entity.type);
        }
        
        public override bool IsLoadingEnabled(Mod mod)
        {
            
            return ModCross.InfernalEclipseAPI != null && ModCross.ThoriumRework != null;
        }
        

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {

            //var type = Type.GetType("InfernalEclipseAPI.InfernalConfig, InfernalEclipseAPI");
            //var info = type?.GetProperty("MergeCraftingTrees", BindingFlags.Public | BindingFlags.Static);
            //var flag = (bool)info.GetValue(null);
            //var type = typeof(InfernalEclipseAPI);
            //var info = type?.GetProperty("InfernalConfig.MergeCraftingTrees", BindingFlags.Public);
            //bool flag = info.GetValue();

            if (item.ModItem == null || item.ModItem.Mod != ModCross.ThoriumRework) return;

            Color InfernalRed = Color.Lerp(
                Color.White,
                new Color(255, 80, 0),
                (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 2.0) * 0.5 + 0.5)
                );

            foreach (TooltipLine tooltip in tooltips)
            {
                if (tooltip.Mod != "Terraria") return;

                if (tooltip.Text.Contains("最大生命增加60") && tooltip.Name == "Tooltip0")
                {
                    if (ModCross.SOTSBardHealer != null)
                    {
                        tooltip.Text = Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.MergedCraftingTreeTooltip.SerpentsTongue");
                        tooltip.OverrideColor = new Color?(InfernalRed);
                    }
                    else
                    {
                        tooltip.Hide();
                    }
                }

                if (tooltip.Text.Contains("治疗法术会额外治疗5点生命值") && tooltip.Name == "Tooltip1")
                {
                    tooltip.Text = Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.MergedCraftingTreeTooltip.ContractNerf");
                }
            }
        }
    }
}
