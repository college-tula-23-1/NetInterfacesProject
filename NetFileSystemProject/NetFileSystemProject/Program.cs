using System.Text;

string dirPath = "H:/Maxim Directory/";

string file1 = dirPath + "file01.txt";
string file2 = dirPath + "file02.txt";
string file3 = dirPath + "file03.txt";

string fileBin1 = dirPath + "file01.bin";

string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

File.WriteAllText(file3, text, Encoding.Unicode);

//string[] names = ["Bobby", "Jimmy", "Sammy"];

//File.WriteAllText(file1, text);
////File.WriteAllLines(file1, names);
//File.AppendAllLines(file1, names);




//List<byte> bufferList = new();
//Random random = new();

//for (int i = 0; i < 10; i++)
//    bufferList.Add((byte)random.Next(32, 255));

//File.WriteAllBytes(fileBin1, bufferList.ToArray());

//var lines = File.ReadAllLines(file1);
//foreach (var line in lines)
//    Console.WriteLine(line);

//var text = File.ReadAllText(file1);
//Console.WriteLine(text);

//var buffer = File.ReadAllBytes(fileBin1);
//foreach (var item in buffer)
//    Console.Write($"{item} ");
//Console.WriteLine();

