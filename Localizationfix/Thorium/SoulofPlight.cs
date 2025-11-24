using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix.Thorium
{
    public class SoulofPlight:GlobalItem
    {
        //瑟银困境之魂——改为恶意之魂

        public override bool InstancePerEntity => true;

        public override bool IsLoadingEnabled(Mod mod)
        {
            Mod IEoR;
            return ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR) && Thorium != null;
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
            if (item.ModItem == null)
            {
                return;
            }

            if (Thorium != null && item.type == Thorium.Find<ModItem>("SoulofPlight").Type) 
            {
                foreach (TooltipLine tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName" && tooltip.Text.Contains("困境之魂"))
                    {
                        tooltip.Text = "恶意之魂";
                    }
                }
            }

            if (Thorium != null && item.type == Thorium.Find<ModItem>("SoulofPlightinaBottle").Type) 
            {
                foreach (TooltipLine tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria"  && tooltip.Name == "ItemName" && tooltip.Text.Contains("瓶中困境之魂"))
                    {
                        tooltip.Text = "瓶中恶意之魂";
                    }
                }
            }

            if (Thorium != null && item.type == Thorium.Find<ModItem>("KeyofPlight").Type)
            {
                foreach (TooltipLine tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria"  && tooltip.Name == "ItemName" && tooltip.Text.Contains("困境钥匙"))
                    {
                        tooltip.Text = "恶意钥匙";
                    }
                }
            }
        }
    }
}
