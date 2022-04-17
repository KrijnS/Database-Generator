using System;
using System.IO;
using System.Text;

namespace DatabaseGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int dbSize = 15000;

            string[] voornamen = System.IO.File.ReadAllLines(@"..\..\..\voornamen.txt");
            string[] achternamen = System.IO.File.ReadAllLines(@"..\..\..\achternamen.txt");
            string[] regios = System.IO.File.ReadAllLines(@"..\..\..\regios.txt");
            string[] functies = System.IO.File.ReadAllLines(@"..\..\..\functies.txt");
            string[] output = new string[dbSize];

            for(int i = 0; i < dbSize; i++)
            {
                output[i] = program.GenEntry(voornamen, achternamen, regios, functies);
            }

            File.AppendAllLines(@"..\..\..\output.txt", output);

        }

        string GenDNA()
        {
            Random rand = new Random(); 
            StringBuilder sequence = new StringBuilder();
            for(int i = 0; i < 14; i++)
            {
                int charChoice = rand.Next(0, 4);
                switch (charChoice)
                {
                    case 0:
                        sequence.Append('A');
                        break;
                    case 1:
                        sequence.Append('T');
                        break;
                    case 2:
                        sequence.Append('G');
                        break;
                    default:
                        sequence.Append('C');
                        break;
                }
            }
            return sequence.ToString();
        }

        string GenAccess()
        {
            Random rand = new Random();
            StringBuilder labs = new StringBuilder();
            int labAccess = rand.Next(10);
            if(labAccess > 5)
            {
                labs.Append("Geen Toegang");
            }
            else
            {
                switch (labAccess)
                {
                    case 0:
                        labs.Append("Lab A");
                        break;
                    case 1:
                        labs.Append("Lab B");
                        break;
                    case 2:
                        labs.Append("Lab C");
                        break;
                    case 3:
                        labs.Append("Lab D");
                        break;
                    case 4:
                        labs.Append("Lab E");
                        break;
                    default:
                        labs.Append("Lab F");
                        break;
                }
            }
            return labs.ToString();
        }

        string GetGender(int gen)
        {
            Random rand = new Random();
            int x = rand.Next(10);
            if (x == 1)
            {
                return "\'X\',";
            }
            else if (gen < 100)
            {
                return "\'M\',";
            }
            else
            {
                return "\'V\',";
            }
        }

        string GenEntry(string[] voornamen, string[] achternamen, string[] regios, string[] functies)
        {
            StringBuilder entry = new StringBuilder();
            Random rand = new Random();
            entry.Append("(\'");
            entry.Append(achternamen[rand.Next(achternamen.Length)]);
            entry.Append("\',\'");
            int voornaam = rand.Next(voornamen.Length);
            entry.Append(voornamen[voornaam]);
            entry.Append("\',");
            entry.Append(GetGender(voornaam));
            entry.Append(rand.Next(18, 68));
            entry.Append(",");
            entry.Append(rand.Next(36, 47));
            entry.Append(",\'");
            entry.Append(regios[rand.Next(regios.Length)]);
            entry.Append("\',\'");
            entry.Append(functies[rand.Next(functies.Length)]);
            entry.Append("\',\'");
            entry.Append(GenAccess());
            entry.Append("\',\'");
            entry.Append(GenDNA());
            entry.Append("\'),");
            return entry.ToString();
        }
    }
}
