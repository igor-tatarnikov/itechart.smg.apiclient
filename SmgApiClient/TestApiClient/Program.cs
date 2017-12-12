namespace TestApiClient
{
    using System;
    using SmgApiClient;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test SMG API client");

            try
            {
                var apiClient = new HttpSmgApiClient(
                    "test",
                    "test");

                var employees = apiClient.GetAllEmployesAsync().Result;

                Console.WriteLine("Employee info (Id / FirstName / LastNameEng / Position");

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.Id} {employee.FirstNameEng} {employee.LastNameEng} {employee.Position}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("Please, press Enter to exit");
            Console.ReadLine();
        }
    }
}
