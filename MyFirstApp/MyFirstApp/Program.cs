class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        if (!Int32.TryParse(Console.ReadLine(), out var a))
        {
            Console.WriteLine("Not a number");
            return;
        }
        Console.WriteLine("Enter a number:");
        if (!Int32.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine("Not a number");
            return;
        }

        Console.WriteLine("Enter a sign ^ or | or &");
        var s = Console.ReadLine();
        if (s.Length == 0 || s.Length > 1)
        {
            Console.WriteLine("Wrong sign");
            return;
        }

        switch (s[0])
        {
            case '&':
                {
                    var result = a & b;
                    Console.WriteLine("Result of {0} & {1} = {2}, binary: {3}, hex: {4}", a, b, result, Convert.ToString(result, 2), Convert.ToString(result, 16).ToUpper());
                    break;
                }
            case '|':
                {
                    var result = a | b;
                    Console.WriteLine("Result of {0} | {1} = {2}, binary: {3}, hex: {4}", a, b, result, Convert.ToString(result, 2), Convert.ToString(result, 16).ToUpper());
                    break;
                }
            case '^':
                {
                    var result = a ^ b;
                    Console.WriteLine("Result of {0} ^ {1} = {2}, binary: {3}, hex: {4}", a, b, result, Convert.ToString(result, 2), Convert.ToString(result, 16).ToUpper());
                    break;
                }
            default: Console.WriteLine("Wrong sign");
                break;
        }
    }
}
