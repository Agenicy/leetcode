#include "Header.h"

class Solution
{
public:
    TreeNode *addOneRow(TreeNode *root, int val, int depth)
    {
        if (root == nullptr)
            return root;
        if (depth == 1)
        {
            return root = new TreeNode(val, root, nullptr);
        }
        else if (depth == 2)
        {
            root->left = new TreeNode(val, root->left, nullptr);
            root->right = new TreeNode(val, nullptr, root->right);
            return root;
        }
        else
        {
            if (root->left)
                addOneRow(root->left, val, depth - 1);
            if (root->right)
                addOneRow(root->right, val, depth - 1);
            return root;
        }
    }
};