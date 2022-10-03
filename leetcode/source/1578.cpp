#include "Header.h"

class Solution
{
public:
    int minCost(string colors, vector<int> &neededTime)
    {
        int maxNum = 0;
        int sum = 0;

        for (size_t i = 1; i < colors.length(); i++)
        {
            /* code */
            if (colors[i] == colors[i - 1])
            {
                if (maxNum == 0)
                {
                    maxNum = neededTime[i - 1];
                }

                sum += min(neededTime[i], maxNum);
                maxNum = max(neededTime[i], maxNum);
            }
            else
                maxNum = 0;
        }
        return sum;
    }
};

int main()
{
    return 0;
}