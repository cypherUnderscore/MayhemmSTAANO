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
using Terraria.DataStructures;

namespace MayhemmSTAANO.Items.Weapons.Unique
{
	public class PBC : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Physics Breaker's Companion");
			Tooltip.SetDefault("Misfires and supershots become weird");
		}

		public override void SetDefaults()
		{
			item.damage = 43;
			item.ranged = true;
			item.width = 38;
			item.height = 20;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 3000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 18f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			float speedXStatic = speedX;
			float speedYStatic = speedY;

			int bulletType = 0;
			int bulletDecider = 0;
			bulletDecider = Main.rand.Next(5);

			if (bulletDecider == 0) //Supershot
			{
				item.useStyle = 1;
				item.noUseGraphic = true;
				player.GetModPlayer<STAANOPlayer>().SixshooterSupershot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
				type = mod.ProjectileType("PBCSuper");
				speedX *= 2;
				speedY *= 2;
				Main.PlaySound(SoundID.Item1, player.position);
			}

			if (bulletDecider == 1) //Misfire or special effects
			{
				item.useStyle = 1;
				item.noUseGraphic = true;
				bulletType = type;
				player.GetModPlayer<STAANOPlayer>().SixshooterMisfire(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
				type = 0;
				Projectile.NewProjectile(position.X, position.Y, speedXStatic, speedYStatic, mod.ProjectileType("PBCMis"), item.damage, 0f, player.whoAmI, (float)bulletType);
				Main.PlaySound(SoundID.Item1, player.position);
			}

			if(bulletDecider != 0 && bulletDecider != 1) //shitty code for sound lol
			{
				Main.PlaySound(SoundID.Item38, player.position);
				Main.PlaySound(SoundID.Item41, player.position);
				item.useStyle = 5;
				item.noUseGraphic = false;

				for (int i = 0; i < 6; i++) //Muzzle flash using dust
				{
					int num2 = Dust.NewDust(position, 0, 0, 127, 0, 0, 0, default(Color), 2f);
					Main.dust[num2].velocity.X = (speedX * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.X;
					Main.dust[num2].velocity.Y = (speedY * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.Y;
					Main.dust[num2].position += muzzleOffset;
					Main.dust[num2].noGravity = true;
				}
			}
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			for (int i = 0; i < 1000; ++i)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && (Main.projectile[i].type == mod.ProjectileType("PBCSuper") || Main.projectile[i].type == mod.ProjectileType("PBCMis")))
				{
					return false;
				}
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(1f, 0.1f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 250);
			recipe.AddIngredient(ItemID.ThrowingKnife);
			recipe.AddIngredient(ItemID.Grenade);
			recipe.AddIngredient(ItemID.SoulofLight, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
