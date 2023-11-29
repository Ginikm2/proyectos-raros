using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CalculadoraCheta_1__prototipo_
{
    public partial class Form1 : Form
    {

        private double valor1;
        private double valor2;
        private double resultado;
        private int operacion;
        
       public Form1()
        {
            InitializeComponent();

            // esto para que salga despleao, porque no salia antes xD
            CbConvertir.Items.AddRange(new string[] { "Decimal", "Binario", "Octal", "Hexadecimal" });
            CbConvertir.SelectedIndexChanged += CbConvertir_SelectedIndexChanged;
        }


        private void Txt_TextChanged(object sender, EventArgs e)
        {
            // vacio porque quise meterle que iniciara en 0 y no se me ocurrio como hacer para que si cambiara (porque no lo hacia)
        }

       // logica de los numeros, para que no pase lo mismo que decia antes y se sobrepongan
        private void Btn0_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "0";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Txt.Text = "";
        
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + "9";
        }

        // funfact: el tutorial que vi me ayudo a entender como poner los puntos y porque es buena idea
        // ponerlos en double desde el inicio
        private void button1_Click(object sender, EventArgs e)
        {
            Txt.Text = Txt.Text + ".";
        }
        // la logica se ve en el boton igual, con calma
        private void BtnSuma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt.Text))
            {

                Txt.Text = "+";
            }
            else
            {

                operacion = 1;
                valor1 = Convert.ToDouble(Txt.Text);
                Txt.Text = "";
            }

        }

        // condicionado porque si no, no me dejaba usar el menos en otras operaciones
            private void BtnResta_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(Txt.Text))
                {
                    
                    Txt.Text = "-";
                }
                else
                {
                   
                    operacion = 2;
                    valor1 = Convert.ToDouble(Txt.Text);
                    Txt.Text = "";
                }
            }

        

        private void BtnMultiplicacion_Click(object sender, EventArgs e)
        {
            operacion = 3;
            valor1 = Convert.ToDouble(Txt.Text);
            Txt.Text = "";
        }

        private void BtnDivision_Click(object sender, EventArgs e)
        {
            operacion = 4;
            valor1 = Convert.ToDouble(Txt.Text);
            Txt.Text = "";

        }
        // logica goat
        private void btnIgual_Click(object sender, EventArgs e)
        {
           valor2 = Convert.ToDouble(Txt.Text);
            switch (operacion)
            {
               
                case 1:
                    operacion = 1;
                    resultado = valor1 + valor2;
                    break;
                         case 2:
                    operacion = 2;
                    resultado = valor1 - valor2;
                    break;
                         case 3:
                    operacion = 3;
                    resultado = valor1 * valor2;
                    break;
                         case 4:
                    operacion = 4;
                    resultado = valor1 / valor2;
                    break;
                    
               
                    
            }
            Txt.Text = resultado.ToString();
        }

        // en esto me quebre la cabeza, para luego mientras investigaba viera que era un Convert xD
        /*private void CbConvertir_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = CbConvertir.SelectedItem.ToString();

            if (double.TryParse(Txt.Text, out double valor))
            {
                switch (opcion)
                {
                    case "Decimal":
                        // Convertir a decimal
                        Txt.Text = valor.ToString();
                        break;
                    case "Binario":
                        // Convertir a binario
                        Txt.Text = Convert.ToString(Convert.ToInt32(valor), 2);
                        break;
                    case "Octal":
                        // Convertir a octal
                        Txt.Text = Convert.ToString(Convert.ToInt32(valor), 8);
                        break;
                    case "Hexadecimal":
                        // Convertir a hexadecimal
                        Txt.Text = Convert.ToString(Convert.ToInt32(valor), 16).ToUpper();
                        break;
                }
            }
            else
            // en mi computadora sale 2 veces este error, estoy intentando arreglarlo
            {
                MessageBox.Show("Ingrese un número válido en el sistema decimal.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        // por si acaso, sale el error 2 veces con el anterior 
        private void CbConvertir_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            CbConvertir.SelectedIndexChanged -= CbConvertir_SelectedIndexChanged;

            string opcion = CbConvertir.SelectedItem.ToString();

            if (double.TryParse(Txt.Text, out double valor))
            {
                switch (opcion)
                {
                    case "Decimal":
                        // Convertir a decimal
                        Txt.Text = valor.ToString();
                        break;
                    case "Binario":
                        // Convertir a binario
                        if (valor % 1 == 0) // Verifica si es un número entero
                        {
                            Txt.Text = Convert.ToString((int)valor, 2);
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un número entero en binario.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Hexadecimal":
                        // Convertir a hexadecimal
                        Txt.Text = BitConverter.DoubleToInt64Bits(valor).ToString("X");
                        break;
                    case "Octal":
                        // Convertir a octal
                        if (valor % 1 == 0) // Verifica si es un número entero
                        {
                            Txt.Text = Convert.ToString((int)valor, 8);
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un número entero en octal.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número válido en el sistema decimal.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Volver a activar el evento
            CbConvertir.SelectedIndexChanged += CbConvertir_SelectedIndexChanged;
        }





    }
}


     
        
    











        

