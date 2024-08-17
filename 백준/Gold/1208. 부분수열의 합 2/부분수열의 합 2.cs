using System;
using System.Collections.Generic;

class MainClass {
    static int N, S;
    static int[] arr;
    static Dictionary<int, int> total = new Dictionary<int, int>();
    static long cnt;

    static void Left(int s, int sum) {
        if (s == N / 2) {
            if (!total.ContainsKey(sum))
                total[sum] = 0;
            total[sum]++;
            return;
        }
        Left(s + 1, sum);
        Left(s + 1, sum + arr[s]);
    }

    static void Right(int s, int sum) {
        if (s == N) {
            if (total.ContainsKey(S - sum))
                cnt += total[S - sum];
            return;
        }
        Right(s + 1, sum);
        Right(s + 1, sum + arr[s]);
    }

    public static void Main (string[] args) {
        string[] input = Console.ReadLine().Split();
        N = int.Parse(input[0]);
        S = int.Parse(input[1]);
        arr = new int[N];

        string[] arrInput = Console.ReadLine().Split();
        for (int i = 0; i < N; i++) {
            arr[i] = int.Parse(arrInput[i]);
        }

        Left(0, 0);
        Right(N / 2, 0);

        if (S == 0) Console.WriteLine(cnt - 1);
        else Console.WriteLine(cnt);
    }
}
