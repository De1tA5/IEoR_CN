using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using System.Reflection;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;
using Mono.Cecil.Cil;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace IEoR_CN.Localizationfix
{
    //抄Homeward Ragnarok的IL钩子修改
    public class CoJSlimeGod_Fix : ModSystem
    {

        public override void Load()
        {
            if (!ModLoader.HasMod("HomewardRagnarok"))
            {
                return;
            }
            Mod coJ;
            if (!ModLoader.TryGetMod("ContinentOfJourney", out coJ))
            {
                return;
            }
            Type bcClass = coJ.Code.GetType("ContinentOfJourney.CoJ_BossChecklist");
            if (bcClass == null)
            {
                return;
            }
            MethodInfo postSetup = bcClass.GetMethod("PostSetupContent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (postSetup == null)
            {
                return;
            }
            this.ilHook = new ILHook(postSetup, new ILContext.Manipulator(this.IL_EditBossChecklistKeys));
        }

            
        private void IL_EditBossChecklistKeys(ILContext il)
        {
            ILCursor c = new ILCursor(il);
            var array = new []
            {
                new
                {
                    Key = "CoJWallOfShadow",
                    Expected = 18.49f,
                    NewVal = 18.48f
                },
                new
                {
                    Key = "CoJOverwatcher",
                    Expected = 19.51f,
                    NewVal = 19.50f
                },
                new
                {
                    Key = "CoJMaterealizer",
                    Expected = 19.52f,
                    NewVal = 19.51f
                },
                new
                {
                    Key = "CoJLifebringer",
                    Expected = 19.53f,
                    NewVal = 19.52f
                },
                new
                {
                    Key = "CoJOrdeals",
                    Expected = 19.9f,
                    NewVal = 19.8f
                },
                new
                {
                    Key = "CoJScarabBelief",
                    Expected = 20.7f,
                    NewVal = 20.6f
                },
                new
                {
                    Key = "CoJWorldsEndEverlastingFallingWhale",
                    Expected = 21.7f,
                    NewVal = 21.6f
                },
                new
                {
                    Key = "CoJSon",
                    Expected = 23.6f,
                    NewVal = 23.5f
                }

            };

            c.Index = 0;
            Instruction instr;
            for (; ; )
            {
                ILCursor ilcursor = c;
                MoveType moveType = MoveType.After;
                Func<Instruction, bool>[] array2 = new Func<Instruction, bool>[1];
                array2[0] = (Instruction i) => ILPatternMatchingExt.MatchLdstr(i, "CoJSlimeGod");
                if (!ilcursor.TryGotoNext(moveType, array2))
                {
                    return;
                }
                int start = c.Index;
                int offset = 1;
                while (offset <= 80 && start + offset < il.Instrs.Count)
                {
                    instr = il.Instrs[start + offset];
                    if (instr.OpCode == OpCodes.Ldstr)
                    {
                        string strVal = instr.Operand as string;
                        if (strVal != null && (strVal.Contains("Mods.ContinentOfJourney.SG") || strVal.Contains("SG")))
                        {
                            goto IL_0128;
                        }
                    }
                    offset++;
                }
            }
            IL_0128:
            instr.Operand = "史莱姆之神 ： 再临";
        }


        public override void Unload()
        {
            ILHook ilhook = this.ilHook;
            if (ilhook != null)
            {
                ilhook.Dispose();
            }
            this.ilHook = null;
        }


        private ILHook ilHook;
    }
    
}
