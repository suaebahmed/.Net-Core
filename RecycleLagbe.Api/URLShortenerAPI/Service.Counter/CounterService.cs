namespace URLShortenerAPI.Service.Counter
{
    public class CounterService
    {
        private long _counter = 100000; // Starting point for URL IDs
       
        public long GetNextCount()
        {
            return _counter++;
        }
    }
}
