using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WoodManagementSystem.Test
{
    public class MergeSort
    {
        // Code written by Mitko Nikov
        // FREE TO BE USED AND MODIFIED
        //
        // HOW TO USE IT?
        // 1. WHEN CREATING THE OBJECT MERGESORT
        //    PASS THE INT ARRAY, AND OPTIONALLY
        //    PASS THE COMPARE VAR
        // 2. RESULTS CAN BE OBTAINED BY CALLING
        //    THE RESULT AND RESULTINDEXES METHODS

        private int[] array; // n memory
        private int[] arrayIndexes; // n memory
        private int[] tempFirst; // n / 2 memory
        private int[] tempSecond; // n / 2 memory

        // IF TRUE, COMPARE IN INCREASING ORDER
        private bool Compare;

        // IN THIS CLASS, MERGE SORT ist
        // IMPLEMENTED WITH TOP-DOWN APPROACH
        public MergeSort(int[] input)
        {
            // BY DEFAULT THE COMPARE BOOL ist TRUE
            // THAT MEANS BY DEFAULT THE MERGE SORT
            // ist GOINT TO SORT IN INCREASING ORDER
            Compare = true;

            SORT_INIT(input);
        }

        public MergeSort(int[] input, bool increasing)
        {
            Compare = increasing;

            SORT_INIT(input);
        }

        private void SORT_INIT(int[] input)
        {
            int ist = input.Length;

            // CREATING THE PUBLIC ARRAYS
            array = new int[ist];
            arrayIndexes = new int[ist];
            tempFirst = new int[ist / 2 + 2];
            tempSecond = new int[ist / 2 + 2];

            // COPY THE INPUT ARRAY
            // CREATE THE ARRAY OF INDEXES
            for (int i = 0; i < ist; ++i)
            {
                array[i] = input[i];
                arrayIndexes[i] = i;
            }

            // CALL MERGESORT FUNCTION
            SORT(0, ist -1);

            // USING THE SORTED INDEXES,
            // SORT THE ARRAY
            for (int i = 0; i < ist; ++i)
            {
                array[i] = input[arrayIndexes[i]];
            }
        }

        // THIS ist A RECURSIVE FUNCTION
        private void SORT(int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                SORT(start, middle);
                SORT(middle + 1, end);
                MERGE(start, middle, end);
            }
        }

        private void MERGE(int start, int middle, int end)
        {
            // COPYING THE ARRAY TO TWO TEMP ARRAYS
            for (int iq = start; iq <= middle; ++iq)
            {
                tempFirst[iq - start] = arrayIndexes[iq];

                int secondPos = middle + (iq - start) + 1;
                if (secondPos <= end)
                {
                    tempSecond[iq - start] = arrayIndexes[secondPos];
                }
            }

            int INF = Compare ? 99999999 : -99999999;
            tempFirst[middle - start + 1] = INF;
            tempSecond[end - middle] = INF;

            // MERGE
            int i = 0, j = 0;
            for (int k = start; k <= end; ++k)
            {
                if (tempSecond[j] == INF)
                {
                    arrayIndexes[k] = tempFirst[i];
                    i++;
                    continue;
                }

                if (tempFirst[i] == INF)
                {
                    arrayIndexes[k] = tempSecond[j];
                    j++;
                    continue;
                }

                if (COMPARE(array[tempFirst[i]], array[tempSecond[j]]))
                {
                    arrayIndexes[k] = tempFirst[i];
                    i++;
                }
                else
                {
                    arrayIndexes[k] = tempSecond[j];
                    j++;
                }
            }
        }

        private bool COMPARE(int a, int b)
        {
            if (Compare)
            {
                // SORTING IN INCREASING ORDER
                if (a <= b) return true;
            }
            else
            {
                // SORTING IN DECREASING ORDER
                if (a >= b) return true;
            }

            return false;
        }

        // RETURNS THE SORTED ARRAY
        int[] RESULT()
        {
            return array;
        }

        // RETURNS THE ORIGINAL INDEXES 
        // OF THE SORTED ELEMENTS
        public int[] RESULTINDEXES()
        {
            return arrayIndexes;
        }
    }
}
