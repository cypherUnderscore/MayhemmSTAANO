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
using MayhemmSTAANO.Items.Materials;

namespace MayhemmSTAANO.Items.Accessories
{
	public class IceFlask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Permafrost Flask");
			Tooltip.SetDefault("'A flask filled with eternally frozen ice'\nIncreased magic abilities\nMagic attacks have a chance to frostburn enemies\nMagic damage has a chance to spawn frost fire around the hit enemy");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = 5000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<STAANOPlayer>().iceFlask = true;
			player.GetModPlayer<STAANOPlayer>().frostFlare = true;
			player.magicCrit += 10;
			player.magicDamage *= 1.15f;
			player.manaCost *= 0.85f;
			player.statManaMax2 += 40;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ectoplasm, 12);
			recipe.AddIngredient(ModContent.ItemType<HellIce>(), 18);
			recipe.AddIngredient(ModContent.ItemType<MagmaFlask>());
			recipe.AddIngredient(ModContent.ItemType<FrostFlare>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
