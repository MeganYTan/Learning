using Generics;

Console.WriteLine("MyStack");
MyStack<int> myStack = new MyStack<int>();
myStack.Push(1);
myStack.Push(2);
Console.WriteLine(myStack.Pop());

Console.WriteLine("MyList");
MyList<int> myList = new MyList<int>();
myList.Add(1);
myList.Add(2);
Console.WriteLine(myList.Find(2));
myList.Remove(1);
Console.WriteLine(myList.Find(2));

Console.WriteLine("MyRepository");
Entity e1 = new Entity(1);
Entity e2 = new Entity(2);
Entity e3 = new Entity(3);
GenericRepository<Entity> genericRepository = new GenericRepository<Entity>();
genericRepository.Add(e1);
genericRepository.Add(e2);
genericRepository.Add(e3);
genericRepository.Save();
genericRepository.Remove(e1);
genericRepository.Save();
Console.WriteLine($"Get by ID = 2: {genericRepository.GetById(2).Id}");