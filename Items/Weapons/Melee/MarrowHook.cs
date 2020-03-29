using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using MayhemmSTAANO.Projectiles.Flails;

namespace MayhemmSTAANO.Items.Weapons.Melee
{
	public class MarrowHookItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marrow Hook");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 32;
			item.damage = 45;
			item.knockBack = 2;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.useTime = 4;
			item.useAnimation = 12;
			item.rare = 2;
			item.melee = true;
			item.shoot = mod.ProjectileType("MarrowHookHead");
			item.shootSpeed = 12.5f;
			item.channel = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, position, 1);
			for(int h = 0; h < 3; h++)
			{
				Vector2 spread = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
				spread *= Main.rand.NextFloat(0.5f, 1.5f);
				Projectile.NewProjectile(position.X, position.Y, spread.X, spread.Y, ModContent.ProjectileType<MarrowHookHead>(), damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PerilMaterial", 24);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
