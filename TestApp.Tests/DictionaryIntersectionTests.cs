using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dictionary1 = new Dictionary<string, int>();
        Dictionary<string, int> dictionary2 = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> intersection = DictionaryIntersection.Intersect(dictionary1, dictionary2);

        // Assert
        Assert.That(intersection, Is.Empty);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dictionary1 = new Dictionary<string, int>();
        Dictionary<string, int> dictionary2 = new Dictionary<string, int>()
        {
            {"one", 1 },
            {"two", 2 }
        };

        // Act
        Dictionary<string, int> intersection = DictionaryIntersection.Intersect(dictionary1, dictionary2);

        // Assert
        Assert.That(intersection, Is.Empty);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dictionary1 = new Dictionary<string, int>()
        {
            {"five", 5 },
            {"ten", 10 }

        };
        Dictionary<string, int> dictionary2 = new Dictionary<string, int>()
        {
            {"one", 1 },
            {"two", 2 }
        };

        // Act
        Dictionary<string, int> intersection = DictionaryIntersection.Intersect(dictionary1, dictionary2);

        // Assert
        Assert.That(intersection, Is.Empty);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> dictionary1 = new Dictionary<string, int>()
        {
            {"banana", 5 },
            {"lemon", 10 },
            {"kiwi", 3}

        };
        Dictionary<string, int> dictionary2 = new Dictionary<string, int>()
        {
            {"banana", 5 },
            {"lemon", 2 },
            {"kiwi", 3 }
        };
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            {"banana", 5 },
            {"kiwi", 3 }
        };

        // Act
        Dictionary<string, int> intersection = DictionaryIntersection.Intersect(dictionary1, dictionary2);

        // Assert
        CollectionAssert.AreEqual(expected, intersection);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dictionary1 = new Dictionary<string, int>()
        {
            {"banana", 5 },
            {"lemon", 10 }

        };
        Dictionary<string, int> dictionary2 = new Dictionary<string, int>()
        {
            {"banana", 1 },
            {"lemon", 2 }
        };

        // Act
        Dictionary<string, int> intersection = DictionaryIntersection.Intersect(dictionary1, dictionary2);

        // Assert
        Assert.That(intersection, Is.Empty);
    }
}
