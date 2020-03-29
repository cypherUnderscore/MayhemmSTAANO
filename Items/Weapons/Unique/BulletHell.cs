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

namespace MayhemmSTAANO.Items.Weapons.Unique
{
	public class BulletHell : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bullet Hell");
			Tooltip.SetDefault("Rapidly shoots a spread of 6 bullets");
		}

		public override void SetDefaults()
		{
			item.damage = 34;
			item.ranged = true;
			item.width = 46;
			item.height = 22;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 6;
			item.autoReuse = true;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 10f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Main.PlaySound(SoundID.Item38, player.position);
			Main.PlaySound(SoundID.Item41, player.position);
			Main.PlaySound(SoundID.Item12, player.position);

			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BulletHellProj"), damage, 0f, player.whoAmI);
			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage, 0f, player.whoAmI);
			}

			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;

			bool bulletDecider = Main.rand.NextBool();

			if (bulletDecider)
			{
				player.GetModPlayer<STAANOPlayer>().SixshooterSupershot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}
			else
			{
				player.GetModPlayer<STAANOPlayer>().SixshooterMisfire(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}

			for (int i = 0; i < 6; i++) //Muzzle flash using dust
			{
				int num3 = Dust.NewDust(position, 0, 0, 169, 0, 0, 0, default(Color), 2f);
				Main.dust[num3].velocity.X = (speedX * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.X;
				Main.dust[num3].velocity.Y = (speedY * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.Y;
				Main.dust[num3].position += muzzleOffset;
				Main.dust[num3].noGravity = true;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-0.1f, 0.1f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 25);
			recipe.AddIngredient(ItemID.Ectoplasm, 8);
			recipe.AddIngredient(null, "Unloader");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
