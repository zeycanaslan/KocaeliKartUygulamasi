using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapc
{
    public abstract class Yolcu
    {
        public abstract double IndirimliFiyat(double ucret);  // polymorphism 
    }
    public class Genel : Yolcu
    {
        public override double IndirimliFiyat(double ucret)
        {
            return ucret; 
        }
    }
    public class Ogrenci : Yolcu
    {
        public override double IndirimliFiyat(double ucret)
        {
            return ucret * 0.5; 
        }
    }
    public class Ogretmen : Yolcu
    {
        public override double IndirimliFiyat(double ucret)
        {
            return ucret * 0.2;
        }
    }
    public class Yasli : Yolcu
    {
        public override double IndirimliFiyat(double ucret)
        {
            return ucret * 0.3; 
        }
    }
}
