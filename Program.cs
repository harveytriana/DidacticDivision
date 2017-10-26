using System;
using System.IO;

namespace División
{
    delegate void ConsoleWriteLine(string _Format, params object[] _Args);
    delegate void ConsoleWrite(string _Text);

    class Program
    {
        static ConsoleWriteLine _wl = (_Format, _Args) =>
        {
            Console.WriteLine(_Format, _Args);
        };

        static ConsoleWrite _w = (_Text) =>
        {
            Console.Write(_Text);
        };
        
        static void Main(string[] args)
        {
            HacerDivisión hd = new HacerDivisión();
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
                int Dividendo = GetInteger(Console.ReadLine());
                _w("Divisor=? ");
                int Divisor = GetInteger(Console.ReadLine());
                //
                if (Dividendo == 0)
                {
                    break;
                }
                hd.Divida(Dividendo, Divisor);
                _wl("");
                hd.Reporte();
                _wl("");
                //hd.Emitido();
            }
        }

        private static int GetInteger(string s)
        {
            int r = 0;
            int.TryParse(s, out r);
            return r;
        }
    }
}