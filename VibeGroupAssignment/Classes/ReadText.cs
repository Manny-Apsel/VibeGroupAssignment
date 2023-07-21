using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibeGroupAssignment.Classes
{
    internal class ReadText
    {
        private static string fileName { get; set; } = @"\input.txt";
        public static string[] readText()
        {
            string workDir = Directory.GetCurrentDirectory();
            string dirPath = Directory.GetParent(workDir).Parent.Parent.FullName + @"\Wordgame";
            string[] lines = File.ReadAllLines(dirPath + fileName, System.Text.Encoding.UTF8);
            lines = lines.Take(150).ToArray();
            return lines;
        }

    }
}
