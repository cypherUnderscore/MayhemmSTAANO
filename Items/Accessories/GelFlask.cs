using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Accessories
{
	public class GelFlask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Concentrated Gel Flask");
			Tooltip.SetDefault("'A flask full of magical gel'\nSlight increases to magic abilities");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 5000;
			item.rare = 1;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 2;
			player.magicDamage *= 1.04f;
			player.manaCost *= 0.95f;
			player.statManaMax2 += 10;
		}
	}
}
