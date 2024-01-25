using System;

public interface ITimeOfDayService
{
    string GetTimeOfDay();
}

public class TimeOfDayService : ITimeOfDayService
{
    public string GetTimeOfDay()
    {
        var currentHour = DateTime.Now.Hour;

        if (currentHour >= 12 && currentHour < 18)
        {
            return "it's daytime";
        }
        else if (currentHour >= 18 && currentHour < 24)
        {
            return "it is evening";
        }
        else if (currentHour >= 0 && currentHour < 6)
        {
            return "it's night now";
        }
        else
        {
            return "it's morning";
        }
    }
}
