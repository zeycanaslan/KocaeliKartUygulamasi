using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapc
{
    public abstract class Arac
    {
        public abstract string Renk { get; }
    }
    public class Otobus : Arac
    {
        public override string Renk => "Mavi";  // Otobüs için mavi renk
    }
    public class Tramvay : Arac
    {
        public override string Renk => "Yeşil";  // Tramvay için yeşil renk
    }
    public class Taksi : Arac
    {
        public override string Renk => "Sarı";  // Taksi için sarı renk
    }
}