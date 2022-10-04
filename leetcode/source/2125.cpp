#include "Header.h"

class Solution
{
public:
    int numberOfBeams(vector<string> &bank)
    {
        int last = 0;
        int sum = 0;
        for (size_t i = 0; i < bank.size(); i++)
        {
            int bit = 0;
            for (char a : bank[i])
            {
                if (a - '0' == 1)
                {
                    bit++;
                }
            }
            if (bit > 0)
            {
                sum += bit * last;
                last = bit;
            }
        }
        return sum;
    }
};