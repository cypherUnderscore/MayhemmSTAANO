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
	public class GunBlueprints : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prototype Revolver Blueprints");
			Tooltip.SetDefault("Supershots and misfires shoot damaging, lingering sparks");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 30;
			item.value = 5000;
			item.rare = 1;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().gunBlueprints = true;
		}
	}
}
