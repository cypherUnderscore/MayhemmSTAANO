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
	public class SingularityMag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Singularity Magazine");
			Tooltip.SetDefault("20% increased ranged damage\nPrevents Sixshooter weapons from misfiring\nMisfires shoot a dark beam and an eclipse grenade, super shots become light beams\nGuns have a chance to fire a rocket or a lost soul\nMisfires and super shots fire sparks and a razorblade typhoon\nBullets have a chance to become Flaming Bullets");
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
			player.GetModPlayer<STAANOPlayer>().diary = true;
			player.GetModPlayer<STAANOPlayer>().gunBlueprints = true;
			player.GetModPlayer<STAANOPlayer>().rocketBook = true;
			player.GetModPlayer<STAANOPlayer>().dukeBullet = true;
			player.GetModPlayer<STAANOPlayer>().fireBullets = true;
			player.rangedDamage += 0.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ExpertGunBook");
			recipe.AddIngredient(null, "FlamingBulletPouch");
			recipe.AddIngredient(null, "PenumbraClip");
			recipe.AddIngredient(null, "DukeBullet");
			recipe.AddIngredient(ItemID.FragmentVortex, 25);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
