using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class Board : IBoard
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Tile> Tiles { get; private set; }
        private IRandomGenerator _random { get; }

        public Board(IRandomGenerator random, int width, int height)
        {
            _random = random;
            Width = width;
            Height = height;
            Tiles = new List<Tile>();
        }

        public void Initialize()
        {
            Tiles = new List<Tile>();

            for (int i = 0; i < Area; i++)
            {
                var isMine = _random.RandomBool();

                Tiles.Add(new Tile(isMine));
            }
        }

        /// <summary>
        /// Place a random mine in an unoccupied spot
        /// </summary>
        public void PlaceRandomMine()
        {
            while (true)
            {
                var tile = GetTile(_random.RandomInt(0, Area));

                if (tile.IsMine)
                    continue;

                tile.IsMine = true;

                break;
            }
        }

        public List<Tile> GetTiles()
        {
            return Tiles;
        }

        public Tile GetTile(int index)
        {
            return Tiles[index];
        }

        public Tile GetTile(int x, int y)
        {
            return Tiles[(x * y) + x];
        }

        // Derived

        public int Area
        {
            get
            {
                return Width * Height;
            }
        }

        public int MineCount
        {
            get
            {
                int count = 0;
                foreach(var tile in Tiles)
                {
                    if (tile.IsMine && !tile.IsRevealed)
                        count++;
                }
                return count;
            }
        }

        public int RevealedTilesCount
        {
            get
            {
                int count = 0;
                foreach (var tile in Tiles)
                {
                    if (tile.IsRevealed)
                        count++;
                }
                return count;
            }
        }

        public int MinesTotal
        {
            get
            {
                int count = 0;
                foreach (var tile in Tiles)
                {
                    if (tile.IsMine)
                        count++;

                }
                return count;
            }
        }
    }
}
