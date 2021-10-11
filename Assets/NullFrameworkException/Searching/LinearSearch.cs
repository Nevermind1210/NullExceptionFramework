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
        SearchLinear(list, valueToBeFound);
    }

    public static int SearchLinear(int[] _arr, int _x)
    {
        int n = _arr.Length;
        for (int i = 0; i < n; i++)
        {
            if (_arr[i] == _x)
            {
                Debug.Log("Found Value!!");
                return i;
            }
        }
        Debug.Log("Value Doesn't Exist!!");
        return -1;
    }
}
