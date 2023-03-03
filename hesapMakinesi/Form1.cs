using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hesapMakinesi
{
    public partial class Form1 : Form
    {
        bool islemDurum=false;
        double sonuc = 0;
        string islem = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rakamlar(object sender, EventArgs e)
        {
            if (txtSonuc.Text == "0" || islemDurum)
                txtSonuc.Clear();

            islemDurum = false;

            Button button = (Button)sender;
            /* Sender parametresi: Click() fonksiyonu içerisinde yer alıyor.
             * Kullanıcı sürekli bir nesneye yada objeye tıkladığında işlem yapıyor.
             * Her buton için ayrı ayrı kod yazmamak için Click olayında bu işlemi yapıyoruz.
             */
            txtSonuc.Text += button.Text;// Alınan değeri txtSonuc ekranına yazdırıyor.
        }

        private void islemler(object sender, EventArgs e)
        {
            islemDurum = true;
            Button button = (Button)sender; // Hangi butona basıldıysa o butonun basılan değerini almak için kullanıyoruz.
            string yeniIslem = button.Text;//Eski islem bilgisini tutmak için.Eski değerini yeni değerine aktarmak için kullanıyoruz.
                                           //Yani yeni islem bilgisini tutmak için yapıyoruz.(Bu işlem bir önceki islemi gerçekleştiriyor.)

            lblSonuc.Text = lblSonuc.Text + " " + txtSonuc.Text + " " + yeniIslem;

            switch (islem)
            {
                case "+": txtSonuc.Text = (sonuc + Double.Parse(txtSonuc.Text)).ToString(); break;
                case "-": txtSonuc.Text = (sonuc - Double.Parse(txtSonuc.Text)).ToString(); break;
                case "*": txtSonuc.Text = (sonuc * Double.Parse(txtSonuc.Text)).ToString(); break;
                case "/": txtSonuc.Text = (sonuc / Double.Parse(txtSonuc.Text)).ToString(); break;
            }

            sonuc = double.Parse(txtSonuc.Text);
            txtSonuc.Text = sonuc.ToString();
            islem = yeniIslem;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtSonuc.Text = "0";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtSonuc.Text = "0";
            lblSonuc.Text = "";
            islem = "";
            sonuc = 0;
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            lblSonuc.Text = "";//İşlem sonucunun labela yansıtılması.
            islemDurum = true;

            switch (islem)
            {
                case "+": txtSonuc.Text = (sonuc + Double.Parse(txtSonuc.Text)).ToString(); break;
                case "-": txtSonuc.Text = (sonuc - Double.Parse(txtSonuc.Text)).ToString(); break;
                case "*": txtSonuc.Text = (sonuc * Double.Parse(txtSonuc.Text)).ToString(); break;
                case "/": txtSonuc.Text = (sonuc / Double.Parse(txtSonuc.Text)).ToString(); break;
            }

            sonuc = double.Parse(txtSonuc.Text);
            txtSonuc.Text = sonuc.ToString();
            islem = ""; // Hafızadaki bilgiyi temizliyor.
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (txtSonuc.Text == "0")//İlk başta sıfır varsa
            {
                txtSonuc.Text = "0";
            }
            else if (islemDurum)// Herhangi bir işlem yapılmışmı onun kontrolü yapıyoruz.Amaç tekrar tekrar sıfıra basmayı engellemek.

            {
                txtSonuc.Text = "0";
            }

            if (!txtSonuc.Text.Contains(","))
            {
                txtSonuc.Text += ",";
            }
            islemDurum = false;
        }
    }
}
