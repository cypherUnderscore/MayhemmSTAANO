using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Debug
{
	public class BuffTester : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BuffTester");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000;
			item.rare = 11;
			item.useStyle = 4;
			item.useTime = 30;
			item.useAnimation = 30;
			item.buffType = mod.BuffType("PerilCorrosion");
			item.buffTime = 300;
		}
	}
}
