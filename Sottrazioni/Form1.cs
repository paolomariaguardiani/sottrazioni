using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

/*
 * Authore: Paolo Maria Guardiani
 * 
 * DEO GRATIAS!
 * 
 * Ho trovato i suoni su freesound.org
 * Ho trovato le immagini su clip-art.library.com
 */

namespace Sottrazioni
{
    public partial class Form1 : Form
    {
        private SoundPlayer soundIntro, soundClick, soundCoin, soundClickSoft, soundClickSpecial, soundError;

        public Form1()
        {
            InitializeComponent();
            soundIntro = new SoundPlayer(Properties.Resources.haydn_divertimento_c_hob_xvi_10);
            soundCoin = new SoundPlayer(Properties.Resources.coin);
            soundClick = new SoundPlayer(Properties.Resources.button_click);
            soundClickSoft = new SoundPlayer(Properties.Resources.button_click_soft);
            soundClickSpecial = new SoundPlayer(Properties.Resources.button_special);
            soundError = new SoundPlayer(Properties.Resources.sound_error);

            // Faccio suonare l'introduzione di Haydn (divertimento in Do - Hob XVI-10)
            soundIntro.Play();
        }

        int counter1, counter2, counter3, counter4, counter5,
            counter6, counter7, counter8, counter9, counter10;

        int minuendo;
        int sottraendo;
        int risultato;
        int punteggio = 0;


        Random randomNumber = new Random();

        private void generaSottrazione(int min, int max)
        {
            int num1 = randomNumber.Next(min, max);
            int num2 = randomNumber.Next(min, max);
            // trovo il maggiore e il minore dei due numeri casuali
            // Thanks to: https://www.developersumo.com/2021/06/24/come-trovare-il-maggiore-tra-due-numeri-in-c/
            minuendo = Math.Max(num1, num2);
            sottraendo = Math.Min(num1, num2);
            risultato = minuendo - sottraendo;
            lblDomanda.Text = $"{minuendo} - {sottraendo} =";
        }
 
        private void btnNew_Click(object sender, EventArgs e)
        {
            soundClickSoft.Play();
            txtRisposta.Text = "";
            generaSottrazione(1, 10);
            controllaLed(minuendo);
            // Nascondo il label risposta
            lblRisposta.Visible = false;
            // Riabilito il pulsante controlla, nel caso fosse disabilitato
            btnControlla.Enabled = true;
        }

        private void btn_num_0_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text = "0";
        }

        private void btn_num_1_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text = "1";
        }

        private void btn_num_2_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text = "2";
        }

        private void btn_num_3_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text = "3";
        }

        private void btn_num_4_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text= "4";
        }

        private void btn_num_5_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text = "5";
        }

        private void btn_num_6_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text = "6";
        }

        private void btn_num_7_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text = "7";
        }

        private void btn_num_8_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text = "8";
        }

        private void btn_num_9_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            txtRisposta.Text = "9";
        }

        private void btnControlla_Click(object sender, EventArgs e)
        {
            soundClickSpecial.Play();
            try
            {
                int inputUtente = int.Parse(txtRisposta.Text);

                if (inputUtente == risultato)
                {
                    soundCoin.Play();
                    punteggio++;
                    lblPunteggio.Text = $"PUNTEGGIO = {punteggio}";
                    lblRisposta.Visible = true;
                    // Thanks to: https://stackoverflow.com/questions/15906090/change-color-of-label-in-c-sharp
                    lblRisposta.ForeColor = Color.Green;
                    lblRisposta.Text = $"CORRETTO!";
                    // Disabilito il pulsante controlla per non guadagnare punti gratis
                    // btnControlla.Location = new Point(200, 262); Questo serve per spostare il bottone!!!
                    btnControlla.Enabled = false;
                }
                else
                {
                    soundError.Play();
                    lblRisposta.Visible = true;
                    lblRisposta.ForeColor = Color.Red;
                    lblRisposta.Text = $"SBAGLIATO,\nIL RISULTATO E' {risultato}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ATTENZIONE, DEVI INSERIRE SOLAMENTE NUMERI INTERI!", "ERRORE");
                txtRisposta.Text = ""; 
            }
        }

        private void controllaLed(int numero)
        {
            // Accendo prima tutti i led
            btn1.Image = Properties.Resources.bottone_on_piccolo;
            btn2.Image = Properties.Resources.bottone_on_piccolo;
            btn3.Image = Properties.Resources.bottone_on_piccolo;
            btn4.Image = Properties.Resources.bottone_on_piccolo;
            btn5.Image = Properties.Resources.bottone_on_piccolo;
            btn6.Image = Properties.Resources.bottone_on_piccolo;
            btn7.Image = Properties.Resources.bottone_on_piccolo;
            btn8.Image = Properties.Resources.bottone_on_piccolo;
            btn9.Image = Properties.Resources.bottone_on_piccolo;
            btn10.Image = Properties.Resources.bottone_on_piccolo;

            // Resetto tutti i counter nuovamente a 0
            counter1 = 0;
            counter2 = 0; 
            counter3 = 0;
            counter4 = 0;
            counter5 = 0;
            counter6 = 0;
            counter7 = 0;
            counter8 = 0;
            counter9 = 0;
            counter10 = 0;

            // Dopo nascondo quelli che non servono per i calcoli
            if (numero == 1)
            {
                btn1.Visible = true;
                btn2.Visible = false;
                btn3.Visible = false;
                btn4.Visible = false;
                btn5.Visible = false;
                btn6.Visible = false;
                btn7.Visible = false;
                btn8.Visible = false;
                btn9.Visible = false;
                btn10.Visible = false;
            }
            else if (numero == 2)
            {
                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = false;
                btn4.Visible = false;
                btn5.Visible = false;
                btn6.Visible = false;
                btn7.Visible = false;
                btn8.Visible = false;
                btn9.Visible = false;
                btn10.Visible = false;
            }
            else if (numero == 3)
            {
                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = true;
                btn4.Visible = false;
                btn5.Visible = false;
                btn6.Visible = false;
                btn7.Visible = false;
                btn8.Visible = false;
                btn9.Visible = false;
                btn10.Visible = false;
            }
            else if (numero == 4)
            {
                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = true;
                btn4.Visible = true;
                btn5.Visible = false;
                btn6.Visible = false;
                btn7.Visible = false;
                btn8.Visible = false;
                btn9.Visible = false;
                btn10.Visible = false;
            }
            else if (numero == 5)
            {
                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = true;
                btn4.Visible = true;
                btn5.Visible = true;
                btn6.Visible = false;
                btn7.Visible = false;
                btn8.Visible = false;
                btn9.Visible = false;
                btn10.Visible = false;
            }
            else if (numero == 6)
            {
                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = true;
                btn4.Visible = true;
                btn5.Visible = true;
                btn6.Visible = true;
                btn7.Visible = false;
                btn8.Visible = false;
                btn9.Visible = false;
                btn10.Visible = false;
            }
            else if (numero == 7)
            {
                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = true;
                btn4.Visible = true;
                btn5.Visible = true;
                btn6.Visible = true;
                btn7.Visible = true;
                btn8.Visible = false;
                btn9.Visible = false;
                btn10.Visible = false;
            }
            else if (numero == 8)
            {
                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = true;
                btn4.Visible = true;
                btn5.Visible = true;
                btn6.Visible = true;
                btn7.Visible = true;
                btn8.Visible = true;
                btn9.Visible = false;
                btn10.Visible = false;
            }
            else if (numero == 9)
            {
                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = true;
                btn4.Visible = true;
                btn5.Visible = true;
                btn6.Visible = true;
                btn7.Visible = true;
                btn8.Visible = true;
                btn9.Visible = true;
                btn10.Visible = false;
            }
            else if (numero == 10)
            {
                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = true;
                btn4.Visible = true;
                btn5.Visible = true;
                btn6.Visible = true;
                btn7.Visible = true;
                btn8.Visible = true;
                btn9.Visible = true;
                btn10.Visible = true;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            // Thanks to: https://youtu.be/9ZM2brRSnVs
            counter1++;
            if (counter1 == 1)
            {
                btn1.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn1.Image = Properties.Resources.bottone_on_piccolo;
                counter1 = 0;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            counter2++;
            if (counter2 == 1)
            {
                btn2.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn2.Image = Properties.Resources.bottone_on_piccolo;
                counter2 = 0;
            }
        }

        private void bnt3_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            counter3++;
            if (counter3 == 1)
            {
                btn3.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn3.Image = Properties.Resources.bottone_on_piccolo;
                counter3 = 0;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            counter4++;
            if (counter4 == 1)
            {
                btn4.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn4.Image = Properties.Resources.bottone_on_piccolo;
                counter4 = 0;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            counter5++;
            if (counter5 == 1)
            {
                btn5.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn5.Image = Properties.Resources.bottone_on_piccolo;
                counter5 = 0;
            }

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            counter6++;
            if (counter6 == 1)
            {
                btn6.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn6.Image = Properties.Resources.bottone_on_piccolo;
                counter6 = 0;
            }
        }
        
        private void btn7_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            counter7++;
            if (counter7 == 1)
            {
                btn7.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn7.Image = Properties.Resources.bottone_on_piccolo;
                counter7 = 0;
            }
        }
                
        private void btn8_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            counter8++;
            if (counter8 == 1)
            {
                btn8.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn8.Image = Properties.Resources.bottone_on_piccolo;
                counter8 = 0;
            }
        }
                
        private void btn9_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            counter9++;
            if (counter9 == 1)
            {
                btn9.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn9.Image = Properties.Resources.bottone_on_piccolo;
                counter9 = 0;
            }
        }
                
        private void btn10_Click(object sender, EventArgs e)
        {
            soundClick.Play();
            counter10++;
            if (counter10 == 1)
            {
                btn10.Image = Properties.Resources.bottone_off_piccolo;
            }
            else
            {
                btn10.Image = Properties.Resources.bottone_on_piccolo;
                counter10 = 0;
            }
        }
    }
}
