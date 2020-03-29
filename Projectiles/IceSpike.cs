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
	public class IceSpike : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Spike");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 30;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.melee = true;
			projectile.alpha = 255;
		}

		public override void AI()
		{
			projectile.alpha -= 15;
			projectile.velocity *= 0.9f;
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
			for (int s = 0; s < 16; s++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<StyxIceDust>(), 0, 0, 0, default(Color), 0.6f);
				Main.dust[d].noGravity = true;
			}
			Main.PlaySound(SoundID.Item27, projectile.position);
		}
	}
}
