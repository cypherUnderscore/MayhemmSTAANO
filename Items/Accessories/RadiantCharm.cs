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
	public class RadiantCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiant Charm");
			Tooltip.SetDefault("Magic projectiles have a chance to spawn stars from the sky\nMagic damage increased by 10%\nMagic critical stike chance increased by 5%");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 26;
			item.value = 5000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().radCharm = true;
			player.magicDamage += 0.1f;
			player.manaCost -= 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofLight, 8);
			recipe.AddIngredient(ItemID.CrystalShard, 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
