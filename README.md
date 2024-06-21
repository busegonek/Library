# Basit Kütüphane Yönetim Sistemi

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş basit bir kütüphane yönetim sistemini göstermektedir. Kullanıcılar kitap rezervasyonu yapabilir, rezervasyonlarını görüntüleyebilir ve sisteme giriş yapabilirler.

## Kullanılan Teknolojiler

- **ASP.NET Core MVC**: Web uygulamaları oluşturmak için kullanılan bir framework.
- **Razor Pages**: ASP.NET Core MVC'de kullanılan bir template motoru.
- **C# Programlama Dili**: Backend mantığı ve işlevselliği sağlamak için kullanılmıştır.
- **HTML, CSS, JavaScript**: Frontend kullanıcı arayüzü ve tasarımı için kullanılmıştır.

## Önemli Özellikler

- **Controller ve View Yapısı**: `HomeController` ve `ReservationController` HTTP isteklerini yönetmek ve view'leri kontrol etmek için kullanılmaktadır.
  
- **Kullanıcı Girişi**: `LoginController` kullanıcıların kullanıcı adı ve şifreleri ile giriş yapmalarını sağlar. Başarılı giriş sonrasında kullanıcı adı bir çerez (cookie) olarak tarayıcıya kaydedilir.
  
- **Rezervasyon İşlemleri**: `ReservationController` kitap rezervasyonlarını yönetir. Aynı kitabın aynı tarihte birden fazla rezervasyonunu önlemek için doğrulama yapar.
  
- **Kullanıcı Oturumu Yönetimi**: Giriş yapan kullanıcılar `UserReservations` action'ı ile rezervasyonlarını görüntüleyebilirler. Giriş yapmayan kullanıcılar ise giriş sayfasına yönlendirilir.

## Teknolojik Detaylar

- **Bağımlılık Enjeksiyonu** (Dependency Injection) : ASP.NET Core'un bağımlılık enjeksiyon mekanizması hizmetleri enjekte etmek için kullanılmıştır.
  
- **HTTP İstek Pipeline'ı** (HTTP Request Pipeline): HTTP istekleri `app.UseRouting()` ve `app.MapControllerRoute()` kullanılarak nasıl işleneceği tanımlanmıştır.
  
- **Çerez Kullanımı** (Cookie Usage): ASP.NET Core'un `Response.Cookies` özelliği kullanılarak kullanıcının tarayıcısında çerez olarak kullanıcı adı saklanır.

## Kullanılan Veri Yapıları

- Geçici veri yapıları olarak List'ler (`List<User>`, `List<Book>`, `List<Reservation>`) kullanılmıştır. Gerçek bir projede bu yapılar kalıcı depolama için veritabanı bağlantıları ile değiştirilir.

## Proje Geliştirme ve İyileştirmeler

- **Veritabanı Entegrasyonu**: Gerçek projelerde veritabanlarıyla entegrasyon (örneğin, SQL Server, MySQL) yapılması gerekmektedir.
  
- **Güvenlik Geliştirmeleri**: Daha güçlü kimlik doğrulama yöntemleri (örneğin, şifre hashleme) ve yetkilendirme mekanizmalarının uygulanması için güvenlik iyileştirmeleri yapılabilir.
  
- **Frontend İyileştirmeleri**: Kullanıcı arayüzü için Bootstrap gibi framework'ler kullanılarak daha şık ve kullanıcı dostu bir görünüm sağlanabilir.

## Sonuç

Bu basit kütüphane yönetim sistemi, ASP.NET Core MVC ve temel web geliştirme becerilerini öğrenmek için bir başlangıç noktası sunar. Gerçek projelerde daha karmaşık gereksinimler ve özelleştirmeler gerekebilir, ancak bu proje temel bir anlayış sağlamaktadır.



