
// Amir Moeini Rad
// August 13, 2025

// Main Concept: Garbage Collection (GC) in .NET

namespace GarbageCollectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Garbage Collection in .NET...");
            Console.WriteLine("-----------------------------\n");

            
            // Create instances of MyClass
            for (int i = 1; i <= 5; i++)
            {
                var obj = new MyClass(i);
            }


            Console.WriteLine("Objects created. Forcing Garbage Collection...\n");


            // Force Garbage Collection
            // In real applications, you typically don't call GC.Collect() manually.      
            // 'Collect()' is used here for demonstration purposes only.
            // It forces the garbage collector to run and finalize objects that are no longer in use.
            // In the code output, you will see 4 objects being destroyed: 1, 2, 3, and 4 (not necessarily in this order!).
            // However, we have created 5 objects!
            // 'obj' is reused in each iteration, so after each loop, the previous object becomes unreferenced!
            // When the loop ends, the variable 'obj' still holds a reference to the last created object (MyClass(5)) and it is still in scope.
            // So, we have 1 reference object and 4 unreferenced objects in the memory.
            // Therefore, GC will collect the 4 unreferenced objects and finalize them.
            GC.Collect();


            // Wait for finalizers to complete by suspending the current thread
            GC.WaitForPendingFinalizers();


            Console.WriteLine("\nDone.");
        }
    }



    ////////////////////////
    // MyClass Definition //
    ////////////////////////
    


    class MyClass
    {
        // Property
        public int Id { get; }
        
        // Custom Constructor
        public MyClass(int id) => Id = id;

        // Finalizer (Destructor)
        ~MyClass() => Console.WriteLine($"MyClass {Id} finalized (collected by GC).");
    }
}
