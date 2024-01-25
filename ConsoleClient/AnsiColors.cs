using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient;

public class AnsiColors
{
    public static string ANSI_RESET = "\u001B[0m";
    public static string ANSI_BLACK = "\u001B[30m";
    public static string ANSI_RED = "\u001B[31m";
    public static string ANSI_GREEN = "\u001B[32m";
    public static string ANSI_YELLOW = "\u001B[33m";
    public static string ANSI_BLUE = "\u001B[34m";
    public static string ANSI_PURPLE = "\u001B[35m";
    public static string ANSI_CYAN = "\u001B[36m";
    public static string ANSI_WHITE = "\u001B[37m";

    public static string ANSI_BLACK_BACKGROUND = "\u001B[40m";
    public static string ANSI_RED_BACKGROUND = "\u001B[41m";
    public static string ANSI_GREEN_BACKGROUND = "\u001B[42m";
    public static string ANSI_YELLOW_BACKGROUND = "\u001B[43m";
    public static string ANSI_BLUE_BACKGROUND = "\u001B[44m";
    public static string ANSI_PURPLE_BACKGROUND = "\u001B[45m";
    public static string ANSI_CYAN_BACKGROUND = "\u001B[46m";
    public static string ANSI_WHITE_BACKGROUND = "\u001B[47m";
    public static string ANSI_CLEAR_SCREEN = "\033[H";

    public static void clear()
    {
        Console.WriteLine(ANSI_CLEAR_SCREEN);
    }
}