using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceAppWithBard.Tests
{
    public class MockCommandLineParser
    {
        public static void ParseArguments(string[] args, CommandLineArguments target)
        {
            // Loop through arguments and set properties in target object
            foreach (var arg in args)
            {
                if (arg.StartsWith("-sourceDir="))
                {
                    target.SourceDirectory = arg.Substring(11); // Skip "-sourceDir=" prefix
                }
                else if (arg.StartsWith("-resizeWidth="))
                {
                    int width;
                    if (int.TryParse(arg.Substring(13), out width)) // Skip "-resizeWidth=" prefix
                    {
                        target.ResizeWidth = width;
                    }
                    else
                    {
                        // Handle potential parsing error (e.g., throw exception or log warning)
                    }
                }
                // ... similar logic for other arguments (resizeHeight, overlay, duration, fps, etc.) ...
                else if (arg.StartsWith("-targetDirResize="))
                {
                    target.TargetDirectoryResize = arg.Substring(17); // Skip "-targetDirResize=" prefix
                }
                else if (arg.StartsWith("-targetDirAlignment="))
                {
                    target.TargetDirectoryAlignment = arg.Substring(21); // Skip "-targetDirAlignment=" prefix
                }
                else if (arg.StartsWith("-referenceImagePath="))
                {
                    target.ReferenceImagePath = arg.Substring(21); // Skip "-referenceImagePath=" prefix
                }
                else if (arg.StartsWith("-overlay"))
                {
                    target.Overlay = true;
                }
                else if (arg.StartsWith("-duration="))
                {
                    int duration;
                    if (int.TryParse(arg.Substring(10), out duration)) // Skip "-duration=" prefix
                    {
                        target.Duration = duration;
                    }
                    else
                    {
                        // Handle potential parsing error
                    }
                }
                else if (arg.StartsWith("-fps="))
                {
                    int fps;
                    if (int.TryParse(arg.Substring(5), out fps)) // Skip "-fps=" prefix
                    {
                        target.Fps = fps;
                    }
                    else
                    {
                        // Handle potential parsing error
                    }
                }
                else if (arg.EndsWith(".mp4") || arg.EndsWith(".avi") || arg.EndsWith(".mkv")) // Assuming valid video extensions
                {
                    target.OutputFileName = arg;
                }
                // ... handle other potential arguments if needed ...
            }
        }
    }
}
