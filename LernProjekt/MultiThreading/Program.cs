using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        private static CancellationToken _token;
        static async Task Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            _token = source.Token;

            ClientDataAccess clientTest = new ClientDataAccess("test");
            ClientDataAccess clientProd = new ClientDataAccess("prod");

            Func<ClientDataAccess, Task> funcTest = Execute;
            Func<ClientDataAccess, Task> funcProd = Execute;

            var taskTest = Task.Run(() => funcTest.Invoke(clientTest), _token);
            var taskProd = Task.Run(() => funcProd.Invoke(clientProd), _token);

        

            Console.ReadKey();
            source.Cancel();

            Task.WaitAll(new Task[] { taskProd, taskTest });

            source.Dispose();

            Console.WriteLine("######### PROGRAMMENDE #########");
        }

        public static async Task Execute(ClientDataAccess data)
        {
            while (true)
            {
                Console.WriteLine(data.Art);


                if (_token.IsCancellationRequested)
                {
                    return;
                }
            }
        }

        
    }
}
