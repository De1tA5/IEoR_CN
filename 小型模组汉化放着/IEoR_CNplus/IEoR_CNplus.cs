using Terraria.ModLoader;
using TigerForceLocalizationLib;
using TigerForceLocalizationLib.Filters;

namespace IEoR_CNplus
{

    //BlueMoon¡ª¡ªÄ§·¨ÔÂÁÁ
    public class BlueMoon : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.HasMod("BlueMoon"))
            {
                TigerForceLocalizationHelper.LocalizeAll("IEoR_CNplus", "BlueMoon", false);
            }
        }
    }
    //CalamityAmmunitions¡ª¡ªÔÖ¶òµ¯Ò©¸½¼Ó
    public class CalamityAmmunitions : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.HasMod("CalamityAmmunitions"))
            {
                TigerForceLocalizationHelper.LocalizeAll("IEoR_CNplus", "CalamityAmmunitions", false);
            }
        }
    }
    //SOTS¡ª¡ª°µÓ°°ÂÃØÓ²±àÂëÐÞ¸´
    public class SOTS : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.HasMod("SOTS"))
            {
                TigerForceLocalizationHelper.LocalizeAll("IEoR_CNplus", "SOTS", false, filters: new()
                {
                    MethodFilter = MethodFilter.MatchNames("UseItem")
                });
            }
        }
    }
}
