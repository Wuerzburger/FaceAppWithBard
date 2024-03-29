using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceAppWithBard
{
    public class CommandLineArguments
    {
        public string SourceDirectory { get; set; }
        public string TargetDirectoryResize { get; set; }
        public string TargetDirectoryAlignment { get; set; }
        public string ReferenceImagePath { get; set; }
        public int? ResizeWidth { get; set; }
        public int? ResizeHeight { get; set; }
        public bool Overlay { get; set; }
        public int Duration { get; set; } = 1000; // Default 1 second
        public int Pause { get; set; } = 500; // Default 0.5 seconds
        public int Fps { get; set; } = 25; // Default 25 frames per second
        public string OutputFileName { get; set; }
    }

}
