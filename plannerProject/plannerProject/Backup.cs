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
            try
            {

                StreamWriter setData = new StreamWriter(documentName);

                for (int i = 0; i < totalRecordsCount; i++)
                {
                    setData.WriteLine($"{names[i]}-{emails[i]}");
                }
                setData.Close();
            } catch(Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public static void GetData(ref string[] emails, ref string[] names, ref int totalRecordsCount)
        {
            try
            { 
                totalRecordsCount = 0;
                int charDivisorPosition = 0;

                StreamReader documentReader = new StreamReader(documentName);
                string documentContactLine = documentReader.ReadLine();
            
                while (documentContactLine != null)
                {
                    
                    charDivisorPosition = documentContactLine.IndexOf("-");
                    names[totalRecordsCount] = documentContactLine.Substring(0, charDivisorPosition);
                    emails[totalRecordsCount] = documentContactLine.Substring(charDivisorPosition + 1);
                    totalRecordsCount++; // totalRecordsCount = totalRecordsCount + 1;
                    documentContactLine = documentReader.ReadLine();
                }
                documentReader.Close();
                
            } catch(Exception error)
            {
                Console.WriteLine(error);
            }


        }



    }
}
