using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Buffs
{
	public class ManaSurgeCooldown : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Surge Cooldown");
			Description.SetDefault("You cannot use Mana Surge");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<STAANOPlayer>().manaSurgeCooldown = true;
		}
	}
}
