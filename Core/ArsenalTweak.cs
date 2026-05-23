using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using InfernalEclipseWeaponsDLC.Content.Projectiles.BardPro;
using MonoMod.RuntimeDetour;
using System.Reflection;

namespace IEoR_CN.Core
{
    [JITWhenModsEnabled("InfernalEclipseWeaponsDLC")]
    [ExtendsFromMod("InfernalEclipseWeaponsDLC")]
    public class ArsenalTweak:ModSystem
    {
        public delegate void Orig_MetalPipe_OnKill(MetalPipe self, int timeLeft);

        private static Hook onKillHook;
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("InfernalEclipseWeaponsDLC");
        }

        public override void Load()
        {
            if (!ModLoader.HasMod("InfernalEclipseWeaponsDLC"))
                return;

            MethodInfo method = typeof(MetalPipe)?.GetMethod("OnKill", BindingFlags.Public | BindingFlags.Instance);

            if (method is not null)
                onKillHook = new Hook(method,On_MetalPipe_OnKill);
        }

        public override void Unload()
        {
            onKillHook?.Dispose();
            onKillHook = null;
        }

        private static void On_MetalPipe_OnKill(Orig_MetalPipe_OnKill orig, MetalPipe self, int timeLeft) 
        {
            Projectile projectile = self.Projectile;
            ParticleOrchestrator.RequestParticleSpawn(false, 0, new ParticleOrchestraSettings()
            {
                PositionInWorld = projectile.Center
            }, new int?(projectile.owner));

            Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Ash, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, Color.White, 1.2f);
            if (!PatchConfig.Instance.RemovePipeSound)
                SoundEngine.PlaySound(new SoundStyle("InfernalEclipseWeaponsDLC/Assets/Sounds/MetalPipe") { Volume = 10f }, new Vector2?(projectile.position));
        }
    }
}
