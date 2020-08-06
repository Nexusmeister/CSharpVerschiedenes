using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Sockets;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine(Enum.Format(typeof(Class1), Class1.x105_60, "F"));
            


            // Specify the data source.
            int[] scores = { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            IEnumerable<string> highScoresQuery2 =
                from score in scores
                where score > 80
                orderby score descending
                select $"The score is {score}";

            foreach (var score in highScoresQuery2)
            {
                Console.WriteLine(score);
            }

            Console.WriteLine();

            int highscoreCount =
                (from score in scores
                    where score > 80
                    select score).Count();

            Console.WriteLine(highscoreCount);

            var nochEinTest = "uiofhrfi";
            var wioufnhfr = 3;




        }
    }
}
