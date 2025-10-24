using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using TigerForceLocalizationLib;

namespace IEoR_CN
{
    //HomewardRagnarok�����˹�;&����ƻ����
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
    //WHummusMultiModBalancing��WHummus���ֶ�&ɪ��ƽ��
    public class WHummusMultiModBalancing:ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.HasMod("WHummusMultiModBalancing")) 
            {
                TigerForceLocalizationHelper.LocalizeAll("IEoR_CN", "WHummusMultiModBalancing", false);
            }
            base.PostSetupContent();
        }


    }
}
