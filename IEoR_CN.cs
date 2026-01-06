using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using TigerForceLocalizationLib;
using TigerForceLocalizationLib.Filters;
using Microsoft.Xna.Framework;
using Terraria.Localization;


namespace IEoR_CN
{
    //进世界文本显示
    
    public class WorldText : ModPlayer
    {
        public override void OnEnterWorld()
        {
            Main.NewText(Language.GetTextValue("Mods.IEoR_CN.EnterWorldText"), new Color(193, 90, 255));
        }
    }


    //HomewardRagnarok—旅人归途&诸神黄昏兼容
    public class HomewardRagnarok : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.HasMod("HomewardRagnarok"))
            {
                TigerForceLocalizationHelper.LocalizeAll("IEoR_CN", "HomewardRagnarok", false);

                base.PostSetupContent();
            }
        }
    }
    //WHummusMultiModBalancing—WHummus的灾厄&瑟银平衡
    public class WHummusMultiModBalancing:ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.HasMod("WHummusMultiModBalancing")) 
            {
                TigerForceLocalizationHelper.LocalizeAll("IEoR_CN", "WHummusMultiModBalancing", false, filters: new()
                {
                    MethodFilter = MethodFilter.MatchNames("TryTeleport", "PostUpdate", "SetAnchor", "ModifyTooltips", "PostUpdateEquips")
                });
            }
            base.PostSetupContent();
        }


    }
    //InfernalEclipseAPI——诸神黄昏：炼狱蚀光
    public class InfernalEclipseAPI : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.HasMod("InfernalEclipseAPI"))
            {
                TigerForceLocalizationHelper.LocalizeAll("IEoR_CN", "InfernalEclipseAPI", false,filters: new()
                {
                    MethodFilter = MethodFilter.MatchNames("TryTeleport", "PostUpdate", "SetAnchor", "ModifyTooltips", "PostUpdateEquips")
                });
            }
        }
    }
}
