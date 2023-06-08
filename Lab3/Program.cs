// Prompt the user to enter the array size
Console.Write("Enter the array size: ");
int size = int.Parse(Console.ReadLine());

// Create an array of integers
double[] numbers = new double[size];

// Prompt the user to enter the elements of the array
Console.WriteLine("Enter the elements of the array:");
for (int i = 0; i < size; i++)
{
    Console.Write($"Element {i + 1}: ");
    numbers[i] = int.Parse(Console.ReadLine());
}

// Reverse the array elements
Array.Reverse(numbers);

// Create a HashSet of doubles from the reversed array
HashSet<double> doublesSet = new HashSet<double>(numbers);

// Perform the operations on the HashSet
doublesSet.Add(4.5); // Add an element to the end of the list
doublesSet.Remove(2.5); // Remove an element from the list
doublesSet.Remove(3.5); // Remove an element that doesn't exist in the list
doublesSet.Add(6.5); // Replace an element in the list
List<double> sortedList = new List<double>(doublesSet);
sortedList.Sort(); // Sort the list in alphabetical order

// Print the elements of the list
Console.WriteLine("Elements of the list:");
foreach (double num in sortedList)
{
    Console.WriteLine(num);
}

try
{
    // Access an element outside the bounds of the array
    Console.WriteLine(numbers[size]);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("ArrayIndexOutOfBoundsException occurred!");
    Console.WriteLine(ex.Message);
}