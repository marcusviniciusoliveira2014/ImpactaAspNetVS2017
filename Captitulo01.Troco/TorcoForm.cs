using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Captitulo01.Troco
{
    public partial class TorcoForm : Form
    {
        public TorcoForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            decimal v_valorcompra   = Convert.ToDecimal(valorCompraTextBox.Text);
            decimal v_valorpago     = Convert.ToDecimal(valorPagoTextBox.Text);
            decimal v_troco =   v_valorpago - v_valorcompra ;

            trocoTextBox.Text = v_troco.ToString("c");

            //ToDo: Refatorar para utilizar estrutura de Repeticao;

            var moedas1 = (int)v_troco;
            //v_troco = v_troco % 1;           
            v_troco %= 1;

            
            var moedas050 = (int)(v_troco / 0.50m);
            v_troco %= 0.5m;

            var moedas025 = (int)(v_troco / 0.25m);
            v_troco %= 0.25m;

            var moedas010 = (int)(v_troco / 0.10m);
            v_troco %= 0.10m;

            var moedas005 = (int)(v_troco / 0.05m);
            v_troco %= 0.05m;

            var moedas001 = (int)(v_troco / 0.01m);
            v_troco %= 0.01m;

            //var moedas001 = (int)v_troco;

            moedasListView.Items[0].Text = moedas1.ToString();
            moedasListView.Items[1].Text = moedas050.ToString();
            moedasListView.Items[2].Text = moedas025.ToString();
            moedasListView.Items[3].Text = moedas010.ToString();
            moedasListView.Items[4].Text = moedas005.ToString();
            moedasListView.Items[5].Text = moedas001.ToString();





        }
    }
}
