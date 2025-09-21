using System;
using System.Security.AccessControl;

namespace ConsoleApp1;

public class LearningGenerics
{
	public LearningGenerics()
	{
		int [] intArray = { 1, 2, 3, 4, 5 };
		string [] stringArray = { "Hello", "World" };
		char [] charArray = { 'A', 'B', 'C', 'D' };

		PrintArray<int>(intArray);
		PrintArray<string>(stringArray);
		PrintArray<char>(charArray);

		PrintArray(intArray); // Type inference

		TestMultipleGenericParameters<string, int>("B", 2);
		TestMultipleGenericParameters<string, string>("A", "Apple");
		TestMultipleGenericParameters<int, string>(1, "One");

		var genericInt = new GenericClassWithConstraint<int>(10);
		var genericString = new GenericClassWithConstraint<string>("Hello");
		Console.WriteLine(genericInt.IsGreaterThan(5)); // True
		Console.WriteLine(genericString.IsGreaterThan("Apple")); // True
    }
	public static void PrintArray<T>(T[] items)
	{
		foreach (var item in items)
		{
			Console.Write(item + " ");
		}
		Console.WriteLine();
    }
	private static void TestMultipleGenericParameters<K, V>(K key, V value)
	{
		Console.WriteLine($"Key: {key}, Value: {value}");
    }
    // class with generic constraint
	public class GenericClassWithConstraint<T> where T : IComparable
	{
		private T value;
		public GenericClassWithConstraint(T value)
		{
			this.value = value;
		}
		public bool IsGreaterThan(T other)
		{
			return value.CompareTo(other) > 0;
		}
    }
}
