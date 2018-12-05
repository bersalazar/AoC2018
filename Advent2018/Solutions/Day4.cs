using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Day4
    {
        public static string GetAnswerA(IEnumerable<string> input)
        {
            var entries = new List<string>
            {
                "[1518-11-01 00:05] falls asleep",
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-01 00:25] wakes up",
                "[1518-11-01 00:30] falls asleep",
                "[1518-11-01 00:55] wakes up",
                "[1518-11-01 23:58] Guard #99 begins shift",
                "[1518-11-02 00:40] falls asleep",
                "[1518-11-02 00:50] wakes up",
                "[1518-11-03 00:05] Guard #10 begins shift",
                "[1518-11-03 00:24] falls asleep",
                "[1518-11-03 00:29] wakes up",
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-04 00:46] wakes up",
                "[1518-11-05 00:03] Guard #99 begins shift",
                "[1518-11-05 00:45] falls asleep",
                "[1518-11-05 00:55] wakes up"
            };

            //1. read the logs
            //it's in input method parameter
            
            //2. sort the logs into a new object
            entries.Sort();
            
            
            var parsedLogs = new Dictionary<DateTime, string>();
            
            entries.ForEach(entry =>
            {
                var dateTimeAsString = entry.Substring(entry.IndexOf("[") + 1, entry.IndexOf("]") - 1);
                var dateTime = DateTime.ParseExact(dateTimeAsString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                var start = entry.IndexOf("]") + 2;
                var end = entry.Length - start;
                var log = entry.Substring(start, end);
                
                // parsed and sorted entries
                parsedLogs.Add(dateTime, log);
            });

            //3. for each guard, sum the minutes asleep
            var guardsAsleep = new Dictionary<string, int>();
            var minuteWhenFallsAsleep = 0;
            var guardId = "";
            
            foreach (var log in parsedLogs)
            {
                if (log.Value.StartsWith("Guard"))
                {
                    guardId = new String(log.Value.Where(Char.IsDigit).ToArray());
                    if (!guardsAsleep.ContainsKey(guardId)) guardsAsleep.Add(guardId, 0);
                }

                if (log.Value.StartsWith("falls"))
                {
                    minuteWhenFallsAsleep = log.Key.Minute;
                }

                if (log.Value.StartsWith("wakes"))
                {
                    var minuteWhenAwakes = log.Key.Minute;
                    guardsAsleep[guardId] = guardsAsleep[guardId] + minuteWhenAwakes - minuteWhenFallsAsleep;
                }
            }
            
            //4. for each guard, count the times of each minute he is sleep
            //5. grab the guard with the highest sum of sleep
            //6. with this guard ID, select the highest sleep minute
            //7. ID * highest sleep minute

//            var allDays = new List<Day>();
//            var yesterday = 0;
//            foreach (var entry in parsedEntries)
//            {
//                // this part will loop the days and create a new day object if the day changes
//                var date = entry.Key;
//                var today = date.Day;
//                if (today != yesterday)
//                {
//                    var day = new Day();
//                    day.Date = $"{date.Month}-{date.Day}";
//                    if (entry.Value.StartsWith("Guard"))
//                    {
//                        day.GuardId = new String(entry.Value.Where(Char.IsDigit).ToArray());
//                    }
//
//                    yesterday = today;
//                }
//                else
//                {
//                    if (entry.Value.StartsWith("falls"))
//                    {
//                        var sleepsAt = date.Minute;
//                    }
//                    else if (entry.Value.StartsWith("wakes"))
//                    {
//                        var awakesAt = date.Minute;
//                    }
//
//                    // here we can do something with the falls asleep or awakes logs
//                }
//            }
            
            return "";
        }
    }
}