<div dir="rtl">
نام پترن: Strategy
<br>
هدف : الگوی Strategy مناسب سناریوهایی است که نیاز به تغییر یا انتخاب رفتار در زمان اجرا دارید، بدون اینکه تغییراتی در ساختار اصلی برنامه ایجاد شود. این الگو باعث انعطاف‌پذیری و قابلیت توسعه در کد شما می‌شود.

<br>
سناریوهای استفاده:
<br>
1.سیستم‌های پرداخت (Payment Processing Systems)
<br>
زمانی که چندین درگاه پرداخت وجود دارد و باید براساس نیاز کاربر یکی از آنها انتخاب شود.
<br>
مثال: انتخاب بین PayPal، Stripe، یا کارت‌های اعتباری بسته به محل یا نیاز کاربر.
<br>

2. اعتبارسنجی فرم‌ها (Form Validation)
<br>
وقتی فرم‌های مختلف نیاز به قوانین اعتبارسنجی متفاوت دارند.
<br>
مثال: فرم ثبت‌نام کاربران و فرم رزرو هتل هرکدام قوانین خاص خود را دارند.
<br>


</div>


الگوی طراحی Strategy یک الگوی رفتاری است که به شما امکان می دهد الگوریتم ها را در زمان اجرا انتخاب کنید. این الگو با تعریف یک خانواده از الگوریتم ها، کپسوله کردن هر یک و ایجاد قابلیت تعویض بین آنها، به شما کمک می کند تا کد خود را انعطاف پذیرتر و قابل نگهداری تر کنید. به طور خلاصه، الگوی Strategy به شما این امکان را می دهد که رفتار یک الگوریتم را از کلاینت هایی که از آن استفاده می کنند جدا کنید.

**اجزای اصلی الگوی Strategy:**
<div dir="rtl">*   **Context:** کلاسی که حاوی ارجاع به یک شی از نوع Strategy است. این کلاس اجرای وظایف را به استراتژی محول می کند و نیازی به دانستن جزئیات پیاده سازی استراتژی ندارد.
*   **Strategy Interface:** یک اینترفیس که یک روش مشترک برای همه استراتژی های مشخص تعریف می کند. این اینترفیس متدی را اعلان می کند که Context از آن برای اجرای یک استراتژی استفاده می کند.
*   **Concrete Strategies:** کلاس هایی که اینترفیس Strategy را پیاده سازی می کنند و هر کدام یک الگوریتم یا روش متفاوت برای انجام یک وظیفه را نشان می دهند.</div>


**اصول و سیاست های کلیدی الگوی Strategy:**

*   **کپسوله سازی تغییرات:** الگوی Strategy بخش های متغیر الگوریتم را از بخش های ثابت جدا می کند. به این معنی که تغییرات در الگوریتم بر کد کلاینت تاثیر نمی گذارد.
*   **برنامه نویسی بر اساس اینترفیس:** کلاینت با استراتژی از طریق یک اینترفیس تعامل می کند، نه مستقیماً با یک پیاده سازی مشخص. این به کلاینت امکان می دهد با هر استراتژی که اینترفیس را پیاده سازی می کند کار کند.
*  **ترجیح ترکیب بر ارث بری**: به جای ارث بردن رفتار، الگوی Strategy از ترکیب برای واگذاری مسئولیت به یک شی استراتژی استفاده می کند. این امر انعطاف پذیری بیشتری در انتخاب رفتار مناسب فراهم می کند.
*   **اصل باز/بسته:** سیستم باید برای توسعه باز باشد اما برای تغییر بسته. می توان استراتژی های جدید را بدون تغییر Context یا نحوه استفاده کلاینت از سیستم اضافه کرد.
*   **اصل مسئولیت واحد:** هر کلاس استراتژی یک مسئولیت واحد دارد که یک الگوریتم یا رفتار خاص را نشان می دهد. این امر باعث می شود که درک، پیاده سازی و تست آنها آسان تر شود.

**مثال عملی با کد:**
برای درک بهتر، یک سیستم پرداخت را در نظر بگیرید که از روش های مختلف پرداخت مانند کارت اعتباری، پی پال و ارز دیجیتال پشتیبانی می کند. در ابتدا، ممکن است سیستم تنها از پرداخت با کارت اعتباری پشتیبانی کند. کد زیر نحوه پیاده سازی بدون الگوی Strategy را نشان می دهد:

```csharp
public class PaymentProcessor
{
    public void ProcessPayment(decimal amount, string method)
    {
        if (method == "CreditCard")
        {
            // Logic to process credit card payment
            Console.WriteLine($"Processing {amount} via Credit Card");
        }
    }
}

// Usage
var paymentProcessor = new PaymentProcessor();
paymentProcessor.ProcessPayment(100.00m, "CreditCard");
```

حال، اگر بخواهیم پی پال را اضافه کنیم، باید یک شرط `if-else` دیگر به متد `ProcessPayment` اضافه کنیم:

```csharp
public class PaymentProcessor
{
    public void ProcessPayment(decimal amount, string method)
    {
        if (method == "CreditCard")
        {
            // Logic to process credit card payment
            Console.WriteLine($"Processing {amount} via Credit Card");
        }
        else if (method == "PayPal")
        {
            // Logic to process PayPal payment
            Console.WriteLine($"Processing {amount} via PayPal");
        }
        // As new payment methods are added, more if-else statements are added here
    }
}

// Usage
var paymentProcessor = new PaymentProcessor();
paymentProcessor.ProcessPayment(100.00m, "CreditCard");
paymentProcessor.ProcessPayment(75.50m, "PayPal");
```

این رویکرد مشکلات زیر را دارد:

*   **مقیاس پذیری:** با اضافه شدن روش های پرداخت جدید، متد `ProcessPayment` به طور نامحدود رشد می کند.
*   **قابلیت نگهداری:** متد `ProcessPayment` به مرور زمان پیچیده تر و مدیریت آن دشوارتر می شود.
*   **نقض اصل باز/بسته:** هر بار که یک نوع پرداخت جدید اضافه می شود، باید کلاس را تغییر دهیم.

برای حل این مشکلات، می توانیم از الگوی Strategy استفاده کنیم. در اینجا نحوه پیاده سازی با الگوی Strategy آمده است:

ابتدا، یک اینترفیس به نام `IPaymentStrategy` تعریف می کنیم:

```csharp
public interface IPaymentStrategy
{
    void ProcessPayment(decimal amount);
}
```

سپس، کلاس های Concrete Strategy را پیاده سازی می کنیم:

```csharp
public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        // Logic to process Credit Card payment
        Console.WriteLine($"Processing {amount} via Credit Card");
    }
}

public class PayPalPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        // Logic to process PayPal payment
        Console.WriteLine($"Processing {amount} via PayPal");
    }
}
```

در نهایت، کلاس Context را پیاده سازی می کنیم:

```csharp
public class PaymentProcessor
{
    private IPaymentStrategy _paymentStrategy;

    public PaymentProcessor(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(decimal amount)
    {
        _paymentStrategy.ProcessPayment(amount);
    }
}
```

نحوه استفاده از کد بالا:

```csharp
var creditCardPayment = new PaymentProcessor(new CreditCardPaymentStrategy());
creditCardPayment.ProcessPayment(100.00m);  // Output: Processing 100.00 via Credit Card

var payPalPayment = new PaymentProcessor(new PayPalPaymentStrategy());
payPalPayment.ProcessPayment(75.50m);  // Output: Processing 75.50 via PayPal
```

برای اضافه کردن یک روش پرداخت جدید، مانند ارز دیجیتال، فقط کافی است یک کلاس جدید ایجاد کنید که اینترفیس `IPaymentStrategy` را پیاده سازی کند:

```csharp
public class CryptoPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing {amount} via Cryptocurrency");
        // Actual cryptocurrency processing logic
    }
}
```

و از آن استفاده کنید:
```csharp
var cryptoPayment = new PaymentProcessor(new CryptoPaymentStrategy());
cryptoPayment.ProcessPayment(50.00m);  // Output: Processing 50.00 via Cryptocurrency
```

**مزایای استفاده از الگوی Strategy:**

*   **سهولت توسعه:** اضافه کردن یک روش پرداخت جدید فقط به ایجاد یک کلاس جدید نیاز دارد و نیازی به تغییر کد موجود نیست.
*   **رعایت اصل باز/بسته:** سیستم برای توسعه باز است اما برای تغییر بسته است. می توانید روش های پرداخت جدید را بدون تغییر کلاس های موجود اضافه کنید.
*   **سادگی و قابلیت نگهداری:** کلاس `PaymentProcessor` ساده می ماند و با اضافه شدن روش های پرداخت جدید، پیچیده تر نمی شود. هر روش پرداخت در کلاس خود کپسوله می شود، که درک و نگهداری سیستم را آسان تر می کند.

به طور خلاصه، الگوی Strategy روشی منعطف و قابل نگهداری برای مدیریت الگوریتم ها و رفتارهای متغیر در نرم افزار فراهم می کند.
