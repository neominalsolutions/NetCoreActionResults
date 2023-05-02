using Microsoft.AspNetCore.Mvc;
using NetCoreActionResults.Models;

namespace NetCoreActionResults.Views.Shared.Components.Test
{
  /// <summary>
  /// 1.Kural: view componentler viewcomponent kalıtım alır
  /// 2.Kural: view componentler içerisinde sadece 1 method bulunur ve adı InvokeAsync olarak tanımlanır
  /// 3.Kural: view componentler performans amaçlı async task formatında tanımlanır. asenkrondur.
  /// </summary>
  public class TestViewComponent:ViewComponent
  {
    // title değeri gönderek yada title parametresi boş geçilerek çağırabiliriz.
    public async Task<IViewComponentResult> InvokeAsync(string? title)
    {

      // ilgili db işlemleri vs yapılıp veri controller yerine bu method içerisinde çekilerek view model olarak gönderilir.
      // yani view'un ihtiyaç duyduğu model bu class olarak controller actiondan izole bir şekilde tanımlanır.

      var model = new ViewComponentViewModel();
      model.Title = title ?? "ViewComponent";
      // default html döndürür.
      // ?? işareti kendinden önce gelen değerin null olup olmamasını kontrol eder.
      // null ise ViewComponent string döner null değilse title parametresinin değeri döner.
      return View(model);
    }
  }
}
