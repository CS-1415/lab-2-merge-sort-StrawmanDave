// David Barlow, 1/21/2025, MergeSort,s

using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Markup;
/*
foreach (int thing in SortViaMergeSort(new int[]{6, 1, -5, 3, 5, 3, 7}))
{
    Console.Write($"{thing} ");
}
*/

System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual(CombineSortedArrays(new int[]{1, 3, 5}, new int[]{-5, 3, 6, 7}),new int[]{-5, 1, 3, 3, 5, 6, 7}));
System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual(SortViaMergeSort(new int[]{1, 10, -5, 2, 5, 2, 5, 8}),new int[]{-5, 1, 2, 2, 5, 5, 8, 10}));
System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual(SortViaMergeSort(new int[]{6, 1, -5, 3, 5, 3, 7}),new int[]{-5, 1, 3, 3, 5, 6, 7}));
System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual(SortViaMergeSort(new int[]{1, 10, -5, 2, 5, 2, 5, 8}),new int[]{-5, 1, 2, 2, 5, 5, 8, 10}));

int [] CombineSortedArrays(int[] a, int[] b)
{   
    //need some sort of counter to count through the index of each array
    int Acount = 0;
    int Bcount = 0;
    int newArrayLength = a.Length + b.Length;
    int[] c = new int[newArrayLength];

    int Ccount = 0;
    while(true)
    {
        if(Acount == a.Length)
        {
            while(Bcount < b.Length)
            {
                c[Ccount] = b[Bcount];
                Ccount ++;
                Bcount ++;
            }
            break;
        }
        if(Bcount == b.Length)
        {   
            while(Acount < a.Length)
            {
                c[Ccount] = a[Acount];
                Ccount ++;
                Acount ++;
            }
            break;
        }
        if(a[Acount] < b[Bcount])
        {
            c[Ccount] = a[Acount]; 
            Acount ++;
        }else
        {
            c[Ccount] = b[Bcount]; 
            Bcount ++;
        }
        Ccount++;
    }
    //Console.WriteLine($"Exited the while loop, Account = {Acount}, Bcount = {Bcount}, and Ccount = {Ccount}");
    return c;
}

int[] SortViaMergeSort(int[] unsortedArray)
{
    int middle = unsortedArray.Length /2;
    if(unsortedArray.Length < 2)
    {
        return unsortedArray;
    }else
    {
        return CombineSortedArrays(SortViaMergeSort(unsortedArray[0..middle]), SortViaMergeSort(unsortedArray[middle..unsortedArray.Length]));
    }
}
