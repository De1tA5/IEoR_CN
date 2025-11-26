using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace IEoR_CN.Localizationfix.Thorium
{
    public class ShootingStar: ModPlayer
    {
        //流影掠星套装效果
        public override bool IsLoadingEnabled(Mod mod)
        {
            Mod IEoR;
            ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR);
            Mod WH;
            ModLoader.TryGetMod("WHummusMultiModBalancing", out WH);
            return WH != null && IEoR != null && Thorium != null;
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
        public static ModItem GetItem(string item)
        {
            ModItem modItem = Thorium.Find<ModItem>(item);
            return modItem;
        }

        public override void PostUpdateEquips()
        {
            if (Thorium == null) return;
            int head = GetItem("ShootingStarHat").Type;
            int chest = GetItem("ShootingStarShirt").Type;
            int leg = GetItem("ShootingStarBoots").Type;
            if (Player.armor[0].type == head &&
                Player.armor[1].type == chest &&
                Player.armor[2].type == leg)
            {
                Player.setBonus = "使咒音增幅持续时间延长6秒\n玩家拥有的每个独特的咒音增幅会增加2.5%音波伤害\n你所拥有的每一种独特的能力都可以让灵感回复率提高2%";
            }
                
        }
    }
}
