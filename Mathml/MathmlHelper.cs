using System;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;


namespace Mathml
{
    public class MathmlHelper
    {
        public void ReadXmlFile()
        {
            string filename = ConfigurationManager.AppSettings.Get("inputFile");
            XmlTextReader reader = null;//TODO: Option to deserialize it to an object.

            if (File.Exists(filename))
                reader = new XmlTextReader(filename);

            if (reader == null)
            {
                Console.WriteLine("File doesn't exist");//TODO: log error to a file.
                return;
            }
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Description")
                {
                    string s = reader.ReadElementContentAsString();//Joe;SUM;TURN10
                    string[] strings = s.Split(';');
                    string name = strings[0];//Joe
                    string op = strings[1].ToUpper();//SUM

                    string n1 = "0";
                    string n2 = "0";

                    reader.Read();
                    if (reader.Name == "Value1") //TODO: Value1 or Value2 is missing from input data. what error to throw.
                    {
                        n1 = reader.ReadElementContentAsString();
                    }

                    reader.Read();
                    if (reader.Name == "Value2") //TODO: Value1 or Value2 is missing from input data. what error to throw.
                    {
                        n2 = reader.ReadElementContentAsString();
                    }

                    if (!IsValidDigit(n1, name) || !IsValidDigit(n2, name))
                    {
                        continue;
                    }
                    //TODO: how big are n1 and n2. it'll fail if it exceed int.MaxValue; Will long be enough or do we need to perform calc on each digit? 
                    //Assumption: int is enough for now.                     
                    string message = PerformOperation(int.Parse(n1), int.Parse(n2), op, name);
                    Console.WriteLine(message);
                    Console.WriteLine();

                }
            }

            reader.Close();

        }

        public string PerformOperation(int n1, int n2, string op, string name)
        {
            int ans = 0;
            string message = String.Empty;
            switch (op)
            {
                case "SUM":
                    ans = n1 + n2;
                    message = name + " - " + op + " - " + n1 + " + " + n2 + " = " + ans;
                    break;
                case "MULTIPLY":
                    ans = n1 * n2;
                    message = name + " - " + op + " - " + n1 + " * " + n2 + " = " + ans;
                    break;
                case "SUB":
                    ans = n1 - n2;
                    message = name + " - " + op + " - " + n1 + " - " + n2 + " = " + ans;
                    break;
                case "DIVIDE":
                    ans = n1 / n2;
                    message = name + " - " + op + " - " + n1 + " / " + n2 + " = " + ans;
                    break;
                default:
                    message = name + " error operation: " + op;//TODO: log error to a file.
                    break;
            }
            return message;

        }
        public bool IsValidDigit(string s, string name)
        {
            foreach (var c in s)
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine(name + " - value not digit.");//TODO: log error to a file.
                    Console.WriteLine();
                    return false;
                }
            }
            return true;

        }

    }
}
