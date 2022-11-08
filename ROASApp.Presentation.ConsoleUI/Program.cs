// ConsoleUI  Roas uygulaması için datayı alıp kaydetmek ve okumak için domain katmanındaki sıfılara ulaşması lazım.
// Bu yüzden Domain katmanını ConsoleUI referans almak zorunda. 
// Referans bağımlılık yönü      Domainden => ConsoleUI a
// Domain data okuma işlemlerinde Data katmanından referans alacak

// Önce benim ROAS tipine ihtiyacım var. Domain katmanına gidip ROAS oluşturucaz.


using ROASApp.Domain; // arkadaki domaindeki ROAS ı kullanmak için
using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ROASApp.PresentationconsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Yeni ROAS Kaydı\n2. Roas Listesi\n3. ROAS Filtrele\n4. Sil\n5. Güncelle\n6. Çıkış");
            MenuSelection();
        }

        private static void MenuSelection()
        {
            Console.Write("Seçiminiz :");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    NewROAS();
                    break;
                case "2":
                    ListOfROAS();
                    break;
                case "3":
                    FilterROAS();
                    break;
                case "4":
                    DeletedROAS();
                    break;
                case "5":
                    UpdateROAS();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;

                default:
                    MenuSelection();
                    break;
            }
        }

        private static void NewROAS()
        {
            Console.WriteLine("Reklam Kanalı Adı :");
            string kanalAdi = Console.ReadLine();
            Console.WriteLine("Reklam Maliyeti :");
            double maliyet = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Satılan Ürünlerin Birim Fiyatı :");
            double birimFiyat = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Satılan Ürün Adedi :");
            int adet = Convert.ToInt32(Console.ReadLine());

            // kullanıcıdan aldığımız değerleri domainde roasservis deki save metosuna gönderdik.ordanda listeye kaydettik. bu değerleri data değişkenine aktarıp aşşağıda yazdırmak için metodu çağırdık
            //var data = ROASService.SaveROAS(kanalAdi, maliyet, birimFiyat, adet);


            //Console.WriteLine($"Hsaplanan ROAS Değeri : %{data.ROASGetirisi()}");
            Console.WriteLine($"Hsaplanan ROAS Değeri : %{ROASService.SaveROAS(kanalAdi,maliyet,birimFiyat,adet).ROASGetirisi().ToString()}");

            Again();
        }
        #region Roas Listeleme İşlemleri

        private static void ListOfROAS()
        {
            var list = ROASService.GetAllROAS();
            PrintList(list);
        }

        static void PrintList(IReadOnlyCollection<ROAS> list)
        {
            Console.WriteLine("----------Liste Başlangıcı--------------");

            foreach (var r in list)
            {
                Console.WriteLine(r.ROASInfo());
                Console.WriteLine("----------------");
            }

            Console.WriteLine("----------Liste Sonu--------------");
            Again();
        } 
        #endregion

        private static void FilterROAS()
        {
            Console.WriteLine("Kanal adı içinde geçen kelimeyi yazın : ");
            string filterKeyword = Console.ReadLine();
            var data = ROASService.FilterByChannelName(filterKeyword);
            PrintList(data);
        }

        private static void DeletedROAS()
        {
            Console.WriteLine("Silinecek raklam Ros ını yazınız");
            string rosIsim = Console.ReadLine();

            ROASService.DeleteList(rosIsim);
            Console.WriteLine("Liste silindi...");
            ListOfROAS();
            Again();
        }

        private static void UpdateROAS()
        {
            Console.WriteLine("Güncellenecek olan ROAS ın REklam Kanalını girin :");
            string roasIsim = Console.ReadLine();
            Console.WriteLine("Yeni Roas İsmi :");
            string newRoasName = Console.ReadLine();

            ROASService.UpdateList(roasIsim, newRoasName);
            Console.WriteLine("Liste güncellendi...");
            ListOfROAS();
            Again();
        }



        static void Again()
        {
            Console.WriteLine("Menüye dönmek için Enter");
            Console.ReadLine();
            Menu();
        }

    }
}