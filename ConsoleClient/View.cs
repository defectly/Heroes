using Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient;

public class View
{
    private static int step = 1;
    private static int l = 0;
    private static string top10 = formatDiv("a") + string.Join("", nCopies(9, formatDiv("-b"))) + formatDiv("-c");

    private static string nCopies(int v1, string v2)
    {
        StringBuilder sb = new();
        for (int i = 0; i < v1; i++)
        {
            sb.Append(v2);
        }

        return sb.ToString();
    }

    private static string midl10 = formatDiv("d") + string.Join("", nCopies(9, formatDiv("-e"))) + formatDiv("-f");
    private static string bottom10 = formatDiv("g") + string.Join("", nCopies(9, formatDiv("-h"))) + formatDiv("-i");
    private static void tabSetter(int cnt, int max)
    {
        int dif = max - cnt + 2;
        if (dif > 0) Console.Write(Repeat(dif, " ") + "\t"); else Console.Write(":\t");
    }
    private static string formatDiv(string str)
    {
        return str.Replace('a', '\u250c')
                .Replace('b', '\u252c')
                .Replace('c', '\u2510')
                .Replace('d', '\u251c')
                .Replace('e', '\u253c')
                .Replace('f', '\u2524')
                .Replace('g', '\u2514')
                .Replace('h', '\u2534')
                .Replace('i', '\u2518')
                .Replace('-', '\u2500');
    }
    private static string getChar(int x, int y)
    {
        string strOut = "| ";
        foreach (Hero human in Program.allTeam)
        {
            if (human.Position.X == x && human.Position.Y == y)
            {
                if (human.Health == 0)
                {
                strOut = "|" + (AnsiColors.ANSI_RED + human.ToString()[0] + AnsiColors.ANSI_RESET);
                    break;
                }
                if (Program.darkness.Contains(human)) strOut = "|" + (AnsiColors.ANSI_GREEN + human.ToString()[0] + AnsiColors.ANSI_RESET);
                if (Program.heaven.Contains(human)) strOut = "|" + (AnsiColors.ANSI_BLUE + human.ToString()[0] + AnsiColors.ANSI_RESET);
                break;
            }
        }
        return strOut;
    }
    public static void view()
    {
        if (step == 1)
        {
            Console.Write(AnsiColors.ANSI_RED + "First step" + AnsiColors.ANSI_RESET);
        }
        else
        {
            Console.Write(AnsiColors.ANSI_RED + "Step:" + step + AnsiColors.ANSI_RESET);
        }
        step++;
        Program.allTeam.ForEach((v)=>l = Math.Max(l, v.ToString().Length));
        Console.Write(Repeat(l * 2, "_"));
        Console.WriteLine();
        Console.Write(top10 + "    ");
        Console.Write("Blue side");
        //for (int i = 0; i < l[0]-9; i++)
        Console.Write(Repeat(l - 9, " "));
        Console.WriteLine(":\tGreen side");
        for (int i = 1; i < 11; i++)
        {
            Console.Write(getChar(1, i));
        }
        Console.Write("|    ");
        Console.Write(Program.heaven.ToString()[0]);
        tabSetter(Program.heaven.ToString()[0].ToString().Length, l);
        Console.WriteLine(Program.darkness.ToString()[0]);
        Console.WriteLine(midl10);

        for (int i = 2; i < 10; i++)
        {
            for (int j = 1; j < 11; j++)
            {
                Console.Write(getChar(i, j));
            }
            Console.Write("|    ");
            Console.Write(Program.heaven.ToString()[i - 1]);
            tabSetter(Program.heaven.ToString()[i - 1].ToString().Length, l);
            Console.WriteLine(Program.darkness.ToString()[i - 1]);
            Console.WriteLine(midl10);
        }
        for (int j = 1; j < 11; j++)
        {
            Console.Write(getChar(10, j));
        }
        Console.Write("|    ");
        Console.Write(Program.heaven.ToString()[0]);
        tabSetter(Program.heaven.ToString()[0].ToString().Length, l);
        Console.WriteLine(Program.darkness.ToString()[0]);
        Console.WriteLine(bottom10);
    }

    public static string Repeat(int count, string str)
    {
        StringBuilder sb = new();

        for (int i = 0; i < count; i++)
        {
            sb.Append(str);
        }

        return sb.ToString();
    }
}
