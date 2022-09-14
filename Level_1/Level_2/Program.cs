using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }

    // 올바른 괄호
    public class CorrectParenthesis
    {
        public bool solution(string s)
        {
            Queue<bool> check = new Queue<bool>();
            if (s[0] == ')' || s[s.Length - 1] == '(')
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    check.Enqueue(false);
                else if (s[i] == ')')
                {
                    if (check.Count > 0)
                        check.Dequeue();
                    else
                        return false;
                }
            }

            if (check.Count > 0)
                return false;
            else
                return true;
        }
    }

    // 다음 큰 숫자
    public class NextBigNumber
    {
        public int solution(int n)
        {
            int answer = 0;
            int num = 0;

            string temp = Convert.ToString(n, 2);
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '1')
                    num++;
            }

            n++;
            while (true)
            {
                int count = 0;
                string str = Convert.ToString(n, 2);
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '1')
                        count++;
                }

                if (num == count)
                {
                    answer = n;
                    break;
                }
                else
                    n++;
            }

            return answer;
        }
    }

    // 최댓값과 최솟값
    public class MaxNumAndMinNum
    {
        public string solution(string s)
        {
            string[] str = s.Split(' ');
            string answer = "";
            List<int> data = new List<int>();

            for (int i = 0; i < str.Length; i++)
            {
                data.Add(int.Parse(str[i].ToString()));
            }

            data.Sort();

            answer = data[0].ToString() + " " + data[data.Count - 1].ToString();

            return answer;
        }
    }

    // 최솟값 만들기
    public class MinNumCreate
    {
        public int solution(int[] A, int[] B)
        {
            int answer = 0;
            Array.Sort(A);
            Array.Sort(B);
            Array.Reverse(B);

            for (int i = 0; i < A.Length; i++)
            {
                answer += A[i] * B[i];
            }

            return answer;
        }
    }

    // 피보나치 수
    public class Fibonacci
    {
        public int solution(int n)
        {
            int answer = 0;

            int first = 0;
            int second = 1;

            for (int i = 2; i <= n; i++)
            {
                answer = (first % 1234567) + (second % 1234567);
                answer = answer % 1234567;
                first = second % 1234567;
                second = answer;
            }

            return answer;
        }
    }
}
