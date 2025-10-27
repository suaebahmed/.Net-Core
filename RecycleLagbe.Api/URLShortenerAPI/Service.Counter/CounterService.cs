namespace URLShortenerAPI.Service.Counter
{
    public class CounterService
    {
        // Total unique possible: 62^7 ~ 3.5 trillion
        private long _counter = 0;
       
        public long GetNextCount()
        {
            return _counter++;
        }
    }
}
