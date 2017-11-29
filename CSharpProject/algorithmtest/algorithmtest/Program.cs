using System;

namespace algorithmtest
{
    class MainClass
    {
        static readonly int[] array = { 12, 8, 10, 43, 51, 49, 32, 30};

        public static void Main(string[] args)
        {

            Console.Write("排序前结果：");
            ShowResult();

            Console.Write("排序后结果：\n");
            //InsertionSort(array, array.Length);
            //BubbleSort(array, array.Length);
            //CocktailSort(array, array.Length);
            //SelectionSort(array, array.Length);
            //InsertionSortDichotomy(array, array.Length);
            //ShellSort(array, array.Length);
            //MergeSortRecursion(array, 0, array.Length - 1);
            //MergeSortIteration(array, array.Length);
            //HeapSort(array, array.Length);
            HeapSort(array);
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
        }

        // 插入排序的更高效改进：希尔排序(Shell Sort)
        // 分类 -------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- 根据步长序列的不同而不同。已知最好的为O(n(logn)^2)
        // 最优时间复杂度 ---- O(n)
        // 平均时间复杂度 ---- 根据步长序列的不同而不同。
        // 所需辅助空间 ------ O(1)
        // 稳定性 ------------ 不稳定
        // 实际上是一种分组插入方法。
        // 先取定一个小于n的整数d1作为第一个增量, 把表的全部记录分成d1个组, 所有距离为d1的倍数的记录放在同一个组中,在各组内进行直接插入排序；
        // 然后,取第二个增量d2(＜d1),重复上述的分组和排序,直至所取的增量dt=1(dt<dt-1<…<d2<d1),即所有记录放在同一组中进行直接插入排序为止.
        static void ShellSort(int[] A, int n)
        {
            int h = 0;
            int param = 3;
            while (h <= n)                          // 生成初始增量
            {
                h = param * h + 1;
            }
            Console.WriteLine();
            while (h >= 1)
            {
                h = (h - 1) / param;
                if (h > 0)
                {
                    Console.Write("h: {0, 2} ---- ", h);
                }
                else
                {
                    Console.WriteLine();
                }
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
                ShowResult();
            }
        }

        // 归并排序(Merge Sort)
        // 分类 -------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- O(nlogn)
        // 最优时间复杂度 ---- O(nlogn)
        // 平均时间复杂度 ---- O(nlogn)
        // 所需辅助空间 ------ O(n)
        // 稳定性 ------------ 稳定
        // 1 申请空间，使其大小为两个已经排序序列之和，该空间用来存放合并后的序列
        // 2 设定两个指针，最初位置分别为两个已经排序序列的起始位置
        // 3 比较两个指针所指向的元素，选择相对小的元素放入到合并空间，并移动指针到下一位置
        // 4 重复步骤3直到某一指针到达序列尾
        // 5 将另一序列剩下的所有元素直接复制到合并序列尾
        static void Merge(int[] A, int left, int mid, int right)
        {
            int len = right - left + 1;
            int[] temp = new int[len];
            int index = 0, i = left, j = mid + 1;
            while (i <= mid && j <= right)
            {
                temp[index++] = A[i] <= A[j] ? A[i++] : A[j++];
            }
            while(i <= mid)
            {
                temp[index++] = A[i++];
            }
            while(j <= right)
            {
                temp[index++] = A[j++];
            }
            for (int k = 0; k < len; k++)
            {
                A[left++] = temp[k];
            }
            ShowResult();
        }

        static void MergeSortRecursion(int[] A, int left, int right)
        {
            if (left == right)
            {
                return;
            }
			int mid = (left + right) / 2;
            if (left < right)
            {
                MergeSortRecursion(A, left, mid);
                MergeSortRecursion(A, mid + 1, right);
            }
			Merge(A, left, mid, right);
        }

        static void MergeSortIteration(int[] A, int len)    // 非递归(迭代)实现的归并排序(自底向上)
        {
            int left = 0, mid = 0, right = 0;// 子数组索引,前一个为A[left...mid]，后一个子数组为A[mid+1...right]
            for (int i = 1; i < len; i *= 2)        // 子数组的大小i初始为1，每轮翻倍
            {
                left = 0;
                while (left + i < len)              // 后一个子数组存在(需要归并)
                {
                    mid = left + i - 1;
                    right = mid + i < len ? mid + i : len - 1;// 后一个子数组大小可能不够
                    Console.WriteLine("i = {0}, left = {1}, mid = {2}, right = {3}", i, left, mid, right);
                    Merge(A, left, mid, right);
                    left = right + 1;               // 前一个子数组索引向后移动
                }
				Console.WriteLine("i = {0}, left = {1}, mid = {2}, right = {3}", i, left, mid, right);
            }
        }

        // 堆排序(Heap Sort)
        // 分类 -------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- O(nlogn)
        // 最优时间复杂度 ---- O(nlogn)
        // 平均时间复杂度 ---- O(nlogn)
        // 所需辅助空间 ------ O(1)
        // 稳定性 ------------ 不稳定
        //static void Heapify(int[] A, int i, int size)
        //{
        //    int left_child = 2 * i + 1;
        //    int right_child = 2 * i + 2;
        //    int max = i;
        //    if (left_child < size && A[left_child] > A[max])
        //    {
        //        max = left_child;
        //    }
        //    if(right_child < size && A[right_child] > A[max])
        //    {
        //        max = right_child;
        //    }
        //    if(max != i){
        //        Swap(A, i, max);
        //        Heapify(A, max, size);
        //    }
        //}

        //static int BuildHeap(int[] A, int n) // 建堆，时间复杂度O(n)
        //{
        //    int heap_size = n;
        //    for (int i = heap_size / 2 - 1; i >= 0; i--) // 从每一个非叶结点开始向下进行堆调整
        //    {
        //        Heapify(A, i, heap_size);
        //    }
        //    return heap_size;
        //}

        //static void HeapSort(int[] A, int n)
        //{
        //    int heap_size = BuildHeap(A, n);    // 建立一个最大堆
        //    while(heap_size > 1)                // 堆（无序区）元素个数大于1，未完成排序
        //    {
        //        // 将堆顶元素与堆的最后一个元素互换，并从堆中去掉最后一个元素
        //        // 此处交换操作很有可能把后面元素的稳定性打乱，所以堆排序是不稳定的排序算法
        //        Swap(A, 0, --heap_size);
        //        Heapify(A, 0, heap_size);       // 从新的堆顶元素开始向下进行堆调整，时间复杂度O(logn
        //    }
        //}

        // 堆排序(Heap Sort)
        // 分类 -------------- 内部比较排序
        // 数据结构 ---------- 数组
        // 最差时间复杂度 ---- O(nlogn)
        // 最优时间复杂度 ---- O(nlogn)
        // 平均时间复杂度 ---- O(nlogn)
        // 所需辅助空间 ------ O(1)
        // 稳定性 ------------ 不稳定
        // 堆是一棵顺序存储的完全二叉树。
        // (1) Ri <= R2i+1 且 Ri <= R2i+2 (小根堆)
        // (2) Ri >= R2i+1 且 Ri >= R2i+2 (大根堆)
        // 设当前元素在数组中以R[i]表示，那么，
		// (1) 它的左孩子结点是：R[2 * i + 1];
		// (2) 它的右孩子结点是：R[2 * i + 2];
		// (3) 它的父结点是：R[(i - 1) / 2];
		// (4) R[i] <= R[2 * i + 1] 且 R[i] <= R[2i + 2]。
        // 堆排序的思想：
        // (1）根据初始数组去构造初始堆（构建一个完全二叉树，保证所有的父结点都比它的孩子结点数值大）。
		// (2）每次交换第一个和最后一个元素，输出最后一个元素（最大值），然后把剩下元素重新调整为大根堆。 
		static void HeapAdjust(int[] A, int parent, int length)
        {
            int temp = A[parent];   // temp保存当前父节点
            int child = 2 * parent + 1; // 先获得左孩子

            while(child < length)
            {
                // 如果有右孩子结点，并且右孩子结点的值大于左孩子结点，则选取右孩子结点
                if(child + 1 < length && A[child] < A[child + 1])
                {
                    child++;
                }

                // 如果父结点的值已经大于孩子结点的值，则直接结束
                if(temp >= A[child])
                {
                    break;
                }

                // 把孩子结点的值赋给父结点
                A[parent] = A[child];
                // 选取孩子结点的左孩子结点,继续向下筛选
                parent = child;
                child = 2 * child + 1;
            }
            A[parent] = temp;
        }

        static void HeapSort(int[] A)
        {
            // 循环建立初始堆
            for (int i = A.Length / 2; i >= 0; i--)
            {
                HeapAdjust(A, i, A.Length);
            }
            // 进行n-1次循环，完成排序
            for (int i = A.Length - 1; i > 0; i--)
            {
                // 最后一个元素和第一元素进行交换
                Swap(A, 0, i);
                // 筛选 R[0] 结点，得到i-1个结点的堆
                HeapAdjust(A, 0, i);
            }
        }

        static void Swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        static void ShowResult()
        {
            for (int i = 0; i < array.Length; i++)
            {
                //Console.Write(A[i] + " ");
                Console.Write("{0, -3}", array[i]); // 三位左对齐 
            }
            Console.WriteLine();
        }
    }
}
