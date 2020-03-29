using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MayhemmSTAANO.Items.Materials;

namespace MayhemmSTAANO.Items.Weapons.Ranged
{
	public class LavaCrossbow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lava Crossbow");
			Tooltip.SetDefault("Turns wooden arrows into hellfire arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 29;
			item.ranged = true;
			item.width = 24;
			item.height = 36;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 2500;
			item.rare = 2;
			item.autoReuse = true;
			item.shoot = 1;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 10f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Main.PlaySound(SoundID.Item5, player.position);
			if(type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.HellfireArrow;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 18);
			recipe.AddIngredient(ModContent.ItemType<AshenTwig>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}