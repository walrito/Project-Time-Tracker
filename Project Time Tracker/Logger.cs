namespace Elements.Logger
{
    internal class Logging
    {
        private static readonly ReaderWriterLockSlim rwl = new ReaderWriterLockSlim();

        public static void LogMessage(string logName, string logMessage, string logType, string msgSource)
        {
            string dirPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\logs\\";
            string filePath = dirPath + logName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            Directory.CreateDirectory(dirPath);

            try
            {
                rwl.EnterWriteLock();
                using StreamWriter sw = File.AppendText(filePath);
                sw.WriteLine("{0} ({2}) {3}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), logMessage, msgSource, logType);
            }
            catch (Exception ex)
            {
                using StreamWriter sw = File.AppendText(dirPath + "LoggerError_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                sw.WriteLine("{0} ({2}) Exception: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), ex.Message, "LogMessage");
            }
            finally
            {
                rwl.ExitWriteLock();
            }
        }

        public static void LogCleanup(int purgeBeforeDays, bool includeError)
        {
            string dirPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\logs\\";

            LogMessage("System", "Deleting log files more than " + purgeBeforeDays + " days old", "log", "LogCleanup");
            foreach (string f in Directory.GetFiles(dirPath))
            {
                try
                {
                    if (!((DateTime.Now.Date - File.GetCreationTime(f).Date).TotalDays > purgeBeforeDays)) continue;
                    if (!includeError && Path.GetFileNameWithoutExtension(f).Contains("Error")) continue;
                    File.Delete(f);
                    LogMessage("System", "Deleted '" + Path.GetFileName(f) + "'.", "log", "LogCleanup");
                }
                catch (Exception ex)
                {
                    using StreamWriter sw = File.AppendText(dirPath + "LoggerError_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                    sw.WriteLine("{0} ({2}) Exception: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"), ex.Message, "LogCleanup");
                }
            }
            LogMessage("System", "Deleted log files more than " + purgeBeforeDays + " days old", "log", "LogCleanup");
        }
    }
}