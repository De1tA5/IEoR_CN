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
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            ModItem item;
            return Thorium.TryFind<ModItem>("NinjaEmblem", out item) && (item.Type == entity.type);
        }
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
            if (item.ModItem == null || item.ModItem.Mod != Thorium) return;

            foreach (TooltipLine tooltip in tooltips)
            {
                if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName" && (tooltip.Text.Contains("多职业徽章") || tooltip.Text.Contains("忍者徽章")))
                {
                    tooltip.Text = "英雄徽章";
                }
            }
            if (ModLoader.HasMod("WHummusMultiModBalancing"))
            {
                int startIndex = tooltips.FindIndex(tooltip => tooltip.Text.Contains("增加8%伤害"));
                int endIndex = tooltips.FindIndex(tooltip => tooltip.Text.Contains("增加5%攻击速度"));
                if (startIndex != -1 && endIndex != -1)
                {
                    tooltips.Insert(endIndex + 1, new TooltipLine(Mod, "TextPatch", "增加5%伤害\n增加6%暴击率\n增加5%攻击速度"));//whummus写2% 实测6%暴
                    tooltips.RemoveRange(startIndex, endIndex + 1 - startIndex);
                }
            }
        }
    }
}
