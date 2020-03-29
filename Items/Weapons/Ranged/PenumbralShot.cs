using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Items.Weapons.Ranged
{
	public class PenumbralShot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Penumbral Shot");
			Tooltip.SetDefault("Every fourth shot fires a penumbral star");
		}

		public override void SetDefaults()
		{
			item.damage = 46;
			item.ranged = true;
			item.width = 20;
			item.height = 48;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 5000;
			item.rare = 5;
			item.autoReuse = true;
			item.shoot = 1;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 10f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		int shotCount = 0;

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(SoundID.Item5, player.position);
			shotCount++;
			if (shotCount >= 4)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX / 1.2f, speedY / 1.2f, mod.ProjectileType("PenumbralStar"), damage, 0f, player.whoAmI);
				shotCount = 0;
				Main.PlaySound(SoundID.Item117, player.position);
			}
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TortureSoul", 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}