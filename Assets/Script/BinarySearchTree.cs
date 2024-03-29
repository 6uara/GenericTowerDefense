using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchTree
{
    private class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(int key)
    {
        root = InsertRec(root, key);
    }

    private Node InsertRec(Node root, int key)
    {
        if (root == null)
        {
            root = new Node(key);
            return root;
        }

        if (key < root.data)
        {
            root.left = InsertRec(root.left, key);
        }
        else if (key > root.data)
        {
            root.right = InsertRec(root.right, key);
        }

        return root;
    }

    public void InOrder()
    {
        InOrderRec(root);
    }

    private void InOrderRec(Node root)
    {
        if (root != null)
        {
            InOrderRec(root.left);
            Console.Write(root.data + " ");
            InOrderRec(root.right);
        }
    }
}
