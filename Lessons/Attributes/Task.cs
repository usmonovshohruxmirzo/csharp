using System.Net.NetworkInformation;

namespace Task
{
  [AttributeUsage(AttributeTargets.Property)]
  class RequiredAttribute(string errorMessage = "This field is required") : Attribute
  {
    public string ErrorMessage { get; } = errorMessage;
  }

  class StringLengthAttribute(int min, int max, string errorMessage = "This field is required") : Attribute
  {
    public int Min { get; set; } = min;
    public int Max { get; set; } = max;
    public string ErrorMessage { get; } = errorMessage;
  }

  public class Task
  {
    public static void Run()
    {
      var form = new UserForm { Username = "Al", Password = "" };
      var errors = FormValidator.Validate(form);

      foreach (var err in errors)
        Console.WriteLine(err);
    }
  }

  public class FormValidator
  {
    public static <T> Validate(T obj)
    {

    }
  }

  class UserForm
  {
    [Required("Username is required")]
    [StringLength(3, 10, "Username must be 3-10 chars")]
    public string Username { get; set; } = "";

    [Required]
    [StringLength(5, 100)]
    public string Password { get; set; } = "";

    public int Age { get; set; }
  }
}
