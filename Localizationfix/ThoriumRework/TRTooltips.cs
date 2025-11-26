using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix.ThoriumRework
{
    public class TRTooltips:GlobalItem
    {
        //瑟银Boss重置
        public override bool InstancePerEntity => true;
        public override bool IsLoadingEnabled(Mod mod)
        {
            Mod IEoR;
            ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR);
            Mod WH;
            ModLoader.TryGetMod("WHummusMultiModBalancing", out WH);
            return WH != null && IEoR != null && ThoriumRework != null;
        }
        private static Mod ThoriumRework
        {
            get 
            {
                Mod TR;
                ModLoader.TryGetMod("ThoriumRework", out TR);
                return TR;
            }
        }

        public static ModItem GetItem(string item)
        {
            ModItem modItem = ThoriumRework.Find<ModItem>(item);
            return modItem;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.ModItem == null || item.ModItem.Mod != ThoriumRework)
            {
                return;
            }

            //脉冲扬声器
            if (ThoriumRework != null && item.type == GetItem("ImpulseAmplifier").Type)
            {
                int index = tooltips.FindIndex(tooltip => tooltip.Text.Contains("电子乐器的弹幕速度大幅提升"));
                if (index != -1) 
                {
                    tooltips.Insert(index + 1, new TooltipLine(Mod, "TooltipPatch", "电子乐器会在最近的敌人间产生闪电链造成10%的武器伤害"));
                }  
                foreach (var tooltip in tooltips) 
                {
                    if (tooltip.Text.Contains("电子乐器的弹幕速度大幅提升")) 
                    {
                        tooltip.Text = "电子乐器的弹幕速度大幅提升并初次击中时施加带电";
                    }
                }
            }

            //粉丝捐款
            if (ThoriumRework != null && item.type == GetItem("FanDonations").Type)
            {
                int index = tooltips.FindIndex(tooltip => tooltip.Text.Contains("电子乐器的弹幕速度大幅提升"));
                tooltips.RemoveRange(index, 1);
                tooltips.Insert(index, new TooltipLine(Mod, "TooltipPatch", "电子乐器的弹幕速度大幅提升并初次击中时施加带电\n电子乐器会在最近的敌人间产生闪电链造成10%的武器伤害"));
            }
        }
    }
}
