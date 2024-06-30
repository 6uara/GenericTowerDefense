using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ITree
{
    TreeNode root;
    public void AddElement(int x)
    {
        if (root == null)
        {
            root = new TreeNode();
            root.info = x;
            root.leftBranch = new Tree();
            root.leftBranch.InicilizeTree();
            root.rightBranch = new Tree();
            root.rightBranch.InicilizeTree();
        }
        else if (root.info > x)
        {
            root.leftBranch.AddElement(x);
        }
        else if (root.info < x)
        {
            root.rightBranch.AddElement(x);
        }
    }

    public bool EmptyTree()
    {
        return (root == null);
    }

    public void InicilizeTree()
    {
        root = null;
    }

    public ITree LeftBranch()
    {
        return root.leftBranch;
    }

    public ITree RightBranch()
    {
        return root.rightBranch;
    }

    public void RemoveElement(int x)
    {
        if (root != null)
        {
            if (root.info == x && root.leftBranch.EmptyTree() && root.rightBranch.EmptyTree())
            {
                root = null;
            }
            else if (root.info == x && !root.leftBranch.EmptyTree())
            {
                root.info = this.Higher(root.leftBranch);
                root.leftBranch.RemoveElement(root.info);
            }
            else if (root.info == x && root.leftBranch.EmptyTree())
            {
                root.info = this.Minor(root.rightBranch);
                root.rightBranch.RemoveElement(root.info);
            }
            else if (root.info < x)
            {
                root.rightBranch.RemoveElement(x);
            }
            else
            {
                root.leftBranch.RemoveElement(x);
            }
        }
    }
    public int Root()
    {
        return root.info;
    }
    public int Higher(ITree a)
    {
        if (a.RightBranch().EmptyTree())
        {
            return a.Root();
        }
        else
        {
            return Higher(a.RightBranch());
        }
    }

    public int Minor(ITree a)
    {
        if (a.LeftBranch().EmptyTree())
        {
            return a.Root();
        }
        else
        {
            return Minor(a.LeftBranch());
        }
    }
}
