using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace IEoR_CN
{
    public class ModCross:ModSystem
    {
        static internal Mod ThoriumRework
        {
            get
            {
                Mod thorRe;
                ModLoader.TryGetMod("ThoriumRework", out thorRe);
                return thorRe;
            }
        }
        static internal Mod InfernalEclipseAPI
        {
            get
            {
                Mod ieor;
                ModLoader.TryGetMod("InfernalEclipseAPI", out ieor);
                return ieor;
            }
        }

        static internal Mod SOTSBardHealer
        {
            get
            {
                Mod sotshb;
                ModLoader.TryGetMod("SOTSBardHealer", out sotshb);
                return sotshb;

            }
        }
    }
}
