using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;

namespace Data
{
    public class Logger
    {
        private int index = 0;
        Stopwatch stopWatch = new Stopwatch();


        public Logger(List<Orb> orbs)
        {
            stopWatch.Start();
            Task t = new Task(async () =>
            {
                while (true)
                {
                    if (stopWatch.IsRunning)
                    {
                        using (StreamWriter streamWriter =
                               new StreamWriter(Directory.GetCurrentDirectory() + "\\ballLogs.txt", true))
                        {
                            TimeSpan ts = stopWatch.Elapsed;
                            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds);
                            string msg = ($". Log from {DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss")}\n" +
                                          $"App running time: " + elapsedTime + "\n");
                            foreach (Orb orb in orbs)
                            {
                                streamWriter.WriteLine(index + msg + JsonSerializer.Serialize(orb));
                                index += 1;
                            }
                        }
                    }

                    await Task.Delay(5);
                }
            });
            t.Start();
        }

        public void Stop()
        {
            stopWatch.Stop();
            index = 0;
        }
    }
}