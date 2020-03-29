using Terraria.ModLoader;
using MayhemmSTAANO.Tiles.Trophies;

namespace MayhemmSTAANO.Items.BossDrops.Prototype
{
    public class ProtoTrophyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Prototype Trophy");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 50000;
            item.rare = 1;
            item.createTile = ModContent.TileType<ProtoTrophyTile>();
            item.placeStyle = 0;
        }
    }
}
