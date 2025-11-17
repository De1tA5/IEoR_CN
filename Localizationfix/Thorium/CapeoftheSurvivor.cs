using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix.Thorium
{
    public class CapeoftheSurvivor : GlobalItem
    {
        //生存者披风
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
                if (Thorium != null && item.type == Thorium.Find<ModItem>("CapeoftheSurvivor").Type)
                {
                    foreach (TooltipLine tooltip in tooltips)
                    {
                        if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("你随时间快速地获取至多20%伤害减免"))
                        {
                            tooltip.Text = tooltip.Text.Replace("20%", "15%");
                        }
                        if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("当此加成高于0%时"))
                        {
                            tooltip.Text = tooltip.Text.Replace("并能阻挡1次伤害性攻击", "");
                        }
                    }
                }
            }
        }
    }
}
