using Lab4;
using System.Reflection;

Semaphore semaphore = new Semaphore(2, 2); // Allow only 2 threads to access the resource


// a) Use Semaphore to limit thread access to a shared resource
for (int i = 1; i <= 5; i++)
{
    int threadId = i;
    Thread t = new Thread(() => AccessSharedResource(threadId));
    t.Start();
}

// b) Create a custom class, print its methods, and invoke a specific method
CustomClass customObj = new CustomClass();
PrintMethods(customObj);
InvokeMethod(customObj, "TestMethod");

// c) Create a generic interface and implement it with a concrete class
MyGenericInterface<int> myObj = new MyGenericClass<int>();
myObj.GenericMethod(10);

void AccessSharedResource(int threadId)
{
    Console.WriteLine("Thread " + threadId + " waiting to access the shared resource.");
    semaphore.WaitOne();

    Console.WriteLine("Thread " + threadId + " accessing the shared resource.");
    Thread.Sleep(2000); // Simulating some work

    Console.WriteLine("Thread " + threadId + " releasing the shared resource.");
    semaphore.Release();
}

void PrintMethods(object obj)
{
    Console.WriteLine("Methods of the class:");

    Type type = obj.GetType();
    MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

    foreach (MethodInfo method in methods)
    {
        Console.WriteLine("Name: " + method.Name + ", Return Type: " + method.ReturnType.Name);
    }
}

void InvokeMethod(object obj, string methodName)
{
    Type type = obj.GetType();
    MethodInfo method = type.GetMethod(methodName);

    if (method != null)
    {
        Console.WriteLine("Invoking method: " + method.Name);
        object result = method.Invoke(obj, null);
        Console.WriteLine("Result: " + result);
    }
    else
    {
        Console.WriteLine("Method not found: " + methodName);
    }
}