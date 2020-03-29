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
	public class Unloader : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Unloader");
			Tooltip.SetDefault("Rapidly shoots a burst of 6 bullets");
		}

		int shotCount = 0;

		public override void SetDefaults()
		{
			item.damage = 18;
			item.ranged = true;
			item.width = 40;
			item.height = 22;
			item.useTime = 3;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.reuseDelay = 8;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 3000;
			item.rare = 3;
			item.autoReuse = true;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 10f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 18.4f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Main.PlaySound(SoundID.Item41, player.position);
			Main.PlaySound(SoundID.Item38, player.position);

			if (shotCount == 0) //Supershot
			{
				player.GetModPlayer<STAANOPlayer>().SixshooterSupershot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}

			shotCount++;

			if (shotCount == 6) //Misfire or special effects
			{
				player.GetModPlayer<STAANOPlayer>().SixshooterMisfire(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
				shotCount = 0;
			}
			
			for (int i = 0; i < 6; i++) //Muzzle flash using dust
			{
				int num2 = Dust.NewDust(position, 0, 0, 169, 0, 0, 0, default(Color), 1.5f);
				Main.dust[num2].velocity.X = (speedX * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.X;
				Main.dust[num2].velocity.Y = (speedY * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.Y;
				Main.dust[num2].position += muzzleOffset;
				Main.dust[num2].noGravity = true;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(6));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;

			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-0.1f, 0.1f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 1);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(null, "Chamberspin");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
