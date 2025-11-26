using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix.Thorium
{
    public class ThoriumTooltips:GlobalItem
    {
        //WHummus灾厄瑟银平衡内容
        public override bool IsLoadingEnabled(Mod mod)
        {
            Mod IEoR;
            ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR);
            Mod WH;
            ModLoader.TryGetMod("WHummusMultiModBalancing", out WH);
            return  WH != null && IEoR != null && Thorium != null;
        }
        public override bool InstancePerEntity => true;
        private static Mod Thorium
        {
            get
            {
                Mod thor;
                ModLoader.TryGetMod("ThoriumMod", out thor);
                return thor;
            }
        }

        public static ModItem GetItem(string item)
        {
            ModItem modItem = Thorium.Find<ModItem>(item);
            return modItem;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.ModItem == null || item.ModItem.Mod != Thorium) return;
            

            //蜂蜜水晶
            if (Thorium != null && item.type == GetItem("CrystalHoney").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加10%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("10%", "5%");
                    }
                }
            }

            //暗元液
            if (Thorium != null && item.type == GetItem("DarkGlaze").Type) 
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加15%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("15%", "10%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加10%光辉暴击率"))
                    {
                        tooltip.Text = tooltip.Text.Replace("10%", "5%");
                    }
                }
            }

            //恶魔之舌
            if (Thorium != null && item.type == GetItem("DemonTongue").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Text.Contains("增加12%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("12%", "10%");
                    }
                }
            }

            //谐振义肢
            if (Thorium != null && item.type == GetItem("ResonatorsArm").Type)
            {     
                int index = tooltips.FindIndex(tooltip => tooltip.Text.Contains("右键花费5点灵感值并短暂格挡对你的下次攻击"));
                if (index != -1)
                {
                    tooltips.Insert(index+1, new TooltipLine(Mod, "TextPatch", "右键格挡有5秒的冷却时间"));
                }
            }

            //乌檀电琴
            if (Thorium != null && item.type == GetItem("BlackMIDI").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Text.Contains("黄色噪声会治疗使用者造成伤害10%的生命值")) 
                    {
                        tooltip.Text = tooltip.Text.Replace("10%", "0.5%");
                    }
                }
            }

            //大恶魔之咒
            if (Thorium != null && item.type == GetItem("ArchDemonCurse").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加20%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("20%", "12%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加12%光辉暴击率"))
                    {
                        tooltip.Text = tooltip.Text.Replace("12%", "5%");
                    }
                }
            }

            //飞羽胸甲
            if (Thorium != null && item.type == GetItem("FlightMail").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("10%", "5%");
                    }
                }
            }

            //青铜头盔
            if (Thorium != null && item.type == GetItem("BronzeHelmet").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("暴击率"))
                    {
                        tooltip.Text = tooltip.Text.Replace("10%", "6%");
                    }
                }
            }

            //青铜胸甲
            if (Thorium != null && item.type == GetItem("BronzeBreastplate").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("20%", "10%");
                    }
                }
            }

            //瘟疫医生面具
            if (Thorium != null && item.type == GetItem("PlagueDoctorsMask").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("12%", "5%");
                    }
                }
            }

            //瘟疫医生外衣
            if (Thorium != null && item.type == GetItem("PlagueDoctorsGarb").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("14%", "15%");
                    }
                }
            }

            //瘟疫医生裤
            if (Thorium != null && item.type == GetItem("PlagueDoctorsLeggings").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("14%", "10%");
                    }
                }
            }

            //真菌帽
            if (Thorium != null && item.type == GetItem("FungusHat").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("8%", "5%");
                    }
                }
            }

            //真菌胸甲
            if (Thorium != null && item.type == GetItem("FungusGuard").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("12%", "10%");
                    }
                }
            }

            //暗影大师面具
            if (Thorium != null && item.type == GetItem("ShadeMasterMask").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("20%", "10%");
                    }
                }
            }

            //暗影大师足具
            if (Thorium != null && item.type == GetItem("ShadeMasterTreads").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("20%", "10%");
                    }
                }
            }

            //白矮星面具
            if (Thorium != null && item.type == GetItem("WhiteDwarfMask").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("20%", "10%");
                    }
                }
            }

            //白矮星胸甲
            if (Thorium != null && item.type == GetItem("WhiteDwarfGuard").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("15%", "10%");
                    }
                }
            }

            //白矮星护胫
            if (Thorium != null && item.type == GetItem("WhiteDwarfGreaves").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("20%", "10%");
                    }
                }
            }

            //光耀头盔
            if (Thorium != null && item.type == GetItem("IridescentHelmet").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加16%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("16%", "5%");
                    }
                }
            }

            //光耀胸甲
            if (Thorium != null && item.type == GetItem("IridescentMail").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加12%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("12%", "10%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加8%光辉暴击率"))
                    {
                        tooltip.Text = tooltip.Text.Replace("8%", "2%");
                    }
                }
            }

            //光耀护胫
            if (Thorium != null && item.type == GetItem("IridescentGreaves").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加10%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("10%", "5%");
                    }
                }
            }

            //绽花战袍
            if (Thorium != null && item.type == GetItem("BloomingTabard").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("治疗法术会额外治疗1点生命值"))
                    {
                        tooltip.Text = tooltip.Text.Replace("1", "2");
                    }
                }
            }

            //生物工程服
            if (Thorium != null && item.type == GetItem("BioTechGarment").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加15%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("15%", "25%");
                    }
                }
            }

            //术士兜帽
            if (Thorium != null && item.type == GetItem("WarlockHood").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加12%光辉暴击率"))
                    {
                        tooltip.Text = tooltip.Text.Replace("12%", "7%");
                    }
                }
            }

            //术士法袍
            if (Thorium != null && item.type == GetItem("WarlockGarb").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("降低25%非光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("25%", "15%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加25%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("25%", "15%");
                    }
                }
            }

            //术士护胫
            if (Thorium != null && item.type == GetItem("WarlockLeggings").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加5%光辉暴击率"))
                    {
                        tooltip.Hide();
                    }
                }
            }

            //堕落圣骑士面盔
            if (Thorium != null && item.type == GetItem("FallenPaladinFaceguard").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("降低20%非光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("20%", "10%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加20%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("20%", "10%");
                    }
                }
            }

            //堕落圣骑士胸甲
            if (Thorium != null && item.type == GetItem("FallenPaladinCuirass").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("降低30%非光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("30%", "20%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加30%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("30%", "20%");
                    }
                }
            }

            //堕落圣骑士护胫
            if (Thorium != null && item.type == GetItem("FallenPaladinGreaves").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("降低25%非光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("25%", "15%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加25%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("25%", "15%");
                    }
                }
            }

            //低语者兜帽
            if (Thorium != null && item.type == GetItem("WhisperingHood").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("降低25%非光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("25%", "20%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加25%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("25%", "20%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加12%光辉暴击率"))
                    {
                        tooltip.Text = tooltip.Text.Replace("12%", "10%");
                    }
                }
            }

            //低语者法袍
            if (Thorium != null && item.type == GetItem("WhisperingTabard").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("降低35%非光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("35%", "25%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加35%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("35%", "25%");
                    }
                }
            }

            //低语者长裤
            if (Thorium != null && item.type == GetItem("WhisperingLeggings").Type)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("降低25%非光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("25%", "15%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加25%光辉伤害"))
                    {
                        tooltip.Text = tooltip.Text.Replace("25%", "15%");
                    }
                    if (tooltip.Mod == "Terraria" && tooltip.Text.Contains("增加6%光辉暴击率"))
                    {
                        tooltip.Hide();
                    }
                }
            }
        }
    }
}
