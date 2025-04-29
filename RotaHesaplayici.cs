using System.Text;
using System.Threading.Tasks;
using static GMap.NET.Entity.OpenStreetMapGraphHopperGeocodeEntity;
using mapc;

namespace mapc
{
    public class RotaHesaplayici
    {
        public string EnUygunRotaBul(double baslangicLat, double baslangicLon, double varisLat, double varisLon, List<Durak> duraklar, Yolcu yolcu, out List<(List<string>, double, double)> tumRotalar)
        {
            Durak enYakinBaslangicDurak = EnYakinDurakBul(baslangicLat, baslangicLon, duraklar);
            Durak enYakinVarisDurak = EnYakinDurakBul(varisLat, varisLon, duraklar);

            Dictionary<string, (double, double, List<string>)> enIyiRotalar = new Dictionary<string, (double, double, List<string>)>();
            PriorityQueue<(Durak, List<string>, double, double), double> queue = new();
            tumRotalar = new List<(List<string>, double, double)>();

            queue.Enqueue((enYakinBaslangicDurak, new List<string> { enYakinBaslangicDurak.name }, 0, 0), 0);

            while (queue.Count > 0)
            {
                var (mevcutDurak, yol, toplamSure, toplamUcret) = queue.Dequeue();

                if (mevcutDurak.id == enYakinVarisDurak.id)
                {
                    tumRotalar.Add((yol, toplamSure, toplamUcret));
                    continue;
                }

                if (enIyiRotalar.ContainsKey(mevcutDurak.id) && enIyiRotalar[mevcutDurak.id].Item1 <= toplamSure)
                    continue;

                enIyiRotalar[mevcutDurak.id] = (toplamSure, toplamUcret, yol);

                foreach (var next in mevcutDurak.nextStops)
                {
                    var nextDurak = duraklar.Find(d => d.id == next.stopId);
                    if (nextDurak != null)
                    {
                        var yeniYol = new List<string>(yol) { nextDurak.name };
                        double yeniSure = toplamSure + next.sure;
                        double yeniUcret = toplamUcret + yolcu.IndirimliFiyat(next.ucret);
                        queue.Enqueue((nextDurak, yeniYol, yeniSure, yeniUcret), yeniSure);
                    }
                }

                if (mevcutDurak.transfer != null)
                {
                    var transferDurak = duraklar.Find(d => d.id == mevcutDurak.transfer.transferStopId);
                    if (transferDurak != null)
                    {
                        var yeniYol = new List<string>(yol) { transferDurak.name + " (Transfer)" };
                        double yeniSure = toplamSure + mevcutDurak.transfer.transferSure;
                        double yeniUcret = toplamUcret + yolcu.IndirimliFiyat(mevcutDurak.transfer.transferUcret);
                        queue.Enqueue((transferDurak, yeniYol, yeniSure, yeniUcret), yeniSure);
                    }
                }
            }

            if (tumRotalar.Count == 0)
                return "Rota bulunamadı.";

            var enIyiRota = tumRotalar.OrderBy(r => r.Item2).ThenBy(r => r.Item3).First();
            StringBuilder sonuc = new StringBuilder();
            sonuc.AppendLine("Olası Rotalar:");
            foreach (var rota in tumRotalar)
            {
                sonuc.AppendLine($"- {string.Join(" → ", rota.Item1)} | Süre: {rota.Item2} dk | Ücret: {rota.Item3} TL\n");
            }
            sonuc.AppendLine($"\nEn Uygun Rota: {string.Join(" → ", enIyiRota.Item1)} | Süre: {enIyiRota.Item2} dk | Ücret: {enIyiRota.Item3} TL");

            return sonuc.ToString();
        }



        public static Durak EnYakinDurakBul(double kullaniciLat, double kullaniciLon, List<Durak> duraklar)
        {
            return duraklar.OrderBy(durak => UzaklikHesaplayici.MesafeHesapla(kullaniciLat, kullaniciLon, durak.lat, durak.lon)).First();
        }
    }


    public class UzaklikHesaplayici  // KM CİNSİNDEN HESAPLANIYOR
    {
        private const double YariCapDunya = 6371; // Dünya'nın yarıçapı (km)
        private const double PI = Math.PI;

        public static double MesafeHesapla(double lat1, double lon1, double lat2, double lon2)
        {
            double farkLat = dereceden_radyana(lat2 - lat1);
            double farkLon = dereceden_radyana(lon2 - lon1);

            // Haversine formülü uygulanıyor
            double a = Math.Sin(farkLat / 2) * Math.Sin(farkLat / 2) +
                       Math.Cos(dereceden_radyana(lat1)) * Math.Cos(dereceden_radyana(lat2)) *
                       Math.Sin(farkLon / 2) * Math.Sin(farkLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));  //Ters tanjant (atan2), iki nokta arasındki açısal mesafe

            return YariCapDunya * c;
        }

        private static double dereceden_radyana(double derece)
        {
            return derece * (PI / 180);
        }
    }
}
