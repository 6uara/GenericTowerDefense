using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksort : MonoBehaviour
{
    public static void Sort(List<Enemies> list)
    {
        if (list == null || list.Count <= 1)
            return;

        QuickSortAlgorithm(list, 0, list.Count - 1);
    }

    private static void QuickSortAlgorithm(List<Enemies> list, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(list, left, right);
            QuickSortAlgorithm(list, left, pivotIndex - 1);
            QuickSortAlgorithm(list, pivotIndex + 1, right);
        }
    }

    private static int Partition(List<Enemies> list, int left, int right)
    {
        Enemies pivot = list[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (list[j].Id <= pivot.Id)
            {
                i++;
                Swap(list, i, j);
            }
        }

        Swap(list, i + 1, right);
        return i + 1;
    }

    private static void Swap(List<Enemies> list, int i, int j)
    {
        Enemies temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
