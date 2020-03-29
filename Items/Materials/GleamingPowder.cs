using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Materials
{
	public class GleamingPowder : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'A pile of fine, shiny powder'");
			DisplayName.SetDefault("Gleaming Powder");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 16;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amethyst);
			recipe.AddIngredient(ItemID.Topaz);
			recipe.AddIngredient(ItemID.Emerald);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddIngredient(ItemID.Ruby);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 15);
			recipe.AddRecipe();
		}
	}
}
