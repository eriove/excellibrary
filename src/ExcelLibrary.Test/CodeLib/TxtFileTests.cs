using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using NUnit.Framework;
using QiHe.CodeLib;

namespace ExcelLibrary.Test.CodeLib
{
    [TestFixture]
    public class TxtFileTests
    {
        private string fileName;

        [SetUp]
        public void Setup()
        {
            fileName = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        [Test]
        public void WriteTextShouldNotAppend()
        {
            File.WriteAllText(fileName,"first text");
            string expectedText = "other string";
            TxtFile.Write(fileName, expectedText);
            string actualText = File.ReadAllText(fileName);
            Assert.AreEqual(expectedText,actualText);
        }

        [Test]
        public void WriteTextShouldNotAppendWithEncoding()
        {
            File.WriteAllText(fileName, "first text", Encoding.UTF32);
            string expectedText = "other string";
            TxtFile.Write(fileName, expectedText, Encoding.UTF32);
            string actualText = File.ReadAllText(fileName, Encoding.UTF32);
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void AppendTextShouldAppend()
        {
            string firstText = "first text";
            File.WriteAllText(fileName, firstText);
            string secondText = "other string";
            TxtFile.Append(fileName, secondText);
            string actualText = File.ReadAllText(fileName);
            Assert.AreEqual(firstText + secondText + Environment.NewLine, actualText);
        }

        [Test]
        public void AppendTextShouldAppendWithEncoding()
        {
            string firstText = "first text";
            File.WriteAllText(fileName, firstText, Encoding.UTF32);
            string secondText = "other string";
            TxtFile.Append(fileName, secondText, Encoding.UTF32);
            string actualText = File.ReadAllText(fileName, Encoding.UTF32);
            Assert.AreEqual(firstText + secondText, actualText);
        }
    }
}
