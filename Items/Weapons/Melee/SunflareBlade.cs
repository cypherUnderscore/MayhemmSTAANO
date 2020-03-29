using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Weapons.Melee
{
	public class SunflareBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sunflare Blade");
			Tooltip.SetDefault("Shoots a fireball");
		}

		public override void SetDefaults()
		{
			item.damage = 65;
			item.melee = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 24;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("SunflareBladeProj");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 shootOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
			if (Collision.CanHit(position, 0, 0, position + shootOffset, 0, 0))
			{
				position += shootOffset;
			}
			for (int i = 0; i < 12; i++)
			{
				int num1 = Dust.NewDust(position, 0, 0, 159, Main.rand.Next(8) - 4, Main.rand.Next(8) - 4, 0, default(Color), 2f);
				Main.dust[num1].noGravity = true;
			}
			Main.PlaySound(SoundID.Item103, player.position);
			damage *= 2;
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TortureSoul", 18);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}