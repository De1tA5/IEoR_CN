using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix.Thorium
{
    public class NinjaEmblem : GlobalItem
    {
        //忍者徽章——>英雄徽章
        public override bool InstancePerEntity => true;

        public override bool IsLoadingEnabled(Mod mod)
        {
            Mod IEoR;
            return ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR);
        }
        private static Mod Thorium
        {
            get
            {
                Mod thor;
                ModLoader.TryGetMod("ThoriumMod", out thor);
                return thor;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.HasMod("InfernalEclipseAPI"))
            {
                if (Thorium != null && item.type == Thorium.Find<ModItem>("NinjaEmblem").Type)
                {
                    foreach (TooltipLine tooltip in tooltips)
                    {
                        if (tooltip.Mod == "Terraria" && tooltip.Name =="ItemName" && tooltip.Text.Contains("忍者徽章"))
                        {
                            tooltip.Text = "英雄徽章";
                        }
                    }
                }
            }
        }
    }
}
