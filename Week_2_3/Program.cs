using System.Reflection;

using Week2._4.Entities;


Console.WriteLine("Calender App");

Meeting meeting1 = new()
{
    Title = "YetGen Jump & Akbank Backend Planlama Toplantısı",
    Details = new List<string>()
     {
         "Katılımcıların alım süreçleri kouşulacak",
         "Akbank'tan gelen mail konuşulacak",
         "Bütçe planlaması konuşulacak"
     },

     StartTime = new DateTime(2023, 09, 18, 19, 00, 00),
    FinishTime = new DateTime(2023, 09, 18, 20, 00, 00),
    Guests = new() { "hakan@deneme.com", "mehmet@deneme.com", "ugurqdeneme.com" },
};

Todo todo1 = new()
{
    Title = "Katılımcı geri bildirimlerini teslim et",
    Details = new List<string>()
    {
        "Değerlendirme sonuçlarının anonimleştirilmesi",
        "Grafik oluşturulması"
    },
    StartTime = new DateTime(2023, 09, 20, 21, 00, 00),
    FinishTime = new DateTime(2023, 09, 20, 22, 00, 00),
    Importance = "High Priority"
};

meeting1.GetNotification();

todo1.GetNotification();