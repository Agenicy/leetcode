#include "Header.h"

class Solution
{
public:
    string frequencySort(string s)
    {
        map<char, int> Map;
        for (auto c : s)
        {
            if (Map.count(c) == 0)
            {
                Map[c] = 0;
            }
            Map[c]++;
        }

        priority_queue<pair<int, char>> pq;
        for (auto c : Map)
        {
            pq.push(c);
        }

        int rear = 0;
        while (pq.size() > 0)
        {
            auto p = pq.top();
            for (size_t i = 0; i < Map[p.second]; i++)
            {
                s[rear++] = p.second;
            }
        }
        return s;
    }
};

int main()
{
    Solution s;
    cout << s.frequencySort("tree") << endl;
    return 0;
}