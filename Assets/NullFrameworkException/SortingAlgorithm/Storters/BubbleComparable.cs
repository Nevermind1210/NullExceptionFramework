using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sorting
{
    public class BubbleComparable : MonoBehaviour
    {
        [SerializeField] private int[] array;
        [SerializeField] private TextMeshProUGUI results;
        private void Awake()
        {
            string output = ""; // We initialize the string
            BubbleSorter(array); // We sort the array
            foreach (var arr in array) // We find each sorted value in the array
            {
                output += $"{arr.ToString()}" + ", "; // We string it!
            }
            Debug.Log(output); // We display it inside the unity console!
        }

        /// <summary>
        /// The algorithm that will sort and compare each number, though bubble sort just does that already
        /// </summary>
        /// <param name="input">Whatever value is that the user has inputted</param>
        /// <typeparam name="T"> T is the generic template for the comparer function </typeparam>
        public static void BubbleSorter<T>(T[] input) where T : IComparable<T>
        {
            for (int x = 0; x < input.Length; x++) // Getting the array
            {
                for (int y = 0; y < input.Length - 1; y++) // Getting the array for comparison
                {
                    if (input[y].CompareTo(input[y + 1]) > 0) // We are comparing the values
                    {
                        if (input[y].CompareTo(input[y + 1]) > 0)  // Doing it again!
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