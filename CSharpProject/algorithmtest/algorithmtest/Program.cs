﻿using System;

namespace algorithmtest
{
    class MainClass
    {
        static readonly int[] A = { 10, 8, 12, 43, 11, 49, 23, 30 };

        public static void Main(string[] args)
        {

            Console.Write("排序前结果：");
            ShowResult();

            Console.Write("排序后结果：");
            //InsertionSort(A, A.Length);
            //BubbleSort(A, A.Length);
            //CocktailSort(A, A.Length);
            //SelectionSort(A, A.Length);
            //InsertionSortDichotomy(A, A.Length);
            ShellSort(A, A.Length);
        }

        // 插入排序(Insertion Sort)
        // 分类 ------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- 最坏情况为输入序列是降序排列的,此时时间复杂度O(n^2)
        // 最优时间复杂度 ---- 最好情况为输入序列是升序排列的,此时时间复杂度O(n)
        // 平均时间复杂度 ---- O(n^2)
        // 所需辅助空间 ------ O(1)
        // 稳定性 ------------ 稳定
        // 插入排序不适合对于数据量比较大的排序应用。
        // 但是，如果需要排序的数据量很小，比如量级小于千，那么插入排序还是一个不错的选择。
        // 在STL的sort算法和stdlib的qsort算法中，都将插入排序作为快速排序的补充，用于少量元素的排序（通常为8个或以下）。
        static void InsertionSort(int[] A, int n)
        {
            for (int i = 1; i < n; i++)
            {
                int card = A[i];
                int j = i - 1;
                while (j >= 0 && A[j] > card)
                {
                    A[j + 1] = A[j];
                    j--;
                }
                A[j + 1] = card;
            }
            ShowResult();
        }

        // 冒泡排序(Bubble Sort): 从低到高去比较序列里的每个元素
        // 分类 -------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- O(n^2)
        // 最优时间复杂度 ---- 如果能在内部循环第一次运行时,使用一个旗标来表示有无需要交换的可能,可以把最优时间复杂度降低到O(n)
        // 平均时间复杂度 ---- O(n^2)
        // 所需辅助空间 ------ O(1)
        // 稳定性 ------------ 稳定
        // 对于少数元素之外的数列排序是很没有效率的
        static void BubbleSort(int[] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        Swap(A, j, j + 1);
                    }
                }
            }
            ShowResult();
        }

        // 鸡尾酒排序(Cocktail Sort), 定向冒泡排序: 从低到高然后从高到低
        // 分类 -------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- O(n^2)
        // 最优时间复杂度 ---- 如果序列在一开始已经大部分排序过的话,会接近O(n)
        // 平均时间复杂度 ---- O(n^2)
        // 所需辅助空间 ------ O(1)
        // 稳定性 ------------ 稳定
        // 
        static void CocktailSort(int[] A, int n)
        {
            int left = 0;
            int right = n - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (A[i] > A[i + 1])
                    {
                        Swap(A, i, i + 1);
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (A[i] < A[i - 1])
                    {
                        Swap(A, i, i - 1);
                    }
                }
                left++;
            }
            ShowResult();
        }

        // 选择排序(Selection Sort)
        // 分类 -------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- O(n^2)
        // 最优时间复杂度 ---- O(n^2)
        // 平均时间复杂度 ---- O(n^2)
        // 所需辅助空间 ------ O(1)
        // 稳定性 ------------ 不稳定
        static void SelectionSort(int[] A, int n)
        {
            for (int i = 0; i < n; i++)     // i为已排序序列的末尾
            {
                int min = i;
                for (int j = i + 1; j < n; j++) // 未排序序列
                {
                    if (A[j] < A[min])       // 找出未排序序列中的最小值
                    {
                        min = j;
                    }
                }
                if (i != min)
                {
                    Swap(A, i, min);    // 放到已排序序列的末尾，该操作很有可能把稳定性打乱
                }
            }
            ShowResult();
        }

        // 插入排序的改进：二分插入排序
        // 分类 -------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- O(n^2)
        // 最优时间复杂度 ---- O(nlogn)
        // 平均时间复杂度 ---- O(n^2)
        // 所需辅助空间 ------ O(1)
        // 稳定性 ------------ 稳定
        static void InsertionSortDichotomy(int[] A, int n)
        {
            for (int i = 1; i < n; i++)
            {
                int left = 0;
                int right = i - 1;
                int card = A[i];
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (A[mid] <= card)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                for (int j = i - 1; j >= left; j--)
                {
                    A[j + 1] = A[j];
                }
                A[left] = card;
            }
            ShowResult();
        }

        // 插入排序的更高效改进：希尔排序(Shell Sort)
        // 分类 -------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- 根据步长序列的不同而不同。已知最好的为O(n(logn)^2)
        // 最优时间复杂度 ---- O(n)
        // 平均时间复杂度 ---- 根据步长序列的不同而不同。
        // 所需辅助空间 ------ O(1)
        // 稳定性 ------------ 不稳定
        // 希尔排序通过将比较的全部元素分为几个区域来提升插入排序的性能。
        // 这样可以让一个元素可以一次性地朝最终位置前进一大步。
        // 然后算法再取越来越小的步长进行排序，算法的最后一步就是普通的插入排序，但是到了这步，需排序的数据几乎是已排好的了（此时插入排序较快）。
        static void ShellSort(int[] A, int n)
        {
            int h = 0;
            while (h <= n)                          // 生成初始增量
            {
                h = 3 * h + 1;
            }
            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    int j = i - h;
                    int card = A[i];
                    while (j >= 0 && A[j] > card)
                    {
                        A[j + h] = A[j];
                        j = j - h;
                    }
                    A[j + h] = card;
                }
                h = (h - 1) / 3;
            }
            ShowResult();
        }


        static void Swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        static void ShowResult()
        {
            for (int i = 0; i < A.Length; i++)
            {
                //Console.Write(A[i] + " ");
                Console.Write("{0, -3}", A[i]); // 三位左对齐 
            }
            Console.WriteLine();
        }
    }
}
