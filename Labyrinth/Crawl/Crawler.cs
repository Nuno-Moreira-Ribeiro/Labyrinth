using Labyrinth.Items;
using Labyrinth.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth.Crawl
{
    public class Crawler : ICrawler
    {
        public static Direction START_DIRECTION = Direction.North;

        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public Tile FacingTile { get; set; }

        public Inventory Walk()
        {
            return new MyInventory();
        }

        public Crawler(int x, int y, Direction direction, Tile facingTile)
        {
            this.X = x;
            this.Y = y;
            this.Direction = START_DIRECTION;
            this.FacingTile = facingTile;
        }
    }
}
