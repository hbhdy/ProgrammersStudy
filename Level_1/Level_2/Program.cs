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
            long data = MaxDistanceJump.solution(4);

            Console.WriteLine("정답은 ? : "+ data.ToString());
        }
    }

    // 게임 맵 최단거리
    public class GameMapMinDistance
    {
        int n = 0;
        int m = 0;

        // 상하좌우
        int[] dx = { 0, 0, -1, 1 };
        int[] dy = { -1, 1, 0, 0 };

        Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();

        public int solution(int[,] maps)
        {
            n = maps.GetLength(0);
            m = maps.GetLength(1);

            BFS(0, 0, maps);

            if (maps[n - 1, m - 1] == 1)
                return -1;
            else
                return maps[n - 1, m - 1];
        }


        public void BFS(int i,int j, int[,] maps)
        {
            queue.Enqueue(new KeyValuePair<int, int>(i, j));

            while (queue.Count != 0)
            {
                KeyValuePair<int, int> keyValue = queue.Dequeue();

                // 4방향 확인 
                for (int dis = 0; dis < 4; dis++)
                {
                    int x = keyValue.Key + dx[dis];
                    int y = keyValue.Value + dy[dis];

                    // 구역안에 있으며, 이동 가능한 위치
                    if ((x >= 0 && n > x) && (y >= 0 && m > y) && maps[x, y] == 1)
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(x, y));
                        
                        // 누적 처리
                        maps[x, y] = maps[keyValue.Key, keyValue.Value] + 1;
                    }
                }
            }
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

    // 멀리 뛰기
    public class MaxDistanceJump
    {
        public static long solution(int n)
        {
            // 정리해보니 피보나치였음.. ㄷㄷ
            long answer = 0;
            
            // 다음 수부터 처리   
            long first = 1;
            long second = 1;

            if (n == 1)
                return 1;

            for (int i = 2; i <= n; i++)
            {
                answer = (first % 1234567) + (second % 1234567);
                first = second % 1234567;
                second = answer;
            }

            answer %= 1234567;         

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
