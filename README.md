# .NET Core Dependency Injection Yaşam Döngüsü (Lifetime) Örnekleri

Bu repoda, .NET Core'da kullanılan Dependency Injection (DI) yöntemlerinin (`AddScoped`, `AddTransient`, `AddSingleton`) çalışma mantığını ve aralarındaki farkları somut bir şekilde göstermek amacıyla basit bir uygulama geliştirdim. Kodun takibini kolaylaştırmak için class, interface ve controller isimlerini yaşam döngüleri ile eşleşecek şekilde isimlendirdim.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## 🟢 1. AddScoped Çalışma Mantığı ve Örneği

`AddScoped` ile kayıt edilen servisler, **her HTTP isteği (request) başına bir kez** oluşturulur. İstek başladıktan sonra ve bitene kadar, o servise ihtiyaç duyan tüm sınıflara **aynı nesne (instance)** verilir.

### Kurulan Senaryo:
1. **`IScopedNumber` & `ScopedNumber`:** Constructor'ında rastgele bir sayı üreterek `Number` property'sine atar.
2. **`IScopedNumber2` & `ScopedNumber2`:** Constructor'ında `IScopedNumber` interface'ini inject eder ve `GetNumber()` metodu ile bu nesnedeki sayıyı döner.
3. **`ScopedNumberController`:** Constructor'ında hem `IScopedNumber` hem de `IScopedNumber2` servislerini inject alır. 

### Gözlem ve Sonuç:
`GetScopedNumber` endpoint'ine bir istek attığınızda ekrana yazılan `number1` (`_scopedNumber.Number`) ve `number2` (`_scopedNumber2.GetNumber()`) değerlerinin **birebir aynı** olduğunu göreceksiniz. 

💡 **Neden?** Çünkü HTTP isteği controller'a ulaştığında DI Container bir `ScopedNumber` nesnesi üretir. İstek henüz tamamlanmadığı için, aradaki `ScopedNumber2` servisi de aynı nesneyi talep ettiğinde container yeni bir nesne üretmez, **ilk oluşturduğu nesneyi verir.**

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## 🟢 2. AddTransient Çalışma Mantığı ve Örneği

`AddSingleton` ile kayıt edilen servisler, uygulamamanın çalıştığı süre boyunca (application lifetime) yalnızca bir kez oluşturulur. İlk talep edildiği andan itibaren uygulama durdurulana veya yeniden başlatılana kadar, o servise ihtiyaç duyan tüm sınıflara ve gelen tüm yeni HTTP isteklerine hep aynı nesne (instance) verilir.

### Kurulan Senaryo:
1. **`ITransientNumber` & `TransientNumber`:** Constructor'ında rastgele bir sayı üreterek `Number` property'sine atar.
2. **`ITransientNumber2` & `TransientNumber2`:** Constructor'ında `ITransientNumber` interface'ini inject eder ve `GetNumber()` metodu ile bu nesnedeki sayıyı döner.
3. **`TransientNumberController`:** Constructor'ında hem `ITransientNumber` hem de `ITransientNumber2` servislerini inject alır. 

### Gözlem ve Sonuç:
`GetTransientNumber` endpoint'ine bir istek attığınızda ekrana yazılan `number1` (`_transientNumber.Number`) ve `number2` (`_transientdNumber2.GetNumber()`) değerlerinin **birbirinen farklı** olduğunu göreceksiniz. 

💡 **Neden?** Çünkü HTTP isteği controller'a ulaştığında DI Container _transientNumber için yeni bir TransientNumber nesnesi üretir. İsteğin devamında, aradaki TransientNumber2 servisi de aynı arayüzü talep ettiğinde container ilk ürettiğini kullanmaz, sıfırdan ikinci bir TransientNumber nesnesi daha oluşturur. Bu yüzden number1 ve number2 değerleri birbirinden farklı olur.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## 🟢 3. AddSingleton Çalışma Mantığı ve Örneği

### Kurulan Senaryo:
1. **`ISingletonNumber` & `SingletonNumber`:** Constructor'ında rastgele bir sayı üreterek `Number` property'sine atar.
2. **`SingletonNumberController`:** Constructor'ında `ISingletonNumber` servisini inject alır. 

### Gözlem ve Sonuç:
`GetSingletoNumber` endpoint'ine bir istek attığınızda ekrana bir sayı yazılacaktır. Sayfayı yenileyip defalarca yeni HTTP isteği atsanız dahi ekrana yazılan bu sayının hiç değişmediğini ve her zaman sabit kaldığını göreceksiniz.

💡 **Neden?** Çünkü uygulama ayağa kalktıktan sonra ISingletonNumber ilk talep edildiğinde hafızada tek bir SingletonNumber nesnesi üretir. Sayfayı her yenilediğinizde (yeni bir HTTP isteği attığınızda), container sıfırdan bir nesne üretmek yerine hafızada hazır bekleyen o ilk ve tek nesneyi controller'a vermeye devam eder. Bu yüzden uygulama durdurulup yeniden başlatılana kadar dönen sayı birebir aynı ve sabit kalır.
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
