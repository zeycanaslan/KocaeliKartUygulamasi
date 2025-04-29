# KocaeliKartUygulamasi
Kocaeli için Rota Hesaplama Sistemi
# 🧭 Durak Rota ve Taksi Ücreti Hesaplama Uygulaması

Bu C# Windows Forms projesi, kullanıcının belirttiği başlangıç ve varış konumlarına göre en uygun toplu taşıma rotasını hesaplar. Duraklar arası rota oluşturulur, gerektiğinde taksi mesafesi hesaplanır ve toplam ücret kullanıcıya sunulur.

## 🚀 Özellikler

- Kullanıcıdan başlangıç ve varış **enlem-boylam** bilgileri alınır.
- Duraklar arasındaki en kısa toplu taşıma rotası hesaplanır.
- Başlangıç ve varış noktaları, en yakın duraklara olan mesafeye göre analiz edilir.
  - Eğer durak uzaklığı > 3 km ise **taksi ücreti** hesaplanır.
  - Eğer < 3 km ise **yürüme mesafesi** olarak değerlendirilir.
- Yolcu tipi (Genel, Öğrenci, 65+ yaş) ve ödeme türü (Nakit, Kredi Kartı, KentKart) seçilebilir.
- **Toplam süre ve ücret bilgileri** kullanıcıya detaylı olarak gösterilir.
- Rota bilgileri harita üzerinde gösterilir (örnek çizim yöntemiyle).

## 🛠️ Kullanılan Teknolojiler

- C# (.NET Framework)
- Windows Forms
- OOP (Sınıflar: `Yolcu`, `Durak`, `IOdeme`, `RotaHesaplayici`, vb.)

![image](https://github.com/user-attachments/assets/c7513f92-8069-4946-a61a-2cb80005e818)

![image](https://github.com/user-attachments/assets/5711c5c8-19b7-4621-ba5c-680188c16bab)


## 📦 Kurulum

1. Bu projeyi klonlayın:
   ```bash
   git clone https://github.com/zeycanaslan/KocaeliKartUygulamasi.git
