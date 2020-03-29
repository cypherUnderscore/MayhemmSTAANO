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
	public class BloodAmalgam : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Amalgam");
			Tooltip.SetDefault("Magic projectiles split into blood\n5% increased magic damage\n5% decreased mana use");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 5000;
			item.rare = 1;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().ba = true;
			player.magicDamage += 0.05f;
			player.manaCost -= 0.05f;
		}
	}
}
