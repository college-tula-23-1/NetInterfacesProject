using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

//FileStream fileStream1 = new FileStream("H:/Maxim Directory/file01.txt", FileMode.OpenOrCreate);
//using (FileStream fileStream
//    = File.OpenWrite("H:/Maxim Directory/file01.txt"))
//{

//}

// await WriteToFile();
// await ReadFromFile();

//Point point = new Point() { X = 65, Y = 98 };
//using(FileStream fileBin = new("H:/Maxim Directory/file01.bin", 
//                                FileMode.Create,
//                                FileAccess.Write))
//{
//    fileBin.Write(point.ToByteArray());
//}

using (FileStream fileBin = new("H:/Maxim Directory/file01.bin",
                                FileMode.Open,
                                FileAccess.Read))
{
    byte[] buffer = new byte[fileBin.Length];
    fileBin.Read(buffer);

    Point point = new Point();
    point.InitFromByteArray(buffer);
    Console.WriteLine($"X = {point.X}, Y = {point.Y}");
}


    async Task WriteToFile()
{
    // write to file
    using (FileStream file = new("H:/Maxim Directory/file01.txt",
                                FileMode.Create,
                                FileAccess.Write))
    {
        Console.WriteLine(file.Name);
        Console.WriteLine(file.Length);
        Console.WriteLine(file.Position);

        string text = "Hello world";
        byte[] buffer = Encoding.UTF8.GetBytes(text);

        //file.Write(buffer, 0, buffer.Length);
        await file.WriteAsync(buffer, 0, buffer.Length);

        Console.WriteLine("Info writed to file");
    }
}

async Task ReadFromFile()
{
    using (FileStream file = new("H:/Maxim Directory/file01.txt",
                                FileMode.Open,
                                FileAccess.Read))
    {
        Console.WriteLine(file.Name);
        Console.WriteLine(file.Length);
        Console.WriteLine(file.Position);

        byte[] buffer = new byte[file.Length];

        //file.Read(buffer, 0, buffer.Length);
        await file.ReadAsync(buffer, 0, buffer.Length);

        string text = Encoding.UTF8.GetString(buffer);

        Console.WriteLine(text);
    }
}


struct Point
{
    public int X;
    public int Y;

    public byte[] ToByteArray()
    {
        List<byte> buffer = new List<byte>();
        buffer.AddRange(BitConverter.GetBytes(X));
        buffer.AddRange(BitConverter.GetBytes(Y));

        return buffer.ToArray();
    }

    public void InitFromByteArray(byte[] bytes)
    {
        X = BitConverter.ToInt32(bytes, sizeof(int) * 0);
        Y = BitConverter.ToInt32(bytes, sizeof(int) * 1);
    }
}