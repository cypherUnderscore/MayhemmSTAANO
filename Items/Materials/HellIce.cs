using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Materials
{
	public class HellIce : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'A freezing cold substance, originating from the hottest depths of the Underworld'");
			DisplayName.SetDefault("Stygian Ice");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 22;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 7;
		}
	}
}
