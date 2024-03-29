using FaceAppWithBard;
using FaceAppWithBard.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CommandLineArgumentsTests
{
    [TestMethod]
    public void Sets_Default_Values_For_Optional_Arguments()
    {
        var args = new CommandLineArguments();

        Assert.IsNull(args.TargetDirectoryResize);
        Assert.IsNull(args.TargetDirectoryAlignment);
        Assert.IsNull(args.ReferenceImagePath);
        Assert.IsNull(args.ResizeWidth);
        Assert.IsNull(args.ResizeHeight);
        Assert.IsFalse(args.Overlay);
        Assert.AreEqual(1000, args.Duration);
        Assert.AreEqual(500, args.Pause);
        Assert.AreEqual(25, args.Fps);
    }

    [TestMethod]
    public void Sets_Values_From_Provided_Arguments()
    {
        var args = new CommandLineArguments();
        string[] testArgs = {
            "program.exe",
            "-sourceDir=C:\\images",
            "-resizeWidth=320",
            "-overlay",
            "-duration=2000",
            "-fps=30",
            "output.mp4"
        };

        MockCommandLineParser.ParseArguments(testArgs, args);

        Assert.AreEqual("C:\\images", args.SourceDirectory);
        Assert.IsNull(args.TargetDirectoryResize); // Not provided explicitly
        Assert.IsNull(args.TargetDirectoryAlignment); // Not provided explicitly
        Assert.IsNull(args.ReferenceImagePath); // Not provided explicitly
        Assert.AreEqual(320, args.ResizeWidth);
        Assert.IsNull(args.ResizeHeight); // Not provided explicitly
        Assert.IsTrue(args.Overlay);
        Assert.AreEqual(2000, args.Duration);
        Assert.AreEqual(500, args.Pause); // Default value remains
        Assert.AreEqual(30, args.Fps);
        Assert.AreEqual("output.mp4", args.OutputFileName);
    }
}
