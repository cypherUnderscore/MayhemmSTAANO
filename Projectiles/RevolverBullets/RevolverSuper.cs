using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.RevolverBullets
{
	public class RevolverSuper : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bullet");
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.timeLeft = 600;
			projectile.penetrate = 2;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.ranged = true;
			projectile.extraUpdates = 5;
			projectile.light = 0.6f;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			int num1 = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 235, 0, 0, 0, default(Color), 1.2f);
			Main.dust[num1].velocity *= 0.1f;
			Main.dust[num1].noGravity = true;
		}
	}
}
