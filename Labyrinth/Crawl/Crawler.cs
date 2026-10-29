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

        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; }
        private Tile[,] Tiles { get; }
        public Tile FacingTile { 
            get {
                int targetX = X + Direction.DeltaX;
                int targetY = Y + Direction.DeltaY;

                if (targetY< 0 || targetX < 0 
                    || targetX >= Tiles.GetLength(0) 
                    || targetY >= Tiles.GetLength(1))
                {
                    return Outside.Singleton;
                }

                return Tiles[targetX, targetY];
            }
        }

        public Inventory Walk()
        {
            Inventory inventory = this.FacingTile.Pass();
            this.X += Direction.DeltaX;
            this.Y += Direction.DeltaY;
            return inventory;
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
