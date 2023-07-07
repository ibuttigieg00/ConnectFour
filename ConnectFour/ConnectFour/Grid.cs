using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal class Grid
    {
        public enum GridPosition { EMPTY = 0, YELLOW = 1, RED = 2};

        public int Rows { get; set; }
        public int Columns { get; set; }
        public int[,] grid;

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            initGrid();
        }

        public void initGrid()
        {
            grid = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    grid[i, j] = (int)GridPosition.EMPTY;
                }
            }
        }

        public int[,] getGrid()
        {
            return grid;
        }
        public int getColumnCount()
        {
            return Columns;
        }

        public int PlaceDisc(int column, GridPosition disc)
        {
            if (column < 0 || column > Columns)
            {
                throw new ArgumentOutOfRangeException("column out of range");
            }
            if (disc == GridPosition.EMPTY)
            {
                throw new Exception("Invalid disc");
            }
            
            // Place piece in the lowest empty row
            for(int row = Rows - 1; row >= 0; row--)
            {
                if (grid[Rows,Columns] == (int)GridPosition.EMPTY)
                {
                    grid[Rows, Columns] = (int)disc;
                    return row;
                }
            }
            return -1;
        }

        // every time the user inputs a new piece in the grid, we check if that 
        // piece is part of a connectN
        public bool checkWin(int connectN, int row, int col, GridPosition disc)
        {
            // Check horizontal
            int count = 0;
            for(int i = 0; i < Columns; i++)
            {
                if (grid[row,i] == (int)disc)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == connectN)
                    return true;
            }
            
            count = 0;
            // Check Vertical
            for (int r = 0; r < Rows; r++)
            {
                if(grid[r,col] == (int)disc)
                {
                    count++;
                }
                else
                { 
                    count = 0; 
                }
                if (count == connectN)
                    return true;
            }
            
            count = 0;
            // Check diagonal
            //0....
            //.0...
            //..0..
            //...0.

            for(int r = 0; r< Rows; r++)
            {
                int c = row + col - r;
                if(c > 0 && c < Columns && grid[r,c] == (int)disc)
                    count++;
                else 
                    count = 0;
                if (count == connectN)
                    return true;

            }
            // Check anti-diagonal
            //....0
            //...0.
            //..0..
            //.0...
            count = 0;
            for(int r = 0; r < Rows; r++)
            {
                int c = col - row + r;
                if (c > 0 && c < Columns && grid[r, c] == (int)disc)
                    count++;
                else 
                    count= 0;
                if (count == connectN)
                    return true;
            }

            return false;
        }
    }
}
