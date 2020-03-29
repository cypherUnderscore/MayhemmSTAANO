using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using MayhemmSTAANO.Npcs.Bosses.Prototype;
using MayhemmSTAANO.Items.BossDrops.Prototype;
using System.Collections.Generic;

namespace MayhemmSTAANO
{
	public class MayhemmSTAANO : Mod
	{
		public static ModHotKey ManaSurgeHotkey;
		public MayhemmSTAANO()
		{

		}

		public override void Load()
		{
			ManaSurgeHotkey = RegisterHotKey("Mana Surge", "Y");
		}

		public override void Unload()
		{
			ManaSurgeHotkey = null;
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Ore", new int[]
			{
				ItemID.CopperOre,
				ItemID.TinOre,
				ItemID.IronOre,
				ItemID.LeadOre,
				ItemID.SilverOre,
				ItemID.TungstenOre,
				ItemID.GoldOre,
				ItemID.PlatinumOre,
			});
			RecipeGroup.RegisterGroup("MayhemmSTAANO:AnyOre", group);
		}

		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddMiniBoss",
					2.2f,
					ModContent.NPCType<PrototypeMain>(),
					this,
					"The Prototype",
					(Func<bool>)(() => STAANOWorld.downedProto),
					ModContent.ItemType<ProtoSummon>(),
					new List<int> { ModContent.ItemType<ProtoTrophyItem>()/*, ModContent.ItemType<Items.WolfMask>()*/ },
					new List<int> { ModContent.ItemType<ProtoPulsar>(), ModContent.ItemType<PortalCore>(), ModContent.ItemType<ScrapLobber>(), ModContent.ItemType<DarkScrap>(), ModContent.ItemType<BoltSwarm>() },
					"Summoned using a [i:" + ItemType("ProtoSummon") + "]",
					"Prototype has terminated all aggressors",
					default,
					default,
					true
				);
			}
		}
	}
}