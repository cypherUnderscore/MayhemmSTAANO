﻿using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Dusts
{
	public class StyxWaterDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = false;
			dust.noLight = true;
			dust.alpha = 155;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.97f;
			dust.velocity *= 0.98f;
			if (!dust.noGravity)
			{
				dust.velocity.Y += 0.1f;
			}
			if (dust.scale < 0.5f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}