//==============================================
// By: Harvey Triana
// A didactic way of extracting the steps of an 
// arithmetic division by two digits.
//==============================================
using System;
//
using static System.Console;

namespace DidacticDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("DIDATIC DIVISION\n");
            ForegroundColor = ConsoleColor.Gray;

            var hd = new DoDivision();
            /*/
            hd.Divida(8593, 23);
            //
            hd.Divida(453, 23);
            hd.Divida(223, 23);
            hd.Divida(1000, 33);
            hd.Divida(7812, 79);
            
            hd.Divida(1234, 12, true);
            hd.Divida(1220, 10, true);
            hd.Divida(1235678, 32);
            hd.Divida(123456789, 56);
            hd.Divida(7593, 23);
            //*/
            while (true)
            {
                WriteLine("Input");
                WriteLine("-----");
                Write("Dividend             = ? ");
                int dividend = GetInteger(ReadLine());
                Write("Divider (two digits) = ? ");
                int divider = GetInteger(ReadLine());
                //
                if (dividend == 0)
                {
                    break;
                }
                hd.Divide(dividend, divider);
                WriteLine("");
                hd.Report();
                WriteLine("");
                // hd.Emited();
            }
        }

        private static int GetInteger(string s)
        {
            int.TryParse(s, out int r);
            return r;
        }
    }
}