using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles;
using MayhemmSTAANO.Projectiles.Explosions;

namespace MayhemmSTAANO.Projectiles
{
	public class GlobalProj : GlobalProjectile
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		public bool CanTriggerOnHitEffects(int type) //determines whether the projectile can trigger special effects on hit
		{
			if (
				type == ModContent.ProjectileType<SoulOrb>() ||
				type == ModContent.ProjectileType<baBlood>() ||
				type == ModContent.ProjectileType<RadiantCharmProj>() ||
				type == ModContent.ProjectileType<SoulTotem>() ||
				type == ModContent.ProjectileType<FireTotem>() ||
				type == ModContent.ProjectileType<FireTotemProj>() ||
				type == ModContent.ProjectileType<FrostFlareProj>() ||
				type == ModContent.ProjectileType<GenericExplodeFriendly>() ||
				type == ModContent.ProjectileType<CoronaExplosion>() ||
				type == ModContent.ProjectileType<ChaosExplosion>() ||
				type == ModContent.ProjectileType<PerilAcidExplosion>()
			)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
