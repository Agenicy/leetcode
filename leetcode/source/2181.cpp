#include "Header.h"

class Solution
{
public:
    ListNode *mergeNodes(ListNode *head)
    {
        ListNode *ptr, *back;
        ptr = head;
        back = ptr->next;
        while (back->next)
        {
            if (back->val == 0)
            {
                ptr->next = back;
                ptr = back;
                back = ptr->next;
            }
            else
            {
                ptr->val += back->val;
                back = back->next;
            }
        }
        ptr->next = nullptr;
        return head;
    }
};