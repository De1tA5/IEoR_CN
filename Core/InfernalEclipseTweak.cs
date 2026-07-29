using CalamityMod;
using InfernalEclipseAPI.Core.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SOTS;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace IEoR_CN.Core
{
    public class ReaperToothTweak : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("SOTS") && ModLoader.HasMod("InfernalEclipseAPI");
        }
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            ModItem reaperToothNecklace;
            ModContent.TryFind<ModItem>("CalamityMod", "ReaperToothNecklace", out reaperToothNecklace);
            return entity.type == reaperToothNecklace.Type;
        }

        public override void SetDefaults(Item item)
        {
            enableNightmare = true;
        }

        #region 切换系统
        public bool enableNightmare;
        public override bool CanRightClick(Item item) => Main.keyState.PressingShift();
        public override void RightClick(Item item, Player player)
        {
            enableNightmare = !enableNightmare;
            item.NetStateChanged();
        }
        public override bool ConsumeItem(Item item, Player player) => false;
        public override void SaveData(Item item, TagCompound tag)
        {
            tag.Add("enableNightmare", enableNightmare);
        }
        public override void LoadData(Item item, TagCompound tag)
        {
            enableNightmare = tag.GetBool("enableNightmare");
        }
        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write(enableNightmare);
        }
        public override void NetReceive(Item item, BinaryReader reader)
        {
            enableNightmare = reader.ReadBoolean();
        }
        public override void PostDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            CalamityUtils.DrawInventoryDot(spriteBatch, position, new Vector2(16, 16) * Main.inventoryScale, enableNightmare);
        }
        #endregion

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            SOTSPlayer sotsPlayer = player.GetModPlayer<SOTSPlayer>();
            InfernalPlayer infernalPlayer = player.GetModPlayer<InfernalPlayer>();
            if (!enableNightmare) 
            {
                sotsPlayer.CritNightmare = false;
                infernalPlayer.CritNightmare = false;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            //硬编码真爽
            TooltipLine toggleTooltip = new TooltipLine(Mod, "ToggleNightmare", "[c/aaaaaa:在物品栏中按住Shift右键切换启用][i:SOTS/MidnightPrism][c/aaaaaa:午夜棱镜]");
            TooltipLine enableTooltip = new TooltipLine(Mod, "EnableNightmare", "[C/64F83C:已启用][i:SOTS/MidnightPrism][C/64F83C:午夜棱镜暴击效果]");
            TooltipLine disableTooltip = new TooltipLine(Mod, "DisableNightmare", "[C/F83C3C:已禁用][i:SOTS/MidnightPrism][C/F83C3C:午夜棱镜暴击效果]");

            int lastIndex = -1;
            for (int i = 0; i < tooltips.Count; i++) 
            {
                if (tooltips[i].Mod == "Terraria" && tooltips[i].Name.Contains("Tooltip")) 
                {
                    lastIndex = i;
                }
                
            }
            if (lastIndex != -1) 
            {
                tooltips.Insert(lastIndex, toggleTooltip);
            }


            if (enableNightmare)
            {
                tooltips.Insert(lastIndex + 1, enableTooltip);
            }
            else 
            {
                tooltips.Insert(lastIndex + 1, disableTooltip);
            }
        }
    }
}
