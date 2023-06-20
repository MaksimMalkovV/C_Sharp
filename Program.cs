
static void Main()
{
    int[] nums = { 4, -12, 3, 31, 0, 7, 4, 14, 90, 5 };
    nums = QuicSort(nums, 0, nums.Length - 1);
    Console.WriteLine("Множество после быстрой сортировки:");
    foreach (int item in nums)
    {
        Console.Write(item + " ");
    }

    double[] arr = { 9, -62, 5, 31, 7, 7, 4, 56, 30, 5 };
    PyramidSorting.sorting(arr, arr.Length);
    Console.WriteLine("\n Множество после пирамидальной сортировки:");
    foreach (double x in arr)
    {
        System.Console.Write(x + " ");
    }
}
Main(); // писал на VS code/ костылик подложил

// метод выбора основоного элемента
static int FindPivot(int[] nums, int minIndex, int maxIndex)
{
    int pivot = minIndex - 1;
    int temp = 0;
    for (int i = minIndex; i < maxIndex; i++)
    {
        if (nums[i] < nums[maxIndex])
        {
            pivot++;
            temp = nums[pivot];
            nums[pivot] = nums[i];
            nums[i] = temp;
        }
    }
    pivot++;
    temp = nums[pivot];
    nums[pivot] = nums[maxIndex];
    nums[maxIndex] = temp;

    return pivot;
}

// основной метод сортировки
static int[] QuicSort(int[] nums, int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex)
    {
        return nums;
    }

    int pivot = FindPivot(nums, minIndex, maxIndex);
    QuicSort(nums, minIndex, pivot - 1);
    QuicSort(nums, pivot + 1, maxIndex);

    return nums;
}



class PyramidSorting
{
    static int add2pyramid(double[] arr, int i, int N)
    {
        int imax;
        double buf;
        if ((2 * i + 2) < N)
        {
            if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
            else imax = 2 * i + 1;
        }
        else imax = 2 * i + 1;
        if (imax >= N) return i;
        if (arr[i] < arr[imax])
        {
            buf = arr[i];
            arr[i] = arr[imax];
            arr[imax] = buf;
            if (imax < N / 2) i = imax;
        }
        return i;
    }
    public static void sorting(double[] arr, int len)
    {
        //шаг 1: постройка пирамиды
        for (int i = len / 2 - 1; i >= 0; --i)
        {
            long prev_i = i;
            i = add2pyramid(arr, i, len);
            if (prev_i != i) ++i;
        }

        //шаг 2: сортировка
        double buf;
        for (int k = len - 1; k > 0; --k)
        {
            buf = arr[0];
            arr[0] = arr[k];
            arr[k] = buf;
            int i = 0, prev_i = -1;
            while (i != prev_i)
            {
                prev_i = i;
                i = add2pyramid(arr, i, k);
            }
            foreach (double x in arr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
        }
    }
}