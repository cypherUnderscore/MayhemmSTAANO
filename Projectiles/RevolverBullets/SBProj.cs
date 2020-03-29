using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.RevolverBullets
{
	public class SBProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shade");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.timeLeft = 300;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.ranged = true;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, 1, 0.1f, 1);
			projectile.alpha -= 255;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, 0, 0, 0, default(Color), 1.2f);
			Main.dust[num1].velocity *= 0.2f;
			Main.dust[num1].noGravity = true;
		}
	}
}
