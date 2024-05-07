// Gerekli namespace'leri i�e aktar
using System;
using System.Windows.Forms;

// Form s�n�f�n� i�eren ana namespace ve s�n�f� tan�mla
namespace cinema
{
    // Form1 s�n�f�n� geni�leten ana form s�n�f�
    public partial class Form1 : Form
    {
        // Rezervasyon bilgileri i�in i� i�e bir s�n�f tan�mla
        public class RezervasyonBilgileri
        {
            // Rezervasyon bilgileri i�in �zellikler
            public string Ad { get; set; }
            public string Telefon { get; set; }
            public string Seans { get; set; }
            public string Film { get; set; }
            public string BiletTuru { get; set; }
            public string Salon { get; set; }
        }

        // Son t�klanan d��meyi takip etmek i�in �zel bir de�i�ken
        private Button lastClickedButton;

        // Ana formun kurucu metodu
        public Form1()
        {
            // Form bile�enlerini ba�lat
            InitializeComponent();

            // UI'� ba�latan metodu �a��r
            InitializeUI();
        }

        // UI elemanlar�n� ba�latan metot
        private void InitializeUI()
        {
            // UI elemanlar�n� tan�mla
            Label labelAd = new Label();
            Label labelNumara = new Label();
            ComboBox comboFilm = new ComboBox();
            ComboBox comboSalon = new ComboBox();
            ComboBox comboSeans = new ComboBox();
            ComboBox comboBilet = new ComboBox();
            Button btnkd = new Button();
            ListBox listBox1 = new ListBox();

            // UI elemanlar�n�n �zelliklerini belirle

            // Olay dinleyicilerini ekle
            btnkd.Click += btnkd_Click;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;

            // button1'den button20'ye kadar olan d��meleri ekle
            for (int i = 1; i <= 20; i++)
            {
                Button btn = (Button)Controls.Find("button" + i, true)[0];
                btn.Click += button_Click;
            }
        }

        // D��me t�klama olay� i�in olay i�leyici
        private void button_Click(object sender, EventArgs e)
        {
            // E�er �nceki t�klanan d��me varsa rengini kontrol rengi yap
            if (lastClickedButton != null)
            {
                lastClickedButton.BackColor = SystemColors.Control;
            }

            // T�klanan d��meyi al ve arka plan rengini de�i�tir
            Button clickedButton = sender as Button;
            clickedButton.BackColor = Color.Red;

            // Son t�klanan d��meyi g�ncelle
            lastClickedButton = clickedButton;

            // T�klanan d��me hakk�nda bilgileri listBox1'e ekle
            listBox1.Items.Add($"Button {clickedButton.Text} ");
        }

        // Rezervasyon d��mesi t�klama olay� i�in olay i�leyici
        private void btnkd_Click(object sender, EventArgs e)
        {
            // Rezervasyon bilgisi nesnesi olu�tur ve kullan�c� giri�i ile doldur
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
                               $"Seans: {bilgiler.Seans}, Film: {bilgiler.Film}, Bilet T�r�: {bilgiler.BiletTuru}, " +
                               $"Salon: {bilgiler.Salon}");
        }

        // listBox1'in se�ilen indeks de�i�ikli�i i�in olay i�leyici
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // listBox1'deki se�ilen indeks de�i�ikli�i i�in gerekli mant��� ekle
        }

        // button21 t�klama olay� i�in olay i�leyici (metin kutular�n� temizleme)
        private void button21_Click(object sender, EventArgs e)
        {
            // Metin kutular�n� temizle
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
