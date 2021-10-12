using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sorting
{
    public class BubbleSort : BaseSorter
    {
        protected override IEnumerator Sort()
        {
            Node tempNode = null;

            // Loop through the array every time and as many elements as provided
            for (int j = 0; j < nodes.Length - 1; j++)
            {
                for (int i = 0; i < nodes.Length - 1; i++)
                {
                    // Compare the current and next nodes
                    if (nodes[i].Index > nodes[i + 1].Index)
                    {
                        // Swap the elements using the temp node
                        tempNode = nodes[i + 1];
                        nodes[i + 1] = nodes[i];
                        nodes[i] = tempNode;
                
                        // Visualise the swapping of the nodes
                        StartFrame(nodes[i].Index, nodes[i + 1].Index);
                        yield return null; //new WaitForSecondsRealtime(0.05f);
                        EndFrame(nodes[i].Index, nodes[i + 1].Index);
                    }
                }
            }
        }
    }
}