#include "Header.h"

class Solution
{
public:
    vector<vector<int>> kClosest(vector<vector<int>> &points, int k)
    {
        auto cmp = [](pair<int, int> a, pair<int, int> b)
        {
            return a.second < b.second;
        };

        priority_queue<pair<int, int>, vector<pair<int, int>>, decltype(cmp)> pq(cmp);
        for (size_t i = 0; i < points.size(); i++)
        {
            pq.push(pair<int, int>(i, points[i][0] * points[i][0] + points[i][1] * points[i][1]));
            if (pq.size() > k)
                pq.pop();
        }

        vector<vector<int>> ret;
        ret.reserve(k);
        for (size_t i = 0; i < k; i++)
        {
            ret.push_back(points[pq.top().first]);
            pq.pop();
        }
        return ret;
    }
};