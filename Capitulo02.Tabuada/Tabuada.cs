using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitulo02.Tabuada
{
    public partial class TabuadaForm : Form
    {
        public TabuadaForm()
        {
            InitializeComponent();
        }

        private void tabuadaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b' || e.KeyChar == '\r')
            {
                if (e.KeyChar == 13 && tabuadaTextBox.Text != string.Empty)
                {

                    tabuadaListBox.Items.Clear();
                    Calcular();
                }

            }
            else
            {
                e.KeyChar = '\0';

            }
        }

        private void Calcular()
        {
            var v_tabuada = Convert.ToInt32(tabuadaTextBox.Text);

            for (int i = 0; i < 11; i++)
            {
               // tabuadaListBox.Items.Add(v_tabuada + " x " + i + " = " + (v_tabuada * i).ToString("#,##0"));
                tabuadaListBox.Items.Add($"{v_tabuada}  * {i} = {v_tabuada * i}");

                tabuadaTextBox.Focus();
                tabuadaTextBox.SelectAll();
            }


        }
    }
}
