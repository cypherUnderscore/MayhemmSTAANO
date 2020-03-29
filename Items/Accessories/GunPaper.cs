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
	public class GunPaper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Firearms Manual");
			Tooltip.SetDefault("10% increased bullet damage");
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
			player.bulletDamage *= 1.1f;
		}
	}
}
