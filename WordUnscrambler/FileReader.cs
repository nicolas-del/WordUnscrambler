using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string fileName) 
        {
            //declare a string[] to hold the contents of the file 
            //try/catch

            //read from the file - ReadAllLines()
            //return file contents, which is a string[];
            string[] readFiles;

            try
            {
                readFiles = File.ReadAllLines(fileName);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return readFiles;
        }
    }
}
