using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace IEoR_CN
{
    public class PatchConfig: ModConfig
    {
        public static PatchConfig Instance;
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("InfernalEclipseArsenal")]
        [DefaultValue(true)]
        public bool RemovePipeSound { get; set; }
    }
}
