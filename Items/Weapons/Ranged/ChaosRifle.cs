using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Weapons.Ranged
{
	public class ChaosRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bringer of Chaos");
			Tooltip.SetDefault("Fires a barrage of chaos");
		}

		public override void SetDefaults()
		{
			item.damage = 112;
			item.ranged = true;
			item.width = 54;
			item.height = 20;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 1000;
			item.rare = 10;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ChaosLaser");
			item.shootSpeed = 12f;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				item.useTime = 10;
				item.useAnimation = 10;
				item.UseSound = SoundID.Item61;
				item.shoot = mod.ProjectileType("ChaosMine");
			}
			else
			{
				item.useTime = 20;
				item.useAnimation = 20;
				item.shoot = mod.ProjectileType("ChaosLaser");
				item.UseSound = null;
			}
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
				if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
				{
					position += muzzleOffset;
				}

				for (int i = 0; i < 4; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
					float scale = 1f - (Main.rand.NextFloat() * .4f);
					perturbedSpeed = perturbedSpeed * scale;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage / 3, 0f, player.whoAmI);
				}

				for (int i = 0; i < 16; i++) //Muzzle flash using dust
				{
					int num2 = Dust.NewDust(position, 0, 0, 74, 0, 0, 0, default(Color), 0.8f);
					Main.dust[num2].velocity.X = (speedX * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.X;
					Main.dust[num2].velocity.Y = (speedY * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.Y;
					Main.dust[num2].noGravity = true;
				}

				return false;
			}
			else
			{
				Main.PlaySound(SoundID.Item98, player.position);
				Main.PlaySound(SoundID.Item125, player.position);
				Main.PlaySound(SoundID.Item84, player.position);

				Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
				if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
				{
					position += muzzleOffset;
				}
				for (int i = 0; i < 3; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
					float scale = 1f - (Main.rand.NextFloat() * .4f);
					perturbedSpeed = perturbedSpeed * scale;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("ChaosBomb"), damage / 3, 0f, player.whoAmI);
				}

				for (int i = 0; i < 16; i++) //Muzzle flash using dust
				{
					int num2 = Dust.NewDust(position, 0, 0, 74, 0, 0, 0, default(Color), 0.8f);
					Main.dust[num2].velocity.X = (speedX * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.X;
					Main.dust[num2].velocity.Y = (speedY * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.Y;
					Main.dust[num2].noGravity = true;
				}
				return true;
			}
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5f, 0f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(ItemID.FragmentVortex, 25);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}