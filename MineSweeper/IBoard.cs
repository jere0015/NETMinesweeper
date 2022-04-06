using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public interface IBoard
    {
        public void Initialize();

        public void PlaceRandomMine();

        public List<Tile> GetTiles();

        public Tile GetTile(int x, int y);

        public Tile GetTile(int index);
    }
}
