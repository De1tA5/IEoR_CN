using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix.Thorium
{
    public class HereticBreaker : GlobalItem
    {
        //异教毁灭者
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
                if (Thorium != null && item.type == Thorium.Find<ModItem>("HereticBreaker").Type)
                {
                    foreach (TooltipLine tooltip in tooltips)
                    {
                        if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("造成伤害时会治疗附近所有受伤队友"))
                        {
                            tooltip.Text = tooltip.Text.Replace("造成伤害时会治疗附近所有受伤队友", "吸取3生命值");
                        }
                    }
                }
            }
        }
    }
}
