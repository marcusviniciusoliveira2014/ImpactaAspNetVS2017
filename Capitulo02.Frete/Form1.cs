using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitulo02.Frete
{
    public partial class FretesForm : Form
    {
        public FretesForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            if (Validarformulario())
            {
                Calcular();
            }
        }

        private void Calcular()
        {
            var v_percentual = 0m;
            var v_valor = Convert.ToDecimal(ValorTextBox.Text);

            //ToDo:exemplificar o novo Switch c#7.0
            switch (ufComboBox.Text.ToUpper())
            {
                case "SP": v_percentual = 0.20m; break;
                case "AM": v_percentual = 0.60m; break;
                case "MG": v_percentual = 0.35m; break;
                case "RJ": v_percentual = 0.3m; break;
                default: v_percentual = 0.75m; break;
                    //  case null: v_percentual = 0.75m; break; so no C# 7.0
            }


            freteTextBox.Text = v_percentual.ToString("p2");
            totalTextBox.Text = ((1 + v_percentual) * v_valor).ToString("c");  



        }

        private bool Validarformulario()
        {

            if (clienteTextBox.Text == string.Empty)
            {
                MessageBox.Show("Nome do Cliente não foi Informada...!",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (ufComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Não foi selecionada a UF...!",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (ValorTextBox.Text == string.Empty)
            {
                MessageBox.Show("Campo Valor nao foi informado...!",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    Convert.ToDecimal(ValorTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("Valor informado invalido..!",
                        "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            return true;
        }
    }
}
