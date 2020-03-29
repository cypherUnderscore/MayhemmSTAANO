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
	public class EquinoxChamber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Equinox Chamber");
			Tooltip.SetDefault("10% increased ranged damage\nPrevents Sixshooter weapons from misfiring\nMisfires shoot a dark beam and a bone, super shots become light beams\n'Light and dark are mortal enemies, but working together great things can be accomplished'");
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
			player.rangedDamage += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DarkShard);
			recipe.AddIngredient(ItemID.LightShard);
			recipe.AddIngredient(null, "BoneBullet");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
