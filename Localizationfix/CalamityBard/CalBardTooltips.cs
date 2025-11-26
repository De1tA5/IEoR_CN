using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix.CalamityBard
{
    public class CalBardTooltips : GlobalItem
    {
        //灾厄牧师和乐师
        public override bool InstancePerEntity => true;
        public override bool IsLoadingEnabled(Mod mod)
        {
            Mod IEoR;
            ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR);
            Mod WH;
            ModLoader.TryGetMod("WHummusMultiModBalancing", out WH);
            return WH != null && IEoR != null && CalamityBard != null;
        }

        private static Mod CalamityBard
        {
            get 
            {
                Mod calbard;
                ModLoader.TryGetMod("CalamityBardHealer", out calbard);
                return calbard;
            }
        }

        public static ModItem GetItem(string item)
        {
            ModItem modItem;
            CalamityBard.TryFind<ModItem>(item,out modItem);
            return modItem;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.ModItem == null || item.ModItem.Mod != CalamityBard)
            {
                return;
            }

            //龙蒿圣冠
            if (CalamityBard != null && item.type == GetItem("TarragonParagonCrown").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("治疗法术会额外治疗8点生命值"))
                    {
                        tooltip.Text = tooltip.Text.Replace("8", "6");
                    }
                }
            }

            //血焱祭颅盔
            if (CalamityBard != null && item.type == GetItem("BloodflareRitualistMask").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("治疗法术会额外治疗12点生命值"))
                    {
                        tooltip.Text = tooltip.Text.Replace("12", "8");
                    }
                }
            }

            //始源林海护盔
            if (CalamityBard != null && item.type == GetItem("SilvaGuardianHelmet").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("治疗法术会额外治疗15点生命值"))
                    {
                        tooltip.Text = tooltip.Text.Replace("15", "10");
                    }
                }
            }

            //金圣武神盔
            if (CalamityBard != null && item.type == GetItem("AuricTeslaValkyrieVisage").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("治疗法术会额外治疗18点生命值"))
                    {
                        tooltip.Text = tooltip.Text.Replace("18", "10");
                    }
                }
            }
            
            //金圣武神盔+
            if (CalamityBard != null && GetItem("AugmentedAuricTeslaValkyrieVisage") != null && item.type == GetItem("AugmentedAuricTeslaValkyrieVisage").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("治疗法术会额外治疗18点生命值"))
                    {
                        tooltip.Text = tooltip.Text.Replace("18", "10");
                    }
                }
            }

            //元素之花
            if (CalamityBard != null && item.type == GetItem("ElementalBloom").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加20%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("20", "15");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加12%光辉暴击率"))
                    {
                        tooltip.Text = tooltip.Text.Replace("12", "5");
                    }
                }
            }
        }
    }
}
