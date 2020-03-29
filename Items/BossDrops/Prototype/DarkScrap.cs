using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.BossDrops.Prototype
{
	public class DarkScrap : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Tooltip.SetDefault("'A vial of intense colour'");
			DisplayName.SetDefault("Dark Scrap");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.maxStack = 99;
			item.value = 125;
			item.rare = 1;
		}
	}
}
