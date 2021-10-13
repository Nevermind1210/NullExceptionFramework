using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearSearch : MonoBehaviour
{
    [SerializeField] private int[] list;
    [SerializeField] private int valueToBeFound;
    // Update is called once per frame
    void Update()
    {
        SearchLinear(list, valueToBeFound); // The function runs on play!
    }

    public static void SearchLinear(int[] _arr, int _x)
    {
        // We initialize N to be the length of the array
        int n = _arr.Length;
        for (int i = 0; i < n; i++) // for every array we discover
        {
            if (_arr[i] == _x) // if the array that will be compared is THE same
            {
                Debug.Log("Found Value!!");
                return; // The value the user has inputted is in the array! Huarray!
            }
        }
        Debug.Log("Value Doesn't Exist!!"); // Welp try again!
    }
}
