using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class InvisRad : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiation");
		}

		float size = 16;

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.magic = true;
			projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			projectile.alpha -= 255;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;;
			size += 0.7f;
			projectile.width = (int)size;
			projectile.height = (int)size;
			projectile.position.X -= 0.26f;
			projectile.position.Y -= 0.26f;
		}
	}
}
