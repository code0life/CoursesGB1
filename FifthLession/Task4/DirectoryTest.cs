using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class DirectoryTest : Bob
    {
        public List<FileTest> listFiles { get; set; }
        public List<DirectoryTest> listDirectories { get; set; }
        public DirectoryTest(string _name, List<FileTest> _listFiles, List<DirectoryTest> _listDirectories)
        {
            name = _name;
            listFiles = _listFiles;
            listDirectories = _listDirectories;
        }
        public DirectoryTest()
        {
            name = "???";
            listFiles = new List<FileTest>();
            listDirectories = new List<DirectoryTest>();
        }
        public DirectoryTest(string _name)
        {
            name = _name;
        }
    }
}
