using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets;

public class GFG
{
    // Херня, потому что у нас 0 координата слева, ВРОДЕ, я не помню
    public static double normaliseToInteriorAngle(double angle)
    {
        var newAngle = angle;
        if (angle < 0)
        {
            newAngle = angle + (2 * Math.PI);
        }
        if (angle > Math.PI)
        {
            newAngle = 2 * Math.PI - angle;
        }
        return newAngle;
    }

    public static double getDegree(int enemyY, int myY, int enemyX, int myX)
    {
        var angleRadians = Math.Atan2(enemyY - myY, enemyX - myX);

        var fixedAngle = normaliseToInteriorAngle(angleRadians);

        var degree = fixedAngle * (180 / Math.PI);
        return degree;
    }

    public static (int, int) getStep(double degree)
    {
        var (X, Y) = (0, 0);
        if (degree <= 45 && degree > 315)
            X = 1;
        else if (degree <= 135 && degree > 45)
            Y = 1;
        else if (degree <= 225 && degree > 135)
            X = -1;
        else
            Y = -1;
        return (X, Y);
    }

    public static bool IsPositionOccupied()
    {
        return true;
    }

    static public void Main()
    {

        int myX = 0;
        int myY = 0;

        int enemyX = 1;
        int enemyY = 4;

        var degree = getDegree(enemyY, myY, enemyX, myX);
        Console.WriteLine(degree);
        var step = getStep(degree);
        if (IsPositionOccupied())
        {
            var sign = new Random().Next(0, 2) == 0 ? -1 : 1;
            degree += 90 * sign;
            degree = normaliseToInteriorAngle(degree * (Math.PI / 180)) * (180 / Math.PI);
            step = getStep(degree);
        }
        Console.WriteLine(degree);
        _ = step;
        // ходим на position.X += step.X, position.Y += step.Y;
    }
}