using Практическая__7;

do
{
    Console.SetCursorPosition(50, 0);
    Console.WriteLine("Этот компьютер");
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
    DriveInfo[] drives = DriveInfo.GetDrives();
    Console.SetCursorPosition(0, 3);
    try
    {
        foreach (var drive in drives)
        {
            Console.WriteLine("  " + drive.Name + " " + drive.AvailableFreeSpace/1073741824 + "ГБ доступно из " + drive.TotalSize/1073741824 + " ГБ");
        }
    }
    catch
    {
        Console.WriteLine("  Ошибка чтения диска");
    }
    int pos = Menu.Show(3, drives.Length + 2);
    if (pos != -1)
    {
        try
        {
            diskContents.Info(drives[pos - 2].RootDirectory.FullName);
        }
        catch
        {
            Console.WriteLine("Приколдес");
        }
    }
} while (true);