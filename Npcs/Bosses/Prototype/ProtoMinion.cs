using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
namespace MayhemmSTAANO.Npcs.Bosses.Prototype
{
	public class ProtoMinion : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Probe");
        }

		public override void SetDefaults() 
		{
            npc.width = 32;
            npc.height = 20;
            npc.damage = 12;
            npc.defense = 2;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.Item14;
            npc.knockBackResist = 0.2f;
            npc.aiStyle = 2;
            npc.noGravity = true;
		}

        public override void AI()
        {
            npc.rotation = (npc.velocity.X * 0.1f);
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.position, ItemID.Heart);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if(npc.life <= 0)
            {
                int g = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[g].velocity *= 0.4f;
                Gore gore85 = Main.gore[g];
                gore85.velocity.X = gore85.velocity.X + 1f;
                Gore gore86 = Main.gore[g];
                gore86.velocity.Y = gore86.velocity.Y + 1f;
                g = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[g].velocity *= 0.4f;
                Gore gore87 = Main.gore[g];
                gore87.velocity.X = gore87.velocity.X - 1f;
                Gore gore88 = Main.gore[g];
                gore88.velocity.Y = gore88.velocity.Y + 1f;
                g = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[g].velocity *= 0.4f;
                Gore gore89 = Main.gore[g];
                gore89.velocity.X = gore89.velocity.X + 1f;
                Gore gore90 = Main.gore[g];
                gore90.velocity.Y = gore90.velocity.Y - 1f;
                g = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[g].velocity *= 0.4f;
                Gore gore91 = Main.gore[g];
                gore91.velocity.X = gore91.velocity.X - 1f;
                Gore gore92 = Main.gore[g];
                gore92.velocity.Y = gore92.velocity.Y - 1f;

                for (int dn = 0; dn < 8; dn++)
                {
                    int d = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0, 0, 0, default(Color), 2f);
                    Main.dust[d].velocity *= 1.5f;
                    Main.dust[d].noGravity = true;

                    int d2 = Dust.NewDust(npc.position, npc.width, npc.height, 182, 0, 0, 0, default(Color), 2f);
                    Main.dust[d2].velocity *= 1.5f;
                    Main.dust[d2].noGravity = true;
                }
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.429f);
        }
    }
}