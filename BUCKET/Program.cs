using System;
using System.Drawing.Printing;

namespace BUCKET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selector = -1;
            Console.WriteLine("input question number");
            while (selector < 2)
            {
                try
                {
                    selector = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                }
            }
            if (selector == 0 || selector == 1)
            {
                Console.WriteLine("invalid question try a diffrent question. executable questions { 2,3,4 }");
                return;
            }
            if (selector == 2)
                Question2();
            if (selector == 3)
                Question3();
            if (selector == 4)
            {
                int boolean = -1;
                while (boolean != 0 || boolean != 1)
                {
                Console.WriteLine(@"Which part of the question are you doing now
input 0 for part 1 || input 1 for part 2");
                    boolean = int.Parse(Console.ReadLine());
                    Console.Clear();
                }

                if (boolean == 0)
                {
                    Question4();
                }
                else if (boolean == 1)
                {
                    Question4(true);
                }
            }
        }
        public static void Question2()
        {
            int capacity = -1;
            double currentAmount = -1.0;
            for (int i = 0; capacity <= 0 || currentAmount < 0; i++)
            {//Q2.1
                Console.WriteLine("Please enter bucket capacity, current amount (order is important)");
                try
                {
                    capacity = int.Parse(Console.ReadLine());
                    currentAmount = double.Parse(Console.ReadLine());
                }
                catch (Exception) { }
                finally
                {
                    if (currentAmount > capacity * 0.3)
                    {
                        Console.WriteLine("Current amount must be <= 30% of capacity try again");
                        ErrorCorrector();
                    }
                }
            }
            Bucket bucket = new Bucket(capacity, currentAmount);
            Console.WriteLine(bucket.ToString());
            void ErrorCorrector()
            {
                while (currentAmount > capacity * 0.3)
                {
                    try
                    {
                        Console.WriteLine("enter a diffrent value for current amount that is also valid");
                        currentAmount = double.Parse(Console.ReadLine());
                    }
                    catch (Exception) { }
                }
            }
        }
        public static void Question3()
        {
            int capacity = -1;
            double currentAmount = -1.0;
            for (int i = 0; capacity <= 0 || currentAmount < 0; i++)
            {
                Console.WriteLine("Please enter bucket capacity, current amount (order is important)");
                try
                {
                    capacity = int.Parse(Console.ReadLine());
                    currentAmount = double.Parse(Console.ReadLine());
                }
                catch (Exception) { }
                finally
                {
                    if (currentAmount > capacity * 0.3)
                    {
                        Console.WriteLine("Current amount must be <= 30% of capacity try again");
                        ErrorCorrector();
                    }
                }
            }
            Bucket bucket = new Bucket(capacity, currentAmount);
            Console.WriteLine($"Current Bucket: {bucket}\n");
            Console.WriteLine("Bucket is now being filled 4x its capacity");
            bucket.Fill(bucket.GetCapacity() * 4);
            Console.WriteLine($"Updated Bucket: {bucket}\n");
            double amountToFill = 0;
            while (amountToFill == 0)
            {
                Console.WriteLine(@"how much do u want to fill the bucket now
(if you want to test dont use negative numbers.
using 0 wont work as it is used for the loop)");
                try
                {
                    amountToFill = double.Parse(Console.ReadLine());
                }
                catch (Exception) { }
            }
            bucket.Fill(amountToFill);
            Console.WriteLine($"Overloaded Bucket: {bucket}");
            void ErrorCorrector()
            {
                while (currentAmount > capacity * 0.3)
                {
                    try
                    {
                        Console.WriteLine("enter a diffrent value for current amount that is also valid");
                        currentAmount = double.Parse(Console.ReadLine());
                    }
                    catch (Exception) { }
                }
            }
        }
        public static void Question4()
        {
            int capacity = 0;
            while (capacity <= 0)
            {
                Console.WriteLine("Please enter bucket capacity");
                try
                {
                    capacity = int.Parse(Console.ReadLine());
                }
                catch (Exception) { }
            }
            Bucket bucket = new Bucket(capacity);
            bucket.FillAll();
            Console.WriteLine(bucket.ToString());
        }
        public static void Question4(bool arg)
        {
            int capacity = 0;
            while (capacity <= 0)
            {
                Console.WriteLine("Please enter bucket capacity");
                try
                {
                    capacity = int.Parse(Console.ReadLine());
                }
                catch (Exception) { }
            }
            Bucket bucket2 = new Bucket(capacity);
            double amountToFill;
            for (int i = 0; i < 3; i++)
            {
                amountToFill = 0;
                while (amountToFill == 0)
                {
                    try
                    {
                        Console.WriteLine($"Enter how much will you fill the bucket in attempt#{i + 1} ");
                        amountToFill = double.Parse(Console.ReadLine());
                    }
                    catch (Exception) { }
                }
                bucket2.Fill(amountToFill);
                Console.WriteLine($@"The second bucket is full. is this statement true or false?
the statement was {bucket2.IsFull()}
");
                Console.WriteLine($"Second Bucket [attp#{i}]:{bucket2}");
            }
        }
    }
}
