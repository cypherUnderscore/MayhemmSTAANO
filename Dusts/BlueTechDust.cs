using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Dusts
{
	public class BlueTechDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.98f;
			dust.velocity *= 0.98f;
			if (!dust.noGravity)
			{
				dust.velocity.Y += 0.1f;
			}
			if (dust.scale < 0.2f)
			{
				dust.active = false;
			}
			if (!dust.noLight)
			{
				Lighting.AddLight(dust.position, 0, 0, 1f);
			}
			return false;
		}
	}
}