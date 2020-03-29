using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Tools.MultiFunctionTools
{
	public class IcicleHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icicle Hamaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 43;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 30;
			item.hammer = 100;
			item.axe = 23;
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
			recipe.AddIngredient(null, "AshenTwig", 8);
			recipe.AddIngredient(null, "HellIce", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}