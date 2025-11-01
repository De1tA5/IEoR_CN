using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Reflection;
using Terraria.DataStructures;
using System.Collections.Concurrent;
using System.Diagnostics;
using Terraria.Localization;

namespace IEoR_CN.Localizationfix
{
    [JITWhenModsEnabled()]
    public class SealedContract_Fix:GlobalItem
    {
        public int Delaytime = 0;

       
        public override bool IsLoadingEnabled(Mod mod)
        {
            Mod IEoR;
            return ModLoader.TryGetMod("InfernalEclipseAPI", out IEoR);
        }
        private Mod ThoriumRework {
            get {
                Mod thorRe;
                ModLoader.TryGetMod("ThoriumRework", out thorRe);
                return thorRe;
            }
        }
        private Mod InfernalEclipseAPI {
            get {
                Mod ieor;
                ModLoader.TryGetMod("InfernalEclipseAPI", out ieor);
                return ieor;
            }
        }

        private Mod SOTSBardHealer
        {
            get {
                Mod sotshb;
                ModLoader.TryGetMod("SOTSBardHealer", out sotshb);
                return sotshb;
            
            }
        }
        public static class ReflectionCache
        {

            private static readonly ConcurrentDictionary<string, PropertyInfo> _propertyCache
                = new ConcurrentDictionary<string, PropertyInfo>();

            public static PropertyInfo GetProperty(Type type, string propertyName)
            {
                var key = $"{type.FullName}.{propertyName}";
                return _propertyCache.GetOrAdd(key, _ => type.GetProperty(propertyName));
            }
        }

        public override bool InstancePerEntity => true;

        const BindingFlags all = BindingFlags.Public | BindingFlags.Instance;
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Color InfernalRed = Color.Lerp(
                Color.White,
                new Color(255, 80, 0), 
                (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 2.0) * 0.5 + 0.5)
                );
            
            //Delaytime--;
            if (ModLoader.HasMod("InfernalEclipseAPI"))
            {
                var type = ModLoader.GetMod("InfernalEclipseAPI").GetType();
                if (type == null)
                {
                    return;
                }
                PropertyInfo[] array = type.GetProperties(all);
                /*
                for (int i = 0; i < array.Length; i++) {
                    Main.NewText(array[i].Name.ToString());
                    if (array[i].Name.ToString() == "MergeCraftingTrees" && array[i].GetValue(  )) {

                            if (this.ThoriumRework != null && item.type == ThoriumRework.Find<ModItem>("SealedContract").Type)
                            {

                                foreach (TooltipLine tooltip in tooltips)
                                {
                                    if (tooltip.Text.Contains("最大生命增加60"))
                                    {
                                        if (SOTSBardHealer != null)
                                        {
                                            tooltip.Text = Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.MergedCraftingTreeTooltip.SerpentsTongue");
                                            tooltip.OverrideColor = new Color?(InfernalRed);
                                        }
                                    }


                                    if (tooltip.Text.Contains("治疗法术会额外治疗5点生命值"))
                                    {
                                        tooltip.Text = Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.MergedCraftingTreeTooltip.ContractNerf");
                                    }
                                }
                            }
                        

                    }
                }*/

                //var flag = (bool)type.GetProperty("MergeCraftingTrees", all).GetValue(type, null);
                bool flag = true;
                if (flag == true)
                {
                    if (this.ThoriumRework != null && item.type == ThoriumRework.Find<ModItem>("SealedContract").Type)
                    {

                        foreach (TooltipLine tooltip in tooltips)
                        {
                            if (tooltip.Text.Contains("最大生命增加60"))
                            {
                                if (SOTSBardHealer != null)
                                {
                                    tooltip.Text = Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.MergedCraftingTreeTooltip.SerpentsTongue");
                                    tooltip.OverrideColor = new Color?(InfernalRed);
                                }
                                else {
                                    tooltip.Text = "";
                                }
                            }


                            if (tooltip.Text.Contains("治疗法术会额外治疗5点生命值"))
                            {
                                tooltip.Text = Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.MergedCraftingTreeTooltip.ContractNerf");
                            }
                        }
                    }
                }

            }
        }
        
    }
}
