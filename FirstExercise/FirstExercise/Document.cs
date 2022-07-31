using System;
using System.Collections.Generic;
using System.Text;

namespace FirstExercise
{
    public class Document
    {
        public string Number { get; set; }        
        public int MaxSUMM { 
            get
            {
                int MaxSUMM = 500;                
                return MaxSUMM;
            }

                }
        public DateTime Date { get; set; }
        public List<Row> AllRows = new List<Row>();  
    

        public Document(DateTime date)              
        {       
            Date = date;
        }
      
        public void AddNewRow(string code, int summ)  
        {
            if (summ <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(summ), "Invoice amount should be positive.");
            }
            if (RemainingSUMM(MaxSUMM) - summ < 0)
            {
                throw new InvalidOperationException($"This row wasn't added. Summ of the row is {summ}.The allowed maximum summ of document would be exceded by {RemainingSUMM(MaxSUMM)}.");
            }
            if (summ >= MaxSUMM/3)
            {
                throw new InvalidOperationException($"The summ of one row should be <= then maximum document size/3 ({MaxSUMM}/3).");
            }
            var NewRow = new Row(code, summ);
            AllRows.Add(NewRow);
        }

        public string GetAllRows()
        {
            var report = new StringBuilder();
            report.AppendLine("Code    Summ");
            foreach (var item in AllRows)
            {
                report.AppendLine($"{item.Code}\t{item.Summ}\t");
            }
            return report.ToString();
        }
        public int RemainingSUMM(int MaxSUMM)
        {
                int remainingSum = MaxSUMM;
                foreach (var item in AllRows)
                {
                    remainingSum -= item.Summ;    //each time new row is added remainingSumm decreases
                }
                return remainingSum;
        }
        public int DocumentSUMM()
        {
                int totalSUMM = 0;
                foreach (var item in AllRows)
                {
                    totalSUMM += item.Summ;
                }
                return totalSUMM;
        }
        public int NumberOfLines()
        {
                int numberOfLines = 0;
                foreach (var item in AllRows)
                {
                    numberOfLines++;
                }
                return numberOfLines;
        }
        public DateTime FirstDayOfWeek (DateTime dt)
        {
            switch (dt.DayOfWeek)
            { 
                case DayOfWeek.Tuesday: dt = dt.AddDays(-1); break;
                case DayOfWeek.Wednesday: dt = dt.AddDays(-2); break;
                case DayOfWeek.Thursday: dt= dt.AddDays(-3); break;
                case DayOfWeek.Friday: dt= dt.AddDays(-4); break;
                case DayOfWeek.Saturday: dt = dt.AddDays(-5); break;
                case DayOfWeek.Sunday: dt = dt.AddDays(-6); break;

            }
            return dt;
        }
    }
    

}
