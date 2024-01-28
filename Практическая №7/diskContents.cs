using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая__7
{
    public static class diskContents
    {
        public static void Info(string diskName)
        {
            while (true)
            {
                Console.Clear();
                string[] folders = Directory.GetDirectories(diskName);
                string[] files = Directory.GetFiles(diskName);
                List<string> list = new();

                foreach (string folder in folders)
                {
                    list.Add(folder);
                }

                foreach (string file in files)
                {
                    list.Add(file);
                }

                foreach (string corsina in folders)
                {
                    var createDate = Directory.GetCreationTime(corsina);

                    Console.Write("  Путь: " + corsina);
                    Console.SetCursorPosition(60, Console.CursorTop);
                    Console.WriteLine("Время создания: " + createDate);
                }
                foreach (string file in files)
                {
                    var createDate = Directory.GetCreationTime(file);

                    Console.Write("  Путь: " + file);
                    Console.SetCursorPosition(60, Console.CursorTop);
                    Console.Write("Время создания: " + createDate + "\n");
                }

                int pos = Menu.Show(1, folders.Length + files.Length);

                if (pos != -1)
                {
                    try
                    {
                        Info(list[pos]);
                    }
                    catch (IOException)
                    {
                        Process.Start(new ProcessStartInfo { FileName = list[pos], UseShellExecute = true });
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
