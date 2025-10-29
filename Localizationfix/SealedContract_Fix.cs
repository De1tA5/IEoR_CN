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

namespace IEoR_CN.Localizationfix
{
    /*
    public class SealedContract_Fix:GlobalItem
    {

        Color InfernalRed = Color.Lerp(Color.White, new Color(255, 80, 0), (float)(Math.Sin((double)Main.GlobalTimeWrappedHourly * 2.0) * 0.5 + 0.5));
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
            if (ModLoader.HasMod("InfernalEclipseAPI")) {
                var type = ModLoader.GetMod("InfernalEclipseAPI").GetType();
                if (type == null) {
                    return;
                }
                var flag = (bool)type.GetProperty("MergeCraftingTrees", all).GetValue(type, null);
                if (flag == true) {
                    if (this.ThoriumRework != null && item.type == ModContent.Find<ModItem>("SealedContract").Type) {
                        foreach (TooltipLine tooltip in tooltips) {
                            if (tooltip.Text.Contains("") && this.SOTSBardHealer != null) ;


                        }
                    };
                    
                }
            }
        }
        
    }
    */
  
}
