using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SRC.Library.Common
{
    public class FileLog
    {
        private static ReaderWriterLockSlim cacheLock = new System.Threading.ReaderWriterLockSlim();

        public static void WriteToFile(string message, string filePath)
        {
            string directoryName = Path.GetDirectoryName(filePath);

            CreateDirectory(directoryName);
            CreateFile(filePath);
            AddMessageToFile(filePath, message);
        }

        public static void WriteToFile(string message, string filePath, Encoding encoding)
        {
            string directoryName = Path.GetDirectoryName(filePath);

            CreateDirectory(directoryName);
            CreateFile(filePath);
            AddMessageToFile(filePath, message, encoding);
        }

        public static string ReadFromFile(string filePath)
        {
            string data = string.Empty;

            cacheLock.EnterReadLock();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    data = sr.ReadToEnd();
                }
            }
            finally
            {
                cacheLock.ExitReadLock();
            }

            return data;
        }

        #region | PRIVATE METHODS |

        private static void CreateDirectory(string path)
        {
            cacheLock.EnterUpgradeableReadLock();

            try
            {
                if (!Directory.Exists(path))
                {
                    cacheLock.EnterWriteLock();

                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    finally
                    {
                        cacheLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                cacheLock.ExitUpgradeableReadLock();
            }
        }

        private static void CreateFile(string path)
        {
            cacheLock.EnterUpgradeableReadLock();

            try
            {
                if (!File.Exists(path))
                {
                    cacheLock.EnterWriteLock();

                    try
                    {
                        File.Create(path).Dispose();
                    }
                    finally
                    {
                        cacheLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                cacheLock.ExitUpgradeableReadLock();
            }
        }

        private static void AddMessageToFile(string path, string message)
        {
            cacheLock.EnterWriteLock();

            try
            {
                using (FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        writer.AutoFlush = true;
                        writer.Write(message + Environment.NewLine);
                    }
                }
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        private static void AddMessageToFile(string path, string message, Encoding encoding)
        {
            cacheLock.EnterWriteLock();

            try
            {
                using (FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(file, encoding))
                    {
                        writer.AutoFlush = true;
                        writer.Write(message + Environment.NewLine);
                    }
                }
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        #endregion
    }
}