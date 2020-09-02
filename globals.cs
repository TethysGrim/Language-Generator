using System;
using System.Collections.Generic;

public static class Globals
{
    // Instantiate random number generator using system-supplied value as seed.
    public static Random rand = new Random();

    public static List<string> vowels = new List<string>
    {"a", "e", "i", "o", "u"};
    public static List<string> softcs = new List<string>
    {"f", "g", "h", "j", "l", "m", "n", "s", "v", "w", "y", "z"};
    public static List<string> hardcs = new List<string>
    {"b", "c", "d", "g", "k", "p", "q", "t", "x"};
}