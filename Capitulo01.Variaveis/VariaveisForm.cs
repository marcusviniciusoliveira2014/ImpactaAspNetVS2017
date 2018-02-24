using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitulo01.Variaveis
{
    public partial class VariaveisForm : Form
    {
        int _x = 32;
        int _w = 45;
        int _y = 16;
        int _z = 32;

        

        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = 2;
            int b = 6;
            int c = 10;
            int d = 13;


            resultadoListBox.Items.Add("Valor da Variavel a = " + a.ToString());
            resultadoListBox.Items.Add("Valor da Variavel b = " + b.ToString());
            resultadoListBox.Items.Add($" c = {c}, mas d = {d} ");
            resultadoListBox.Items.Add(string.Concat("d = ",d, " mas a = ",a));

            resultadoListBox.Items.Add(new string('-', 50));
            resultadoListBox.Items.Add("c * d = " + (c * d));
            resultadoListBox.Items.Add("c / a = " + (c / a));
            resultadoListBox.Items.Add("5 / 2 = " + (5 / 2));
            resultadoListBox.Items.Add("d % a = " + (d % a));

            /*
                        decimal valor = 10;
                        string nomeCliente = "Marcus";
                        bool habilitado = false;
                        DateTime dataNascimento = new DateTime(1970, 08, 08);

                        if (true)
                        {

                        }
            */


        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = 5;
            resultadoListBox.Items.Add(" _x  = " + x);
            //x = x-3;
            x -= 3;
            resultadoListBox.Items.Add(" _x  = " + x);         
        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            a = 5;
            resultadoListBox.Items.Add("Exemplo pré-incremental");
            resultadoListBox.Items.Add(" a = " + a);
            resultadoListBox.Items.Add("2 + ++a = " + (2 + ++a));
            resultadoListBox.Items.Add(" a = " + a);
            

            a = 5;
            resultadoListBox.Items.Add("Exemplo Pós-incremental");
            resultadoListBox.Items.Add(" a = " + a);
            resultadoListBox.Items.Add("2 + a++ = " + (2 + a++));
            resultadoListBox.Items.Add(" a = " + a);
            

        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVariaveis();

            resultadoListBox.Items.Add("w <= _x = " + (_w <= _x));
            resultadoListBox.Items.Add("_x == z = " + (_x == _z));
            resultadoListBox.Items.Add("_x != z = " + (_x != _z));

        }

        private void MostrarVariaveis()
        {
            resultadoListBox.Items.Add("_x = " + _x);
            resultadoListBox.Items.Add("_w = " + _w);
            resultadoListBox.Items.Add("y = " + _y);
            resultadoListBox.Items.Add("z = " + _z);

        }

        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVariaveis();
            resultadoListBox.Items.Add(new string('-',50));
            resultadoListBox.Items.Add(" _w <= _x || _y == 16 = " + (_w <= _x || _y == 16));
            resultadoListBox.Items.Add(" _x == _z && _z != _x = " + (_x == _z && _z != _x));

            resultadoListBox.Items.Add(" !(_y > _w) = " + (!(_y > _w)));
        }

        private void ternariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ano;
            ano = 2014;

            resultadoListBox.Items.Add("ano = " + ano);
            resultadoListBox.Items.Add(string.Format("O ano {0} é bissexto? {1}.",ano, DateTime.IsLeapYear(ano)? "Sim":"Não"));

            ano = 2016;

            resultadoListBox.Items.Add("ano = " + ano);
            resultadoListBox.Items.Add(string.Format("O ano {0} é bissexto? {1}.", ano, DateTime.IsLeapYear(ano) ? "Sim" : "Não"));

        }
    }
}
