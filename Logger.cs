using System;
using System.IO;

namespace OTGCG_Utility
{
    public static class Logger
    {
        private static string StartTime = DateTime.Now.ToString("(ddMMMyyyy HH-mm-ss)");
        public static string Path { get; private set; } = Directory.GetCurrentDirectory() + "/logs" + $"/{StartTime} ClientLog.txt";
        private static StreamWriter streamWriter { get; set; } = new StreamWriter(Path, true);

        public static void Log(string msg)
        {
            streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffff") + " LOG: " + msg);
            streamWriter.Flush();
        }
        public static void Warn(string msg)
        {
            streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffff") + " WRN: " + msg);
            streamWriter.Flush();
        }
        public static void LogError(string msg, int lvl)
        {
            if (lvl == 0)
            {
                streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffff") + " ERR: " + msg);
            }
            else if (lvl == 1)
            {
                streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffff") + " FATAL_ERR: " + msg);
                Environment.Exit(0);
            }
            streamWriter.Flush();
        }
    }
}
