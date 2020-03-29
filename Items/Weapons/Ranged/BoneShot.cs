using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MayhemmSTAANO.Projectiles;

namespace MayhemmSTAANO.Items.Weapons.Ranged
{
	public class BoneShot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Shot");
		}

		public override void SetDefaults()
		{
			item.damage = 27;
			item.ranged = true;
			item.width = 24;
			item.height = 36;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 5000;
			item.rare = 1;
			item.autoReuse = true;
			item.shoot = 1;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 8f;
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
				type = ModContent.ProjectileType<BoneShotProj>();
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PerilMaterial", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}