using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Ascii
{
    public enum AnsiForegroundColor
    {
        // DEFAULT FG COLORS

        /// <summary>ANSI color code for black.</summary>
        Black = 30,

        /// <summary>ANSI color code for red.</summary>
        Red = 31,

        /// <summary>ANSI color code for green.</summary>
        Green = 32,

        /// <summary>ANSI color code for yellow.</summary>
        Yellow = 33,

        /// <summary>ANSI color code for blue.</summary>
        Blue = 34,

        /// <summary>ANSI color code for magenta.</summary>
        Magenta = 35,

        /// <summary>ANSI color code for cyan.</summary>
        Cyan = 36,

        /// <summary>ANSI color code for white.</summary>
        White = 37,

        /// <summary>ANSI color code for default.</summary>
        Default = 39
    }

    // Background Colors              
    public enum AnsiBackgroundColor
    {
        /// <summary>ANSI color code for black background.</summary>
        Black = 40,

        /// <summary>ANSI color code for red background.</summary>
        Red = 41,

        /// <summary>ANSI color code for green background.</summary>
        Green = 42,

        /// <summary>ANSI color code for yellow background.</summary>
        Yellow = 43,

        /// <summary>ANSI color code for blue background.</summary>
        Blue = 44,

        /// <summary>ANSI color code for magenta background.</summary>
        Magenta = 45,

        /// <summary>ANSI color code for cyan background.</summary>
        Cyan = 46,

        /// <summary>ANSI color code for white background.</summary>
        White = 47
    }
}
