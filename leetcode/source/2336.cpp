#include "Header.h"

class SmallestInfiniteSet
{
    priority_queue<int, vector<int>, greater<int>> pq;
    int back;

public:
    SmallestInfiniteSet()
    {
        pq.push(back = 1);
    }

    int popSmallest()
    {
        int topNum = pq.top();
        pq.pop();
        if (pq.size() == 0)
        {
            pq.push(back = topNum + 1);
        }

        while (pq.top() == topNum)
            pq.pop();

        return topNum;
    }

    void addBack(int num)
    {
        if (num < back)
            pq.push(num);
    }
};

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet* obj = new SmallestInfiniteSet();
 * int param_1 = obj->popSmallest();
 * obj->addBack(num);
 */