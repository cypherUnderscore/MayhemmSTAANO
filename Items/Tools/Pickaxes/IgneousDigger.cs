using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MayhemmSTAANO.Items.Materials;

namespace MayhemmSTAANO.Items.Tools.Pickaxes
{
	public class IgneousDigger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Igneous Digger");
		}

		public override void SetDefaults()
		{
			item.damage = 13;
			item.melee = true;
			item.width = 36;
			item.height = 32;
			item.useTime = 12;
			item.useAnimation = 25;
			item.pick = 90;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 2500;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
		}

		public override void OnHitPvp(Player player, Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 16);
			recipe.AddIngredient(ModContent.ItemType<AshenTwig>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}