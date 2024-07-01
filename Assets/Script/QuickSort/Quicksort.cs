using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksort : MonoBehaviour
{
    public static void Sort(List<KeyValuePair<string, int>> list)
    {
        if (list == null || list.Count <= 1)
            return;

        QuickSortAlgorithm(list, 0, list.Count - 1);
    }

    private static void QuickSortAlgorithm(List<KeyValuePair<string, int>> list, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(list, left, right);
            QuickSortAlgorithm(list, left, pivotIndex - 1);
            QuickSortAlgorithm(list, pivotIndex + 1, right);
        }
    }

    private static int Partition(List<KeyValuePair<string, int>> list, int left, int right)
    {
        int pivot = list[right].Value;
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (list[j].Value >= pivot)
            {
                i++;
                Swap(list, i, j);
            }
        }

        Swap(list, i + 1, right);
        return i + 1;
    }

    private static void Swap(List<KeyValuePair<string, int>> list, int i, int j)
    {
        KeyValuePair<string, int> temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
