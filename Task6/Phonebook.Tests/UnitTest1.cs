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


    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      this.phonebook = null;
    }

    [Test]
    public void AddSubscriber_NewSubscriber_AddedSuccessfully()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());

      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.That(this.phonebook.GetSubscriber(subscriberId), Is.EqualTo(expectedSubscriber));
    }

    [Test]
    public void AddSubscriber_NewSubscriberWithoutId_ThrowsArgumentNullException()
    {
      var subscriberId = Guid.Empty;
      var subscriberName = "Julia";

      Assert.Throws<ArgumentNullException>(()=> new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>()));
    }

    [Test]
    public void AddSubscriber_NewSubscriberWithoutName_ThrowsArgumentNullException()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = string.Empty;
      
      Assert.Throws<ArgumentNullException>(()=> new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>()));
    }
    
    [Test]
    public void AddSubscriber_SubscriberAlreadyExists_ThrowsInvalidOperationException()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());

      Assert.Throws<InvalidOperationException>(()=>
      {
        this.phonebook.AddSubscriber(expectedSubscriber);
        this.phonebook.AddSubscriber(expectedSubscriber);
      });
    }
    
    [Test]
    public void AddSubscriber_SubscriberWithInvalidNumber_ThrowsArgumentException()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";

      Assert.Throws<ArgumentException>(() => this.phonebook.AddSubscriber(new Subscriber(subscriberId, 
        subscriberName, new List<PhoneNumber>() 
      { new PhoneNumber("66516546", PhoneNumberType.Personal) })));
    }

    [Test]
    public void AddNumberToSubscriber_AddedSuccessfully()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
      var newPhoneNumber = new PhoneNumber("+7(951)208-4428", PhoneNumberType.Personal);

      this.phonebook.AddSubscriber(expectedSubscriber);
      this.phonebook.AddNumberToSubscriber(expectedSubscriber, newPhoneNumber);

      Assert.That(this.phonebook.GetSubscriber(subscriberId), Is.EqualTo(expectedSubscriber));
    }

    [Test]
    public void AddNumberToSubscriber_NumberIsEmpty_ThrowsArgumentException()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
      var newPhoneNumber = new PhoneNumber(string.Empty, PhoneNumberType.Personal);

      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.Throws<ArgumentException>(() => this.phonebook.AddNumberToSubscriber(expectedSubscriber, newPhoneNumber));
    }

    [Test]
    public void AddNumberToSubscriber_NumberHasIncorrectFormat_ThrowsArgumentException()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
      var newPhoneNumber = new PhoneNumber("+7951208-4428", PhoneNumberType.Personal);

      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.Throws<ArgumentException>(() => this.phonebook.AddNumberToSubscriber(expectedSubscriber, newPhoneNumber));
    }

    [Test]
    public void AddNumberToSubscriber_NumberAlreadyExists_ThrowsArgumentException()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var newPhoneNumber = new PhoneNumber("+7(951)208-4428", PhoneNumberType.Personal);
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>() { newPhoneNumber});

      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.Throws<ArgumentException>(() => this.phonebook.AddNumberToSubscriber(expectedSubscriber, newPhoneNumber));
    }
    
    [Test]
    public void RenameSubscriber_RenameSuccessfully()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
      var newName = "Yulia";

      this.phonebook.AddSubscriber(expectedSubscriber);
      this.phonebook.RenameSubscriber(expectedSubscriber, newName);

      Assert.That(this.phonebook.GetSubscriber(subscriberId), Is.EqualTo(expectedSubscriber));
    }
    
    [Test]
    public void RenameSubscriber_WithEmptyName_ThrowsArgumentNullException()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
      var newName = string.Empty;

      this.phonebook.AddSubscriber(expectedSubscriber);
      
      Assert.Throws<ArgumentNullException>(() => this.phonebook.RenameSubscriber(expectedSubscriber, newName));
    }

    [Test]
    public void RenameSubscriber_WithOldName_ThrowsArgumentNullException()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());

      this.phonebook.AddSubscriber(expectedSubscriber);
      
      Assert.Throws<ArgumentException>(() => this.phonebook.RenameSubscriber(expectedSubscriber, subscriberName));
    }

    [Test]
    public void DeleteSubscriber_DeleteSuccessfully()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());

      this.phonebook.AddSubscriber(expectedSubscriber);
      this.phonebook.DeleteSubscriber(expectedSubscriber);

      Assert.Throws<InvalidOperationException>(() => this.phonebook.GetSubscriber(subscriberId));
    }

    [Test]
    public void GetSubscriber_GetSuccessfully()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());

      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.That(expectedSubscriber, Is.EqualTo(this.phonebook.GetSubscriber(subscriberId)));
    }

    [Test]
    public void GetSubscriber_WithEmptyId_ThrowsInvalidOperationException()
    {
      var subscriberId = Guid.NewGuid();
      var subscriberName = "Julia";
      var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());

      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.Throws<InvalidOperationException>(() => this.phonebook.GetSubscriber(Guid.Empty));
    }


  }
}