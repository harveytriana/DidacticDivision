using System;
using System.IO;
//
using static System.Console;

namespace División
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("DIDATIC DIVISION\n");
            ForegroundColor = ConsoleColor.Gray;

            DoDivision hd = new DoDivision();
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
                WriteLine("Datos de la División");
                WriteLine("--------------------");
                Write("Dividendo             = ? ");
                int dividend = GetInteger(ReadLine());
                Write("Divisos (two numbers) = ? ");
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
                //hd.Emitido();
            }
        }

        private static int GetInteger(string s)
        {
            int.TryParse(s, out int r);
            return r;
        }
    }
}