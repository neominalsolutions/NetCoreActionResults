using System.Text.Json.Serialization;

namespace NetCoreActionResults.Models
{
  // JSONResult ile formdan veri post işlemi için kullanılacaktır.
  public class UserInputModel
  {


    public string UserName { get; set; }


    public string Email { get; set; }

  }
}
