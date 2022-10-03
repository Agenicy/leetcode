#include "Header.h"

class Solution {
public:
    int maximumScore(int a, int b, int c) {
        int big = max(a, max(b, c));
        if(big > (a+b+c)-big)
            return min(big, (a+b+c)-big);
        else
            return (a+b+c)/2;
    }
};