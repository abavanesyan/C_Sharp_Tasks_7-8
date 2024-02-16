Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Give the value of row");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Give the value of column");
int m = Convert.ToInt32(Console.ReadLine());

int[,] arr = { {2, 3, 4, 4, 4, 4, 3, 2 },
               {3, 4, 6, 6, 6, 6, 4, 3 },
               {4, 6, 8, 8, 8, 8, 6, 4 },
               {4, 6, 8, 8, 8, 8, 6, 4 },
               {4, 6, 8, 8, 8, 8, 6, 4 },
               {4, 6, 8, 8, 8, 8, 6, 4 },
               {3, 4, 6, 6, 6, 6, 4, 3 },
               {2, 3, 4, 4, 4, 4, 3, 2 }, };

int min, ind_i, ind_j;
void knight(int n, int m)
{
    min = 9;
    ind_i = 0;
    ind_j = 0;
    for (int i = 1; i < 9; i++)
    {
        for (int j = 1; j < 9; j++)
        {
            if (arr[i - 1, j - 1] == 9)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("K ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if ((Math.Abs(n - i) == 2 && Math.Abs(m - j) == 1) || (Math.Abs(n - i) == 1 && Math.Abs(m - j) == 2))
            {
                if (arr[i - 1, j - 1] < min)
                {
                    min = arr[i - 1, j - 1];
                    ind_i = i;
                    ind_j = j;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(arr[i - 1, j - 1] + " ");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (n == i && m == j)
            {
                arr[i - 1, j - 1] = 9;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("K ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("0 ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine("Do you want to continue (y or n)");
    string ans = Console.ReadLine();

    if (ans == "y")
    {
        if (min != 9)
        {
            knight(ind_i, ind_j);
        }
        else
        {
            Console.WriteLine("There is no place left");
        }
    }
}
if (n > 0 && n < 9 && m > 0 && m < 9)
{
    knight(n, m);
}
else
{
    Console.WriteLine("You have mistaken the numbers");
}