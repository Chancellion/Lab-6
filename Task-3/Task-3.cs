using System;
using System.Collections.Generic;

public class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();
    private class CacheItem
    {
        public TResult Result { get; set; }
        public DateTime Expiration { get; set; }
    }
    public delegate TResult Func(TKey key);
    public TResult GetOrAdd(TKey key, Func function, TimeSpan duration)
    {
        if (cache.ContainsKey(key))
        {
            CacheItem item = cache[key];
            if (DateTime.Now < item.Expiration)
            {
                return item.Result;
            }
            else
            {
                cache.Remove(key);
            }
        }

        TResult result = function(key);
        cache[key] = new CacheItem { Result = result, Expiration = DateTime.Now.Add(duration) };
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Данiїл Iванченко, КIб-1-23-4.0д");
        FunctionCache<int, int> cache = new FunctionCache<int, int>();
        FunctionCache<int, int>.Func squareFunction = key => key * key;
        int result1 = cache.GetOrAdd(5, squareFunction, TimeSpan.FromMinutes(1));
        Console.WriteLine("Результат 1: " + result1);
        int result2 = cache.GetOrAdd(5, squareFunction, TimeSpan.FromMinutes(1));
        Console.WriteLine("Результат 2: " + result2);
        System.Threading.Thread.Sleep(TimeSpan.FromMinutes(2));
        int result3 = cache.GetOrAdd(5, squareFunction, TimeSpan.FromMinutes(1));
        Console.WriteLine("Результат 3: " + result3);
    }
}
