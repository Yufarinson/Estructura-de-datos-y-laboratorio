using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_01_POO;

public class Time
{
    private int _hours;
    private int _milisecond;
    private int _minutes;
    private int _seconds;

    public Time()
    {
        Hours = 0;
        Milisecond = 0;
        Minutes = 0;
        Seconds = 0;
    }

    public Time(int hours)
    {
        Hours = hours;
    }

    public Time(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }

    public Time(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public Time(int hours, int minutes, int seconds, int miliseconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Milisecond = miliseconds;
    }

    public int Hours { get => _hours; set => _hours = ValidateHour(value); }
    public int Milisecond { get => _milisecond; set => _milisecond = ValidateMilisecond(value); }
    public int Minutes { get => _minutes; set => _minutes = ValidateMinute(value); }
    public int Seconds { get => _seconds; set => _seconds = ValidateSecond(value); }

    public Time Add(Time time)
    {
        int hours = Hours + time.Hours;
        int minutes = Minutes + time.Minutes;
        int seconds = Seconds + time.Seconds;
        int miliseconds = Milisecond + time.Milisecond;
        if (miliseconds > 999)
        {
            miliseconds -= 1000;
            seconds++;
        }
        if (seconds > 59)
        {
            seconds -= 60;
            minutes++;
        }
        if (minutes > 59)
        {
            minutes -= 59;
            hours++;
        }
        if (hours > 23)
        {
            hours = hours - 23;
        }
        return new Time(hours, minutes, seconds, miliseconds);
    }

    public bool IsOtherDay(Time time)
    {
        int totalHours = Hours + time.Hours;
        int totalMinutes = Minutes + time.Minutes;
        int totalSeconds = Seconds + time.Seconds;
        int totalMiliseconds = Milisecond + time.Milisecond;

        if (totalMiliseconds > 999)
        {
            totalMiliseconds -= 1000;
            totalSeconds++;
        }
        if (totalSeconds > 59)
        {
            totalSeconds -= 60;
            totalMinutes++;
        }
        if (totalMinutes > 59)
        {
            totalMinutes -= 60;
            totalHours++;
        }
        return totalHours != time.Hours;
    }



    public int ToMiliseconds()
    {
        return _milisecond + _seconds * 1000 + _minutes * 60000 + _hours * 3600000;
    }

    public int ToMinutes()
    {
        return _minutes + _hours * 60;
    }

    public int ToSeconds()
    {
        return _seconds + _minutes * 60 + _hours * 3600;
    }

    public override string ToString()
    {
        string tt = _hours < 12 ? "AM" : "PM";
        int normalHours;

        if (Hours == 13) normalHours = 1;
        else if (Hours == 14) normalHours = 2;
        else if (Hours == 15) normalHours = 3;
        else if (Hours == 16) normalHours = 4;
        else if (Hours == 17) normalHours = 5;
        else if (Hours == 18) normalHours = 6;
        else if (Hours == 19) normalHours = 7;
        else if (Hours == 20) normalHours = 8;
        else if (Hours == 21) normalHours = 9;
        else if (Hours == 22) normalHours = 10;
        else if (Hours == 23) normalHours = 11;
        else normalHours = Hours;

        return $"{normalHours:00}:{Minutes:00}:{Seconds:00}.{Milisecond:000} {tt}";
    }

    public int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hour; {hour}, is not valid");
        }
        return hour;
    }

    public int ValidateMilisecond(int milisecond)
    {
        if (milisecond < 0 || milisecond > 999)
        {
            throw new Exception($"The milisecond; {milisecond}, is not valid");
        }
        return milisecond;
    }

    public int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute; {minute}, is not valid");
        }
        return minute;
    }

    public int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second; {second}, is not valid");
        }
        return second;
    }

}
