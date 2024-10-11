namespace Phonebook.Tests
{
  public class Tests
  {
    private Phonebook phonebook;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
      this.phonebook = new Phonebook();
    }

    [Test]
    public void Test1()
    {
      Assert.Pass();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      this.phonebook = null;
    }
  }
}