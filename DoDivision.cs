//==============================================
// By: Harvey Triana
// A didactic way of extracting the steps of an 
// arithmetic division by two digits.
//==============================================
using System;
using System.Collections.Generic;

namespace DidacticDivision
{
    class DoDivision
    {// Source: http://es.wikipedia.org/wiki/Divisi%C3%B3n_(matem%C3%A1tica)
        string _dividend;
        string _divider;
        string _quotient;
        string _residue;
        int _counter;
        bool _emitir = true;
        //
        List<string> _report = new List<string>();
        List<string> _emited = new List<string>();

        public void Divide(int Dividendo, int Divisor) {
            if (ValidParameters(Dividendo, Divisor)) {
                Run(Dividendo.ToString(), Divisor.ToString());
            }
        }

        public void Run(int dividend, int divider, bool emit) {
            _emitir = emit;
            Divide(dividend, divider);
        }

        private void Run(string dividend, string divider) {
            _dividend = dividend;
            _divider = divider;
            _quotient = "";
            _residue = "";
            _counter = 0;
            _report.Clear();
            _emited.Clear();

            Emit("DIVIDE:");
            Emit("Dividend = {0}", _dividend);
            Emit("Divider  = {0}", _divider);
            Emit("---------------------------------------------------------\n\r");
            string r = _dividend;
            while (r.Length > 0) { r = Partial(r, divider); }

            Emit("RESULT:");
            Emit("Quotient = {0}", _quotient);
            Emit("Residue  = {0}\n\r", _residue);
        }

        private bool ValidParameters(int dividend, int divider) {
            if (divider.ToString().Length != 2 ||
                dividend.ToString().Length < 2 ||
                divider > dividend) {
                Emit("Invalid data entered");
                return false;
            }
            return true;
        }

        string Partial(string dividend, string divider) {
            int partialRatio;
            int rest;
            int substractor;
            string subDividend;

            Emit("dividend = {0}", dividend);
            Emit("divider  = {0}\n\r", divider);

            int d = int.Parse(divider);
            int a = int.Parse(dividend[0].ToString());
            int b = int.Parse(divider[0].ToString());
            int c;

            Emit("first number of dividend = {0} = a", a);
            Emit("first number of divider = {0} = b\n\r", b);
            Emit("If a <= b");
            Emit("   a = Take the first two digits");
            Emit("   c = Take the first three digits");
            Emit("Otherwise");
            Emit("   a = Take the first digit (no changes)");
            Emit("   c = Take the first two digits\n\r");

            if (a <= b) {
                a = int.Parse(dividend.Substring(0, 2));
                c = int.Parse(dividend.Substring(0, 3));
            } else {
                c = int.Parse(dividend.Substring(0, 2));
            }
            Emit("a = {0}", a);
            Emit("b = {0}", b);
            Emit("c = {0}", c);

            // the number that multiplied by the divisor approaches more by default to 'a'

            partialRatio = a / b;
            Emit("Partial Quotient = a / b = {0}\n\r", partialRatio);
            Emit("We search that '{0}' - Partial Quotient * Divider >= 0\nSubtracting 1 from Partial Quotient", c);
            while (true) {
                substractor = partialRatio * d;
                Emit("    {0} - {1} * {2} = {3}", c, partialRatio, divider, c - substractor);
                // Emit("Subtractor = Partial Ratio * _Divisor = ({0} * {1}) = {2}", Partial Ratio, _Divisor, Subtractor);
                if (substractor > c) partialRatio--;
                else break;
            }

            _report.Add(substractor.ToString());

            rest = c - substractor;
            _residue = rest.ToString();

            //Emit("\ n \ rRest = c - Subtractor = ({0} - {1}) = {2} \ n \ r", c, Subtractor, Rest);
            Emit("");

            _quotient += partialRatio.ToString();

            Emit("Acomulated quotient = {0}", _quotient);
            Emit("Partial residue     = {0}\n\r", _residue);

            if (_counter == 0)
                _counter += c.ToString().Length;
            else
                _counter++;

            if (_counter < _dividend.Length) {
                Emit("We add the following figure to the Residue => {0} ... {1} = {0} {1}", _residue, _dividend[_counter].ToString());
                subDividend = (rest == 0 ? "" : rest.ToString()) + _dividend[_counter].ToString();

                if (int.Parse(subDividend) < d) {
                    Emit("How {0} is less than {1} we add '0' to the quotient", subDividend, d);
                    _quotient += "0";
                    _counter++;
                    if (_counter < _dividend.Length) {
                        Emit("We add the following digit to the Residue => {0} ... {1} = {0} {1}", subDividend, _dividend[_counter].ToString());
                        subDividend += _dividend[_counter].ToString();
                    } else {
                        _residue = subDividend;
                        subDividend = "";
                    }
                }
                if (subDividend != "") _report.Add(subDividend);
            } else {// No more dividend digits, iteration ends
                subDividend = "";
            }
            Emit("---------------------------------------------------------\n\r");
            return subDividend;
        }

        void Emit(string FormatString, params object[] a) {
            if (_emitir) _emited.Add(string.Format(FormatString, a));
        }

        public int Quotient => int.Parse(_quotient);
        public int Residue => int.Parse(_residue);

        public void Report() {
            if (_dividend == null) {
                Console.WriteLine("there is no data to report");
                return;
            }

            int i = 0;
            string n = (_dividend.Length).ToString();
            Console.WriteLine("{0, -" + n + "} | {1}", _dividend, _divider);
            foreach (string s in _report) {
                if (i == 0) {
                    Console.WriteLine("---------------");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0, -" + n + "}", s);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" | {0}", _quotient);
                } else {
                    Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                    Console.WriteLine("{0}", s);
                }
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0}", _residue);
            Console.WriteLine("---------------");

            // TEST
            int r = int.Parse(_quotient) * int.Parse(_divider) + int.Parse(_residue);

            Console.WriteLine("Test = Quotient * Divider + Residue = {0}\n\r", r);

            if (r == int.Parse(_dividend) && int.Parse(_residue) < int.Parse(_divider))
                Console.WriteLine("Correct division");
            else
                Console.WriteLine("Incorrect division");
        }

        public void Emited() {
            foreach (string s in _emited) {
                Console.WriteLine(s);
            }
        }
    }
}