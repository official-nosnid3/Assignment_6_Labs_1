using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace Assignment_6_Labs_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Week 6 Challenge Labs 1
             * 
             * Given a non-empty array of integers nums, every element appears twice 
             * except for one. Find that single one.
             * */

            int[] ints = { 1, 2, 1, 2, 3, 3 };

            Console.WriteLine("Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.");
            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }
            
            var (theInt, occurences) = FindTheOne(ints);

            if (theInt == -1)
                Console.WriteLine("\n\nThere was no int that fit the description in the given array.");
            else Console.WriteLine($"In the given array {theInt} appears {occurences} times.");
        }

        static (int, int) FindTheOne(int[] Ints_)
        {

            // The single int can either only have one copy, or have 3
            // or more copies within the array

            // Will keep count of occurances within the array
            // Keys will be every unique number and values will be the number of occurances
            Dictionary<int, int> counter = new Dictionary<int, int>();

            // Iterate through the array and store information onto the counter
            for (int i = 0; i < Ints_.Length; i++)
            {
                // If the int is not already in the dict then add it
                // Increment the value of int every other occurance
                if (!counter.ContainsKey(Ints_[i]))
                    counter.Add(Ints_[i], 1);
                else counter[Ints_[i]]++;
            }

            // Iterate through the counter and if there is a key that does not contain a value
            // of 2, then that key is the int we are looking for
            int myKey = -1; // default value if not found
            int myValue = 0;
            foreach (KeyValuePair<int, int> kvp in counter)
            {
                if (kvp.Value != 2)
                {
                    myKey = kvp.Key;
                    myValue = kvp.Value;
                    break;
                }
            }

            return (myKey, myValue);
        }
    }
}
