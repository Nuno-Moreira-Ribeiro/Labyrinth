using Labyrinth.Items;
using Labyrinth.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth.Crawl
{
    public class Crawler : ICrawler
    {
        public static Direction StartDirection => Direction.North;

        public int X { get; }
        public int Y { get; }
        public Direction Direction { get; }
        private Tile[,] Tiles { get; }
        public Tile FacingTile { 
            get {
                int targetX = X + Direction.DeltaX;
                int targetY = Y + Direction.DeltaY;

                if (targetY< 0 || targetX < 0 || targetX >= Tiles.GetLength(0))
                {
                    return Outside.Singleton;
                }

                return Tiles[targetX, targetY];
            }
        }

        public Inventory Walk()
        {
            return new MyInventory();
        }

        public Crawler(int x, int y, Direction direction, Tile[,] tiles)
        {
            this.X = x;
            this.Y = y;
            this.Direction = StartDirection;
            this.Tiles = tiles;
        }
    }
}
