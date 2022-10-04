#include "Header.h"

class Solution {
public:
    int maxCoins(vector<int>& piles) {
        sort(piles.begin(), piles.end(), greater<int>());
        int sum = 0;
        for (size_t i = 1; i < piles.size()*2/3; i+=2)
        {
            sum += piles[i];
        }
        return sum;
    }
};