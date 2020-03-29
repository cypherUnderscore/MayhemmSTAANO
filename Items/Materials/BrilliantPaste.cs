using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Materials
{
	public class BrilliantPaste : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'A vial of intense colour'");
			DisplayName.SetDefault("Brilliant Paste");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 20;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 1;
		}
	}
}
