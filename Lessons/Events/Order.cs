public class Order
{
  public event Action<string>? StatusChanged;

  public void SetStatus(string status)
  {
    Status = status;
    StatusChanged?.Invoke(status);
  }

  public string Status { get; private set; } = "Created";
}
