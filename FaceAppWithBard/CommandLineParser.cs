using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CommandLineUtils;
//using Google.Protobuf.WellKnownTypes;


namespace FaceAppWithBard
{
    public static class CommandLineParser
    {
        public static Parser BuildParser()
        {
            var sourceDirOption = new Option<string>("--sourceDir", "Path to the directory containing source images", isRequired: true);

            var resizeWidthOption = new Option<int?>("--resizeWidth", "Target width for image resizing (optional)");

            var resizeHeightOption = new Option<int?>("--resizeHeight", "Target height for image resizing (optional)");

            var targetDirResizeOption = new Option<string>(
                "--targetDirResize", "Path to the directory for storing resized images (optional)");

            var targetDirAlignmentOption = new Option<string>(
                "--targetDirAlignment", "Path to the directory for storing aligned images (optional)");

            var referenceImagePathOption = new Option<string>(
                "--referenceImagePath", "Path to the reference image for alignment (optional)");

            var overlayOption = new Option<bool>("--overlay", "Enable overlay during image alignment (optional)");

            var durationOption = new Option<int>(
                "--duration", "Duration (in milliseconds) for each morph transition (optional)",
                defaultValue: 1000); // Default 1 second

            var pauseOption = new Option<int>(
                "--pause", "Duration (in milliseconds) to pause on the final image (optional)",
                defaultValue: 500); // Default 0.5 seconds

            var fpsOption = new Option<int>(
                "--fps", "Frames per second for the final video (optional)",
                defaultValue: 25);

            var outputFileNameOption = new Option<string>(
                "--output", "Name for the generated time-lapse video file",
                parseArgumentValue: value =>
                {
                    if (!value.EndsWith(".mp4") && !value.EndsWith(".avi") && !value.EndsWith(".mkv"))
                    {
                        throw new ArgumentException("Output filename must have a valid video extension (.mp4, .avi, .mkv)");
                    }
                    return value;
                });

            var rootCommand = new RootCommand
            {
                Name = "FaceAppWithBard",
                Description = "Create a time-lapse video from your images."
            };

            rootCommand.AddOption(sourceDirOption);
            rootCommand.AddOption(resizeWidthOption);
            rootCommand.AddOption(resizeHeightOption);
            rootCommand.AddOption(targetDirResizeOption);
            rootCommand.AddOption(targetDirAlignmentOption);
            rootCommand.AddOption(referenceImagePathOption);
            rootCommand.AddOption(overlayOption);
            rootCommand.AddOption(durationOption);
            rootCommand.AddOption(pauseOption);
            rootCommand.AddOption(fpsOption);
            rootCommand.AddOption(outputFileNameOption);

            rootCommand.Handler = HandleCommand;

            return rootCommand as Parser; // Cast to Parser
        }

    }

    public class CommandLineOptions
    {
        public string SourceDirectory { get; set; }
        public int? ResizeWidth { get; set; }
        public int? ResizeHeight { get; set; }
        public string TargetDirectoryResize { get; set; }
        public string TargetDirectoryAlignment { get; set; }
        public string ReferenceImagePath { get; set; }
        public bool Overlay { get; set; }
        public int Duration { get; set; }
        public int Pause { get; set; }
        public int Fps { get; set; }
        public string OutputFileName { get; set; }
    }
}
