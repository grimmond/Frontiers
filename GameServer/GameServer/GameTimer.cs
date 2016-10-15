// QueryPerfCounter.cs
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GameServer
{
    public class GameTimer
    {
        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(
          out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private long start;
        private long stop;
        private long mark;
        private long frequency;
        Decimal multiplier = new Decimal(1.0e9);

        public GameTimer()
        {
            if (QueryPerformanceFrequency(out frequency) == false)
            {
                // Frequency not supported
                throw new Win32Exception();
            }
        }

        /// <summary>
        /// Start Timer.
        /// </summary>
        public void Start()
        {
            QueryPerformanceCounter(out start);
        }

        /// <summary>
        /// "Stop" Timer.  Doesn't really, but need if you use the Duration method
        /// </summary>
        public void Stop()
        {
            QueryPerformanceCounter(out stop);
        }

        /// <summary>
        /// Returns time in seconds
        /// </summary>
        /// <returns></returns>
        public double Duration()
        {
            //return ((((double)(stop - start) * (double)multiplier) / (double)frequency)); //original
            return (((double)(stop - start)  / (double)frequency));
        }

        /// <summary>
        /// Returns time in seconds
        /// </summary>
        /// <returns></returns>
        public double Elapsed()
        {
            QueryPerformanceCounter(out mark);
            //return ((((double)(mark - start) * (double)multiplier) / (double)frequency));
            return (((double)(mark - start) / (double)frequency));
        }
    }
}
