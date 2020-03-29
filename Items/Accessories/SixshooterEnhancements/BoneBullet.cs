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
	public class BoneBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boney Bullet");
			Tooltip.SetDefault("5% increased ranged damage\nPrevents Sixshooter weapons from misfiring\nMisfires shoot a bone");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().preventMisfire = true;
			player.GetModPlayer<STAANOPlayer>().boneBullet = true;
			player.rangedDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 12);
			recipe.AddIngredient(ItemID.SilverBar, 6);
			recipe.AddIngredient(null, "AntiMisfire");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 12);
			recipe.AddIngredient(ItemID.TungstenBar, 6);
			recipe.AddIngredient(null, "AntiMisfire");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
