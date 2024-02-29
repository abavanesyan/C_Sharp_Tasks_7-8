Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Give the value of row");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Give the value of column");
int m = Convert.ToInt32(Console.ReadLine());

int[,] arr = new int[8, 8];
int[,] arr2 = new int[8, 8];
List<int[]> loc = new List<int[]>();
int maxindex = 0;
int maxcounter = 0;
void helper(int n, int m, int index) // This function is for finding the best place that the queen can be placed
{
    int counter = 0;
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (n - 1 == i && m - 1 == j)
            {
            }
            else if ((Math.Abs(n - 1 - i) == Math.Abs(m - 1 - j)) || j == m - 1 || i == n - 1)
            {
            }
            else
            {
                if (arr[i, j] != 1 && arr[i, j] != 9)
                {
                    counter++;
                }
            }
        }
    }
    arr2[n - 1, m - 1] = counter;
    if (counter > maxcounter)
    {
        maxcounter = counter;
        maxindex = index;
    }
}
void queen(int n, int m)
{
    maxindex = 0;
    maxcounter = 0;
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (n - 1 == i && m - 1 == j)
            {
                arr[i, j] = 9;
            }
            else if ((Math.Abs(n - 1 - i) == Math.Abs(m - 1 - j)) || j == m - 1 || i == n - 1)
            {
                arr[i, j] = 1;
            }
        }
    }
    loc.Clear();
    for (int k = 0; k < 8; k++)
    {
        for (int l = 0; l < 8; l++)
        {
            if (arr[k, l] == 9)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Q ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (arr[k, l] == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("1 ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                loc.Add([k, l]);
                Console.Write("0 ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine("Do you want to continue (y or n)");
    string ans = Console.ReadLine();

    if (ans == "y")
    {
        if (loc.Count != 0)
        {
            for (int i = 0; i < loc.Count; i++)
            {
                helper(loc[i][0] + 1, loc[i][1] + 1, i);
            }
            for (int k = 0; k < 8; k++)
            {
                for (int l = 0; l < 8; l++)
                {
                    if (arr[k, l] == 1)
                    {
                        Console.Write("1  ");
                    }
                    else if (arr[k, l] == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Q  ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (arr2[k, l] == maxcounter)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(maxcounter + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (maxcounter < 10)
                        {
                            Console.Write(" ");
                        }
                    }
                    else if (arr2[k, l] >= 0)
                    {
                        Console.Write(arr2[k, l] + " ");
                        if (arr2[k, l] < 10)
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            queen(loc[maxindex][0] + 1, loc[maxindex][1] + 1);
        }
        else
        {
            Console.WriteLine("There is no place left");
        }
    }
}
if (n > 0 && n < 9 && m > 0 && m < 9)
{
    queen(n, m);
}
else
{
    Console.WriteLine("You have mistaken the numbers");
}
