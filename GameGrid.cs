namespace TetrisGame
{
    public class GameGrid
    {
        private readonly int[,] grid;

        public int Rows { get; }
        public int Columns { get; }

        public int this[int row, int column]
        {
            get => grid[row, column];
            set => grid[row, column] = value;
        }

        public GameGrid(int rows,int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[Rows, Columns];
        }

        public bool IsInside(int row, int column)
        {
            return row >= 0 && column >= 0 && row < Rows && column < Columns;
        }

        public bool IsEmpty(int row, int column)
        {
            return IsInside(row, column) && grid[row,column] == 0;
        }

        public bool IsRowFull(int row)
        {
            for(int c = 0; c < Columns; c++)
            {
                if (grid[row,c] == 0)
                {
                    return false;
                }    
            }
            return true;
        }
        public bool IsRowEmpty(int row)
        {
            for(int c = 0; c < Columns; c++)
            {
                if (grid[row,c] == 0)
                {
                    return true;
                }    
            }
            return false;
        }

        private void ClearRow(int r)
        {
            for(int c = 0;c< Columns; c++)
            {
                grid[r,c] = 0;
            }
        }

        private void MoveRowdown(int r, int numRows)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r + numRows,c] = grid[r,c];
                grid[r,c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for(int r = Rows-1;r>= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared>0)
                {
                    MoveRowdown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
