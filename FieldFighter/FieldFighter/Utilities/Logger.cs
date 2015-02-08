using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldFighter.Utilities
{
    public class Logger
    {
        private const String LogPath = @"C:\Users\Nolan\DevLogs\";
        private const String LogFile = LogPath + "HellowWorldApp.log.txt";

        public static void d(String message) { log("[DEBUG]", message); }
        public static void i(String message) { log("[INFO ]", message); }
        public static void w(String message) { log("[WARN ]", message); }
        public static void e(String message) { log("[ERROR]", message); }

        private static void log(String tag, String message)
        {
            //Debug.WriteLine(System.DateTime.Now.ToString("HH:mm:ss.fff") + " " + tag + " -- " + message);
        }
    }
}
