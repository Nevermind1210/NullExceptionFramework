using System;
using System.Collections;
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
            string logOutput = "";
            BubbleSorter(array);
            foreach (var arr in array)
            {
                logOutput += $"{arr.ToString()} ,";
            }
            Debug.Log(logOutput);
        }

        public static void BubbleSorter<T>(T[] input) where T : IComparable<T>
        {
            for (int x = 0; x < input.Length; x++)
            {
                for (int y = 0; y < input.Length - 1; y++)
                {
                    if (input[y].CompareTo(input[y + 1]) > 0)
                    {
                        if (input[y].CompareTo(input[y + 1]) > 0)
                        {
                            T temp = input[y + 1];
                            input[y + 1] = input[y];
                            input[y] = temp;
                        }
                    }
                }
            }
        }
    }
}