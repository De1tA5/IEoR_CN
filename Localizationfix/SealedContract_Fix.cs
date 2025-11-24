using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Reflection;
using Terraria.DataStructures;
using System.Collections.Concurrent;
using System.Diagnostics;
using Terraria.Localization;

namespace IEoR_CN.Localizationfix
{
    //增加正式契约文本
    [JITWhenModsEnabled("SOTSBardHealer", "InfernalEclipseAPI")]
    public class SealedContract_Fix:GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            ModItem item;
            return ThoriumRework.TryFind<ModItem>("SealedContract", out item) && (item.Type == entity.type);
        }
        public override bool InstancePerEntity => true;
        public override bool IsLoadingEnabled(Mod mod)
        {
            Mod IEoR;
            return ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR) && ThoriumRework != null;
        }
        private Mod ThoriumRework {
            get {
                Mod thorRe;
                ModLoader.TryGetMod("ThoriumRework", out thorRe);
                return thorRe;
            }
        }
        private Mod InfernalEclipseAPI {
            get {
                Mod ieor;
                ModLoader.TryGetMod("InfernalEclipseAPI", out ieor);
                return ieor;
            }
        }

        private Mod SOTSBardHealer
        {
            get
            {
                Mod sotshb;
                ModLoader.TryGetMod("SOTSBardHealer", out sotshb);
                return sotshb;

            }
        }
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.ModItem == null) 
            {
                return;
            }

            Color InfernalRed = Color.Lerp(
                Color.White,
                new Color(255, 80, 0), 
                (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 2.0) * 0.5 + 0.5)
                );
           

            foreach (TooltipLine tooltip in tooltips)
            {
                if (tooltip.Text.Contains("最大生命增加60"))
                {
                    if (SOTSBardHealer != null)
                    {
                        tooltip.Text = Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.MergedCraftingTreeTooltip.SerpentsTongue");
                        tooltip.OverrideColor = new Color?(InfernalRed);
                    }
                    else {
                        tooltip.Hide();
                    }
                }


                if (tooltip.Text.Contains("治疗法术会额外治疗5点生命值"))
                {
                    tooltip.Text = Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.MergedCraftingTreeTooltip.ContractNerf");
                }
            }
            
            
            
        } 
    }
}
