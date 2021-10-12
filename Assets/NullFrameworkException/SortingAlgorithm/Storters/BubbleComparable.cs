using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sorting
{
    public class BubbleComparable : MonoBehaviour
    {
        [SerializeField] private int[] array;
        private void Update()
        {
            BubbleSort(array);
        }

        public static void BubbleSort<T>(T[] input) where T : IComparable<T>
        {
            for (int x = 0; x < input.Length; x++)
            {
                for (int y = 0; y < input.Length - 1; y++)
                {
                    if (input[y].CompareTo(input[y + 1]) > 0)
                    {
                        T temp = input[y + 1];
                        input[y + 1] = input[y];
                        input[y] = temp;
                        Debug.Log(input.ToString());
                    }
                }
            }
        }

        public static void SelectionSort<T>(T[] input) where T : IComparable<T>
        {
            for (int x = 0; x < input.Length; x++)
            {
                int index_of_min = x;

                for (int y = x; y < input.Length; y++)
                {
                    if (input[index_of_min].CompareTo(input[y]) > 0)
                    {
                        index_of_min = y;
                    }
                }

                T temp = input[x];
                input[x] = input[index_of_min];
                input[index_of_min] = temp;
            }
        }
    }
}