using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Projectiles
{
	public class MagmaticStaffProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flare");
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.magic = true;
		}

		public override void AI()
		{
			projectile.rotation += 0.1f;
			for (int i = 0; i < 2; i++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0, 0, 0, default(Color), 2f);
				Main.dust[d].velocity *= 0f;
				Main.dust[d].noGravity = true;
			}

			for(int t = 0; t < 200; t++)
			{
				float distToX = Main.npc[t].position.X + (float)Main.npc[t].width * 0.5f - projectile.Center.X;
				float distToY = Main.npc[t].position.Y + (float)Main.npc[t].height * 0.5f - projectile.Center.Y;
				float distance = (float)System.Math.Sqrt((double)(distToX * distToX + distToY * distToY));

				if(distance < 500 && !Main.npc[t].friendly && Main.npc[t].lifeMax > 5 && Main.npc[t].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[t].Center, 1, 1))
				{
					Vector2 desiredVelocity = Vector2.Normalize(new Vector2(distToX / distance, distToY / distance));

					projectile.velocity += desiredVelocity / 8;

					Vector2 maxVel = Vector2.Normalize(new Vector2(1, 1)) * 8;
					
					if(projectile.velocity.X > maxVel.X)
					{
						projectile.velocity.X = maxVel.X;
					}
					else if (projectile.velocity.Y > maxVel.Y)
					{
						projectile.velocity.Y = maxVel.Y;
					}
					else if (projectile.velocity.X < -maxVel.X)
					{
						projectile.velocity.X = -maxVel.X;
					}
					else if (projectile.velocity.Y < -maxVel.Y)
					{
						projectile.velocity.Y = -maxVel.Y;
					}
					return;
				}
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
			}
		}
	}
}
