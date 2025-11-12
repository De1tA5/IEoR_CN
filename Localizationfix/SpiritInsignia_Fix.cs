using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace IEoR_CN.Localizationfix
{
    //删除圣魂之证无限飞行文本
    public class SpiritInsignia_Fix:GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            Mod IEoR;
            return ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR);
        }
        private Mod SOTS
        {
            get
            {
                Mod sots;
                ModLoader.TryGetMod("SOTS", out sots);
                return sots;
            }
        }
        public override bool InstancePerEntity => true;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.HasMod("InfernalEclipseAPI")) {
                if (SOTS != null && item.type == SOTS.Find<ModItem>("SpiritInsignia").Type) {
                    foreach (TooltipLine tooltip in tooltips) {
                        if (tooltip.Mod =="Terraria" && tooltip.Text.Contains("使你获得无限的翅膀和火箭靴飞行时间")) {
                            tooltip.Text = "提升25%飞行时间";
                        }
                    }
                }
            }
        }

    }
}
