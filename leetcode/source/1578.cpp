#include "Header.h"

class Solution
{
public:
    int minCost(string colors, vector<int> &neededTime)
    {
        int max = 0;
        int sum = 0;
        bool isAdding = false;

        for (size_t i = 1; i < colors.length(); i++)
        {
            /* code */
            if (colors[i] == colors[i - 1])
            {
                if (!isAdding)
                {
                    isAdding = true;
                    max = neededTime[i - 1];
                }

                if (neededTime[i] > max)
                {
                    sum += max;
                    max = neededTime[i];
                }
                else
                {
                    sum += neededTime[i];
                }
                isAdding = true;
            }
            else
                isAdding = false;
        }
        return sum;
    }
};

int main()
{
    return 0;
}