#pragma warning disable CA2255
using IEoR_CN.Systems;
using System.Collections.Generic;
using Terraria.ModLoader;
using System.Runtime.CompilerServices;
namespace IEoR_CN.HomewardRagnarokTranslator
{
	public class HomewardRagnarokTranslator
	{
		private class HomewardRagnarok{}
		[ExtendsFromMod("HomewardRagnarok"), JITWhenModsEnabled("HomewardRagnarok")]
		private class TranslatorLoad : ForceLocalizeSystem<HomewardRagnarok, TranslatorLoad>{}
		[ModuleInitializer]
		public static void LoadTranslator()
		{
			if(LoadModAssembly.LoadModContext.TryGetValue("HomewardRagnarok",out _))
			{
				#region HomewardRagnarok.Mods.BossChecklist.CoJBCLKeyChanger
				TranslatorLoad.LocalizeByTypeFullName("HomewardRagnarok.Mods.BossChecklist.CoJBCLKeyChanger", "IL_EditBossChecklistKeys", new ()
				{
					{"史莱姆之神：再临","Slime God: Rematch"},
				});
				#endregion HomewardRagnarok.Mods.BossChecklist.CoJBCLKeyChanger


			}
		}
	}
}
