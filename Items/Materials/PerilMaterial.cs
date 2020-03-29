using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Materials
{
	public class PerilMaterial : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'A horrible amalgam of flesh and bone'");
			DisplayName.SetDefault("Perilous Biomass");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 10;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 2;
		}
	}
}
