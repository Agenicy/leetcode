#include "Header.h"

class Solution
{
public:
    bool isStrictlyPalindromic(int n)
    {
        int front = 0, rear = nlz1(n);
        cout << rear << endl;
        while (rear > front)
        {
            if ((1 << front++ & n) ^ (1 << rear-- & n))
                return false;
        }
        return true;
    }

    int nlz1(unsigned x)
    {
        int n;

        if (x == 0)
            return (32);
        n = 0;
        if (x <= 0x0000FFFF)
        {
            n = n + 16;
            x = x << 16;
        }
        if (x <= 0x00FFFFFF)
        {
            n = n + 8;
            x = x << 8;
        }
        if (x <= 0x0FFFFFFF)
        {
            n = n + 4;
            x = x << 4;
        }
        if (x <= 0x3FFFFFFF)
        {
            n = n + 2;
            x = x << 2;
        }
        if (x <= 0x7FFFFFFF)
        {
            n = n + 1;
        }
        return n;
    }
};