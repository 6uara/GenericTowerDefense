using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue<T>
{
    private T[] items;
    private int front, rear, size;

    public Queue(int capacity)
    {
        items = new T[capacity];
        front = 0;
        rear = -1;
        size = 0;
    }

    public void Enqueue(T item)
    {
        if (size == items.Length)
        {
            throw new InvalidOperationException("Queue is full");
        }

        rear = (rear + 1) % items.Length;
        items[rear] = item;
        size++;
    }

    public T Dequeue()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = items[front];
        front = (front + 1) % items.Length;
        size--;
        return item;
    }

    public T Peek()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return items[front];
    }

    public int Count()
    {
        return items.Length;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }
}
