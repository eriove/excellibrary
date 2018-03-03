using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QiHe.CodeLib
{
    /// <summary>
    /// TxtFile
    /// </summary>
    public class TxtFile
    {
        /// <summary>
        /// Creates the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        public static void Create(string file)
        {
            using (StreamWriter sw = File.CreateText(file))
            { }
        }
        /// <summary>
        /// Reads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public static string Read(string file)
        {
            using (StreamReader sr = File.OpenText(file))
            {
                string text = sr.ReadToEnd();
                return text;
            }
        }
        //Encodings: "ASCII","UTF-8","Unicode","GB2312","GB18030"
        /// <summary>
        /// Reads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public static string Read(string file, string encoding)
        {
            return Read(file, Encoding.GetEncoding(encoding));
        }
        /// <summary>
        /// Reads the lines.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public static List<string> ReadLines(string file, string encoding)
        {
            return ReadLines(file, Encoding.GetEncoding(encoding));
        }
        /// <summary>
        /// Reads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public static string Read(string file, Encoding encoding)
        {
            using (var fileStream = File.OpenRead(file))
            using (StreamReader sr = new StreamReader(fileStream, encoding))
            {
                return sr.ReadToEnd();
            }
        }
        /// <summary>
        /// Reads the lines.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public static List<string> ReadLines(string file, Encoding encoding)
        {
            using (var fileStream = File.OpenRead(file))
            using (StreamReader reader = new StreamReader(fileStream, encoding))
            {
                List<string> lines = new List<string>();
                string line = reader.ReadLine();
                while (line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
                return lines;
            }
        }
        /// <summary>
        /// Writes the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="text">The text.</param>
        public static void Write(string file, string text)
        {
            using (var fileStream = File.OpenWrite(file))
            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
            {
                sw.Write(text);
            }
        }
        /// <summary>
        /// Writes the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="text">The text.</param>
        /// <param name="encoding">The encoding.</param>
        public static void Write(string file, string text, Encoding encoding)
        {
            using (var fileStream = File.OpenWrite(file))
            using (StreamWriter sw = new StreamWriter(fileStream, encoding))
            {
                sw.Write(text);
            }
        }
        /// <summary>
        /// Appends the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="text">The text.</param>
        public static void Append(string file, string text)
        {
            using (StreamWriter sw = File.AppendText(file))
            {
                sw.WriteLine(text);
            }
        }
        /// <summary>
        /// Appends the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="text">The text.</param>
        /// <param name="encoding">The encoding.</param>
        public static void Append(string file, string text, Encoding encoding)
        {
            File.AppendAllText(file, text, encoding);
        }

        /// <summary>
        /// Gets the text from current position of reader to specified tag.
        /// tag should occupy just one line.
        /// if tag is null then read to the end of file.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="tag">The tag.</param>
        /// <returns>the text from current position of reader to specified tag, tag is not included.</returns>
        public static string GetText(TextReader reader, string tag)
        {
            if (tag == null)
            {
                return reader.ReadToEnd();
            }
            StringBuilder text = new StringBuilder();
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line == tag)
                {
                    int n = Environment.NewLine.Length;
                    if (text.Length > n)
                    {
                        text.Remove(text.Length - n, n);
                    }
                    return text.ToString();
                }
                text.Append(line + Environment.NewLine);
                line = reader.ReadLine();
            }
            return null;
        }


        /// <summary>
        /// Gets the text between two tags in file.
        /// each tag should occupy just one line.
        /// </summary>
        /// <param name="file">The file in UTF-8.</param>
        /// <param name="startTag">The start tag.</param>
        /// <param name="endTag">The end tag.</param>
        /// <returns>the text between two tags in file, or null if startTag is not found.</returns>
        public static string GetText(string file, string startTag, string endTag)
        {
            using (StreamReader reader = File.OpenText(file))
            {
                StringBuilder text = new StringBuilder();
                bool found = false;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line == endTag)
                    {
                        break;
                    }
                    if (found)
                    {
                        text.AppendLine(line);
                    }
                    if (line == startTag)
                    {
                        found = true;
                    }
                    line = reader.ReadLine();
                }
                if (found) return text.ToString();
                return null;
            }
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="startTag">The start tag.</param>
        /// <param name="endTag">The end tag.</param>
        /// <param name="lineNum">The line num.</param>
        /// <returns></returns>
        public static string GetText(string file, string startTag, string endTag, out int lineNum)
        {
            using (StreamReader reader = File.OpenText(file))
            {
                StringBuilder text = new StringBuilder();
                bool found = false;
                int linecounter = 0;
                lineNum = -1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    linecounter++;
                    if (line == endTag)
                    {
                        break;
                    }
                    if (found)
                    {
                        text.AppendLine(line);
                    }
                    if (line == startTag)
                    {
                        found = true;
                        lineNum = linecounter + 1;
                    }
                    line = reader.ReadLine();
                }
                if (found) return text.ToString();
                return null;
            }
        }

        /// <summary>
        /// Counts the lines and chars.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="lines">The lines.</param>
        /// <param name="chars">The chars.</param>
        public static void CountLinesAndChars(string file, out int lines, out int chars)
        {
            using (StreamReader reader = File.OpenText(file))
            {
                lines = 0;
                chars = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lines++;
                    chars += line.Length;
                    line = reader.ReadLine();
                }
            }
        }
    }
}