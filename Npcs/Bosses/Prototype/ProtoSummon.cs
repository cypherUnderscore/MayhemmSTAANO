using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Npcs.Bosses.Prototype
{
	public class ProtoSummon : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'The data contained is highly encrypted'");
			DisplayName.SetDefault("Suspicious Coordinate Chip");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 16;
			item.maxStack = 30;
			item.value = 1000;
			item.rare = 1;
			item.useStyle = 4;
			item.useTime = 45;
			item.useAnimation = 45;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("PrototypeMain"));
			}
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (!NPC.AnyNPCs(mod.NPCType("PrototypeMain")))
			{
				return true;
			}
			return false;
		}
	}
}
