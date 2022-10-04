#include "Header.h"

class Solution
{
    int sum = 0;

public:
    bool DFS(TreeNode *parent, int &targetSum)
    {
        sum += parent->val;
        if (sum == targetSum)
            return true;

        if (!parent->left && !parent->right)
        {
            sum -= parent->val;
            return false;
        }
        else
        {
            if (parent->left && DFS(parent->left, targetSum))
                return true;

            if (parent->right && DFS(parent->right, targetSum))
                return true;
            sum -= parent->val;
            return false;
        }
    }

    bool hasPathSum(TreeNode *root, int targetSum)
    {
        if (!root)
            return false;
        return DFS(root, targetSum);
    }
};