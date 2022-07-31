using System;
using System.Collections.Generic;
using System.Text;

namespace FirstExercise
{
    public class Row
    {
        public string Code { get; set; }   
        public int Summ { get; set; }

        public Row(string code, int summ)  
        {
            Code = code;
            Summ = summ;
        }
    }
}
