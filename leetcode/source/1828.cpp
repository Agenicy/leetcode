#include "Header.h"

class Solution {
public:
    vector<int> countPoints(vector<vector<int>>& points, vector<vector<int>>& queries) {
        vector<int> ret;
        ret.reserve(queries.size());
        for (auto query:queries)
        {
            int r2 = query[2] *  query[2];
            int sum = 0;
            for (auto point :points)
            {
                if(pow(point[0] - query[0], 2) +  pow(point[1] - query[1], 2) <= r2 )
                sum++;
            }
            ret.push_back(sum);
        }
        return ret;
    }
};