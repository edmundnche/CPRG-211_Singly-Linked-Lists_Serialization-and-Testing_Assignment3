using Assignment3;
using Assignment3.Utility;
using NUnit.Framework;

namespace Assignment3.Tests
{


	[TestFixture]
	public class SLLTesting
	{
		private ILinkedListADT users;
		private SLL userSLL; 
		
		[SetUp]
		public void Setup()
		{
			this.users = new SLL();
			users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
			users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
			users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
			users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

		}

		[Test]
		public void TestAddFirst()
		{
			users.AddFirst(new User(0, "Noah Gallasic", "noah.gallasic@gmail.com", "123456"));

			string expectedName = users.GetValue(0).Name;

			Assert.AreEqual("Noah Gallasic", expectedName);

		}

		[Test]
		public void TestAddLast()
		{
			users.AddLast(new User(30, "Asfandyar Khan", "asfandyar-khan@yahoo.com", "963852"));
			string expectedName = users.GetValue(4).Name;
			Assert.That(expectedName, Is.EqualTo("Asfandyar Khan"));
		}

		[Test]
		public void TestAdd()
		{
			users.Add(new User(10, "Marklee Pinera", "marklee@sait.com", "98765400"), 2);
			string expectedName = users.GetValue(2).Name;
			Assert.That(expectedName, Is.EqualTo("Marklee Pinera"));
		}

		[Test]
		public void TestRemoveFirst()
		{
			users.RemoveFirst();
			string expectedName = users.GetValue(0).Name;
			Assert.That(expectedName, Is.EqualTo("Joe Schmoe"));
		}

		[Test]
		public void TestRemoveLast()
		{
			users.RemoveLast();
			string expectedName = users.GetValue(2).Name;
			int expectedSize = users.Count();
			Assert.That(expectedName, Is.EqualTo("Colonel Sanders"));
			Assert.That(expectedSize, Is.EqualTo(3));
		}

		[Test]
		public void TestRemove()
		{
			users.Remove(2);
			int expectedNumber = users.GetValue(2).Id;
			Assert.That(expectedNumber, Is.EqualTo(4));
		}

		[Test]
		public void TestSLLToArray()
		{
			User[] expectedArray = new User[]
			{
				new User(1, "Joe Blow", "jblow@gmail.com", "password"),
				new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"),
				new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"),
				new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999")
			};

			User[] actualArray = ((SLL)users).SLLToArray();
			CollectionAssert.AreEqual(actualArray, expectedArray);

		}

		[Test]
		public void TestDivided()
		{
			User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
			User user2 = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
			User user3 = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
			User user4 = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            		SLL users1 = new SLL();
			users1.AddLast(user1);
			users1.AddLast(user2);
			users1.AddLast(user3);
			users1.AddLast(user4);
            		SLL users2 = new SLL();
            		users2.AddLast(user1);
            		users2.AddLast(user2);
            		users2.AddLast(user3);
            		users2.AddLast(user4);
            		SLL users3 = new SLL();
            		users3.AddLast(user1);
            		users3.AddLast(user2);
            		users3.AddLast(user3);
            		users3.AddLast(user4);
            		//Test 1: divide from the middle
            		SLL newUsers1 = new SLL();
			newUsers1 = users1.Divided(2);

			int actualID1 = newUsers1.GetValue(1).Id;
			int expectedID1 = 4;

			//Test 2: divide from the beginning
			SLL newUsers2 = new SLL();
			newUsers2 = users2.Divided(1);

			int actualID2 = newUsers2.GetValue(0).Id;
			int expectedID2 = 2;

			//Test 3: divide at the end
			SLL newUsers3 = new SLL();
			newUsers3 = users3.Divided(3);
			
			int actualID3 = users3.GetValue(2).Id;
			int expectedID3 = 3;

            		// Testing 1
            		Assert.That(users1.Size, Is.EqualTo(2));
            		Assert.That(newUsers1.Size, Is.EqualTo(2));
            		Assert.That(expectedID1, Is.EqualTo(actualID1));
            		// Testing 2
            		Assert.That(users2.Size, Is.EqualTo(1));
            		Assert.That(newUsers2.Size, Is.EqualTo(3));
            		Assert.That(expectedID2, Is.EqualTo(actualID2));
            		// Testing 3
            		Assert.That(users3.Size, Is.EqualTo(3));
            		Assert.That(newUsers3.Size, Is.EqualTo(1));
            		Assert.That(expectedID3, Is.EqualTo(actualID3));
		}

		[Test]
		public void TestGetValue()
		{
    		int expectedIndex = users.GetValue(2).Id;
    		Assert.That(expectedIndex, Is.EqualTo(3));
		}

		[Test]
		public void IsEmptyTest()
		{
			Assert.IsFalse(users.IsEmpty());
		}

		[Test]
		public void ReplaceTest()
		{
			users.Replace(new User(9, "Eugene Krabs", "goldpile@hotmail.com", "moneymoney"), 2);
			string expected = "Eugene Krabs";
			string outputted = users.GetValue(2).Name;

			Assert.AreEqual(expected, outputted);
		}

		[Test]
		public void ReverseLinkedListTest()
		{
			userSLL = new SLL();
			userSLL.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            		userSLL.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            		userSLL.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            		userSLL.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

			Node<User> reversedList = userSLL.ReverseLinkedList();
			userSLL.Head = reversedList;

			int expected1 = 4;
			int expected2 = 3;
			int expected3 = 2;
			int expected4 = 1;

			int outputted1 = userSLL.GetValue(0).Id;
            		int outputted2 = userSLL.GetValue(1).Id;
            		int outputted3 = userSLL.GetValue(2).Id;
            		int outputted4 = userSLL.GetValue(3).Id;

			Assert.AreEqual(expected1, outputted1);
           		Assert.AreEqual(expected2, outputted2);
            		Assert.AreEqual(expected3, outputted3);
            		Assert.AreEqual(expected4, outputted4);
		}
	}
}
