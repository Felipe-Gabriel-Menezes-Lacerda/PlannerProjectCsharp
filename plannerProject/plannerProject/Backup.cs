using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plannerProject
{
    internal class Backup
    {
        public static string documentName = "data.txt";
        public static bool updateDocument = false;

        public static void SetData(ref string[] emails, ref string[] names,ref int totalRecordsCount)
        {
            StreamWriter setData = new StreamWriter(documentName);

            for (int i = 0; i < totalRecordsCount; i++)
            {
                setData.WriteLine($"{names[i]} - {emails[i]}");
            }
            setData.Close();
        }

        public static void GetData()
        {

        }



    }
}
