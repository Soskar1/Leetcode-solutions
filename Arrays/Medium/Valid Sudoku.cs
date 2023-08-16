//Problem: https://leetcode.com/problems/valid-sudoku/

class Solution
{
    private const int NUMBER_OF_BOXES = 9;
    private const int BOX_SIZE = 3;

    public bool IsValidSudoku(char[][] board)
    {
        Dictionary<char, bool> dictionary = new Dictionary<char, bool>();

        return ValidateRows(board, dictionary) && ValidateColumns(board, dictionary) && ValidateBoxes(board, dictionary);
    }

    private bool ValidateRows(char[][] board, Dictionary<char, bool> dictionary)
    {
        for (int i = 0; i < board.Length; ++i)
        {
            for (int j = 0; j < board[i].Length; ++j)
            {
                if (board[i][j] == '.')
                    continue;

                if (dictionary.ContainsKey(board[i][j]))
                    return false;

                dictionary.Add(board[i][j], true);
            }

            dictionary.Clear();
        }

        return true;
    }

    private bool ValidateColumns(char[][] board, Dictionary<char, bool> dictionary)
    {
        for (int i = 0; i < board.Length; ++i)
        {
            for (int j = 0; j < board[i].Length; ++j)
            {
                if (board[j][i] == '.')
                    continue;

                if (dictionary.ContainsKey(board[j][i]))
                    return false;

                dictionary.Add(board[j][i], true);
            }

            dictionary.Clear();
        }

        return true;
    }

    private bool ValidateBoxes(char[][] board, Dictionary<char, bool> dictionary)
    {
        int xOffset = 0;
        int yOffset = 0;

        for (int box = 1; box <= NUMBER_OF_BOXES; ++box)
        {
            for (int i = 0; i < BOX_SIZE; ++i)
            {
                for (int j = 0; j < BOX_SIZE; ++j)
                {
                    int xIndex = i + xOffset;
                    int yIndex = j + yOffset;

                    if (board[xIndex][yIndex] == '.')
                        continue;

                    if (dictionary.ContainsKey(board[xIndex][yIndex]))
                        return false;

                    dictionary.Add(board[xIndex][yIndex], true);
                }
            }

            dictionary.Clear();
            xOffset += BOX_SIZE;

            if (box % BOX_SIZE == 0)
            {
                xOffset = 0;
                yOffset += BOX_SIZE;
            }
        }

        return true;
    }
}