using System;

public class InvalidSongException : Exception
{
    public InvalidSongException(string message = "Invalid song.")
        : base(message)
    {
    }
}