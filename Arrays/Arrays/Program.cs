namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                //An array of 8 Fibonacci numbers.
                Console.WriteLine("Task #1: An array of 8 Fibonacci numbers.");
                int[] fibonacci = new int[8];
                fibonacci[0] = 0;
                fibonacci[1] = 1;
                for (int i = 2; i < fibonacci.Length; i++)
                {
                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                }
                Console.WriteLine("Fibonacci:");
                foreach (var num in fibonacci) Console.Write(num + " ");
            }
            Console.WriteLine("Task #1: End.");
            Console.WriteLine();


            //Array of month names in English.
            Console.WriteLine("Task #2: Array of month names in English.");
            string[] months = new string[]
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
            };

            //Output the result to the console.
            foreach (string month in months)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine("Task #2: End.");
            Console.WriteLine();

            //Two-dimensional array 3x3.
            Console.WriteLine("Task #3: Two-dimensional array 3x3");
            int[,] matrix = new int[3, 3];

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    int baseNumber = col + 2;      // 2, 3, 4
                    int exponent = row + 1;        // 1, 2, 3
                    matrix[row, col] = (int)Math.Pow(baseNumber, exponent);
                    Console.Write(matrix[row, col] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Task #3: End.");
            Console.WriteLine();


            Console.WriteLine("Task #4: Jagged array.");
            double[][] jaggedArray = new double[3][];
            jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new double[] { Math.E, Math.PI };
            jaggedArray[2] = new double[]
            {
                Math.Log10(1),
                Math.Log10(10),
                Math.Log10(100),
                Math.Log10(1000)
            };
            foreach (var arr in jaggedArray)
            {
                foreach (var val in arr)
                    Console.Write(val + "\t");
                Console.WriteLine();
            }
            Console.WriteLine("Task #4: End.");
            Console.WriteLine();


            //Two Arrays
            Console.WriteLine("Task #5-6: Copy and Print.");
            int[] array = { 1, 2, 3, 4, 5 };
                int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
                //Copy the first 3 elements of the first array to the second.
                Array.Copy(array, array2, 3);
                
                //Resize the first array so that it has twice as many elements.
                string[] sample = { "", "" };
                Array.Resize(ref array, array.Length * 2);
                PrintArray(array, "array");
                PrintArray(array2, "array2");

            void PrintArray(int[] array, string message)
            {
                Console.WriteLine(message);
                foreach(int i in array)
                {
                    var c = i + "\t";
                    Console.Write(c);
                }
                Console.WriteLine("Task #5-6: End.");
                Console.WriteLine();
            }
        }
    }
}