using ROASApp.Data.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ROASApp.Domain
{
    public class ROASService
    {
        // Todo: Roasların kaydedileceği List
        private static List<ROAS> liste = new List<ROAS>(); 


        // Todo:Roas kaydetme metodu
        public static ROAS SaveROAS(string reklamKanali, double reklamMaliyeti, double birimFiyat, double satisAdedi)
        {
            ROAS roas = new ROAS();
            roas.reklamKanali = reklamKanali;
            roas.reklamMaliyeti = reklamMaliyeti;
            roas.birimFiyat = birimFiyat;
            roas.satisAdedi = satisAdedi;

            liste.Add(roas);

            // JSON Convert
            //JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            //serializerOptions.IncludeFields = true;
            //string json = JsonSerializer.Serialize(liste, serializerOptions);

            WriteListFromFile(); // Todo: Dosya Operasyonu metodu
            return roas;
        } 


        // geriye dönüş tipi IReadOnlyCollection. listemizi sadece okunabilir liste yaptık
        // Todo:Roas listeleme metodu
        public static IReadOnlyCollection<ROAS> GetAllROAS()
        {

            LoadListFromFile();

            return liste.AsReadOnly();
        }

        public static IReadOnlyCollection<ROAS> FilterByChannelName(string channelNane)
        {
            LoadListFromFile();
            List<ROAS> filteredROAS = new List<ROAS>();
            // yeni listeye attık
            foreach (var r in liste) // yukarıdaki listeyi gez diyoruz.eşleşen varsa filteredROAS listesine ekle
            {
                if (r.reklamKanali.ToLower().Contains(channelNane.ToLower()))
                {
                    filteredROAS.Add(r);
                }

            }
            return filteredROAS.AsReadOnly();
        }

        private static void WriteListFromFile()
        {
            // JSON Convert
            string json = JsonSerializer.Serialize(liste, new JsonSerializerOptions { IncludeFields = true });
            FileOperation.Write(json);
        }

        public static void LoadListFromFile()
        {
            string json = FileOperation.Read();
            liste = JsonSerializer.Deserialize<List<ROAS>>(json,
               new JsonSerializerOptions { IncludeFields = true });
        }

        
        public static List<ROAS> DeleteList(string roasIsim)
        {
            LoadListFromFile();


            for (int i = liste.Count - 1; i >= 0; i--)
            {
                if (liste[i].reklamKanali.ToLower()==roasIsim.ToLower())
                {
                    liste.Remove(liste[i]);
                }
            }
            WriteListFromFile();
            return liste;
        }

        public static List<ROAS> UpdateList(string roasIsim,string newRoasName)
        {
            LoadListFromFile();
           
            foreach (var item in liste)
            {
                if (item.reklamKanali==roasIsim)
                {
                    item.reklamKanali = newRoasName;
                }
                
            }

            WriteListFromFile();
            return liste;
        }


        // JsonSerializer.Serialize(liste)   => listeyi json formatına dönüştür demek


    }
}
