using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Data
{
    public class Logger
    {
        private int index = 0;
        private Stopwatch stopWatch = new Stopwatch();
        private List<Orb> orbs;
        private XDocument xmlDoc;

        public Logger(List<Orb> orbs)
        {
            this.orbs = orbs;
            xmlDoc = new XDocument(new XElement("Logs"));
            stopWatch.Start();

            Task t = new Task(async () =>
            {
                while (true)
                {
                    if (stopWatch.IsRunning)
                    {
                        StringBuilder sb = new StringBuilder();

                        TimeSpan ts = stopWatch.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                        string msg = $". Log from {DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss")}\n" + $"App running time: {elapsedTime}\n";

                        foreach (Orb orb in orbs)
                        {
                            sb.AppendLine(index + msg + SerializeToXml(orb));
                            index += 1;
                        }

                        string xmlContent = sb.ToString();
                        XElement logsElement = new XElement("Logs", xmlContent);
                        xmlDoc.Root.Add(logsElement);

                        await Task.Delay(100);
                    }
                }
            });

            t.Start();
        }

        private string SerializeToXml(Orb orb)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Orb));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, orb);
                return writer.ToString();
            }
        }

        public void Stop()
        {
            stopWatch.Stop();
            index = 0;
            xmlDoc.Save("Logs.xml");
        }
    }
}
