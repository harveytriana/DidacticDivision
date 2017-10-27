//==============================================
// By: Harvey Triana
// TESTING
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
        static void Main(string[] args) {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("DIDATIC DIVISION\n");
            ForegroundColor = ConsoleColor.Gray;

            var hd = new DoDivision();
            /* samples
            hd.Divide(8593, 23);
            hd.Divide(453, 23);
            hd.Divide(223, 23);
            hd.Divide(1000, 33);
            hd.Divide(7812, 79);
            hd.Divide(1234, 12, true);
            hd.Divide(1220, 10, true);
            hd.Divide(1235678, 32);
            hd.Divide(123456789, 56);
            hd.Divide(7593, 23);
            */
            while (true) {
                WriteLine("Input");
                WriteLine("-----");
                Write("Dividend             = ? ");
                int.TryParse(ReadLine(), out int dividend);
                Write("Divider (two digits) = ? ");
                int.TryParse(ReadLine(), out int divider);
                //
                if (dividend == 0) {
                    WriteLine("Quit");
                    break;
                }
                hd.Divide(dividend, divider);
                WriteLine("");
                hd.Report();
                WriteLine("");
                // hd.Emited();
            }
        }
    }
}