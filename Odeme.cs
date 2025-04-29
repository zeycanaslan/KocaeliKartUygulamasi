using System;

namespace mapc
{
    public interface IOdeme
    {
        String OdemeYap();
    }
    public class Nakit : IOdeme
    {
        public string OdemeYap()
        {
            return "Nakit ödeme yapıldı.";
        }
    }
    public class KrediKarti : IOdeme
    {
        public string OdemeYap()
        {
            return "Kredi Kartı ile  ödeme yapıldı.";
        }
    }
    public class Kentkart : IOdeme
    {
        public string OdemeYap()
        {
            return "KentKart ile  ödeme yapıldı.";
        }
    }
}