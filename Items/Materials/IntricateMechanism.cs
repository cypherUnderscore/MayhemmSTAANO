using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Materials
{
	public class IntricateMechanism : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'An incredibly intricate mechanical contraption'");
			DisplayName.SetDefault("Intricate Mechanism");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 10;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ArcaneShard", 5);
			recipe.AddIngredient(null, "ReflectiveAlloy", 2);
			recipe.AddIngredient(ItemID.Wire, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
