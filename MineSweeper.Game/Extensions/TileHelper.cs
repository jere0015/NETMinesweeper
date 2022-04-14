
namespace MineSweeper.Game
{
    /// <summary>
    /// Helper extension for an ITile object
    /// </summary>
    public static class TileHelper
    {
        /// <summary>
        /// Get the count of neighbourgh tiles who contain a main
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>Count of neighbouring mine tiles</returns>
        public static int NeighbourghsMineCount(this ITile tile)
        {
            return tile.Neighbourghs().Where(tile => tile.IsMine).Count();
        }

        /// <summary>
        /// Get the tile above this tile
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>Tile if inbounds, null if out of bounds</returns>
        public static ITile? Up(this ITile tile)
        {
            return tile.Neighbourgh(0, -1);
        }

        /// <summary>
        /// Get the tile below this tile
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>Tile if inbounds, null if out of bounds</returns>
        public static ITile? Down(this ITile tile)
        {
            return tile.Neighbourgh(0, 1);
        }

        /// <summary>
        /// Get the tile left of this tile
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>Tile if inbounds, null if out of bounds</returns>
        public static ITile? Left(this ITile tile)
        {
            return tile.Neighbourgh(-1, 0);
        }


        /// <summary>
        /// Get the tile right of this tile
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>Tile if inbounds, null if out of bounds</returns>
        public static ITile? Right(this ITile tile)
        {
            return tile.Neighbourgh(1, 0);
        }

        /// <summary>
        /// Get a neighbourghing tile from x and y offset
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="x_offset">Relative X offset</param>
        /// <param name="y_offset">Relative Y offset</param>
        /// <returns>Tile if inbounds, null if out of bounds</returns>
        public static ITile? Neighbourgh(this ITile tile, int x_offset, int y_offset)
        {
            var x = tile.X + x_offset;
            var y = tile.Y + y_offset;

            if (tile.Parent.IsValidBoardCoordinates(x, y))
            {
                return tile.Parent.GetTile(x, y);
            }

            return null;
        }

        /// <summary>
        /// Get this tiles' neighbourghs.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>An enumerable of neighbourghing tiles</returns>
        public static IEnumerable<ITile> Neighbourghs(this ITile tile)
        {
            var neighbourghs = new List<ITile?>()
            {
                tile.Up(),
                tile.Up()?.Left(),
                tile.Up()?.Right(),

                tile.Down(),
                tile.Down()?.Left(),
                tile.Down()?.Right(),

                tile.Left(),
                tile.Right(),
            };

            return neighbourghs.Where((tile) => tile is not null) as IEnumerable<ITile>;
        }
    }
}
