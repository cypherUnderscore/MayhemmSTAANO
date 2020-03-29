using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class baBlood : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood");
		}

		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.timeLeft = 150;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.magic = true;
			projectile.alpha = 155;
		}

		public override void AI()
		{
			projectile.rotation += 0.1f;
			for (int i = 0; i < 2; i++)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5, 0, 0, 200, default(Color), 1f);
				Main.dust[num1].velocity *= 0f;
			}
			projectile.velocity.Y += 0.1f;
			projectile.velocity.X *= 0.98f;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 5, projectile.velocity.X, projectile.velocity.Y, 155, default(Color), 1f);
			}
		}
	}
}
