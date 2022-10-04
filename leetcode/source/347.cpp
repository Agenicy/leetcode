#include "Header.h"

class Solution
{
public:
    vector<int> topKFrequent(vector<int> &nums, int k)
    {

        map<int, int> Map;

        for (auto num : nums)
            Map[num]++;

        priority_queue<pair<int, int>, vector<pair<int, int>>, less<pair<int, int>>> pq;

        for (auto num : Map)
            pq.push(make_pair(num.second, num.first));

        vector<int> ret;
        ret.reserve(k);
        for (size_t i = 0; i < k; i++)
        {
            ret.push_back(pq.top().second);
            pq.pop();
        }
        return ret;
    }
};