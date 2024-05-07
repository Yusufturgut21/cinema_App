// Gerekli namespace'leri içe aktar
using System;
using System.Windows.Forms;

// Form sýnýfýný içeren ana namespace ve sýnýfý tanýmla
namespace cinema
{
    // Form1 sýnýfýný geniþleten ana form sýnýfý
    public partial class Form1 : Form
    {
        // Rezervasyon bilgileri için iç içe bir sýnýf tanýmla
        public class RezervasyonBilgileri
        {
            // Rezervasyon bilgileri için özellikler
            public string Ad { get; set; }
            public string Telefon { get; set; }
            public string Seans { get; set; }
            public string Film { get; set; }
            public string BiletTuru { get; set; }
            public string Salon { get; set; }
        }

        // Son týklanan düðmeyi takip etmek için özel bir deðiþken
        private Button lastClickedButton;

        // Ana formun kurucu metodu
        public Form1()
        {
            // Form bileþenlerini baþlat
            InitializeComponent();

            // UI'ý baþlatan metodu çaðýr
            InitializeUI();
        }

        // UI elemanlarýný baþlatan metot
        private void InitializeUI()
        {
            // UI elemanlarýný tanýmla
            Label labelAd = new Label();
            Label labelNumara = new Label();
            ComboBox comboFilm = new ComboBox();
            ComboBox comboSalon = new ComboBox();
            ComboBox comboSeans = new ComboBox();
            ComboBox comboBilet = new ComboBox();
            Button btnkd = new Button();
            ListBox listBox1 = new ListBox();

            // UI elemanlarýnýn özelliklerini belirle

            // Olay dinleyicilerini ekle
            btnkd.Click += btnkd_Click;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;

            // button1'den button20'ye kadar olan düðmeleri ekle
            for (int i = 1; i <= 20; i++)
            {
                Button btn = (Button)Controls.Find("button" + i, true)[0];
                btn.Click += button_Click;
            }
        }

        // Düðme týklama olayý için olay iþleyici
        private void button_Click(object sender, EventArgs e)
        {
            // Eðer önceki týklanan düðme varsa rengini kontrol rengi yap
            if (lastClickedButton != null)
            {
                lastClickedButton.BackColor = SystemColors.Control;
            }

            // Týklanan düðmeyi al ve arka plan rengini deðiþtir
            Button clickedButton = sender as Button;
            clickedButton.BackColor = Color.Red;

            // Son týklanan düðmeyi güncelle
            lastClickedButton = clickedButton;

            // Týklanan düðme hakkýnda bilgileri listBox1'e ekle
            listBox1.Items.Add($"Button {clickedButton.Text} ");
        }

        // Rezervasyon düðmesi týklama olayý için olay iþleyici
        private void btnkd_Click(object sender, EventArgs e)
        {
            // Rezervasyon bilgisi nesnesi oluþtur ve kullanýcý giriþi ile doldur
            RezervasyonBilgileri bilgiler = new RezervasyonBilgileri
            {
                Ad = textBox1.Text,
                Telefon = textBox2.Text,
                Seans = comboBox4.SelectedItem?.ToString(),
                Film = comboBox1.SelectedItem?.ToString(),
                BiletTuru = comboBox3.SelectedItem?.ToString(),
                Salon = comboBox2.SelectedItem?.ToString()
            };

            // Rezervasyon bilgisini listBox1'e ekle
            listBox1.Items.Add($"Ad: {bilgiler.Ad}, Numara: {bilgiler.Telefon}, " +
                               $"Seans: {bilgiler.Seans}, Film: {bilgiler.Film}, Bilet Türü: {bilgiler.BiletTuru}, " +
                               $"Salon: {bilgiler.Salon}");
        }

        // listBox1'in seçilen indeks deðiþikliði için olay iþleyici
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // listBox1'deki seçilen indeks deðiþikliði için gerekli mantýðý ekle
        }

        // button21 týklama olayý için olay iþleyici (metin kutularýný temizleme)
        private void button21_Click(object sender, EventArgs e)
        {
            // Metin kutularýný temizle
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
