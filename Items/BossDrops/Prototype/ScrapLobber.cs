using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.BossDrops.Prototype
{
	public class ScrapLobber : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Scrap Lobber");
			//Tooltip.SetDefault("Shoots a fireball");
		}

		public override void SetDefaults()
		{
			item.damage = 23;
			item.melee = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("Scrap1");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			damage /= 2;
			for(int s = 0; s < 3; s++)
			{
				Vector2 randomSpread = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
				int rand = Main.rand.Next(4);
				if (rand == 0)
				{
					type = mod.ProjectileType("Scrap1");
				}
				else if (rand == 1)
				{
					type = mod.ProjectileType("Scrap2");
				}
				else if (rand == 2)
				{
					type = mod.ProjectileType("Scrap3");
				}
				else if (rand == 3)
				{
					type = mod.ProjectileType("Scrap4");
				}
				Projectile.NewProjectile(position.X, position.Y, randomSpread.X, randomSpread.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}