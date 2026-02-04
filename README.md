# BookingApp – Otel Rezervasyon Yönetim Sistemi (Backend API)

BookingApp, ASP.NET Core Web API kullanılarak geliştirilmiş, otel rezervasyon süreçlerini yöneten kapsamlı bir backend uygulamasıdır. Proje; kullanıcı yönetimi, otel ve oda yönetimi, rezervasyon sistemi, bakım modu altyapısı ve JWT tabanlı güvenlik mekanizması içermektedir. Katmanlı mimari yapısı sayesinde sürdürülebilir, geliştirilebilir ve ölçeklenebilir bir sistem olarak tasarlanmıştır.

Bu proje, modern yazılım mimarisi prensipleri dikkate alınarak geliştirilmiş olup, eğitim ve portföy amacıyla hazırlanmıştır.

---

## Projenin Amacı

BookingApp’in temel amacı, bir otel rezervasyon sisteminin backend altyapısını profesyonel standartlara uygun şekilde oluşturmaktır.

Bu proje ile:

- Katmanlı mimari uygulanması
- Güvenli kimlik doğrulama sistemleri
- Veritabanı yönetimi
- Transaction ve hata yönetimi
- Middleware kullanımı
- Repository ve Unit of Work pattern’lerinin uygulanması

gibi ileri seviye backend geliştirme konularının pratiği yapılmıştır.

---

## Proje Mimarisi

Proje 3 ana katmandan oluşmaktadır:

### 📁 Business Katmanı
- İş kurallarının yazıldığı katmandır.
- Servisler, DTO’lar ve validasyonlar burada yer alır.
- Kullanıcı, otel, özellik ve ayar işlemleri bu katmanda yönetilir.

### 📁 Data Katmanı
- Veritabanı işlemleri bu katmanda gerçekleştirilir.
- Entity Framework Core kullanılmıştır.
- Repository Pattern ve Unit of Work Pattern uygulanmıştır.
- Migration yönetimi burada yapılmaktadır.

### 📁 WebApi Katmanı
- Dış dünyaya açılan API katmanıdır.
- Controller’lar bu katmanda yer alır.
- JWT Authentication ve Middleware yapıları burada çalışır.

---

## 🔐 Güvenlik ve Kimlik Doğrulama

Sistemde JWT (JSON Web Token) tabanlı authentication sistemi kullanılmaktadır.

Özellikler:

- Kullanıcı kayıt ve giriş sistemi
- Token üretimi
- Token doğrulama
- Rol bazlı yetkilendirme (Admin / Customer)
- Swagger üzerinde JWT desteği

Parolalar, ASP.NET Data Protection altyapısı ile şifrelenerek saklanmaktadır.

---

## 👤 Kullanıcı Yönetimi

Sistemde iki tip kullanıcı bulunmaktadır:

- Admin
- Customer

Kullanıcılar:

- Kayıt olabilir
- Giriş yapabilir
- Token alabilir
- Yetkilerine göre işlem gerçekleştirebilir

Admin kullanıcılar sistem yönetimi işlemlerine erişebilir.

---

## 🏨 Otel ve Özellik Yönetimi

Sistem üzerinden:

- Otel ekleme
- Otel güncelleme
- Otel silme
- Otel listeleme
- Otel yıldız güncelleme
- Otel özellik eşleştirme

işlemleri yapılabilmektedir.

Her otel, birden fazla özellikle ilişkilendirilebilir. Bu ilişki ara tablo (HotelFeatures) üzerinden yönetilmektedir.

---

## 🛏️ Oda ve Rezervasyon Sistemi

Otel sisteminde:

- Odalar otellere bağlıdır
- Rezervasyonlar odalara ve kullanıcılara bağlıdır

Rezervasyon sistemi sayesinde:

- Başlangıç ve bitiş tarihleri
- Misafir sayısı
- Kullanıcı ilişkisi

gibi bilgiler yönetilmektedir.

---

## 🛠️ Bakım Modu (Maintenance Mode)

Projede bakım modu altyapısı bulunmaktadır.

Bakım modu aktif edildiğinde:

- Sistem geçici olarak kapatılır
- Sadece belirli endpoint’lere izin verilir
- Kullanıcılar bilgilendirilir

Bu yapı özel olarak geliştirilen Middleware ile sağlanmaktadır.

Bakım durumu veritabanındaki Settings tablosu üzerinden yönetilmektedir.

---

## 📄 Middleware Yapısı

Projede özel middleware kullanılmıştır:

- MaintenanceMiddleware

Bu middleware, her isteği kontrol ederek sistemin bakımda olup olmadığını denetler.

---

## 📊 Veritabanı Yapısı

Veritabanı olarak SQL Server kullanılmaktadır.

Ana tablolar:

- Users
- Hotels
- Rooms
- Reservations
- Features
- HotelFeatures
- Settings

Entity Framework Core ile Code First yaklaşımı kullanılmıştır.

Migration sistemi ile veritabanı otomatik oluşturulmaktadır.

---

## 📚 Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- Data Protection API
- Repository Pattern
- Unit of Work Pattern

---

## ⚙️ Kurulum

### 1️⃣ Projeyi Klonla

```bash
git clone https://github.com/selinozluk/BookingApp.git
