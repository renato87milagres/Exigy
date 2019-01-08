using System;
using System;
using System.Linq;
class Solution
{
       
    public int solution1()
    {
        int sum = 0;
        int T = 0;
        int[] A = new int[] { 2, 3, 4, 1, 5 };
        for (int i = 0; i < A.Length; i++)
        {
            sum = sum + A[i];
            if (sum >= A.Length)
            {
                T = i;
                i = A.Length;
            }

        }
        Console.WriteLine(T);
        Console.ReadLine();
        return T;


    }

    public int solution2(int[] ranks)
    {
        
        int[] reportToNumber = new int[ranks.Length];
        int cont = 0;

        for (int i = 0; i < ranks.Length; i++)
        {
            reportToNumber[i] = ranks[i] + 1;
        
        }


        int[] B = ranks.Distinct().ToArray();
               
        for (int i = 0; i < B.Length; i++ )
        {
            
            for (int j = 0; j < reportToNumber.Length; j++)
            {
              

                if (B[i] == reportToNumber[j])
                {
                    cont = cont + 1;

                }
                
            }


      
           
         
        }
        Console.WriteLine(cont);
        Console.ReadKey();

        return cont;
        
    }




    static void Main(string[] args)
    {
        int[] A = new int[] { 0, 1, 3, 3, 4, 4 };
        Solution n = new Solution();
     
        //int teste = n.solution1();
        int T = n.solution2(A);
    }



}
