using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Materials
{
	public class ReflectiveAlloy : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'A bar of incredibly shiny metal'");
			DisplayName.SetDefault("Reflective Alloy");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 16;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrilliantPaste");
			recipe.AddIngredient(null, "ArcaneShard", 3);
			recipe.AddIngredient(null, "GleamingPowder");
			recipe.AddRecipeGroup("MayhemmSTAANO:AnyOre", 4);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
