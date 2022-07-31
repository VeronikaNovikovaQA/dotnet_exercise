using System;
using System.Linq;

namespace FirstExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Document = new Document(DateTime.Now);

            Console.WriteLine("Please enter Document number:");
            Document.Number = Console.ReadLine();
    
            bool AddOneMoreRow = true;
            do
            {
                try
                {
                    Console.WriteLine("Please enter Row code:");
                    string RowCode = Console.ReadLine();
                    Console.WriteLine($"Please enter Row summ: (note : maximum summ of document is {Document.MaxSUMM})");
                    int RowSumm = Convert.ToInt32(Console.ReadLine());

                    if (Document.AllRows.Count == 0)
                    {
                        Document.AddNewRow(RowCode, RowSumm);
                    }
                    else
                    {
                        bool exists = false;
                        foreach (var row in Document.AllRows)
                        {
                            if (row.Summ == RowSumm)
                            {
                                Console.WriteLine("This summ already exists in the document.Please enter another summ.");
                                exists = true;
                                break;
                            }
                        }
                        if (exists == false) { Document.AddNewRow(RowCode, RowSumm); }
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Please check the row summ!");
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine("Do you want to add next row? Yes?/No");

                string answer = Console.ReadLine();
                switch(answer.ToUpper())
                {
                    case "NO":
                        AddOneMoreRow = false;
                        break;
                    case "YES":
                        continue;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid answer, programm finishes execution.");
                        Console.WriteLine();
                        AddOneMoreRow = false;
                        break;
                }
            }
            while(AddOneMoreRow == true);

            Console.WriteLine($"Document date - {Document.FirstDayOfWeek(DateTime.Now).ToString("dd.MM.yyyy")}\tDocument number - {Document.Number}\tMaximum summ - {Document.MaxSUMM}");
            Console.WriteLine(Document.GetAllRows());
            Console.WriteLine($"Summ of the document - {Document.DocumentSUMM()}\tNumber of lines - {Document.NumberOfLines()}");
            

        }

    }
}
