#include "Header.h"

class Solution
{
public:
    ListNode *addTwoNumbers(ListNode *l1, ListNode *l2)
    {
        ListNode *result = new ListNode();
        ListNode *ptr = result;
        int add = 0;
        int sum;
        while (l1 != nullptr || l2 != nullptr)
        {

            sum = (l1 ? l1->val : 0) + (l2 ? l2->val : 0) + add;
            add = sum / 10;
            sum -= add * 10;

            ptr->next = new ListNode(sum);
            ptr = ptr->next;

            if (l1)
                l1 = l1->next;
            if (l2)
                l2 = l2->next;
        };
        if (add)
        {

            ptr->next = new ListNode(add);
        }
        return result->next;
    }
};