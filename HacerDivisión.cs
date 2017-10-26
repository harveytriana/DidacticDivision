using System;
using System.Diagnostics;
using System.Collections.Generic;
// Por: Harvey Triana
namespace División
{
    class HacerDivisión
    {// Algoritmo: http://es.wikipedia.org/wiki/Divisi%C3%B3n_(matem%C3%A1tica)

        string m_Dividendo;
        string m_Divisor;
        string m_Cociente;
        string m_Residuo;
        int m_Contador;
        bool m_Emitir = true;
        //
        List<string> m_Reporte = new List<string>();
        List<string> m_Emitido = new List<string>();

        public void Divida(int Dividendo, int Divisor)
        {
            if (PatametrosValidos(Dividendo, Divisor))
            {
                Divida(Dividendo.ToString(), Divisor.ToString());
            }
        }
        public void Divida(int Dividendo, int Divisor, bool Emitir)
        {
            m_Emitir = Emitir;
            Divida(Dividendo, Divisor);
        }
        private void Divida(string Dividendo, string Divisor)
        {
            m_Dividendo = Dividendo;
            m_Divisor = Divisor;
            m_Cociente = "";
            m_Residuo = "";
            m_Contador = 0;
            m_Reporte.Clear();
            m_Emitido.Clear();

            Emíta("DIVIDIR:");
            Emíta("Dividendo = {0}", m_Dividendo);
            Emíta("Divisor = {0}", m_Divisor);
            Emíta("---------------------------------------------------------\n\r");
            string r = m_Dividendo;
            while (r.Length > 0) { r = Parcial(r, Divisor); }

            Emíta("RESULTADO:");
            Emíta("Cociente = {0}", m_Cociente);
            Emíta("Residuo = {0}\n\r", m_Residuo);
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
            }
            else
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

            m_Reporte.Add(Sustractor.ToString());

            Resto = c - Sustractor;
            m_Residuo = Resto.ToString();

            //Emíta("\n\rResto = c - Sustractor = ({0} - {1}) = {2}\n\r", c, Sustractor, Resto);
            Emíta("");

            m_Cociente += CocienteParcial.ToString();

            Emíta("Cociente acomulado = {0}", m_Cociente);
            Emíta("Residuo Parcial = {0}\n\r", m_Residuo);

            if (m_Contador == 0) 
                m_Contador += c.ToString().Length;
            else
                m_Contador++;

            if (m_Contador < m_Dividendo.Length)
            {
                Emíta("Agregamos siguiente cifra al Residuo => {0}...{1} = {0}{1}", m_Residuo, m_Dividendo[m_Contador].ToString());
                SubDividendo = (Resto == 0 ? "" : Resto.ToString()) + m_Dividendo[m_Contador].ToString();

                if (int.Parse(SubDividendo) < d)
                {
                    Emíta("Cómo {0} es menor que {1} agregamos '0' al cociente", SubDividendo, d);
                    m_Cociente += "0";
                    m_Contador++;
                    if (m_Contador < m_Dividendo.Length)
                    {
                        Emíta("Agregamos siguiente cifra al Residuo => {0}...{1} = {0}{1}", SubDividendo, m_Dividendo[m_Contador].ToString());
                        SubDividendo += m_Dividendo[m_Contador].ToString();
                    }
                    else
                    {
                        m_Residuo = SubDividendo;
                        SubDividendo = "";
                    }
                }
                if (SubDividendo != "") m_Reporte.Add(SubDividendo);
            }
            else
            {// No hay más cifras del dividendo, termina iteración
                SubDividendo = "";
            }
            Emíta("---------------------------------------------------------\n\r");
            return SubDividendo;
        }

        void Emíta(string FormatString, params object[] a)
        {
            if (m_Emitir) m_Emitido.Add(string.Format(FormatString, a));
        }

        public int Cociente { get { return int.Parse(m_Cociente); } }
        public int Residuo { get { return int.Parse(m_Residuo); } }

        public void Reporte()
        {
            if (m_Dividendo == null)
            {
                Console.WriteLine("no hay datos que reportar");
                return;
            }

            int i = 0;
            string n = (m_Dividendo.Length).ToString();
            Console.WriteLine("{0, -" + n +"} | {1}", m_Dividendo, m_Divisor);
            foreach (string s in m_Reporte)
            {
                if (i == 0)
                {
                    Console.WriteLine("---------------");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0, -" + n + "}", s);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" | {0}", m_Cociente);
                }
                else
                {
                    Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                    Console.WriteLine("{0}", s);
                }
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0}", m_Residuo);
            Console.WriteLine("---------------");

            // probar

            int r = int.Parse(m_Cociente) * int.Parse(m_Divisor) + int.Parse(m_Residuo);

            Console.WriteLine("Prueba = Cociente * Divisor + Residuo = {0}\n\r", r);

            if (r == int.Parse(m_Dividendo) && int.Parse(m_Residuo) < int.Parse(m_Divisor))
                Console.WriteLine("División correcta");
            else
                Console.WriteLine("División incorrecta");
        }


        public void Emitido()
        {
            foreach (string s in m_Emitido) Console.WriteLine(s);
        }
    }
}