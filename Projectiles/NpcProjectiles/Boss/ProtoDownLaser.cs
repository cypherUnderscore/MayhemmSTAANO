using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles.NpcProjectiles.Boss
{
	public class ProtoDownLaser : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void AI()
		{
			projectile.alpha -= 255;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;;

			int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 182, 0, 0, 0, default(Color), 2f);
			Main.dust[d].velocity *= 0f;
			Main.dust[d].noGravity = true;
			Main.dust[d].position = projectile.Center;
		}
	}
}
