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
	public class StygianSprayProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water");
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.timeLeft = 240;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.magic = true;
			projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			projectile.rotation += 0.1f;
			for (int i = 0; i < 2; i++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<StyxWaterDust>(), 0, 0, 0, default(Color), 1.6f);
				Main.dust[d].velocity *= 0f;
				Main.dust[d].noGravity = true;
			}
			projectile.velocity.Y += 0.03f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Dissolving>(), 60);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Dissolving>(), 60);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<StyxWaterDust>(), projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
			}
		}
	}
}
