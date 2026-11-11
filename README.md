<div dir="rtl">

# 💻 السي شارب المتقدم — المحاضرة 01: الأنواع المعممة (Generics)، القيود (Constraints)، والـ Variance
### Advanced C# 01: Generics Internals, Type Constraints, Covariance/Contravariance & Generic Cache<TKey,TValue>

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Module](https://img.shields.io/badge/Module-03_Advanced_CSharp-0284c7?style=for-the-badge)](#)
[![Interactive Guide](https://img.shields.io/badge/%F0%9F%8C%90_Live_Study_Guide-HTML_Interactive-8b5cf6?style=for-the-badge)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-01/blob/master/Study_Guide/Generics_Deep_Part1_Core.html)

> **نبذة عن المشروع:** ⚡ [03 Advanced C# - Session 01] Generics Deep Dive (14 Source Files / 20 Tasks): Generic Cache<TKey,TValue> with TTL, IRepository<T>, SafeList<T>, Type Constraints & Covariance/Contravariance + 3 HTML Guides.

---

## 🌐 الدليل التفاعلي المشروح بالـ HTML (Interactive Study Guide)

تم تضمين الدليل التفاعلي المشروح بالكامل داخل مجلد [`Study_Guide/`](./Study_Guide) في هذا المستودع، ويمكنك قراءته مباشرة في المتصفح عبر الروابط التالية:

- 🌐 الدليل التفاعلي (1/3): الأساس وميكانيزم Generics في الـ CLR (HTML): **[🌐 معاينة حية في المتصفح (Live Preview)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-01/blob/master/Study_Guide/Generics_Deep_Part1_Core.html)** | **[📄 فتح ملف الـ HTML في المستودع](./Study_Guide/Generics_Deep_Part1_Core.html)**
- 🌐 الدليل التفاعلي (2/3): قيود الأنواع Constraints & Variance (HTML): **[🌐 معاينة حية في المتصفح (Live Preview)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-01/blob/master/Study_Guide/Generics_Deep_Part2_Constraints_Variance.html)** | **[📄 فتح ملف الـ HTML في المستودع](./Study_Guide/Generics_Deep_Part2_Constraints_Variance.html)**
- 🌐 الدليل التفاعلي (3/3): حل الـ 20 سؤالاً وتمارين الكود (HTML): **[🌐 معاينة حية في المتصفح (Live Preview)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-01/blob/master/Study_Guide/Generics_Deep_Part3_Quiz_Refs.html)** | **[📄 فتح ملف الـ HTML في المستودع](./Study_Guide/Generics_Deep_Part3_Quiz_Refs.html)**
- 📂 **[فتح مجلد المحاضرة المحلي الكامل في `nots` (للتصفح المحلي على الجهاز)](../../../../nots/03_Advanced-CSharp/Session_01_Generics)**

---

### 🧠 الملاحظات الهندسية والمفاهيم المعمارية (Engineering Notes)
1. **كيف ينفذ الـ CLR الـ Generics عبر `Reification` (مقابل `Type Erasure` في Java)؟**
   - يحتفظ `.NET` بمعلومات النوع المعمم `T` في الـ IL ووقت التشغيل. عند استخدام `Value Type` (مثل `Container<int>`)، يولد الـ JIT كود آلة مخصصاً (`Specialized Native Code`) بحجم الـ `int` الفعلي **بدون أي Boxing أو Unboxing**! بينما تتشارك جميع الـ `Reference Types` نفس الكود المترجم لأن حجم المؤشر ثابت (8 بايت).
2. **الحقول الساكنة في الأنواع المعممة (`Static Fields per Closed Generic Type`):**
   - كل نوع مغلق (`Closed Constructed Type`) مثل `Container<int>` و `Container<string>` يمتلك نسخة مستقلة خاصة به من الحقول الـ `static`!
3. **قيود الأنواع (`Generic Constraints`) والـ `Variance`:**
   - فرض شروط صارمة وقت الترجمة عبر `where T : struct`, `where T : class`, `where T : new()`, `where T : BaseClass`, و `where T : IComparable<T>`.
   - **Covariance (`out T`):** يسمح بإسناد `IProducer<Derived>` إلى `IProducer<Base>` لأن `T` يستخدم للإخراج فقط.
   - **Contravariance (`in T`):** يسمح بإسناد `IConsumer<Base>` إلى `IConsumer<Derived>` لأن `T` يستخدم كمدخل فقط.
4. **مشروع `Cache<TKey, TValue>` المتكامل مع صلاحية زمنية (`TTL Expiration`):**
   - بناء نظام تخزين مؤقت معمم يدعم إضافة العناصر مع وقت انتهاء الصلاحية (`TimeSpan`)، الفحص التلقائي، والإزالة الكسولة للعناصر المنتهية.

---

## 🗂️ هيكلة الكود والتمارين التطبيقية المحلولة

| الملف المصدري | المفهوم الهندسي المطبق |
| :--- | :--- |
| [`Cache.cs`](./Advanced-CSharp-01/Cache.cs) & [`CacheItem.cs`](./Advanced-CSharp-01/CacheItem.cs) | نظام `Cache<TKey, TValue>` المتكامل مع إدارة انتهاء الصلاحية `Expiration Time (TTL)` (السؤال 20). |
| [`Container.cs`](./Advanced-CSharp-01/Container.cs) & [`Pair.cs`](./Advanced-CSharp-01/Pair.cs) | بناء الكلاسات المعممة أحادية ومتعددة المعاملات `Container<T>` و `Pair<TKey, TValue>`. |
| [`GenericUtilities.cs`](./Advanced-CSharp-01/GenericUtilities.cs) | دوال `Swap<T>`, `FindMax<T>`, و `DefaultValue<T>` باستخدام `default(T)`. |
| [`IRepository.cs`](./Advanced-CSharp-01/IRepository.cs) & [`SafeList.cs`](./Advanced-CSharp-01/SafeList.cs) | واجهة المستودع المعمم `IRepository<T>` وقائمة محمية الحدود `SafeList<T>`. |
| [`StructConstraintExample.cs`](./Advanced-CSharp-01/StructConstraintExample.cs), [`ClassConstraintExample.cs`](./Advanced-CSharp-01/ClassConstraintExample.cs), [`NewConstraintExample.cs`](./Advanced-CSharp-01/NewConstraintExample.cs), [`InterfaceConstraintExample.cs`](./Advanced-CSharp-01/InterfaceConstraintExample.cs), [`MultipleConstraintsExample.cs`](./Advanced-CSharp-01/MultipleConstraintsExample.cs) | تطبيق جميع أنواع القيود (`where T : struct, class, new(), IComparable<T>`). |
| [`VarianceExamples.cs`](./Advanced-CSharp-01/VarianceExamples.cs) | أمثلة عملية على **Covariance (`out T`)** و **Contravariance (`in T`)**. |

---

## 🧭 خريطة مسار هندسة `.NET` الكامل على GitHub

| # | المرحلة (Module) | المستودع (Repository) | الموضوع الرئيسي | الدليل التفاعلي (Live HTML) |
| :---: | :--- | :--- | :--- | :---: |
| **01** | `01_CSharp_Basics` | **[`CSharp-Basics02-Assigment`](https://github.com/mohamedadel452/CSharp-Basics02-Assigment)** | أنواع البيانات، نموذج الكائنات (System.Object)، والتحويلات | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics02-Assigment/blob/master/Study_Guide/CSharp_Basics_Session02_Guide.html) |
| **02** | `01_CSharp_Basics` | **[`CSharp-Basics03-Assigment`](https://github.com/mohamedadel452/CSharp-Basics03-Assigment)** | معمارية النصوص (Strings & StringBuilder)، جمل التحكم، والحلقات | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics03-Assigment/blob/master/Study_Guide/CSharp_Basics_Session03_Guide.html) |
| **03** | `01_CSharp_Basics` | **[`CSharp-Basics04-Assigment`](https://github.com/mohamedadel452/CSharp-Basics04-Assigment)** | المصفوفات (1D & 2D Arrays) وتمرير المعاملات للدوال (Value / ref / out / params) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics04-Assigment/blob/master/Study_Guide/CSharp_Basics_Session04_Guide.html) |
| **04** | `01_CSharp_Basics` | **[`CSharp-Basics05-Assigment`](https://github.com/mohamedadel452/CSharp-Basics05-Assigment)** | محددات الوصول (Access Modifiers)، التغليف، والـ Enums | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics05-Assigment/blob/master/Study_Guide/CSharp_Basics_Session05_Guide.html) |
| **05** | `02_OOP` | **[`OOP-Session-01-Assigment`](https://github.com/mohamedadel452/OOP-Session-01-Assigment)** | الـ Struct، التغليف، الخصائص، والـ Indexers (نظام Smart Delivery) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-01-Assigment/blob/master/Study_Guide/OOP_Session01_Deep_Dive.html) |
| **06** | `02_OOP` | **[`OOP-Session-02-Assigment`](https://github.com/mohamedadel452/OOP-Session-02-Assigment)** | الفئات (Classes)، الوراثة، وتسلسل الـ Constructors (Smart Delivery Part 1) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-02-Assigment/blob/master/Study_Guide/OOP_Session02_Deep_Dive.html) |
| **07** | `02_OOP` | **[`OOP-Session-03-Assigment`](https://github.com/mohamedadel452/OOP-Session-03-Assigment)** | تعدد الأشكال (Polymorphism)، الربط الديناميكي، والكلاسات المختومة (Sealed) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-03-Assigment/blob/master/Study_Guide/OOP_Session03_04_Dispatch_&_SOLID_Deep_Dive.html) |
| **08** | `02_OOP` | **[`OOP-Session-04-Assigment`](https://github.com/mohamedadel452/OOP-Session-04-Assigment)** | التجريد (Abstraction)، الفئات المجردة، والواجهات (Smart Delivery Part 3) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-04-Assigment/blob/master/Study_Guide/OOP_Session04_Deep_Dive.html) |
| **09** | `02_OOP` | **[`OOP-Session-05-Assigment`](https://github.com/mohamedadel452/OOP-Session-05-Assigment)** | نسخ الكائنات، Static، دوال التوسيع، والـ Partial Classes (Smart Delivery Final) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-05-Assigment/blob/master/Study_Guide/OOP_Session05_Deep_Dive.html) |
| **10** | `03_Advanced_CSharp` | **[`Advanced-CSharp-01`](https://github.com/mohamedadel452/Advanced-CSharp-01)** | الأنواع المعممة (Generics)، القيود (Constraints)، والـ Variance | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-01/blob/master/Study_Guide/Generics_Deep_Part1_Core.html) |
| **11** | `03_Advanced_CSharp` | **[`Advanced-CSharp-02`](https://github.com/mohamedadel452/Advanced-CSharp-02)** | المفوضات (Delegates)، تعبيرات Lambda، ونظام ShopMaster | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-02/blob/master/Study_Guide/Delegates_Part1_Core.html) |
| **12** | `03_Advanced_CSharp` | **[`Advanced-CSharp-03`](https://github.com/mohamedadel452/Advanced-CSharp-03)** | معمارية هياكل البيانات والـ Collections (6 أنظمة تطبيقية) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-03/blob/master/Study_Guide/session03-part1-collections-list.html) |
| **13** | `04_Database` | **[`Database-Session-01-Assigment`](https://github.com/mohamedadel452/Database-Session-01-Assigment)** | تصميم قواعد البيانات، مخططات الـ ERD، والتحويل العلائقي (Relational Mapping) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Database-Session-01-Assigment/blob/master/Study_Guide/ERD_Part1_Design_Intro.html) |

---

## 🚀 طريقة التشغيل المحلي (How to Run)

```bash
git clone https://github.com/mohamedadel452/Advanced-CSharp-01.git
cd Advanced-CSharp-01
dotnet run --project "Advanced-CSharp-01/Advanced-CSharp-01.csproj"
```

**إعداد وتطوير:** [محمد عادل محمد بيومي (mohamedadel452)](https://github.com/mohamedadel452) — كلية الحاسبات والمعلومات، جامعة عين شمس.

</div>
