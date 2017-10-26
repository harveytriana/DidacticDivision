using System;
using System.Diagnostics;
using System.Collections.Generic;
// Por: Harvey Triana
namespace División
{
    class HacerDivisión
    {// Algoritmo: http://es.wikipedia.org/wiki/Divisi%C3%B3n_(matem%C3%A1tica)

        string _dividendo;
        string _divisor;
        string _cociente;
        string _residuo;
        int _contador;
        bool _emitir = true;
        //
        List<string> _reporte = new List<string>();
        List<string> _emitido = new List<string>();

        public void Divida(int Dividendo, int Divisor)
        {
            if (PatametrosValidos(Dividendo, Divisor))
            {
                Divida(Dividendo.ToString(), Divisor.ToString());
            }
        }

        public void Divida(int Dividendo, int Divisor, bool Emitir)
        {
            _emitir = Emitir;
            Divida(Dividendo, Divisor);
        }
        private void Divida(string Dividendo, string Divisor)
        {
            _dividendo = Dividendo;
            _divisor = Divisor;
            _cociente = "";
            _residuo = "";
            _contador = 0;
            _reporte.Clear();
            _emitido.Clear();

            Emíta("DIVIDIR:");
            Emíta("Dividendo = {0}", _dividendo);
            Emíta("Divisor = {0}", _divisor);
            Emíta("---------------------------------------------------------\n\r");
            string r = _dividendo;
            while (r.Length > 0) { r = Parcial(r, Divisor); }

            Emíta("RESULTADO:");
            Emíta("Cociente = {0}", _cociente);
            Emíta("Residuo = {0}\n\r", _residuo);
        }

        private bool PatametrosValidos(int Dividendo, int Divisor)
        {
            if (Divisor.ToString().Length != 2 ||
                Dividendo.ToString().Length < 2 ||
                Divisor > Dividendo)
            {
                Emíta("Parámetros no validos");
                return false;
            }
            return true;
        }

        string Parcial(string _Dividendo, string _Divisor)
        {
            int CocienteParcial;
            int Resto;
            int Sustractor;
            string SubDividendo;

            Emíta("_Dividendo = {0}", _Dividendo);
            Emíta("_Divisor = {0}\n\r", _Divisor);

            int d = int.Parse(_Divisor);
            int a = int.Parse(_Dividendo[0].ToString());
            int b = int.Parse(_Divisor[0].ToString());
            int c;

            Emíta("Primera cifra _Dividendo = {0} = a", a);
            Emíta("Primera cifra _Divisor = {0} = b\n\r", b);
            Emíta("Si a <= b");
            Emíta("   a = Toma dos primeras cifras");
            Emíta("   c = Toma las tres primeras cifras");
            Emíta("En caso contrario");
            Emíta("   a = Toma la primera cifra (no varia)");
            Emíta("   c = Toma las dos primeras cifras\n\r");

            if (a <= b)
            {
                a = int.Parse(_Dividendo.Substring(0, 2));
                c = int.Parse(_Dividendo.Substring(0, 3));
            } else
            {
                c = int.Parse(_Dividendo.Substring(0, 2));
            }
            Emíta("a = {0}", a);
            Emíta("b = {0}", b);
            Emíta("c = {0}", c);

            //  el número que multiplicado por el divisor se aproxima más por defecto a 'a'

            CocienteParcial = a / b;
            Emíta("CocienteParcial = a / b = {0}\n\r", CocienteParcial);
            Emíta("Buscamos que '{0}' - CocienteParcial * Divisor >= 0\n\rRestando 1 de CocienteParcial", c);
            while (true)
            {
                Sustractor = CocienteParcial * d;
                Emíta("    {0} - {1} * {2} = {3}", c, CocienteParcial, _Divisor, c - Sustractor);
                //Emíta("Sustractor = CocienteParcial *_Divisor = ({0} * {1}) = {2}", CocienteParcial, _Divisor, Sustractor);
                if (Sustractor > c) CocienteParcial--;
                else break;
            }

            _reporte.Add(Sustractor.ToString());

            Resto = c - Sustractor;
            _residuo = Resto.ToString();

            //Emíta("\n\rResto = c - Sustractor = ({0} - {1}) = {2}\n\r", c, Sustractor, Resto);
            Emíta("");

            _cociente += CocienteParcial.ToString();

            Emíta("Cociente acomulado = {0}", _cociente);
            Emíta("Residuo Parcial = {0}\n\r", _residuo);

            if (_contador == 0)
                _contador += c.ToString().Length;
            else
                _contador++;

            if (_contador < _dividendo.Length)
            {
                Emíta("Agregamos siguiente cifra al Residuo => {0}...{1} = {0}{1}", _residuo, _dividendo[_contador].ToString());
                SubDividendo = (Resto == 0 ? "" : Resto.ToString()) + _dividendo[_contador].ToString();

                if (int.Parse(SubDividendo) < d)
                {
                    Emíta("Cómo {0} es menor que {1} agregamos '0' al cociente", SubDividendo, d);
                    _cociente += "0";
                    _contador++;
                    if (_contador < _dividendo.Length)
                    {
                        Emíta("Agregamos siguiente cifra al Residuo => {0}...{1} = {0}{1}", SubDividendo, _dividendo[_contador].ToString());
                        SubDividendo += _dividendo[_contador].ToString();
                    } else
                    {
                        _residuo = SubDividendo;
                        SubDividendo = "";
                    }
                }
                if (SubDividendo != "") _reporte.Add(SubDividendo);
            } else
            {// No hay más cifras del dividendo, termina iteración
                SubDividendo = "";
            }
            Emíta("---------------------------------------------------------\n\r");
            return SubDividendo;
        }

        void Emíta(string FormatString, params object[] a)
        {
            if (_emitir) _emitido.Add(string.Format(FormatString, a));
        }

        public int Cociente { get { return int.Parse(_cociente); } }
        public int Residuo { get { return int.Parse(_residuo); } }

        public void Reporte()
        {
            if (_dividendo == null)
            {
                Console.WriteLine("no hay datos que reportar");
                return;
            }

            int i = 0;
            string n = (_dividendo.Length).ToString();
            Console.WriteLine("{0, -" + n + "} | {1}", _dividendo, _divisor);
            foreach (string s in _reporte)
            {
                if (i == 0)
                {
                    Console.WriteLine("---------------");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0, -" + n + "}", s);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" | {0}", _cociente);
                } else
                {
                    Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                    Console.WriteLine("{0}", s);
                }
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0}", _residuo);
            Console.WriteLine("---------------");

            // probar

            int r = int.Parse(_cociente) * int.Parse(_divisor) + int.Parse(_residuo);

            Console.WriteLine("Prueba = Cociente * Divisor + Residuo = {0}\n\r", r);

            if (r == int.Parse(_dividendo) && int.Parse(_residuo) < int.Parse(_divisor))
                Console.WriteLine("División correcta");
            else
                Console.WriteLine("División incorrecta");
        }


        public void Emitido()
        {
            foreach (string s in _emitido) Console.WriteLine(s);
        }
    }
}