using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using MayhemmSTAANO.Items.Accessories.SixshooterEnhancements;
using MayhemmSTAANO.Items.Accessories;
using MayhemmSTAANO.Items.Materials;
using MayhemmSTAANO.Items.Weapons.Ranged;
using MayhemmSTAANO.Npcs.Bosses.Prototype;
using MayhemmSTAANO.Items.Weapons.Dedicated;

namespace MayhemmSTAANO.Npcs
{
	public class GlobalNpc : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		public bool perilCorrosion = false;
		public bool dissolving = false;

		public override void NPCLoot(NPC npc)
		{
			if(npc.type == NPCID.Reaper)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TortureSoul"), Main.rand.Next(3) + 1);
			}

			if (npc.type == NPCID.Mothron)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TortureSoul"), Main.rand.Next(10) + 6);
			}

			if ((npc.type == NPCID.SkeletonCommando || npc.type == NPCID.SkeletonSniper || npc.type == NPCID.TacticalSkeleton) && Main.rand.Next(29) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DungeonBook"), 1);
			}

			if ((npc.type == NPCID.BloodZombie || npc.type == NPCID.Drippler) && Main.rand.Next(50) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodAmalgam"));
			}

			//if(Main.player[Main.myPlayer].ZoneUnderworldHeight)

			if ((npc.type == NPCID.LavaSlime || npc.type == NPCID.Lavabat || npc.type == NPCID.Hellbat) && NPC.downedBoss3)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<MagmaCrystal>(), Main.rand.Next(1, 2));
			}

			if(npc.type == NPCID.KingSlime && Main.rand.NextBool())
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<GelFlask>());
			}

			if(Main.rand.Next(10000) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<JaredSword>());
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.ArmsDealer)
			{
				if (NPC.downedSlimeKing == true)
				{
					shop.item[nextSlot].SetDefaults(ItemType<GunPaper>());
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++;
				}

				if (NPC.downedBoss1 == true)
				{
					shop.item[nextSlot].SetDefaults(ItemType<AntiMisfire>());
					shop.item[nextSlot].shopCustomPrice = 50000;
					nextSlot++;
				}

				if (NPC.downedBoss2)
				{
					shop.item[nextSlot].SetDefaults(ItemType<Autocannon>());
					shop.item[nextSlot].shopCustomPrice = 200000;
					nextSlot++;
				}

				if(NPC.downedFishron == true)
				{
					shop.item[nextSlot].SetDefaults(ItemType<DukeBullet>());
					shop.item[nextSlot].shopCustomPrice = 750000;
					nextSlot++;
				}
			}

			if (type == NPCID.GoblinTinkerer)
			{
				if (NPC.downedBoss1 == true)
				{
					shop.item[nextSlot].SetDefaults(ItemType<GunBlueprints>());
					shop.item[nextSlot].shopCustomPrice = 250000;
					nextSlot++;
				}
			}

			if (type == NPCID.Cyborg)
			{
				if (NPC.downedGolemBoss == true)
				{
					shop.item[nextSlot].SetDefaults(ItemType<RocketBook>());
					shop.item[nextSlot].shopCustomPrice = 500000;
					nextSlot++;
				}
			}

			if(type == NPCID.DyeTrader || type == NPCID.Painter)
			{
				shop.item[nextSlot].SetDefaults(ItemType<BrilliantPaste>());
				shop.item[nextSlot].shopCustomPrice = 500;
				nextSlot++;
			}

			if (type == NPCID.Merchant)
			{
				if (NPC.downedBoss1)
				{
					shop.item[nextSlot].SetDefaults(ItemType<ProtoSummon>());
					shop.item[nextSlot].shopCustomPrice = 25000;
					nextSlot++;
				}
				if (Main.hardMode == true)
				{
					shop.item[nextSlot].SetDefaults(ItemType<GleamingPowder>());
					shop.item[nextSlot].shopCustomPrice = 1000;
					nextSlot++;
				}
			}
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (perilCorrosion)
			{
				npc.lifeRegen -= 20;
				if (damage < 2)
				{
					damage = 4;
				}
				npc.defense -= 12;
			}

			if (dissolving)
			{
				npc.lifeRegen -= 20;
				if (damage < 2)
				{
					damage = 4;
				}
				npc.defense -= 12;
			}
		}
	}
}
