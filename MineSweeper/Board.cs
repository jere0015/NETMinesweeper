using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class Board : IBoard
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dimensions">Width and height of the board</param>
        public Board(IRandomGenerator random)
        {
            Random = random;
            Tiles = new List<Tile>();
        }

        /// <summary>
        /// Initializes the board
        /// </summary>
        public void Initialize(int width, int height)
        {
            Width = width;
            Height = height;

            Tiles = new List<Tile>();

            for (int i = 0; i < Area; i++)
            {
                var isMine = Random.RandomBool();

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
                var tile = GetTile(Random.RandomInt(0, Area));

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


        public int Width { get; set; }
        public int Height { get; set; }
        public int Area { get => Width * Height; }

        public IRandomGenerator Random { get; }
        public List<Tile> Tiles { get; private set; }
    }

}
