using System;
using System.Linq;

namespace OnlineRadioDatabase
{
    public class Song
    {
        string name;
        string artist;
        int minutes;
        int seconds;

        public Song(string[] tokens)
        {
            ValidateArgs(tokens);
            Artist = tokens[0];
            Name = tokens[1];
            int[] lengthArgs = ValidateLength(tokens[2]);
            Minutes = lengthArgs[0];
            Seconds = lengthArgs[1];
        }

        private string Name
        {
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                name = value;
            }
        }

        private string Artist
        {
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                artist = value;
            }
        }

        private int Minutes
        {
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                minutes = value;
            }
        }

        private int Seconds
        {
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                seconds = value;
            }
        }

        private void ValidateArgs(string[] tokens)
        {
            if (tokens.Length != 3)
            {
                throw new InvalidSongException();
            }
        }

        private int[] ValidateLength(string length)
        {
            var tokens = length.Split(':');
            if (tokens.Length != 2 || tokens.Any(t => !t.All(c => Char.IsDigit(c))))
            {
                throw new InvalidSongLengthException();
            }

            return tokens.Select(int.Parse).ToArray();
        }

        public int GetLengthInSeconds()
        {
            return minutes * 60 + seconds;
        }
    }
}
