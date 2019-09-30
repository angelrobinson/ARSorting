/*
 * Name: Angela Robinson
 * Date: 9/27/2019
 * Class: Data Structures and Algorithms
 * Assignment: Sorting
 * Descriptioin:
 *  Code/Implement a sorting algorithms of your choice (for example, insertion sort, merge sort, quick sort) that operates on a data structure 
 *  (i.e. Linked List, Doubly linked list, array). 
 *  For testing, your program should accept an array of integers with a minimum of 20 integers OR your program could take two arguments, 
 *  the filename of a data file, and an integer that defines the algorithm that will be used to sort.
 *  
 *  The data file contains one integer per line, for an unknown number of lines.  
 *  Your program should parse this data file into your linked list structure, and then use the specified algorithm to sort the array.  
 *  Your program should time how long it takes to sort the data, and report that information to the console in seconds.  
 *  Take care to only report the time it takes to sort, not perform file i/o.  
 *  For small dataset sizes, you may have to average several consecutive sorts in order to arrive at a valid timing measurement. 
 *  
 *  If the size of the dataset is less than 100, your program should print the sorted list to the console screen.
 *  
 *  Once all of your data is collected, graph the performance of each algorithm by data set size, and use a trend-line to determine the growth-rate of each algorithm. 
 */
using System;
using System.Collections.Generic;

namespace ARSorting
{
    
    /// <summary>
    /// This class holds methods for several sorting algorithms
    /// </summary>
    public class Sorting
    {

        #region Bubble Sort
        /// <summary>
        /// Sorts a doubly linked list:
        /// Starting with p position, compare to adjoining element
        /// -swap if needed putting lower element on left.
        /// -recursively,or repeat looping until no swapping was performed
        /// running time should be: O(N^2) 
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="llist">reference to linked list to be sorted</param>
        public void BubbleSort<T>(ref LinkedList<T> llist)
        {
            //counter to keep track of swaps each iteration
            int swaps;

            //loop through the list to make sure that the
            do
            {
                swaps = 0;

                var current = llist.First;

                while (current != null)
                {
                    var j = current.Next;

                    //check if element is a comparable item and compare it to the next element
                    if (j != null && ((current.Value is IComparable<T> && ((IComparable<T>)current.Value).CompareTo(j.Value) > 0) 
                        || StringComparer.CurrentCulture.Compare(current.Value, j.Value) > 0))
                    {
                        //first element is greater than second element
                        //need to swap
                        var temp = current;
                        llist.Remove(current);
                        llist.AddAfter(j, temp);

                        //increment swaps
                        ++swaps;
                    }

                    current = j != null ? j.Next : null;
                }

            } while (swaps != 0);
        }
        /// <summary>
        /// Sorts a Single linked list:
        /// Starting with p position, compare to adjoining element
        /// -swap if needed putting lower element on left.
        /// -recursively,or repeat looping until no swapping was performed
        /// running time should be: O(N^2) 
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="list">reference to linked list to be sorted</param>
        public void BubbleSort<T>(ref List<T> list)
        {
            //counter to keep track of swaps each iteration
            int swaps;

            //loop through the array to make sure that the
            do
            {
                swaps = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    int j = i + 1;

                    //check if element is a comparable item and compare it to the next element
                    if (j < list.Count &&
                        ((list[i] is IComparable<T> && ((IComparable<T>)list[i]).CompareTo(list[j]) > 0) || StringComparer.CurrentCulture.Compare(list[i], list[j]) > 0))
                    {
                        //first element is greater than second element
                        //need to swap
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;

                        //increment swaps
                        ++swaps;
                    }
                }
            } while (swaps != 0);
        }

        /// <summary>
        /// Sorts and array: 
        /// Starting with p position, compare to adjoining element
        /// -swap if needed putting lower element on left.
        /// -recursively,or repeat looping until no swapping was performed
        /// running time should be: O(N^2) 
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="array">reference to array to be sorted</param>        

        public void BubbleSort<T>(ref T[] array)
        {
            //counter to keep track of swaps each iteration
            int swaps;

            //loop through the array to make sure that the
            do
            {
                swaps = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    int j = i + 1;

                    //check if element is a comparable item and compare it to the next element
                    if (j < array.Length && 
                        ((array[i] is IComparable<T> && ((IComparable<T>)array[i]).CompareTo(array[j]) > 0)|| StringComparer.CurrentCulture.Compare(array[i], array[j]) > 0))
                    {
                        //first element is greater than second element
                        //need to swap
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;

                        //increment swaps
                        ++swaps;
                    }
                }
            } while (swaps != 0);
           
        }
        #endregion

        #region Insertion Sort
        /// <summary>
        /// sort doubly linked list using insertion algorithm
        /// Starting with p position, move element left until the proper place is found.
        /// -element goes into a temp holder while all other elements are shifted to the right
        /// -no swapping needed
        /// average running time should be: O(N^2) (becuase of nested loops)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="llist"></param>
        public void InsertionSort<T>(ref LinkedList<T> llist)
        {
            //set position
            var position = llist.First.Next;


            //first loop
            while (position != null)
            {
                //create temp
                var tempValue = position.Value;

                

                var current = position.Previous;

                //second loop
                while (current != null)
                {
                    //check if element is a comparable item and compare it to the next element
                    int result = tempValue is IComparable<T> ? ((IComparable<T>)tempValue).CompareTo(current.Value) 
                        : StringComparer.CurrentCulture.Compare(tempValue, current.Value);

                    if (result < 0 || result == 0)
                    {
                        //temp is less than or equal to place
                        //go to the next item to look at
                        current = current.Previous;
                    }
                    else
                    {
                        break;
                    }


                    //current = current.Previous;
                }

                //add tempValue to list
                if (current != null)
                {
                    llist.AddAfter(current, tempValue);
                }
                else
                {
                    llist.AddFirst(tempValue);
                }

                var temp = position;
                //increment position
                position = position.Next;

                //delete original node
                llist.Remove(temp);
            }
        }

        /// <summary>
        /// sort linked list using insertion algorithm
        /// Starting with p position, move element left until the proper place is found.
        /// -element goes into a temp holder while all other elements are shifted to the right
        /// -no swapping needed
        /// average running time should be: O(N^2) (becuase of nested loops)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void InsertionSort<T>(ref List<T> list)
        {
            //set position
            int position = 1;

            while (position < list.Count)
            {
                //create temp variable for the position element
                var temp = list[position];
                int place = position - 1;

                for (; place >= 0; place--)
                {
                    //check if element is a comparable item and compare it to the next element
                    int result = temp is IComparable<T> ? ((IComparable<T>)temp).CompareTo(list[place]) : StringComparer.CurrentCulture.Compare(temp, list[place]);


                    if (result < 0 || result == 0)

                    {
                        //temp is less than or equal to place
                        //move place data over to the right
                        list[place + 1] = list[place];
                    }
                    else
                    {
                        break;
                    }

                }

                //insert into array
                list[place + 1] = temp;

                //increment position
                position++;
            }
        }
        /// <summary>
        /// Sort array using insertion sort algorithm
        /// Starting with p position, move element left until the proper place is found.
        /// -element goes into a temp holder while all other elements are shifted to the right
        /// -no swapping needed
        /// average running time should be: O(N^2) (becuase of nested loops)
        /// </summary>
        /// <typeparam name="T">data type</typeparam>
        /// <param name="array">reference to array to be sorted</param>
        public void InsertionSort<T>(ref T[] array)
        {
            //set position
            int position = 1;

            while (position < array.Length)
            {
                //create temp variable for the position element
                var temp = array[position];
                int place = position-1;

                for (; place >= 0; place--)
                {
                    //check if element is a comparable item and compare it to the next element
                    int result = temp is IComparable<T> ? ((IComparable<T>)temp).CompareTo(array[place]) : StringComparer.CurrentCulture.Compare(temp, array[place]);
                                        

                    if (result < 0 || result == 0)
                        
                    {
                        //temp is less than or equal to place
                        //move place data over to the right
                        array[place + 1] = array[place];
                    }
                    else
                    {
                        break;
                    }
                    
                }

                //insert into array
                array[place +1] = temp;

                //increment position
                position++;
            }
           
             
        }
        #endregion

        #region Merge Sort

        /// <summary>
        /// Sort doubly linked list using merge sort algorithm
        /// Split data structure in half, sort sub-structures
        /// -Recursively, or use loops, to continue spliting sub-structures until they have 1-2 elements left to compare and swap
        /// -if structure only has 1 element, return and merge with other sub-structure
        /// 
        /// Merge the two sorted structures together
        /// -using a third structure to hold the finished product
        /// -iterate through the substructures, comparing element at pointer
        /// -insert lower element into third structure and move pointer to the right
        /// -if one sub-structure is depleted, concat the remaining elements to the final structure
        /// 
        /// Worst case running time should be: O(N logN)
        /// </summary>
        /// <typeparam name="T">data type of doubly linked list</typeparam>
        /// <param name="array">doubly linked list to be sorted</param>
        public void MergeSort<T>(ref LinkedList<T> llist)
        {
            //find the middle of the array
            //this will be the first array in the "right" array
            int center = llist.Count / 2;

            //copy into left array            
            T[] left = new T[center];

            var current = llist.First;

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = current.Value;

                current = current.Next;
            }



            //copy into right array
            T[] right = new T[llist.Count - center];
            //int centerCopy = center;
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = current.Value;
                current = current.Next;
            }

            //break it down more by calling recursively
            if (left.Length > 1)
            {
                MergeSort(ref left);
            }

            if (right.Length > 1)
            {
                MergeSort(ref right);
            }

            //merge
            int listCount = llist.Count;
            llist.Clear();
            int rightIndex = 0;
            int leftIndex = 0;

            for (int i = 0; i < listCount; i++)
            {
                if (rightIndex >= right.Length && leftIndex < left.Length)
                {
                    //right array is exhausted
                    llist.AddLast(left[leftIndex]);

                    //increment index
                    leftIndex++;
                }
                else if (leftIndex >= left.Length && rightIndex < right.Length)
                {
                    //left array is exhausted
                    llist.AddLast(right[rightIndex]);

                    //increment index
                    rightIndex++;
                }
                else
                {
                    //both arrays have something left to compare
                    int result = right[rightIndex] is IComparable<T> ?
                        ((IComparable<T>)right[rightIndex]).CompareTo((left[leftIndex])) :
                        StringComparer.CurrentCulture.Compare(right[rightIndex], left[leftIndex]);

                    if (result < 0)
                    {
                        //right is less than left
                        llist.AddLast(right[rightIndex]);

                        //increment index
                        rightIndex++;
                    }
                    else if (result > 0)
                    {
                        //left is less than right
                        llist.AddLast(left[leftIndex]);

                        //increment index
                        leftIndex++;
                    }
                    else
                    {
                        //they are equal, so we will do left as default
                        llist.AddLast(left[leftIndex]);

                        //increment index
                        leftIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// Sort linked list using merge sort algorithm
        /// Split data structure in half, sort sub-structures
        /// -Recursively, or use loops, to continue spliting sub-structures until they have 1-2 elements left to compare and swap
        /// -if structure only has 1 element, return and merge with other sub-structure
        /// 
        /// Merge the two sorted structures together
        /// -using a third structure to hold the finished product
        /// -iterate through the substructures, comparing element at pointer
        /// -insert lower element into third structure and move pointer to the right
        /// -if one sub-structure is depleted, concat the remaining elements to the final structure
        /// 
        /// Worst case running time should be: O(N logN)
        /// </summary>
        /// <typeparam name="T">data type of linked list</typeparam>
        /// <param name="array">linked list to be sorted</param>
        public void MergeSort<T>(ref List<T> list)
        {
            //find the middle of the array
            //this will be the first array in the "right" array
            int center = list.Count / 2;

            //copy into left array            
            T[] left = new T[center];



            for (int i = 0; i < left.Length; i++)
            {
                left[i] = list[i];
            }



            //copy into right array
            T[] right = new T[list.Count - center];
            int centerCopy = center;
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = list[centerCopy];
                centerCopy++;
            }

            //break it down more by calling recursively
            if (left.Length > 1)
            {
                MergeSort(ref left);
            }

            if (right.Length > 1)
            {
                MergeSort(ref right);
            }

            //merge
            int rightIndex = 0;
            int leftIndex = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (rightIndex >= right.Length && leftIndex < left.Length)
                {
                    //right array is exhausted
                    list[i] = left[leftIndex];

                    //increment index
                    leftIndex++;
                }
                else if (leftIndex >= left.Length && rightIndex < right.Length)
                {
                    //left array is exhausted
                    list[i] = right[rightIndex];

                    //increment index
                    rightIndex++;
                }
                else
                {
                    //both arrays have something left to compare
                    int result = right[rightIndex] is IComparable<T> ?
                        ((IComparable<T>)right[rightIndex]).CompareTo((left[leftIndex])) :
                        StringComparer.CurrentCulture.Compare(right[rightIndex], left[leftIndex]);

                    if (result < 0)
                    {
                        //right is less than left
                        list[i] = right[rightIndex];

                        //increment index
                        rightIndex++;
                    }
                    else if (result > 0)
                    {
                        //left is less than right
                        list[i] = left[leftIndex];

                        //increment index
                        leftIndex++;
                    }
                    else
                    {
                        //they are equal, so we will do left as default
                        list[i] = left[leftIndex];

                        //increment index
                        leftIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// Sort array using merge sort algorithm
        /// Split data structure in half, sort sub-structures
        /// -Recursively, or use loops, to continue spliting sub-structures until they have 1-2 elements left to compare and swap
        /// -if structure only has 1 element, return and merge with other sub-structure
        /// 
        /// Merge the two sorted structures together
        /// -using a third structure to hold the finished product
        /// -iterate through the substructures, comparing element at pointer
        /// -insert lower element into third structure and move pointer to the right
        /// -if one sub-structure is depleted, concat the remaining elements to the final structure
        /// 
        /// Worst case running time should be: O(N logN)
        /// </summary>
        /// <typeparam name="T">data type of array</typeparam>
        /// <param name="array">array to be sorted</param>
        public void MergeSort<T>(ref T[] array)
        {
            //find the middle of the array
            //this will be the first array in the "right" array
            int center = array.Length / 2;

            //copy into left array            
            T[] left = new T[center];
            

            
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = array[i];
            }

            

            //copy into right array
            T[] right = new T[array.Length - center];
            int centerCopy = center;
            for (int i = 0; i < right.Length; i++)
            {                
                right[i] = array[centerCopy];
                centerCopy++;
            }

            //break it down more by calling recursively
            if (left.Length > 1)
            {
                MergeSort(ref left);
            }

            if (right.Length > 1)
            {
                MergeSort(ref right);
            }

            //merge
            int rightIndex = 0;
            int leftIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (rightIndex >= right.Length && leftIndex < left.Length)
                {
                    //right array is exhausted
                    array[i] = left[leftIndex];

                    //increment index
                    leftIndex++;
                }
                else if (leftIndex >= left.Length && rightIndex < right.Length)
                {
                    //left array is exhausted
                    array[i] = right[rightIndex];

                    //increment index
                    rightIndex++;
                }
                else
                {
                    //both arrays have something left to compare
                    int result = right[rightIndex] is IComparable<T> ?
                        ((IComparable<T>)right[rightIndex]).CompareTo((left[leftIndex])) :
                        StringComparer.CurrentCulture.Compare(right[rightIndex], left[leftIndex]);

                    if (result < 0)
                    {
                        //right is less than left
                        array[i] = right[rightIndex];

                        //increment index
                        rightIndex++;
                    }
                    else if (result > 0)
                    {
                        //left is less than right
                        array[i] = left[leftIndex];

                        //increment index
                        leftIndex++;
                    }
                    else
                    {
                        //they are equal, so we will do left as default
                        array[i] = left[leftIndex];

                        //increment index
                        leftIndex++;
                    }
                }
            }
        }
        #endregion

        #region Quick Sort
        /// <summary>
        /// sort the doubly linked list using the quick sort algorithm
        /// Choose an item arbitrarily, or find the median of the structure,
        /// Split the structure into 2 or 3 sub-structures (less than, same, greater than)
        /// Concat the sub-structures together
        /// 
        /// Sort sub-structures by recursively, or looping, the algorithm
        /// Average case runnign time should be: O(N logN)
        /// Worst case running time should be: O(N^2)
        /// </summary>
        /// <typeparam name="T">data type of the doubly linked list</typeparam>
        /// <param name="array">doubly linked to be sorted</param>
        public void QuickSort<T>(LinkedList<T> llist) { throw new NotImplementedException(); }

        /// <summary>
        /// sort the linked list using the quick sort algorithm
        /// Choose an item arbitrarily, or find the median of the structure,
        /// Split the structure into 2 or 3 sub-structures (less than, same, greater than)
        /// Concat the sub-structures together
        /// 
        /// Sort sub-structures by recursively, or looping, the algorithm
        /// Average case runnign time should be: O(N logN)
        /// Worst case running time should be: O(N^2)
        /// </summary>
        /// <typeparam name="T">data type of the linked list</typeparam>
        /// <param name="array">linked list to be sorted</param>
        public void QuickSort<T>(List<T> list) { throw new NotImplementedException(); }

        /// <summary>
        /// sort the array using the quick sort algorithm
        /// Choose an item arbitrarily, or find the median of the structure,
        /// Split the structure into 2 or 3 sub-structures (less than, same, greater than)
        /// Concat the sub-structures together
        /// 
        /// Sort sub-structures by recursively, or looping, the algorithm
        /// Average case runnign time should be: O(N logN)
        /// Worst case running time should be: O(N^2)
        /// </summary>
        /// <typeparam name="T">data type of the array</typeparam>
        /// <param name="array">array to be sorted</param>
        public void QuickSort<T>(T[] array) { throw new NotImplementedException(); }

        #endregion
        
        public void HeapSort() { throw new NotImplementedException(); }
        public void ShellSort() { throw new NotImplementedException(); }
        public void BucketSort() { throw new NotImplementedException(); }

    }
}
