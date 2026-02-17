using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;
// Subject
public interface INewsAgency
{
    void Attach(ISubscriber subscriber);
    void Detach(ISubscriber subscriber);
    void Notify();
}

// ConcreteSubject
public class NewsAgency : INewsAgency
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();
    private string _news;
    public void Attach(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }
    public void Detach(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }
    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(_news);
        }
    }
    public void ReleaseNews(string news)
    {
        _news = news;
        Notify();
    }
}

// Observer
public interface ISubscriber
{
    void Update(string news);
}
// ConcreteObserver
public class Newspaper : ISubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"Newspaper received news: {news}");
    }
}

class TVChannel : ISubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"TV Channel received news: {news}");
    }
}

class RadioStation : ISubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"Radio Station received news: {news}");
    }
}

class YTChannel : ISubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"Youtube Channel received news: {news}");
    }
}

public class ObserverPattern
{
    public ObserverPattern()
    {
        NewsAgency agency = new NewsAgency();

        Newspaper newspaper = new Newspaper();
        TVChannel tvChannel = new TVChannel();
        RadioStation radioStation = new RadioStation();
        YTChannel yTChannel = new YTChannel();

        agency.Attach(newspaper);
        agency.Attach(tvChannel);
        agency.Attach(radioStation);
        agency.Attach(yTChannel);


        agency.ReleaseNews("Breaking News: Observer Pattern in C#");

        agency.Detach(radioStation);
        // Console.WriteLine("\nRadio Station unsubscribed.\n");

        agency.ReleaseNews("Update: Observer Pattern Example Completed");
    }
}