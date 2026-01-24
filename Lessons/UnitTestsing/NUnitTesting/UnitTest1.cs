namespace NUnitTesting
{
  [TestFixture]
  public class Tests
  {
    private Calculator _calculator;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      TestContext.Out.WriteLine("OneTimeSetUp: Runs once before all tests.");
    }

    [SetUp]
    public void SetUp()
    {
      _calculator = new Calculator();
    }

    [TearDown]
    public void TearDown()
    {
      TestContext.Out.WriteLine("TearDown: Runs after each test.");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      TestContext.Out.WriteLine("OneTimeTearDown: Runs once after all tests.");
    }

    [Test]
    public void Add_ReturnCorrectSum()
    {
      // Arrange
      int a = 5;
      int b = 8;

      // Act
      int result = _calculator.Add(a, b);

      // Assert
      Assert.That(result, Is.EqualTo(13));
    }

    [Test]
    public void Divide_ReturnDivideByZeroException()
    {
      // Arrange
      int a = 5;
      int b = 0;

      // Act & Assert
      Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }

    [Test]
    public void Add_MultipleAssertions()
    {
      Assert.Multiple(() =>
      {
        Assert.That(_calculator.Add(5, 5), Is.EqualTo(10));
        Assert.That(_calculator.Add(5, 15), Is.EqualTo(20));
      });
    }

    [TestCase(1, 2, 3)]
    [TestCase(-1, 1, 0)]
    [TestCase(0, 0, 0)]
    public void Add_TestCases(int a, int b, int expacted)
    {
      // Act & Arrange
      int result = _calculator.Add(a, b);

      // Assert
      Assert.That(expacted, Is.EqualTo(result));
    }

    [Test, TestCaseSource(nameof(AddTestCases))]
    public void Add_TestCaseSource(int a, int b, int expacted)
    {
      // Act & Arrange
      int result = _calculator.Add(a, b);

      // Assert
      Assert.That(result, Is.EqualTo(expacted));
    }

    private static IEnumerable<TestCaseData> AddTestCases()
    {
      yield return new TestCaseData(1, 2, 3);
      yield return new TestCaseData(2, 3, 5);
      yield return new TestCaseData(-1, -2, -3);
    }

    [Test]
    public async Task AddAsync_ReturnCorrectSum()
    {
      int result = await _calculator.AddAsync(5, 5);
      Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    [Ignore("Not implemented yet")]
    public void TestFeature()
    {
      // test code
    }
  }
}
