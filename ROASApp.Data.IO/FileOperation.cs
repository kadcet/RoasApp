namespace ROASApp.Data.IO
{
    // Bir dosyaya basit şekilde okumak veya yazmak için File sınıfını kullanılır.
    public class FileOperation
    {
        private const string filePath = "data.txt";

        public static void Write(string data)
        {
            File.WriteAllText(filePath, data);
            
        }

        public static string Read()
        {
            if (File.Exists(filePath)) // exist metodu bir dosyanın olup olmadığını kontrol eder
                return File.ReadAllText(filePath);
            else
                return null;

        }
    }
}