using FileSystemCommands;

public class FileSystemCommandsTests
{
    [Fact]
    public void DirectorySizeCommand_ShouldCalculateSize()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "test1.txt"), "Hello");
        File.WriteAllText(Path.Combine(testDir, "test2.txt"), "World");

        var command = new DirectorySizeCommand(testDir);
        command.Execute();

        Directory.Delete(testDir, true);
    }

    [Fact]
    public void FindFilesCommand_ShouldFindMatchingFiles()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "file1.txt"), "Text");
        File.WriteAllText(Path.Combine(testDir, "file2.log"), "Log");

        var command = new FindFilesCommand(testDir, "*.txt");
        command.Execute();

        Directory.Delete(testDir, true);
    }
    [Fact]
    public void DirectorySizeCommand_ShouldReturnZeroBecauseEmptyDirectory()
    {
        var testDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(testDir);

        var command = new DirectorySizeCommand(testDir);
    
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
    
        command.Execute();
    
        Assert.Contains("Directory size:0 bytes", consoleOutput.ToString());

        Directory.Delete(testDir);
    }

    [Fact]
    public void FindFilesCommand_ShouldReturnBecauseNoMatches()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir_" + Guid.NewGuid());
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "file1.log"), "Log");

        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        new FindFilesCommand(testDir, "*.txt").Execute();

        Assert.Contains("Found 0 files", consoleOutput.ToString());

        Directory.Delete(testDir, true);
    }
}