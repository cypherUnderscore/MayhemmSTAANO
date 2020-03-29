using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Materials
{
	public class AshenTwig : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Too frail to be of any use in construction'");
			DisplayName.SetDefault("Ashen Twig");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.maxStack = 999;
			item.value = 150;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AshBlock);
			recipe.AddIngredient(ItemID.Hellstone);
			recipe.AddRecipeGroup("Wood", 2);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}
