using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    // 1. Check what the counts were last week
    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    // 2. Check how many birds visited today
    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    // 3. Increment today's count
    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    // 4. Check if there was a day with no visiting birds
    public bool HasDayWithoutBirds()
    {
        foreach (int count in birdsPerDay)
        {
            if (count == 0)
            {
                return true;
            }
        }
        return false;
    }

    // 5. Calculate the number of visiting birds for the first number of days
    public int CountForFirstDays(int numberOfDays)
    {
        int sum = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            sum += birdsPerDay[i];
        }
        return sum;
    }

    // 6. Calculate the number of busy days
    public int BusyDays()
    {
        int busyCount = 0;
        foreach (int count in birdsPerDay)
        {
            if (count >= 5)
            {
                busyCount++;
            }
        }
        return busyCount;
    }
}