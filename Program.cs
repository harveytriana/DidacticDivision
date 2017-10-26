using System;
using System.IO;

namespace División
{
    delegate void ConsoleWriteLine(string format, params object[] args);
    delegate void ConsoleWrite(string text);

    class Program
    {
        static ConsoleWriteLine _wl = (format, args) =>
        {
            Console.WriteLine(format, args);
        };

        static ConsoleWrite _w = (text) =>
        {
            Console.Write(text);
        };

        static void Main(string[] args)
        {
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
                _wl("Datos de la División");
                _wl("--------------------");
                _w("Dividendo=? ");
                int dividend = GetInteger(Console.ReadLine());
                _w("Divisor=? ");
                int divider = GetInteger(Console.ReadLine());
                //
                if (dividend == 0)
                {
                    break;
                }
                hd.Divide(dividend, divider);
                _wl("");
                hd.Report();
                _wl("");
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