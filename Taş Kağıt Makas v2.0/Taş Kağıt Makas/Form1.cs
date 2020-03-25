using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taş_Kağıt_Makas
{
    public partial class Form1 : Form
    {
        #region Tanımlamalar

        Random r = new Random(); // rasgetgele sayı üretim için

        int otomatik, skor1=0, skor2=0; /* otomatik pc nin rastgele seçtiği sayıyı tutacak.
                                     * skor1 senin skorunu skor2 pc nin skorunu tutacak. */

        int tur; //  oynanmak istenen  tur sayısını tutacak

        int sayac = 0; // o an oynanan tur sayısını tutacak

        int sayac2 = 0; // Yeni oyun ve oyuna başla butonunun oyun içinde kodsal işlev sırasını belirlemek için.

        #endregion

        #region Metodlar

        public void temizle()
        {
            skor1 = 0;
            skor2 = 0;
            tur = 0;
            sayac = 0;
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            label7.Text = "";
            groupboxgizle();
          
        }

        public void grobboxgörünür()
        {
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
        }

        public void groupboxgizle()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            temizle();
            button4.Text = "Oyuna Başla";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // taş butonuna tıklandığında

            #region if 1
            if (sayac < tur) /* ilk başta sayacı 0 dan başlattığım için küçük dedim
                              * sayacı 1 den başlatsa idim <= yapmam gerekirdi. */
            {
                #region panelrengi
                
                //tıklanan butonun arkaplandaki panelini siyah yaparak seçimimizi belirgin hale getirdik.

                panel2.BackColor = SystemColors.Highlight; 
                panel3.BackColor = SystemColors.Highlight;
                panel1.BackColor = Color.Yellow;

                #endregion

                

                sayac++; // oynan tur sayısını tutan sayacı bir artırdık.
                label6.Text = sayac.ToString();
                otomatik = r.Next(3); // 3 tane seçenek olduğu için 0 ile 3 arasında rastgele değer aldık.

                #region if 2
                if (otomatik == 0) // bilgisayarın seçtiği sayı 0 ise bu taş nesnesine denk geliyor.
                {
                    pictureBox1.Image = button1.BackgroundImage;
                    label7.Text = "İki seçimde aynı";
                }

                else if (otomatik == 1) // bilgisayarın seçtiği sayı 1 ise bu  kağıt nesnesine denk geliyor.
                {
                    pictureBox1.Image = button2.BackgroundImage;
                    label7.Text = "Kağıt taşı sarar";
                    skor2++;
                    label5.Text = skor2.ToString();
                
                
                }

                else if (otomatik == 2) // bilgisayarın seçtiği sayı 2 ise bu makas nesnesine denk geliyor.
                {
                    pictureBox1.Image = button3.BackgroundImage;
                    label7.Text = "Taş makası kırar";
                    skor1++;
                    label4.Text = skor1.ToString();

                }

                #endregion
            }
            #endregion

            #region else

           if(sayac==tur)
            {
                label6.Text = "Oyun Bitti";
                if (skor1 == skor2)
                    MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Berabere kaldınız");
                else if (skor1 > skor2)
                    MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Kazandın mübarek olsun.");
                else if (skor1 < skor2)
                    MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Olmadı hacı bir dahaki sefere artık.");
            }

            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* comboboxta seçim yapıldığı anda yapılacak işlemler */

            tur = int.Parse(comboBox1.SelectedItem.ToString()); // seçilen değeri tur değişkenine atadık.  
      
       }

        private void button2_Click(object sender, EventArgs e)
        {
            // kağıt tuşuna tıklandığında

            #region if 1
            if (sayac < tur)
            {
                
                panel1.BackColor = SystemColors.Highlight;
                panel3.BackColor = SystemColors.Highlight;
                panel2.BackColor = Color.Yellow;

                sayac++;
                label6.Text = sayac.ToString();
                otomatik = r.Next(3); // 3 tane seçenek olduğu için 0 ile 3 arasında rastgele değer aldık.
                #region if 2
                if (otomatik == 0)
                {
                    pictureBox1.Image = button1.BackgroundImage;
                    label7.Text = "Bravo kağıt taşı sarar";
                    skor1++;
                    label4.Text = skor1.ToString();
                }

                else if (otomatik == 1)
                {
                    pictureBox1.Image = button2.BackgroundImage;
                    label7.Text = "iki seçimde aynı"; 
                }

                else if (otomatik == 2)
                {
                    pictureBox1.Image = button3.BackgroundImage;
                    label7.Text = ":( Makas kağıdı kese";
                    skor2++;
                    label5.Text = skor2.ToString();

                }

                #endregion
            }
            #endregion

            #region else
            if (sayac == tur)
            {
                label6.Text = "Oyun Bitti";
                if (skor1 == skor2)
                    MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Berabere kaldınız");
                else if (skor1 > skor2)
                    MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Kazandın mübarek olsun.");
                else if (skor1 < skor2)
                    MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Olmadı hacı bir dahaki sefere artık.");
            }

            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // makas tuşuna tıklandığında

            #region if 1
            if (sayac < tur)
            {
               
                panel1.BackColor = SystemColors.Highlight;
                panel2.BackColor = SystemColors.Highlight;
                panel3.BackColor = Color.Yellow;
                

                sayac++;
                label6.Text = sayac.ToString();
                otomatik = r.Next(3); // 3 tane seçenek olduğu için 0 ile 3 arasında rastgele değer aldık.
               
                #region if 2

                if (otomatik == 0)
                {
                    pictureBox1.Image = button1.BackgroundImage;
                    label7.Text = "Taş Makası kırar";
                    skor2++;
                    label5.Text = skor2.ToString();
                }

                else if (otomatik == 1)
                {
                    pictureBox1.Image = button2.BackgroundImage;
                    label7.Text = "Makas kağıdı keser";
                    skor1++;
                    label4.Text = skor1.ToString();
                }

                else if (otomatik == 2)
                {
                    pictureBox1.Image = button3.BackgroundImage;
                    label7.Text = "İki seçimde aynı";
                }

                #endregion
            }
            #endregion

            #region else
            if (sayac == tur)
            {
                label6.Text = "Oyun Bitti";
                if (skor1 == skor2)
                    MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Berabere kaldınız");
                else if (skor1 > skor2)
                    MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Kazandın mübarek olsun.");
                else if (skor1 < skor2)
                    MessageBox.Show("Sen=" + skor1 + "\n" + "Bilgisayar=" + skor2 + "\n" + "Olmadı hacı bir dahaki sefere artık.");
            }
            #endregion
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (sayac2%2==0)
            {
                if (tur==0)
                {
                    MessageBox.Show("Oynanacak tur sayısını seçmediniz. Lütfen öncelikle tur sayısını seçiniz");
                }

                else
                {
                    grobboxgörünür();                    
                    
                    button4.Text = "Yeni Oyun";

                    comboBox1.Enabled = false;
                    sayac2++;
                }
               
            }

            else
            {
                temizle();
                button4.Text = "Oyuna Başla";
                comboBox1.Enabled = true;
                sayac2++;

            }

           

        }
    }
}
