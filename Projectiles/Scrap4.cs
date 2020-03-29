using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Projectiles
{
	public class Scrap4 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scrap");
		}

		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 6;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.melee = true;
		}

		public override void AI()
		{
			projectile.velocity.Y += 0.2f;
			projectile.rotation += projectile.velocity.X / 25;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = -oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = -oldVelocity.Y;
			}
			projectile.velocity *= 0.7f;
			return false;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, projectile.position);
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
		}
	}
}
