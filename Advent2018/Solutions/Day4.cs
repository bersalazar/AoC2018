using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Advent2018.Solutions
{
    public static class Day4
    {
        public static string GetAnswerA(IEnumerable<string> input)
        {
            //ID * highest sleep minute
            var answer = ProcessEntries(input.ToList());
            var sleepyGuard = int.Parse((string) answer["sleepyGuard"]);
            var minuteWhereGuardSleptMost = int.Parse((string) answer["minuteWhereGuardSleptMost"]);
            
            return Convert.ToString(sleepyGuard * minuteWhereGuardSleptMost);
        }

        public static string GetAnswerB(IEnumerable<string> input)
        {
            //ID * highest sleep minute
            var answer = ProcessEntries(input.ToList());
            var mfmc = int.Parse((string) answer["mostFrequentMinute"]);
            var mfmg = int.Parse((string) answer["mostFrequentMinuteGuardId"]);

            return Convert.ToString(mfmg * mfmc);
        }
        
        public static Dictionary<string, object> ProcessEntries(List<string> entries)
        {
            //sort the logs into a new object
            entries.Sort();
            
            var parsedLogs = new Dictionary<DateTime, string>();
            
            entries.ForEach(entry =>
            {
                var dateTimeAsString = entry.Substring(entry.IndexOf("[", StringComparison.Ordinal) + 1, entry.IndexOf("]", StringComparison.Ordinal) - 1);
                var dateTime = DateTime.ParseExact(dateTimeAsString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                var start = entry.IndexOf("]", StringComparison.Ordinal) + 2;
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
            var minuteCounter = new Dictionary<string, Dictionary<string, int>>();
            
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
                    for (int min = minuteWhenFallsAsleep; min < minuteWhenAwakes; min++)
                    {
                        var minuteString = Convert.ToString(min);
                        if (!minutesWhereGuardsSlept.ContainsKey(guardId)) {
                            minutesWhereGuardsSlept.Add(guardId, new List<string>());
                        }

                        //for each guard, store how many times a minute he's sleep
                        if (!minuteCounter.ContainsKey(guardId))
                        {
                            minuteCounter.Add(guardId, new Dictionary<string, int>()
                            {
                                {minuteString, 0}
                            });
                        }
                        
                        if (!minuteCounter[guardId].ContainsKey(minuteString))
                        {
                            minuteCounter[guardId].Add(minuteString, 0);
                        }
                        
                        minuteCounter[guardId][minuteString]++;

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
            
            // PART B
            // guard who is most frequently asleep on the same minute
            var max = 0;
            var minute = "";
            var guard = "";
            foreach (var g in minuteCounter)
            {
                foreach (var m in g.Value)
                {
                    if (m.Value > max)
                    {
                        max = m.Value;
                        guard = g.Key;
                        minute = m.Key;
                    }
                }
            }

            return new Dictionary<string, object>()
            {
                {"minuteWhereGuardSleptMost", minuteWhereGuardSleptMost},
                {"sleepyGuard", sleepyGuard},
                {"mostFrequentMinute", minute},
                {"mostFrequentMinuteGuardId", guard}
            };
        }
    }
}