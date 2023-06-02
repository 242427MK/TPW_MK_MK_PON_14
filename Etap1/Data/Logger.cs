using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class Logger
    {
        private int index = 0;
        private Stopwatch stopWatch = new Stopwatch();
        private List<Orb> orbs;

        public Logger(List<Orb> orbs)
        {

            this.orbs = orbs;
            stopWatch.Start();
            Task t = new Task(async () =>
            {
                while (true)
                {
                    if (stopWatch.IsRunning)
                    {
                        using (FileStream fileStream = new FileStream(
                            Directory.GetCurrentDirectory() + "\\ballLogs.txt",
                            FileMode.Append,
                            FileAccess.Write,
                            FileShare.ReadWrite))
                        {
                            TimeSpan ts = stopWatch.Elapsed;
                            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                            string msg = $". Log from {DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss")}\n" +
                                         $"App running time: {elapsedTime}\n";

                            foreach (Orb orb in orbs)
                            {
                                byte[] logBytes = Encoding.UTF8.GetBytes(index + msg + JsonSerializer.Serialize(orb) + Environment.NewLine);
                                await fileStream.WriteAsync(logBytes, 0, logBytes.Length);
                                index += 1;
                            }
                        }
                    }

                    await Task.Delay(10);
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
