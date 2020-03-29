using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Accessories
{
	public class DungeonBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soldier's Diary");
			Tooltip.SetDefault("Guns have a chance to fire a homing soul\n'The diary of a long dead soldier, it is so beaten and battered you fear it will fall apart at any second'");
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 38;
			item.value = 25000;
			item.rare = 7;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().diary = true;
		}
	}
}
