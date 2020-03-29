using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.RevolverBullets
{
	public class BoneBulletProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 240;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.ranged = true;
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if(projectile.ai[0] >= 20)
			{
				projectile.velocity.Y = projectile.velocity.Y += 0.1f;
				projectile.velocity.X *= 0.993f;
			}
			projectile.rotation += projectile.velocity.X * 0.03f;
			if (projectile.velocity.Y >= 8f)
			{
				projectile.velocity.Y = 8f;
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, projectile.position);
		}
	}
}