using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix.Thorium
{
    //public class ScryingGlass : GlobalItem
    //{
    //    //全知水晶球
    //    public override bool InstancePerEntity => true;

    //    public override bool IsLoadingEnabled(Mod mod)
    //    {
    //        Mod IEoR;
    //        return ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR);
    //    }
    //    private static Mod Thorium
    //    {
    //        get
    //        {
    //            Mod thor;
    //            ModLoader.TryGetMod("ThoriumMod", out thor);
    //            return thor;
    //        }
    //    }

    //    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    //    {
    //        if (ModLoader.HasMod("InfernalEclipseAPI"))
    //        {
    //            if (Thorium != null && item.type == Thorium.Find<ModItem>("ScryingGlass").Type)
    //            {
    //                foreach (TooltipLine tooltip in tooltips)
    //                {
    //                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加你的最大哨兵数量"))
    //                    {
    //                        tooltip.Text = "";
    //                    }

    //                }
    //            }
    //        }
    //    }
    //}
}
