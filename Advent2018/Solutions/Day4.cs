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

            var parsedEntries = new Dictionary<DateTime, string>();

            entries.Sort();
            entries.ForEach(entry =>
            {
                var dateTimeAsString = entry.Substring(entry.IndexOf("[") + 1, entry.IndexOf("]") - 1);
                var dateTime = DateTime.ParseExact(dateTimeAsString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                var start = entry.IndexOf("]") + 2;
                var end = entry.Length - start;
                var log = entry.Substring(start, end);
                parsedEntries.Add(dateTime, log);
            });

            var allDays = new List<Day>();

            var lastDay = 0;    
            foreach (var entry in parsedEntries)
            {
                // this part will loop the days and create a new day object if the day changes
                var currentDay = entry.Key;
                if (currentDay.Day != lastDay)
                {
                    var day = new Day();
                    day.Date = $"{entry.Key.Month}-{entry.Key.Day}";
                    if (entry.Value.StartsWith("Guard"))
                    {
                        day.GuardId = new String(entry.Value.Where(Char.IsDigit).ToArray());
                    }

                    lastDay = currentDay.Day;
                }
                else
                {
                    // here we can do something with the falls asleep or awakes logs
                }
            }
            
            return "";
        }
    }
}