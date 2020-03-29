using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles;

namespace MayhemmSTAANO.Items.Weapons.Ranged
{
	public class Ashfrost : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ashfrost");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.ranged = true;
			item.width = 38;
			item.height = 24;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 15000;
			item.rare = 7;
			item.autoReuse = true;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, position, 41);
			Main.PlaySound(2, position, 106);
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 shootSpread = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(6));
			shootSpread *= Main.rand.NextFloat(0.75f, 1.2f);
			Projectile.NewProjectile(position, shootSpread, ModContent.ProjectileType<AshfrostBomb>(), (int)(damage * 0.66f), knockBack, player.whoAmI);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AshenTwig", 12);
			recipe.AddIngredient(null, "HellIce", 16);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}