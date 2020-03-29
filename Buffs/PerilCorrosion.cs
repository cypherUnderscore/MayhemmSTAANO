using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Npcs;

namespace MayhemmSTAANO.Buffs
{
	public class PerilCorrosion : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Peril Corrosion");
			Description.SetDefault("You are dissolving");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<STAANOPlayer>().perilCorrosion = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<GlobalNpc>().perilCorrosion = true;
		}
	}
}
