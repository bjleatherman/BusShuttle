namespace BusShuttle.Tests;

using BusShuttle;

public class FileSaverTests
{

    FileSaver fileSaver;
    string testFileName;

    public FileSaverTests()
    {
        testFileName = "test-doc.txt";
        fileSaver = new FileSaver(testFileName);
    }

    [Fact]
    public void Test_FileSaver_Append()
    {
        string testText = "Hello, World!";

        fileSaver.AppendLine(testText);
        var contentsFromFile = File.ReadAllText(testFileName);

        Assert.Equal(contentsFromFile, testText+Environment.NewLine);
    }
}