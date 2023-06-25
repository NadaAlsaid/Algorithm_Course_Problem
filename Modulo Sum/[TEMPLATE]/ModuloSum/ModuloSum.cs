using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class ModuloSum
    {
        #region YOUR CODE IS HERE    

        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// Fill this function to check whether there's a subsequence numbers in the given array that their sum is divisible by M
        /// </summary>
        /// <param name="items">array of integers</param>
        /// <param name="N">array size </param>
        /// <param name="M">value to check against it</param>
        /// <returns>true if there's subsequence with sum divisible by M... false otherwise</returns>
        static List<int> numbers;
        static bool isSubsequence;
        static Dictionary<int, int> dic;
        static public bool SolveValue(int[] items, int N, int M)
        {
            //DC Code
            /*
        //if (N==0)
        //    return false;
        //if (items[N-1] == M)
        //    return true;
        //if (M == 0)
        //    return true;
        //if (items[N-1 ]  != M)
        //{
        //    B1 = SolveValue(items, N - 1,(M - items[N-1]) %M );
        //    B2 = SolveValue(items, N - 1, M);
        //    return B1 || B2;
        //}
        //else
        //{
        //    return SolveValue(items, N - 1, M);
        //}
        */

            dic = new Dictionary<int, int>(); // To make sure that I insert item once
            bool[,] R = new bool[N + 1, M + 1]; // To certain there is sum of number divided on M or not
            numbers = new List<int>(); //To sort items that divided on M
            isSubsequence = false;
            //if N=1 or m=1 , check first item if it divided on M or not 
            if (N == 1 || M == 1)
            {
                isSubsequence = (items[0] % M == 0);
                if (isSubsequence)
                {
                    numbers = new List<int>
                    {
                        items[0]
                    };
                }
                return isSubsequence;
            }
            //check items if there is sum of numbers divided on M or not 
            for (int i = 0; i <= N; i++)
            {
                for (int j = 1; j <= M; j++)
                {
                    if (i == 0)
                    {
                        R[i, j] = true;
                    }
                    else if (items[i - 1] != j )
                    {
                        R[i, j] = R[i - 1, Math.Abs((j - items[i - 1])) % M] || R[i - 1, j];
                        
                        if (  items[i - 1]   % M == 0  )
                        {
                            
                            numbers = new List<int>{
                                    items[i - 1]
                            };

                            isSubsequence = true;
                            return true;
                        }

                        if (R[i - 1, Math.Abs((j - items[i - 1])) % M] && !dic.ContainsKey(i)&& ( items[i - 1] - j) > 0 )
                        {
                            dic.Add(i, items[i - 1]);
                            numbers.Add(items[i - 1]);
                        }
                    }
                    else
                    {
                        R[i, j] = R[i-1, j];
                       
                    }
                }

            }
            isSubsequence = R[N, M];
            return isSubsequence;
        }
        #endregion

        #region FUNCTION#2: Construct the Solution
        //Your Code is Here:
        //==================
        /// <returns>if exists, return the numbers themselves whose sum is divisible by ‘M’ else, return null</returns>
        static public int[] ConstructSolution(int[] items, int N, int M)
        {
        
            if (!isSubsequence)
                return null;
            return numbers.ToArray();
        }


        #endregion
        #endregion
    }
}
