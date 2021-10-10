using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sorting
{
    public class SelectionSort : BaseSorter
    {
        protected override IEnumerator Sort()
        {
            int nodeCount = nodes.Length;
            int smallest = 0;
            int old = 0;
            Node tempNode = null;

            // Loop until the final element of the array
            for (int i = 0; i < nodeCount - 1; i++)
            {
                // Update the smallest and old values to the current iteration of i
                smallest = i;
                old = i;
                
                // Loop from the current i + 1 index to the end of the array
                for (int j = i + 1; j < nodeCount; j++)
                {
                    // Compare the jth element to the current smallest element
                    if (nodes[j].Index < nodes[smallest].Index)
                    {
                        // assign smallest to the j index
                        smallest = j;
                    }
                }
                
                // Swap the old and current nodes using a temp node
                tempNode = nodes[smallest];
                nodes[smallest] = nodes[old];
                nodes[old] = tempNode;
                
                // Visualise the swapping of the nodes
                StartFrame(old, smallest);
                yield return null;
                EndFrame(old, smallest);
            }
        }
    }
}