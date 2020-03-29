using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;

namespace MayhemmSTAANO.Projectiles
{
	public class FireTotem : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Totem");
		}

		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 26;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		int shootTimer = 25;

		public override void AI()
		{
			shootTimer--;
			if (shootTimer <= 0)
			{
				for (int s = 0; s < 2; s++)
				{
					Projectile.NewProjectile(new Vector2(projectile.position.X + (projectile.width * 0.5f), projectile.position.Y), new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, -8)), ModContent.ProjectileType<FireTotemProj>(), projectile.damage / 4, 0, projectile.owner);
				}
				shootTimer = Main.rand.Next(20, 30);
			}
			if(projectile.timeLeft < 30)
			{
				projectile.alpha += 15;
				projectile.damage = 0;
				shootTimer = 30;
			}
			projectile.velocity.Y += 0.1f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
