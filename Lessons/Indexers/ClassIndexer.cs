namespace Indexers
{
  public class ClassIndexer
  {
    public static readonly int[] num = [1, 2, 3];

    public int this[int index]
    {
      get => num[index];
    }

    public string this[string number]
    {
      get => number switch
      {
        "1" => "One",
        "2" => "Two",
        _ => "Unknown"
      };
    }
  }

  public class Sentence
  {
    string[] words = "The quick brown fox".Split();

    public string this[Index index] => words[index];
    public string[] this[Range range] => words[range];
  }
}
