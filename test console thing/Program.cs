using ConsoleStuff;

var writer = new StreamWriter("test.txt");
ConsoleHelper.OtherWriter = writer;

ConsoleHelper.WriteType = ConsoleHelper.WriteTypeEnum.Console;
Console.WriteLine("Hello, world! (Console)");
Console.WriteLine("Hello, world 2! (Console)");

ConsoleHelper.WriteType = ConsoleHelper.WriteTypeEnum.Other;
Console.WriteLine("Hello, world! (File)");
Console.WriteLine("Hello, world 2! (File)");
Console.WriteLine("Hello, world Test! (File)");

ConsoleHelper.WriteType = ConsoleHelper.WriteTypeEnum.Both;
Console.WriteLine();
Console.WriteLine("Hello, world! (Console + File)");
Console.WriteLine("This is 10/10 1000%");

using (new TempTextWriter(new StreamWriter("test2.txt")))
{
    Console.WriteLine("This should only be in the new File!");
    Console.WriteLine("yes yes");
}

using (new TempTextWriter("test3.txt", ConsoleHelper.WriteTypeEnum.Both ))
{
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("This should be in the console and another file");
    Console.WriteLine("yes yes yes");
    Console.WriteLine("-----------------------------------------------");
}

Console.WriteLine("This should be in both!");


ConsoleHelper.WriteType = ConsoleHelper.WriteTypeEnum.Console;
writer.Close();

Console.WriteLine("\nEnd.");
