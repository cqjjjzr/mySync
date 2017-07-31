using System.Threading;

namespace mySync
{
    public class CountDownLatch
    {
        private readonly object _lockObj = new object();
        private int _counter;

        public CountDownLatch(int counter)
        {
            _counter = counter;
        }

        public void Await()
        {
            lock (_lockObj)
            {
                while (_counter > 0)
                {
                    Monitor.Wait(_lockObj);
                }
            }
        }

        public void CountDown()
        {
            lock (_lockObj)
            {
                _counter--;
                Monitor.PulseAll(_lockObj);
            }
        }
    }
}
