using System;

[Author("Ventsi")]
class StartUp
{
    [Author("Gosho")]
    public static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}

