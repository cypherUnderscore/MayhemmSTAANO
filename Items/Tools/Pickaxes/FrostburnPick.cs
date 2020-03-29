using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Tools.Pickaxes
{
	public class FrostburnPick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostburn Excavator");
		}

		public override void SetDefaults()
		{
			item.damage = 34;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 5;
			item.useAnimation = 25;
			item.pick = 220;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 15000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AshenTwig", 16);
			recipe.AddIngredient(null, "HellIce", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}