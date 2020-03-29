using Terraria;
using Terraria.ModLoader;

namespace MayhemmSTAANO.Buffs
{
	public class ManaSurge : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mana Surge");
			Description.SetDefault("Your magic abilities are enhanced");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<STAANOPlayer>().manaSurge = true;
		}
	}
}
