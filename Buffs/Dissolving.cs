using Terraria;
using Terraria.ModLoader;
using MayhemmSTAANO.Npcs;

namespace MayhemmSTAANO.Buffs
{
	public class Dissolving : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dissolving");
			Description.SetDefault("Your soul is being dissolved");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<STAANOPlayer>().dissolving = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<GlobalNpc>().dissolving = true;
		}
	}
}
