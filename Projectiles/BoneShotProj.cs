using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Dusts;
using MayhemmSTAANO.Buffs;

namespace MayhemmSTAANO.Projectiles
{
	public class BoneShotProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arrow");
		}

		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.timeLeft = 600;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.ranged = true;
			projectile.extraUpdates = 2;
			projectile.alpha = 0;
		}

		public override void AI()
		{
			projectile.velocity.Y += 0.025f;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			int d = Dust.NewDust(projectile.Center, 0, 0, ModContent.DustType<PerilAcidDust>(), 0, 0, 155, default(Color), 1.5f);
			Main.dust[d].position = projectile.Center;
			Main.dust[d].velocity *= 0f;
			Main.dust[d].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<PerilCorrosion>(), 300);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<PerilCorrosion>(), 300);
		}
	}
}
