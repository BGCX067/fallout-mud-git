using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Output;
using System.Collections;
using System.IO;

namespace Mud.Ascii
{
    public class AsciiOutputParser : IOutputParser
    {
        private static Dictionary<char, string> _colors = new Dictionary<char, string>();
        private const string ESC = "\x1B";

        static AsciiOutputParser()
        {
            _colors.Add('R', GetSequence(AnsiForegroundColor.Red, 1));
            _colors.Add('r', GetSequence(AnsiForegroundColor.Red, 0));
            _colors.Add('w', GetSequence(AnsiForegroundColor.White, 1));
            _colors.Add('W', GetSequence(AnsiForegroundColor.White, 0));
            _colors.Add('Y', GetSequence(AnsiForegroundColor.Yellow, 1));
            _colors.Add('y', GetSequence(AnsiForegroundColor.Yellow, 0));
            _colors.Add('G', GetSequence(AnsiForegroundColor.Green, 1));
            _colors.Add('g', GetSequence(AnsiForegroundColor.Green, 0));
        }

        private string GetColor(char input)
        {
            if (_colors.ContainsKey(input))
                return _colors[input];
            return GetSequence(AnsiForegroundColor.Default, 1);
        }

        private static string GetSequence(AnsiForegroundColor color, int bright)
        {
            return string.Format("{0}[{2}m{0}[{1}m", ESC, (int)color, bright);
        }

        public string Parse(string message)
        {
            StringBuilder sb = new StringBuilder();
            StringReader sr = new StringReader(message);
            char[] buf = new char[1];
            while (sr.Read(buf, 0, 1) > 0)
            {
                if (buf[0] == '&')
                {
                    if (sr.Read(buf, 0, 1) > 0)
                    {
                        if (buf[0] == '&')
                            sb.Append('&');
                        else
                            sb.Append(GetColor(buf[0]));
                    }
                    else
                        break;
                }
                else
                {
                    sb.Append(buf[0]);
                }
            }
            return sb.ToString();
        }
    }
}
