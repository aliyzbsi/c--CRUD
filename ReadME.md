### ProductApi Projesi Dokümantasyonu

## İçindekiler

1. [Proje Genel Bakış](#1-proje-genel-bakış)
2. [Kurulum ve Çalıştırma](#2-kurulum-ve-çalıştırma)
3. [API Endpoints](#3-api-endpoints)
4. [Veritabanı Yapılandırması](#4-veritabanı-yapılandırması)
5. [Çevre Değişkenleri](#5-çevre-değişkenleri)
6. [Geliştirme Kılavuzu](#6-geliştirme-kılavuzu)

## 1. Proje Genel Bakış

ProductApi, ürün yönetimi için geliştirilmiş bir RESTful API projesidir. ASP.NET Core 6.0 ve Entity Framework Core kullanılarak geliştirilmiştir. Veritabanı olarak PostgreSQL kullanılmaktadır.

### Teknoloji Yığını

- **Backend**: ASP.NET Core 6.0
- **ORM**: Entity Framework Core 6.0
- **Veritabanı**: PostgreSQL
- **Dokümantasyon**: Swagger/OpenAPI
- **Çevre Değişkenleri**: DotNetEnv

### Proje Yapısı

```plaintext
ProductApi/
├── Controllers/
│   └── ProductsController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── DTOs/
│   └── ProductResponse.cs
├── Migrations/
│   └── [Migration dosyaları]
├── Models/
│   └── Product.cs
├── Program.cs
├── appsettings.json
└── .env
```

## 2. Kurulum ve Çalıştırma

### Ön Koşullar

- .NET 6.0 SDK
- Docker (PostgreSQL için)
- Git (opsiyonel)

### Adım 1: Projeyi Klonlama

```shellscript
git clone <repository-url>
cd ProductApi
```

### Adım 2: PostgreSQL Kurulumu (Docker ile)

```shellscript
docker run --name postgres -e POSTGRES_PASSWORD=mysecretpassword -p 5432:5432 -d postgres
```

### Adım 3: Veritabanı Şemasını Oluşturma

```shellscript
docker exec -it postgres psql -U postgres -c "CREATE SCHEMA IF NOT EXISTS fdotnet;"
```

### Adım 4: Çevre Değişkenlerini Ayarlama

Proje kök dizininde `.env` dosyası oluşturun:

```plaintext
DB_PASSWORD=mysecretpassword
```

### Adım 5: Bağımlılıkları Yükleme

```shellscript
dotnet restore
```

### Adım 6: Veritabanı Migration'larını Uygulama

```shellscript
dotnet ef database update
```

### Adım 7: Uygulamayı Çalıştırma

```shellscript
dotnet run
```

Uygulama varsayılan olarak [https://localhost:7149](https://localhost:7149) adresinde çalışacaktır.

## 3. API Endpoints

API, aşağıdaki endpoints'leri sağlar:

### Ürünleri Listeleme

```plaintext
GET /Products
```

**Yanıt Örneği:**

```json
[
  {
    "title": "Örnek Ürün",
    "sku": "SKU123",
    "barcode": "BARCODE123",
    "price": 19.99,
    "titleDomestic": "Örnek Ürün Yerel",
    "hasVideo": true,
    "stock": 100,
    "currencyName": "TRY"
  }
]
```

### Ürün Detayı Görüntüleme

```plaintext
GET /Products/{id}
```

**Yanıt Örneği:**

```json
{
  "title": "Örnek Ürün",
  "sku": "SKU123",
  "barcode": "BARCODE123",
  "price": 19.99,
  "titleDomestic": "Örnek Ürün Yerel",
  "hasVideo": true,
  "stock": 100,
  "currencyName": "TRY"
}
```

### Yeni Ürün Oluşturma

```plaintext
POST /Products
```

**İstek Gövdesi Örneği:**

```json
{
  "productStatusId": 1,
  "productStatusName": "Aktif",
  "productUrl": "https://example.com/product1",
  "title": "Yeni Ürün",
  "titleDomestic": "Yeni Ürün Yerel",
  "descriptionDomestic": "Bu bir örnek ürün açıklamasıdır",
  "sku": "SKU123",
  "barcode": "BARCODE123",
  "otherCode": "OTHER123",
  "stock": 100,
  "currencyName": "TRY",
  "price": 199.99,
  "priceDiscountedDomestic": 179.99,
  "priceDiscounted": 159.99,
  "isFeatured": true,
  "isElonkyFeatured": false,
  "hasVideo": true,
  "hasPersonalization": false,
  "isTaxable": true,
  "whenMade": "2023",
  "whoMade": "Üretici",
  "personalizationDescription": "",
  "isDigital": false
}
```

### Ürün Güncelleme

```plaintext
PUT /Products/{id}
```

**İstek Gövdesi Örneği:**

```json
{
  "productStatusId": 1,
  "productStatusName": "Aktif",
  "productUrl": "https://example.com/product1",
  "title": "Güncellenmiş Ürün",
  "titleDomestic": "Güncellenmiş Ürün Yerel",
  "descriptionDomestic": "Bu güncellenmiş bir ürün açıklamasıdır",
  "sku": "SKU123",
  "barcode": "BARCODE123",
  "otherCode": "OTHER123",
  "stock": 150,
  "currencyName": "TRY",
  "price": 249.99,
  "priceDiscountedDomestic": 229.99,
  "priceDiscounted": 199.99,
  "isFeatured": true,
  "isElonkyFeatured": false,
  "hasVideo": true,
  "hasPersonalization": false,
  "isTaxable": true,
  "whenMade": "2023",
  "whoMade": "Üretici",
  "personalizationDescription": "",
  "isDigital": false
}
```

### Ürün Silme

```plaintext
DELETE /Products/{id}
```

## 4. Veritabanı Yapılandırması

Proje, PostgreSQL veritabanını kullanmaktadır. Veritabanı bağlantısı, `appsettings.json` dosyasında yapılandırılmıştır:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=${DB_PASSWORD}"
  }
}
```

### Veritabanı Şeması

Ürün verileri, `fdotnet` şemasındaki `products` tablosunda saklanmaktadır. Tablo yapısı şu şekildedir:

| Alan                       | Tip     | Açıklama                         |
| -------------------------- | ------- | -------------------------------- |
| ProductStatusId            | bigint  | Birincil anahtar, otomatik artan |
| ProductStatusName          | text    | Ürün durumu (Aktif, Pasif vb.)   |
| ProductUrl                 | text    | Ürün URL'si                      |
| Title                      | text    | Ürün başlığı                     |
| TitleDomestic              | text    | Yerel dildeki ürün başlığı       |
| DescriptionDomestic        | text    | Yerel dildeki ürün açıklaması    |
| Sku                        | text    | Stok Tutma Birimi                |
| Barcode                    | text    | Barkod                           |
| OtherCode                  | text    | Diğer kod                        |
| Stock                      | integer | Stok miktarı                     |
| CurrencyName               | text    | Para birimi                      |
| Price                      | numeric | Fiyat                            |
| PriceDiscountedDomestic    | numeric | Yerel indirimli fiyat            |
| PriceDiscounted            | numeric | İndirimli fiyat                  |
| IsFeatured                 | boolean | Öne çıkan ürün mü?               |
| IsElonkyFeatured           | boolean | Elonky'de öne çıkan ürün mü?     |
| HasVideo                   | boolean | Ürün videosu var mı?             |
| HasPersonalization         | boolean | Kişiselleştirme var mı?          |
| IsTaxable                  | boolean | Vergilendirilebilir mi?          |
| WhenMade                   | text    | Üretim zamanı                    |
| WhoMade                    | text    | Üretici                          |
| PersonalizationDescription | text    | Kişiselleştirme açıklaması       |
| IsDigital                  | boolean | Dijital ürün mü?                 |

## 5. Çevre Değişkenleri

Proje, hassas bilgileri (örneğin veritabanı şifresi) güvenli bir şekilde yönetmek için çevre değişkenlerini kullanır. Bu değişkenler, `.env` dosyasında saklanır ve DotNetEnv kütüphanesi kullanılarak yüklenir.

### Gerekli Çevre Değişkenleri

| Değişken    | Açıklama                      | Örnek Değer      |
| ----------- | ----------------------------- | ---------------- |
| DB_PASSWORD | PostgreSQL veritabanı şifresi | mysecretpassword |

### .env Dosyası Örneği

```plaintext
DB_PASSWORD=mysecretpassword
```

**Not:** `.env` dosyası, güvenlik nedeniyle git deposuna eklenmemelidir. Bunun yerine, `.env.example` dosyası oluşturarak gerekli değişkenleri belgeleyebilirsiniz.

## 6. Geliştirme Kılavuzu

### Yeni Bir Model Ekleme

1. `Models` klasöründe yeni bir model sınıfı oluşturun
2. `ApplicationDbContext.cs` dosyasına DbSet ekleyin
3. DTO sınıflarını oluşturun
4. Yeni bir controller oluşturun
5. Migration oluşturun ve uygulayın:

```shellscript
dotnet ef migrations add AddNewModel
dotnet ef database update
```

### Mevcut Bir Modeli Güncelleme

1. Model sınıfını güncelleyin
2. Migration oluşturun ve uygulayın:

```shellscript
dotnet ef migrations add UpdateExistingModel
dotnet ef database update
```

### Kod Stili ve En İyi Uygulamalar

- Sınıf ve metot adları için PascalCase kullanın
- Değişken adları için camelCase kullanın
- Her sınıf ve metot için XML belgeleri ekleyin
- Asenkron programlama için Task-based Asynchronous Pattern (TAP) kullanın
- Hata yönetimi için try-catch blokları kullanın
- Bağımlılık enjeksiyonu için constructor injection kullanın
