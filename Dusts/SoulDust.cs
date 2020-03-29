using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Dusts
{
	public class SoulDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
			dust.rotation += Main.rand.NextFloat(6);
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.98f;
			dust.velocity *= 0.98f;
			dust.alpha -= 255;
			if (!dust.noGravity)
			{
				dust.velocity.Y += 0.1f;
			}
			if (dust.scale < 0.4f)
			{
				dust.active = false;
			}
			if (!dust.noLight)
			{
				Lighting.AddLight(dust.position, 0.2f, 0.2f, 0.2f);
			}
			return false;
		}
	}
}