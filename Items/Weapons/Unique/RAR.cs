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
	public class RAR : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("R.A.R");
			Tooltip.SetDefault("'It's nerf or nothing'");
		}

		public override void SetDefaults()
		{
			item.damage = 23;
			item.ranged = true;
			item.width = 38;
			item.height = 20;
			item.useTime = 7;
			item.useAnimation = 7;
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
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 23f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Main.PlaySound(SoundID.Item11, player.position);

			int bulletDecider = 0;
			bulletDecider = Main.rand.Next(5);

			if (bulletDecider == 0) //Supershot
			{
				player.GetModPlayer<STAANOPlayer>().SixshooterSupershot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
				damage /= 2;
			}

			if (bulletDecider == 1) //Misfire or special effects
			{
				player.GetModPlayer<STAANOPlayer>().SixshooterMisfire(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
				damage *= 2;
			}	

			for (int i = 0; i < 6; i++) //Muzzle flash using dust
			{
				int num2 = Dust.NewDust(position, 0, 0, 127, 0, 0, 0, default(Color), 2f);
				Main.dust[num2].velocity.X = (speedX * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.X;
				Main.dust[num2].velocity.Y = (speedY * Main.rand.NextFloat(0.6f) + 0.1f) + player.velocity.Y;
				Main.dust[num2].position += muzzleOffset;
				Main.dust[num2].noGravity = true;
			}

			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 1);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(null, "IntricateMechanism", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
