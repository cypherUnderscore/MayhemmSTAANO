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

namespace MayhemmSTAANO.Items.Accessories.SixshooterEnhancements
{
	public class DukeBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trufflesteel Shot");
			Tooltip.SetDefault("Misfires and supershots create a mini razorblade typhoon");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 10000;
			item.rare = 7;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().dukeBullet = true;
		}
	}
}
