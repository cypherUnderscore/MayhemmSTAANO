using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Materials
{
	public class MagmaCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Too hot to touch'");
			DisplayName.SetDefault("Magma Crystal");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.maxStack = 99;
			item.value = 250;
			item.rare = 2;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Materials/MagmaCrystal");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}
	}
}
