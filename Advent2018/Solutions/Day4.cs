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
            var test = false;
            var entries = test ? new List<string>
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
            } : input.ToList();

            //sort the logs into a new object
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

            //for each guard, sum the minutes asleep
            var guardsAsleep = new Dictionary<string, int>();
            var minuteWhenFallsAsleep = 0;
            var guardId = "";
            var minutesWhereGuardsSlept = new Dictionary<string, List<string>> ();
            
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
                    
                    //total time each guard is asleep
                    guardsAsleep[guardId] = guardsAsleep[guardId] + minuteWhenAwakes - minuteWhenFallsAsleep;

                    //for each guard, count the times of each minute he is sleep
                    for (int min = minuteWhenFallsAsleep; min <= minuteWhenAwakes; min++)
                    {
                        if (!minutesWhereGuardsSlept.ContainsKey(guardId)) {
                            minutesWhereGuardsSlept.Add(guardId, new List<string>());
                        }

                        //minutes that each guard slept
                        minutesWhereGuardsSlept[guardId].Add(Convert.ToString(min));
                    }
                }
            }
            
            //grab the guard with the highest sum of sleep
            var sleepyGuard = guardsAsleep.OrderByDescending(g => g.Value).First().Key;
            
            //with this guard ID, select the highest sleep minute
            var minuteWhereGuardSleptMost = minutesWhereGuardsSlept[sleepyGuard]
                .GroupBy(s => s)
                .OrderByDescending(s => s.Count())
                .First().Key;
            
            //ID * highest sleep minute
            return Convert.ToString(int.Parse(sleepyGuard) * int.Parse(minuteWhereGuardSleptMost));
            //return "";
        }
    }
}