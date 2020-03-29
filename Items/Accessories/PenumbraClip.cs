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
	public class PenumbraClip : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Penumbra Clip");
			Tooltip.SetDefault("15% increased ranged damage\nPrevents Sixshooter weapons from misfiring\nMisfires shoot a dark beam and an eclipse grenade, super shots become light beams\n'When the Sun falls dark, nothing can protect you from my wrath'");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 25000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().preventMisfire = true;
			player.GetModPlayer<STAANOPlayer>().equinoxChamber = true;
			player.GetModPlayer<STAANOPlayer>().darkClip = true;
			player.rangedDamage += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TortureSoul", 32);
			recipe.AddIngredient(null, "FlamingBulletPouch");
			recipe.AddIngredient(null, "EquinoxChamber");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
