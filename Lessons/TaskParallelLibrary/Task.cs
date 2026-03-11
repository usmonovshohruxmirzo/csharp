class FileItem
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int SizeMb { get; set; }
}

class FileResult
{
  public int FileId { get; set; }
  public bool Success { get; set; }
}
