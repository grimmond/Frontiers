using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameServer;

namespace GameServerTester
{
    class Program
    {
        Main gameServer = new Main();
        Thread thread = null;

        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Starting server....");
            p.thread = new Thread (p.StartupServer);
            p.thread.IsBackground = true;
            p.thread.Start();
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();

            p.gameServer.OnStop();
            p.thread.Join(15000);
            
            if (p.thread.IsAlive)
            {
                Console.WriteLine("Could not terminate, killing...");
                p.thread.Abort();
                Console.WriteLine("killed.");
            }

            Console.WriteLine("Gameloop ended.  Anykey to end.");
            Console.ReadKey();
        }

        public void StartupServer()
        {
            gameServer.OnStart();
        }
    }

    
}
