using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int number =-1;
        int sum = 0;
        int largest = 1;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        }while (number != 0);
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        float avg = ((float)sum) / numbers.Count;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] >= largest)
            {
                largest = numbers[i];
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}