using System.Text;

namespace ROASApp.Domain
{
    public class ROAS
    {
        public ROAS()
        {
            
            sayac++;
            reklamNo = sayac;
        }

        #region Constructur Example
        //public ROAS()
        //{

        //}
        //public ROAS(string _reklamKanali)
        //{
        //    reklamKanali = _reklamKanali;
        //}
        //public ROAS(double _reklamMaliyeti)
        //{
        //    reklamMaliyeti = _reklamMaliyeti;
        //}
        //public ROAS(string _reklamKanali,double _reklamMaliyeti)
        //{
        //    reklamKanali = _reklamKanali;
        //    reklamMaliyeti = _reklamMaliyeti;
        //} 
        #endregion

        //reklamno ya her yeni roas oluşturulduğunda yeni bir değer atayayım
        public static ushort sayac;
        public ushort reklamNo;
        public string reklamKanali;
        public double reklamMaliyeti;
        public double birimFiyat;
        public double satisAdedi;

        public double ROASGetirisi()
        {
            return (ToplamGelir() / reklamMaliyeti);
        }

        private double ToplamGelir()
        {
            return (satisAdedi * birimFiyat);
        }

        // bu metod ROAS hakkında bilgiler verecek.Ekrana yazırmak için. Datayı sitring olarak döneyim o nerde göstercekse göstersin
        // Console,windowsForm,Web v.s
        public string ROASInfo()
        {
            StringBuilder sb=new StringBuilder();
            sb.Append($"Reklam No : {reklamNo}\n");
            sb.Append($"Reklam Kanalı : {reklamKanali}\n");
            sb.Append($"Reklam Maliyeti : {reklamMaliyeti}\n");
            sb.Append($"Satış Adedi : {satisAdedi}\n");
            sb.Append($"Birim Fiyat : {birimFiyat}\n");
            sb.Append($"ROAS Getisi : {ROASGetirisi()}\n");

            return sb.ToString();
        }
    }
}