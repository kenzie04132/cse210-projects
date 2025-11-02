using NUnit.Framework;
using prove_07;

public class Tests
{
    [Test]
    public void Test1AddLast1()
    {
        // Sample Test Cases (may not be comprehensive) 
        var list = InitializeLinkedList([5, 4, 3, 2, 2, 2, 1]);
        list.AddLast(0);
        int[] expected = [5, 4, 3, 2, 2, 2, 1, 0];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test1AddLast2()
    {
        var list = InitializeLinkedList([5, 4, 3, 2, 2, 2, 1, 0]);
        list.AddLast(-1);
        int[] expected = [5, 4, 3, 2, 2, 2, 1, 0, -1];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test2RemoveLast1()
    {
        var list = InitializeLinkedList([5, 4, 3, 2, 2, 2, 1, 0, -1]);
        list.RemoveLast();
        int[] expected = [5, 4, 3, 2, 2, 2, 1, 0];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test2RemoveLast2()
    {
        var list = InitializeLinkedList([5, 4, 3, 2, 2, 2, 1, 0]);
        list.RemoveLast();
        int[] expected = [5, 4, 3, 2, 2, 2, 1];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test3Remove1()
    {
        var list = InitializeLinkedList([5, 6, 4, 3, 35, 2, 2, 2, 1]);
        list.Remove(-1);
        int[] expected = [5, 6, 4, 3, 35, 2, 2, 2, 1];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test3Remove2()
    {
        var list = InitializeLinkedList([5, 6, 4, 3, 35, 2, 2, 2, 1]);
        list.Remove(3);
        int[] expected = [5, 6, 4, 35, 2, 2, 2, 1];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test3Remove3()
    {
        var list = InitializeLinkedList([5, 6, 4, 35, 2, 2, 2, 1]);
        list.Remove(6);
        int[] expected = [5, 4, 35, 2, 2, 2, 1];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test3Remove4()
    {
        var list = InitializeLinkedList([5, 4, 35, 2, 2, 2, 1]);
        list.Remove(1);
        int[] expected = [5, 4, 35, 2, 2, 2];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test3Remove5()
    {
        var list = InitializeLinkedList([5, 4, 35, 2, 2, 2]);
        list.Remove(5);
        int[] expected = [4, 35, 2, 2, 2];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test3Remove6()
    {
        var list = InitializeLinkedList([4, 35, 2, 2, 2]);
        list.Remove(2);
        int[] expected = [4, 35, 2, 2];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test4Replace1()
    {
        var list = InitializeLinkedList([4, 35, 2, 2]);
        list.Replace(2, 10);
        int[] expected = [4, 35, 10, 10];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test4Replace2()
    {
        var list = InitializeLinkedList([4, 35, 10, 10]);
        list.Replace(7, 5);
        int[] expected = [4, 35, 10, 10];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test4Replace3()
    {
        var list = InitializeLinkedList([4, 35, 10, 10]);
        list.Replace(4, 100);
        int[] expected = [100, 35, 10, 10];
        Assert.That(list, Is.EqualTo(expected));
    }

    [Test]
    public void Test5Reverse()
    {
        var list = InitializeLinkedList([100, 35, 10, 10]);
        int[] expected = [10, 10, 35, 100];
        Assert.That(list.Reverse(), Is.EqualTo(expected));
    }

    private static LinkedList InitializeLinkedList(int[] startingData)
    {
        var linkedList = new LinkedList();
        for (int i = startingData.Count() - 1; i >= 0; i--)
        {
            linkedList.AddFirst(startingData[i]);
        }

        return linkedList;
    }
}