using System;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using Newtonsoft.Json;

namespace mapc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        GMapOverlay routeOverlay; // harita üzerinde rota çizmek için

        private void Form1_Resize(object sender, EventArgs e)
        {
            int solPanelWidth = 300;
            int sagPanelWidth = 550;

            panel_sol.Width = solPanelWidth;
            panel_sag.Width = sagPanelWidth;

            panel_sol.Height = this.ClientSize.Height;
            panel_sag.Height = this.ClientSize.Height;

            panel_harita.Width = this.ClientSize.Width - (solPanelWidth + sagPanelWidth);
            panel_harita.Height = this.ClientSize.Height;
            panel_harita.Left = solPanelWidth;
            panel_harita.Top = 0;

            // harita panelin içini tamamen kaplasın
            gMapControl1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gMapControl1.Parent = panel_harita; // Haritayı panele bağla

            panel_sol.Dock = DockStyle.Left;
            panel_sag.Dock = DockStyle.Right;

            listBox1.Left = 0;
            listBox1.Width = panel_sag.Width;
            listBox1.Top = dateTimePicker1.Bottom + 45;
            listBox1.Height = panel_sag.Height;

            sola_dondur.Location = new Point(3, 820);
            saga_dondur.Location = new Point(3, 700);
            btn_vector_map.Location = new Point(3, 120);
            btn_hibrit_map.Location = new Point(3, 220);
            btn_uydu_map.Location = new Point(3, 320);
            label1.Location = new Point(3, 50);
            label2.Location = new Point(3, 420);

            this.Resize += new EventHandler(Form1_Resize);
            Form1_Resize(this, EventArgs.Empty); // başlangıç düzenlemelerini sağlar

            //baslangıc konumu default dursun
            double default_lat, default_lon;
            default_lat = 40.77788;
            default_lon = 29.94991;

            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl1.Position = new PointLatLng(default_lat, default_lon);
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 22;
            gMapControl1.Zoom = 18; // baslangıczoon-mseviyesş

            GMapOverlay o = new GMapOverlay("o");
            GMapMarker m = new GMarkerGoogle(new PointLatLng(default_lat, default_lon), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);

            gMapControl1.Overlays.Add(o);
            o.Markers.Add(m);
            gMapControl1.Invalidate();
            gMapControl1.Update();
            m.ToolTipMode = MarkerTooltipMode.Always;

            // JSON verisini oku ve haritaya ekle
            LoadBusStops();
        }

        private List<Durak> duraklar = new List<Durak>(); // Durak" sınıfından durakları saklamak için liste 

        private void LoadBusStops()  // verileri jsondan cekmece
        {
            try
            {
                string jsonFilePath = @"C:\Users\User\OneDrive\Masaüstü\prolab\mapc\veri.json";
                string jsonData = File.ReadAllText(jsonFilePath);
                jsonVerisi veri = JsonConvert.DeserializeObject<jsonVerisi>(jsonData);
                // durakları listeye ekle
                duraklar = veri.duraklar;

                // yeni bir overlay oluştur 
                GMapOverlay overlay = new GMapOverlay("duraklar");
                listBox1.Items.Add("Güncel Duraklar");
                foreach (var durak in veri.duraklar)
                {
                    PointLatLng point = new PointLatLng(durak.lat, durak.lon);

                    // durak türüne göre ikon seç
                    GMarkerGoogle marker;

                    listBox1.Items.Add($"Durak: {durak.name}");
                    if (durak.nextStops != null && durak.nextStops.Count > 0)
                    {
                        listBox1.Items.Add("  -> Sonraki Duraklar:");
                        foreach (var next in durak.nextStops)
                        {
                            listBox1.Items.Add($"     - ID: {next.stopId}");
                            listBox1.Items.Add($"     -Mesafe: {next.mesafe} km");
                            listBox1.Items.Add($"     -Süre: {next.sure} dk");
                            listBox1.Items.Add($"     -Mesafe: {next.ucret} TL");
                        }
                    }
                    else
                    {
                        listBox1.Items.Add("  -> Sonraki durak bilgisi yok.");
                    }

                    if (durak.transfer != null)
                    {
                        listBox1.Items.Add("  -> Transfer Noktası:");
                        listBox1.Items.Add($"     - Hedef Durak ID: {durak.transfer.transferStopId}");
                        listBox1.Items.Add($"     - Süre: {durak.transfer.transferSure} dk");
                        listBox1.Items.Add($"     - Ücret: {durak.transfer.transferUcret} TL");
                    }

                    if (durak.type == "bus")
                    {
                        Bitmap busIcon = new Bitmap(@"C:\Users\User\OneDrive\Masaüstü\prolab\mapc\bus.png");
                        busIcon = new Bitmap(busIcon, new Size(32, 32));
                        marker = new GMarkerGoogle(point, busIcon);
                    }
                    else if (durak.type == "tram")
                    {
                        Bitmap tramIcon = new Bitmap(@"C:\Users\User\OneDrive\Masaüstü\prolab\mapc\tramvay.png");
                        tramIcon = new Bitmap(tramIcon, new Size(32, 32));
                        marker = new GMarkerGoogle(point, tramIcon);
                    }
                    else
                    {
                        marker = new GMarkerGoogle(point, GMarkerGoogleType.gray_small); //default
                    }
                    marker.ToolTipText = durak.name;
                    marker.ToolTipMode = MarkerTooltipMode.Always;

                    overlay.Markers.Add(marker);
                }
                gMapControl1.Overlays.Add(overlay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void bulundugu_konum_Click(object sender, EventArgs e)
        {
            string bulundugu_enlem_text = bulundugu_enlem.Text;
            string bulundugu_boylam_text = bulundugu_boylam.Text;
            try
            {
                double enlem = Convert.ToDouble(bulundugu_enlem_text); // text oldukları içn
                double boylam = Convert.ToDouble(bulundugu_boylam_text);

                gMapControl1.Position = new PointLatLng(enlem, boylam);

                GMapOverlay o = new GMapOverlay("o");
                GMapMarker m = new GMarkerGoogle(new PointLatLng(enlem, boylam), GMarkerGoogleType.purple_small);

                // Daha önce eklenmiş olan kullanıcının konum overlay'ini temizle
                var mevcutKonumOverlay = gMapControl1.Overlays.FirstOrDefault(o => o.Id == "konum");

                if (mevcutKonumOverlay != null)
                {
                    gMapControl1.Overlays.Remove(mevcutKonumOverlay);
                }

                GMapOverlay konumOverlay = new GMapOverlay("konum");
                GMapMarker konumMarker = new GMarkerGoogle(new PointLatLng(enlem, boylam), GMarkerGoogleType.purple_small);

                konumMarker.ToolTipText = "Şu an buradasınız";
                konumMarker.ToolTipMode = MarkerTooltipMode.Always;

                konumOverlay.Markers.Add(konumMarker);
                gMapControl1.Overlays.Add(konumOverlay);

                gMapControl1.Refresh();
            }
            catch (FormatException)
            {
                MessageBox.Show("Geçerli bir enlem ve boylam giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void uygun_rotayi_bul_Click(object sender, EventArgs e)
        {
            // YOLCU.CS DEN 
            Yolcu secilenYolcu = null;
            if (comboBox1.SelectedItem.ToString() == "Normal (Genel)")
            {
                secilenYolcu = new Genel();
            }
            else if (comboBox1.SelectedItem.ToString() == "Öğrenci")
            {
                secilenYolcu = new Ogrenci();
            }
            else if (comboBox1.SelectedItem.ToString() == "Öğretmen")
            {
                secilenYolcu = new Ogretmen();
            }
            else if (comboBox1.SelectedItem.ToString() == "+65 Yaş Üzeri")
            {
                secilenYolcu = new Yasli();
            }

            // ÖDEME SEKLİ SECMECE
            IOdeme secilenOdeme = null;
            if (comboBox2.SelectedItem.ToString() == "Nakit")
            {
                secilenOdeme = new Nakit();
                //  listBox1.Items.Add($"Ödeme Bilgisi: {secilenOdeme.OdemeYap()}");
            }
            else if (comboBox2.SelectedItem.ToString() == "Kredi Kartı")
            {
                secilenOdeme = new KrediKarti();
            }
            else if (comboBox2.SelectedItem.ToString() == "KentKart")
            {
                secilenOdeme = new Kentkart();
            }

            //girdiğimiz enlem ve boylam değerlerini doubşe sayıya çevir
            if(!double.TryParse(bulundugu_enlem.Text, out double baslangicLat) ||
                !double.TryParse(bulundugu_boylam.Text, out double baslangicLon) ||
                !double.TryParse(hedef_enlem.Text, out double varisLat) ||
                !double.TryParse(hedef_boylam.Text, out double varisLon))
            {
                MessageBox.Show("Lütfen geçerli enlem ve boylam değerleri girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<(List<string>, double, double)> tumRotalar;  // muhtemel rotalarımız
            string rotaBilgisi = new RotaHesaplayici().EnUygunRotaBul(
                baslangicLat, baslangicLon, varisLat, varisLon, duraklar, secilenYolcu, out tumRotalar
            );
            MessageBox.Show(rotaBilgisi);

            var enIyiRota = tumRotalar.OrderBy(r => r.Item2).ThenBy(r => r.Item3).First(); //ilk once item2(sure) bakar sonra ucret

            // sadece yurume giderse yani toplam uzaklık km
            double mesafe = UzaklikHesaplayici.MesafeHesapla(baslangicLat, baslangicLon, varisLat, varisLon);

            Durak enYakinBaslangicDurak = RotaHesaplayici.EnYakinDurakBul(baslangicLat, baslangicLon, duraklar);

            //varış noktası için başlangıç durağı ile aynı olmayan en yakın durağı bul
            Durak enYakinVarisDurak = duraklar
                .Where(d => d.id != enYakinBaslangicDurak.id) // başlangıc durağından farklı olmalı
                .OrderBy(d => UzaklikHesaplayici.MesafeHesapla(varisLat, varisLon, d.lat, d.lon)) //en yakına göre sıralama
                .FirstOrDefault(); //En yakını almak için

            double baslangicDurakMesafe = UzaklikHesaplayici.MesafeHesapla(
                baslangicLat, baslangicLon, enYakinBaslangicDurak.lat, enYakinBaslangicDurak.lon);

            double varisDurakMesafe = UzaklikHesaplayici.MesafeHesapla(
                varisLat, varisLon, enYakinVarisDurak.lat, enYakinVarisDurak.lon);

            double taksiAcilisUcreti = 10.0;
            double kmBasiUcret = 4.0;
            double taksiUcreti = 0;

            listBox1.Items.Clear();

            listBox1.Items.Add($"Mevcut konum: {baslangicLat}, {baslangicLon}");
            listBox1.Items.Add($"Varış konumu: {varisLat}, {varisLon}");

            if (baslangicDurakMesafe > 3)
            {
                taksiUcreti = taksiAcilisUcreti + (kmBasiUcret * baslangicDurakMesafe);
                listBox1.Items.Add($"Taksi ile en yakın durağa ({enYakinBaslangicDurak.name}) gidiniz ({baslangicDurakMesafe:F2} km)");
            }
            else
            {
                listBox1.Items.Add($"Yürüyerek {baslangicDurakMesafe:F2} km giderek {enYakinBaslangicDurak.name} durağa gidniz.");
            }

            if (varisDurakMesafe > 3)
            {
                taksiUcreti = taksiAcilisUcreti + (kmBasiUcret * varisDurakMesafe);
                listBox1.Items.Add($"Son duraktan taksi ile ({enYakinVarisDurak.name}) hedefe gidiniz ({varisDurakMesafe:F2} km)");
            }
            else
            {
                listBox1.Items.Add($"Yürüyerek {varisDurakMesafe:F2} km giderek {enYakinVarisDurak.name} durağa gidiniz.");
            }

            listBox1.Items.Add($"Toplam taksi ücreti: {taksiUcreti:C}");
            listBox1.Items.Add($"Toplam ödenecek ücret (taksi + uygun rotadan gelen ücret): {enIyiRota.Item3 + taksiUcreti:C}");
            listBox1.Items.Add($"Ödeme Bilgisi: {secilenOdeme.OdemeYap()}");
            TimeSpan sure = TimeSpan.FromMinutes(enIyiRota.Item2);
            listBox1.Items.Add($"Başlangıç zamanı: {dateTimePicker1.Value} tahmini yolculuk bitiş zamanı: {dateTimePicker1.Value.Add(sure)}");
            listBox1.Items.Add($"Eğer tüm yolu yürümek istersen toplam mesafe: {mesafe:F2} km");

            // Rota haritada çizilsin
            List<Durak> enIyiRotaDuraklari = enIyiRota.Item1
                .Select(id => duraklar.Find(d => d.name == id))
                .Where(d => d != null) // null olanları filtrele
                .ToList();
            RotaCiz(enIyiRotaDuraklari);

            StringBuilder sonuc = new StringBuilder();
            sonuc.AppendLine("Olası Rotalar:");
            foreach (var rota in tumRotalar)
            {
                sonuc.AppendLine($"- {string.Join(" → ", rota.Item1)} | Süre: {rota.Item2} dk | Ücret: {rota.Item3} TL\n");
            }
            sonuc.AppendLine($"En Uygun Rotanız: {string.Join(" → ", enIyiRota.Item1)} | Süre: {enIyiRota.Item2} dk | Ücret: {enIyiRota.Item3} TL");

            //  return sonuc.ToString();
        }

        // Rota çizme fonksiyonu
        void RotaCiz(List<Durak> rotaDuraklari)
        {
            if (routeOverlay != null)
            {
                gMapControl1.Overlays.Remove(routeOverlay); // Önceki rotayı temizle
            }

            routeOverlay = new GMapOverlay("rota");

            // Her iki durak arasında çizgi çizmek için döngü
            for (int i = 0; i < rotaDuraklari.Count - 1; i++)
            {
                GMapRoute routeSegment = new GMapRoute(new List<PointLatLng>
        {
            new PointLatLng(rotaDuraklari[i].lat, rotaDuraklari[i].lon),
            new PointLatLng(rotaDuraklari[i + 1].lat, rotaDuraklari[i + 1].lon)
        }, $"Segment_{i}");       //------------------------------

                routeSegment.Stroke = new Pen(Color.Red, 4); // Çizgi rengi ve kalınlığı
                routeOverlay.Routes.Add(routeSegment);
            }

            // Duraklara işaret (marker) ekle
            foreach (var durak in rotaDuraklari)
            {
                if (durak != null)
                {
                    GMarkerGoogle marker = new GMarkerGoogle(
                        new PointLatLng(durak.lat, durak.lon),
                        GMarkerGoogleType.blue
                    );
                    marker.ToolTipText = durak.name;
                    routeOverlay.Markers.Add(marker);
                }
            }
            gMapControl1.Overlays.Add(routeOverlay);
            gMapControl1.Refresh(); // Haritayı güncelle
        }

        private void gMapControl2_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_vector_map_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
        }

        private void btn_uydu_map_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
        }

        private void btn_hibrit_map_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleHybridMapProvider.Instance;
        }

        private void saga_dondur_Click(object sender, EventArgs e)
        {
            gMapControl1.Bearing -= 10;
        }

        private void sola_dondur_Click(object sender, EventArgs e)
        {
            gMapControl1.Bearing += 10;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm";  // Yalnızca saat ve dakika
        }
    }
}
public class Durak
{
    public string city { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public bool sonDurak { get; set; }

    public List<NextStop> nextStops { get; set; } 
    // JSON verisinde nextStops bir liste olarak tanımlanmış, ama transfer tek bir obje. ondan dolayı transfer için liste tanımlanmadı  
    public Transfer transfer { get; set; }   
}
public class jsonVerisi
{
    public List<Durak> duraklar { get; set; } //Tüm durakları tek bir JSON nesnesinde sakla
}

public class NextStop
{
    public string stopId { get; set; }
    public double mesafe { get; set; }
    public int sure { get; set; }
    public double ucret { get; set; }
}
public class Transfer
{
    public string transferStopId { get; set; }
    public int transferSure { get; set; }
    public double transferUcret { get; set; }
}



