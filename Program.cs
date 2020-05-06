using System;
using System.IO;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string command, fileName;
            while (true)
            {
                command = Utils.GetInput("Would you like to read or write a file? ");
                switch(command.ToLower())
                {
                    case "write":
                        WriteFile(fileName = Utils.GetInput("The name of the file? "));
                        break;
                    case "read":
                        ReadFile(fileName = Utils.GetInput("The name of the file? "));
                        break;
                    case "exit":
                        return;
                    
                }
            }
        }

        static void WriteFile(string fileName)
        {
            //Instantiate a FileStream that will open a file named by the user 
            FileStream stream = new FileStream("../../../" + fileName, FileMode.Append, FileAccess.Write);
            StreamWriter textFile = new StreamWriter(stream);

            string userInput = Utils.GetInput("Enter Text:");

            //input loop
            while (userInput.Length != 0)
            {
                textFile.WriteLine(userInput);
                userInput = Console.ReadLine();
            }
            textFile.Close();
        } //end WriteFile()

        static void ReadFile(string fileName)
        {
            string line;

            //Instantiate a FileStream that will open a file named by the user 
            FileStream stream = new FileStream("../../../" + fileName, FileMode.Open, FileAccess.Read);
            StreamReader textFile = new StreamReader(stream);

            // read loop
            while ((line = textFile.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            textFile.Close();
        } //end ReadFile()
    }
}
