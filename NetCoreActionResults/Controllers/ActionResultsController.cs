using Microsoft.AspNetCore.Mvc;
using NetCoreActionResults.Models;

namespace NetCoreActionResults.Controllers
{
  public class ActionResultsController : Controller
  {
    /// <summary>
    /// string html static bir içeriği ekranda göstermek için kullanılan bir result
    /// </summary>
    /// <returns></returns>

    [HttpGet("html-result", Name = "htmlResultRoute")]
    public ContentResult HtmlContent()
    {
      //return new ContentResult()
      return Content("<p>Content Result</p>","text/html");
    }

    /// <summary>
    /// Partialview ise tanımlanmış olan bir html'i arayüzde bir parça halinde göstermek için kullanılır. partial view html içeriği kendi sayfasında üretilir.
    /// </summary>
    /// <returns></returns>
    [HttpGet("partial-result", Name ="partialResultRoute")]
    public PartialViewResult Partial()
    {
      var model = new PartialViewModel();

      //return PartialView("~/Views/Home/Partials/_TestPartial.cshtml", model);
      // shared klasörü altından klasör ismi view ismi şeklinde çağırabiliriz.
      return PartialView("Partials/_TestPartial",model);
    }

    /// <summary>
    /// ViewComponentler Shared Components klasörü altından çağırılırlar
    /// ViewComponentler partialview çok benzer fakat partialviewden daha bağımsız yapılardır.
    /// </summary>
    /// <returns></returns>

    [HttpGet("view-component-result", Name = "viewComponentResultRoute")]
    public ViewComponentResult ViewComponentResult()
    {
      return ViewComponent("Test");
    }

    [HttpGet("users", Name ="viewResultRoute")]
    public ViewResult Users()
    {
      var users = new List<UserViewModel>();
      users.Add(new UserViewModel { Id = 1, Email = "test1@test.com", UserName = "test1" });
      users.Add(new UserViewModel { Id = 2, Email = "test2@test.com", UserName = "test2" });
      users.Add(new UserViewModel { Id = 3, Email = "test3@test.com", UserName = "test3" });


      return View(users);
    }

    /// <summary>
    /// Uygulama AJAX gibi yapılar ile sayfa yenilenmeden javascript kodu ile arayüzde güncelleme yapmamız gereken durumlarda tercih edilen bir result tipidir. Uygula içinde yazılmış başka uygulamaların besleneceği bir servis gibi de kullanılabilir.
    /// like,comment,paylaş gibi arayüzde sayfa yenilenmeden yapılması gereken işlemler için tercih ederiz.
    /// json Resultların kendine ait bir view olmaz bir view içerisinde viewcomponent gibi veya partial gibi çağırılırlar. Tek değişiklik js olarak çağırılmalarıdır.
    /// AJAX için FromBody yazmayı unutmayalım !
    /// Fetch işlemlerinde post ederken FromBody attribute yazmamıza gerek yok.
    /// </summary>
    /// <returns></returns>
    /// 
    [HttpPost("json-result", Name ="jsonResultRoute")]
    public JsonResult JsonResult([FromBody] UserInputModel data)
    {

      // veri tabanı işlemleri kayıt update işlemleri

      var result = new JsonViewModel
      {
        IsSucceded = true,
        Message = "İşlem Başarılı"

      };


      return Json(result);
    }


    [HttpGet("file-result", Name ="fileResultRoute")]
    public FileResult FileResult()
    {
      return File("~/docs/NET-Microservices-Architecture-for-Containerized-NET-Applications.pdf","application/pdf");
    }

    [HttpGet("unauthorized-result", Name = "unAuthorizedResultRoute")]
    public UnauthorizedResult UnauthorizedResult()
    {
      return Unauthorized(); // 401 sayfası döndürür.
    }


    [HttpGet("notfound-result", Name = "notFoundResultRoute")]
    public NotFoundResult NotFoundResult()
    {
      // kaynak link bulunamadığı zaman döndüreceğimiz result tipi
      return NotFound();
    }



    [HttpGet("redirect-result", Name ="redirectResultRoute")]
    public RedirectResult RedirectResult()
    {
      //return RedirectToAction("Privacy","Home");
      
      return Redirect("/Home/Privacy");
    }

    [HttpGet("redirect-route-result", Name ="redirectRouteResultRoute")]
    public RedirectToRouteResult RedirectRouteResult()
    {
      return RedirectToRoute("htmlResultRoute");
    }



  }
}
