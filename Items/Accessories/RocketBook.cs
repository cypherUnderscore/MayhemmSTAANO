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
	public class RocketBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beginner's Guide to Rocket Weaponry");
			Tooltip.SetDefault("Guns have a chance to fire a rocket\n10% increased rocket damage\n'The Cyborg seems to have figured out some ungodly technique to fit a rocket inside the barrel of a gun'");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 38;
			item.value = 25000;
			item.rare = 8;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().rocketBook = true;
			player.rocketDamage *= 1.1f;
		}
	}
}
