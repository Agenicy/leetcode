#include "Header.h"

class Solution
{
public:
    int countSquares(vector<vector<int>> &matrix)
    {
        int count = min(matrix.size(), matrix[0].size());

       
        auto conv2D = [&](int x, int y)
        {
            return (matrix[x + 1][y + 1]) ? min(matrix[x][y], min(matrix[x + 1][y], matrix[x][y + 1]))
                                          : 0;
        };

        int sum = 0;
        /* code */
        for (size_t i = 0; i < matrix.size(); i++)
        {
            /* code */
            for (size_t j = 0; j < matrix[0].size(); j++)
            {
                /* code */
                sum += matrix[i][j];
                if (i + 1 < matrix.size() && j + 1 < matrix[0].size())
                    matrix[i + 1][j + 1] += conv2D(i, j);
            }
        }
        return sum;
    }
};