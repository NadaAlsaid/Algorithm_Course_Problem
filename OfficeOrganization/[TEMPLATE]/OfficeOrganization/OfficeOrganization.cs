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
    public static class OfficeOrganization
    {
        #region YOUR CODE IS HERE
        /// <summary>
        /// find the minimum costs in MOST EFFICIENT WAY to organize your office to meet your father needs.
        /// </summary>
        /// <param name="N">initial load</param>
        /// <param name="M">target load required by your father</param>
        /// <param name="A">cost of reducing the load by half</param>
        /// <param name="B">cost of reducing the load by 1</param>
        /// <returns>Min total cost to reduce the load from N to M</returns>
        public static int OrganizeTheOffice(int N, int M, int A, int B)
        {
            int result = 0;
            while (N > M)
            {
                if ((N - M) * B > (A + (N/2 - M) * B) && N/2 >= M)
                {
                    N /= 2;
                    result += A;
                }
                else
                {
                    result += (N - M) * B;
                    N = M ;
                }
                
            }
            return result;
        }
        #endregion
    }
}
