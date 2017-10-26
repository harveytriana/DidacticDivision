using System;
using System.Diagnostics;
using System.Collections.Generic;
// Por: Harvey Triana
namespace División
{
    class DoDivision
    {// Algoritmo: http://es.wikipedia.org/wiki/Divisi%C3%B3n_(matem%C3%A1tica)

        string _dividend;
        string _divider;
        string _quotient;
        string _residue;
        int _counter;
        bool _emitir = true;
        //
        List<string> _report = new List<string>();
        List<string> _emited = new List<string>();

        public void Divide(int Dividendo, int Divisor)
        {
            if (ValidParameters(Dividendo, Divisor))
            {
                Run(Dividendo.ToString(), Divisor.ToString());
            }
        }

        public void Run(int dividend, int divider, bool emit)
        {
            _emitir = emit;
            Divide(dividend, divider);
        }
        private void Run(string dividend, string divider)
        {
            _dividend = dividend;
            _divider = divider;
            _quotient = "";
            _residue = "";
            _counter = 0;
            _report.Clear();
            _emited.Clear();

            Emit("DIVIDIR:");
            Emit("Dividendo = {0}", _dividend);
            Emit("Divisor = {0}", _divider);
            Emit("---------------------------------------------------------\n\r");
            string r = _dividend;
            while (r.Length > 0) { r = Partial(r, divider); }

            Emit("RESULTADO:");
            Emit("Cociente = {0}", _quotient);
            Emit("Residuo = {0}\n\r", _residue);
        }

        private bool ValidParameters(int dividend, int divider)
        {
            if (divider.ToString().Length != 2 ||
                dividend.ToString().Length < 2 ||
                divider > dividend)
            {
                Emit("Parámetros no validos");
                return false;
            }
            return true;
        }

        string Partial(string dividend, string divider)
        {
            int partialRatio;
            int rest;
            int substractor;
            string subDividend;

            Emit("_Dividendo = {0}", dividend);
            Emit("_Divisor = {0}\n\r", divider);

            int d = int.Parse(divider);
            int a = int.Parse(dividend[0].ToString());
            int b = int.Parse(divider[0].ToString());
            int c;

            Emit("Primera cifra _Dividendo = {0} = a", a);
            Emit("Primera cifra _Divisor = {0} = b\n\r", b);
            Emit("Si a <= b");
            Emit("   a = Toma dos primeras cifras");
            Emit("   c = Toma las tres primeras cifras");
            Emit("En caso contrario");
            Emit("   a = Toma la primera cifra (no varia)");
            Emit("   c = Toma las dos primeras cifras\n\r");

            if (a <= b)
            {
                a = int.Parse(dividend.Substring(0, 2));
                c = int.Parse(dividend.Substring(0, 3));
            } else
            {
                c = int.Parse(dividend.Substring(0, 2));
            }
            Emit("a = {0}", a);
            Emit("b = {0}", b);
            Emit("c = {0}", c);

            //  el número que multiplicado por el divisor se aproxima más por defecto a 'a'

            partialRatio = a / b;
            Emit("CocienteParcial = a / b = {0}\n\r", partialRatio);
            Emit("Buscamos que '{0}' - CocienteParcial * Divisor >= 0\n\rRestando 1 de CocienteParcial", c);
            while (true)
            {
                substractor = partialRatio * d;
                Emit("    {0} - {1} * {2} = {3}", c, partialRatio, divider, c - substractor);
                //Emíta("Sustractor = CocienteParcial *_Divisor = ({0} * {1}) = {2}", CocienteParcial, _Divisor, Sustractor);
                if (substractor > c) partialRatio--;
                else break;
            }

            _report.Add(substractor.ToString());

            rest = c - substractor;
            _residue = rest.ToString();

            //Emíta("\n\rResto = c - Sustractor = ({0} - {1}) = {2}\n\r", c, Sustractor, Resto);
            Emit("");

            _quotient += partialRatio.ToString();

            Emit("Cociente acomulado = {0}", _quotient);
            Emit("Residuo Parcial = {0}\n\r", _residue);

            if (_counter == 0)
                _counter += c.ToString().Length;
            else
                _counter++;

            if (_counter < _dividend.Length)
            {
                Emit("Agregamos siguiente cifra al Residuo => {0}...{1} = {0}{1}", _residue, _dividend[_counter].ToString());
                subDividend = (rest == 0 ? "" : rest.ToString()) + _dividend[_counter].ToString();

                if (int.Parse(subDividend) < d)
                {
                    Emit("Cómo {0} es menor que {1} agregamos '0' al cociente", subDividend, d);
                    _quotient += "0";
                    _counter++;
                    if (_counter < _dividend.Length)
                    {
                        Emit("Agregamos siguiente cifra al Residuo => {0}...{1} = {0}{1}", subDividend, _dividend[_counter].ToString());
                        subDividend += _dividend[_counter].ToString();
                    } else
                    {
                        _residue = subDividend;
                        subDividend = "";
                    }
                }
                if (subDividend != "") _report.Add(subDividend);
            } else
            {// No hay más cifras del dividendo, termina iteración
                subDividend = "";
            }
            Emit("---------------------------------------------------------\n\r");
            return subDividend;
        }

        void Emit(string FormatString, params object[] a)
        {
            if (_emitir) _emited.Add(string.Format(FormatString, a));
        }

        public int Quotient { get { return int.Parse(_quotient); } }
        public int Residue { get { return int.Parse(_residue); } }

        public void Report()
        {
            if (_dividend == null)
            {
                Console.WriteLine("no hay datos que reportar");
                return;
            }

            int i = 0;
            string n = (_dividend.Length).ToString();
            Console.WriteLine("{0, -" + n + "} | {1}", _dividend, _divider);
            foreach (string s in _report)
            {
                if (i == 0)
                {
                    Console.WriteLine("---------------");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0, -" + n + "}", s);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" | {0}", _quotient);
                } else
                {
                    Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                    Console.WriteLine("{0}", s);
                }
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0}", _residue);
            Console.WriteLine("---------------");

            // probar

            int r = int.Parse(_quotient) * int.Parse(_divider) + int.Parse(_residue);

            Console.WriteLine("Prueba = Cociente * Divisor + Residuo = {0}\n\r", r);

            if (r == int.Parse(_dividend) && int.Parse(_residue) < int.Parse(_divider))
                Console.WriteLine("División correcta");
            else
                Console.WriteLine("División incorrecta");
        }


        public void Emited()
        {
            foreach (string s in _emited) Console.WriteLine(s);
        }
    }
}