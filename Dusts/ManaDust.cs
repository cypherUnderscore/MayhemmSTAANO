using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Dusts
{
	public class ManaDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = true;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.99f;
			float light = 0.35f * dust.scale;
			Lighting.AddLight(dust.position, 50, 235, 255);
			if (dust.scale < 0.5f)
			{
				dust.active = false;
			}
			dust.alpha -= 255;
			return false;
		}
	}
}