namespace ParallelTest
{
    class ParallelTest
    {
        private static void TimedMessage(string arg_Message, int arg_Interval)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Source {arg_Message} - Cycle {i} for Interval {arg_Interval}");
                Task.Delay(200 * arg_Interval).Wait(); // Simulate delay synchronously
            }

            Console.WriteLine($"{arg_Message} - Complete");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Synchronous Program");
            Console.WriteLine("-----------------------------");
            TimedMessage("Four", 4);
            TimedMessage("Two", 2);

            Console.WriteLine("\nStarting Parallel Program");
            Console.WriteLine("-----------------------------");
            Parallel.Invoke(
                () => TimedMessage("Four", 4),
                () => TimedMessage("Two", 2)
            );

            // Wait for input before exiting
            Console.WriteLine("\nPress enter to finish after both [Complete] messages appear.");
            Console.ReadLine();
        }
    }
}
