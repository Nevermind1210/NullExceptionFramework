using System.Collections;

namespace Sorting
{
    public class MergeSort : BaseSorter
    {
        protected override IEnumerator Sort()
        {
            yield return SortMerge(nodes, 0, nodes.Length - 1);
        }

        IEnumerator SortMerge(Node[] arr, int lower, int range)
        {
            // if the range becomes too low then the recursion ends
            if (lower < range)
            {
                // find the middle point of the upper and lower ranges
                int middle = lower + (range - lower) / 2;

                // recursively run the sort on the array for the smaller arrays first
                // then merge them back into larger arrays
                yield return SortMerge(arr, lower, middle);
                yield return SortMerge(arr, middle + 1, range);
                // merge the array
                yield return Merge(arr, lower, middle, range);
            }
        }

        IEnumerator Merge(Node[] arr, int lower, int middle, int range)
        {
            // Find sizes of two
            // subarrays to be merged
            int lowerLength = middle - lower + 1;
            int upperLength = range - middle;

            // Create temp arrays
            Node[] lowerArray = new Node[lowerLength];
            Node[] upperArray = new Node[upperLength];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < lowerLength; ++i)
                lowerArray[i] = arr[lower + i];
            for (j = 0; j < upperLength; ++j)
                upperArray[j] = arr[middle + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged subarry array
            int k = lower;

            // sort the sub arrays
            while (i < lowerLength && j < upperLength)
            {
                if (lowerArray[i].Index <= upperArray[j].Index)
                {
                    arr[k] = lowerArray[i];
                    StartFrame(i, k);
                    yield return null;
                    EndFrame(i, k);
                    i++;
                }
                else
                {
                    arr[k] = upperArray[j];
                    StartFrame(k, j);
                    yield return null;
                    EndFrame(k, j);
                    j++;
                }

                k++;
            }

            // Copy the sorted elements of the lower array back into the main array
            while (i < lowerLength)
            {
                arr[k] = lowerArray[i];
                StartFrame(i, k);
                yield return null;
                EndFrame(i, k);
                i++;
                k++;
            }

            // Copy the sorted elements of the lower array back into the main array
            while (j < upperLength)
            {
                arr[k] = upperArray[j];
                StartFrame(k, j);
                yield return null;
                EndFrame(k, j);
                j++;
                k++;
            }
        }
    }
}