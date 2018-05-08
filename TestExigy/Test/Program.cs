using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    using System.Globalization;

    class Exigy
    {
        static void Main(string[] args)
        {
            
            try
            {    //document with data, the system will read the information in this text you can find the document in this solution Data>Data.txt;   
                Console.WriteLine("\nPlease inform the folder where the system will find information for run this program");
                string folder = Console.ReadLine();
                string text = System.IO.File.ReadAllText(@folder);
                //validation of document
                if (text != "")
                {
                    //execution and print the results.
                    Console.Write(ResolveMine(text)); //call the function and write the result
                    Console.WriteLine("\nPress Key to finish ");
                    Console.ReadKey(true);
                }
                else
                { //if document is blank
                    Console.Write("Document is Blank, please check the TXT and Try Again");
                    Console.ReadKey(true);
                }
            }
            catch (Exception ex) //if can't find the document or other problems; 
            {
                Console.Write(ex.Message);
                Console.ReadKey(true);
            }
            

           

        }
        public static string ResolveMine(string mineField)
        {
            if (string.IsNullOrEmpty(mineField))
                return string.Empty;
            if (mineField == "*")
                return "*";
            if (mineField == ".")
                return "0";
            string result = string.Empty;
            var splittedMineField = mineField.Split('\n');
            var currentLine = 0;
            var fieldCount = 0;
            while (currentLine < splittedMineField.Count() - 1)
            {
                fieldCount++;
                var fieldDef = splittedMineField[currentLine].Split(' ');
                var lineCount = Int32.Parse(fieldDef[0]);
                var columnCount = Int32.Parse(fieldDef[1]);
                if (lineCount == 0 && columnCount == 0)
                {
                    return result.Substring(0, result.Length - 1);
                }

                currentLine++;
                result += string.Format("Field #{0}:\n", fieldCount);
                result += SolveMine(splittedMineField.Skip(currentLine).Take(lineCount).ToArray());
                currentLine += lineCount;
                
            }
            if (result.Length >= 1)
                return result.Substring(0, result.Length - 1);
                return result;
           
        }
        /*This method count number of mines and set its value*/
        private static string SolveMine(string[] splittedMineField)
        {
            string result = string.Empty;

            for (int cptLigne = 0; cptLigne < splittedMineField.Length; cptLigne++)
            {
                for (int cptColonne = 0; cptColonne < splittedMineField[cptLigne].Length; cptColonne++)
                {
                    if (splittedMineField[cptLigne][cptColonne] == '*')
                    {
                        result += '*';
                    }
                    else
                    {
                        try
                        {
                            
                            var nbMine = 0;
                            if (cptColonne > 0 && cptLigne > 0 && splittedMineField[cptLigne - 1][cptColonne - 1] == '*')
                                nbMine++;

                            if (cptColonne > 0 && splittedMineField[cptLigne][cptColonne - 1] == '*')
                                nbMine++;

                            if (cptColonne > 0 && cptLigne < splittedMineField.Length - 1 &&
                                splittedMineField[cptLigne + 1][cptColonne - 1] == '*')
                                nbMine++;

                            if (cptLigne > 0 && splittedMineField[cptLigne - 1][cptColonne] == '*')
                                nbMine++;

                            if (cptLigne < splittedMineField.Length - 1 && splittedMineField[cptLigne + 1][cptColonne] == '*')
                                nbMine++;


                            if (cptColonne < splittedMineField[cptLigne].Length - 1 && cptLigne > 0 &&
                                splittedMineField[cptLigne - 1][cptColonne + 1] == '*')
                                nbMine++;

                            
                            if (cptColonne < splittedMineField[cptLigne].Length - 1 &&
                                splittedMineField[cptLigne][cptColonne + 1] == '*')
                                nbMine++;

                            if (cptColonne < splittedMineField[cptLigne].Length - 1 && cptLigne < splittedMineField.Length - 1 &&
                                splittedMineField[cptLigne + 1][cptColonne + 1] == '*')
                                nbMine++;

                            result += nbMine.ToString(CultureInfo.InvariantCulture);
                        }
                        catch (System.IndexOutOfRangeException  ex)
                        {
                           // System.Console.WriteLine(ex.Message);
                            // Set IndexOutOfRangeException to the new exception's InnerException.
                            return ("index parameter is out of range , please check the Txt and Try again \nerro in line : " + splittedMineField[cptLigne] +"\n");
                            
                        }
                    }
                }
                result += "\n";
            }
            return result;
            }
           

        }
    
  }

