namespace DataStructuresIssues.Solutions
{
    internal class AnimalShelter : ISolveIssue
    {
        ///<summary>
        ///Animal Shelter: An animal shelter, which holds only dogs and cats, operates on a strictly "first in, first
        ///out" basis. People must adopt either the "oldest" (based on arrival time) of all animals at the shelter, 
        ///or they can select whether they would prefer a dog or a cat(and will receive the oldest animal of
        ///that type). They cannot select which specific animal they would like.Create the data structures to
        ///maintain this system and implement operations such as enqueue, dequeueAny, dequeueDog,
        ///and dequeueCat.You may use the built-in LinkedList data structure
        ///</summary>
        public void Solve()
        {
            AnimalQueue aq = new AnimalQueue();
            aq.Enqueue(new Animal("Cat1", AnimalType.Cat));
            aq.Enqueue(new Animal("Cat2", AnimalType.Cat));
            aq.Enqueue(new Animal("Dog1", AnimalType.Dog));
            while (true)
            {
                Console.WriteLine("Enter operation: c -get cat, d -get dog, a -get any, ic -insert cat, id -insert dog:");
                string? operation = Console.ReadLine();
                if (string.IsNullOrEmpty(operation) || operation == Helper.QuitStr)
                    return;
                switch (operation)
                {
                    case "c":
                        Console.WriteLine(aq.DequeueCat());
                        break;
                    case "d":
                        Console.WriteLine(aq.DequeueDog());
                        break;
                    case "a":
                        Console.WriteLine(aq.Dequeue());
                        break;
                    case "ic":
                        string? cat1 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(cat1))
                            aq.Enqueue(new Animal(cat1, AnimalType.Cat));
                        break;
                    case "id":
                        string? dog1 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(dog1))
                            aq.Enqueue(new Animal(dog1, AnimalType.Dog));
                        break;
                    default: break;
                }
            }
        }
        enum AnimalType
        {
            Cat,Dog
        }
        private class Animal
        {
            public string Name { get; set; }
            public AnimalType Type { get; set; }
            public Animal(string name, AnimalType type)
            {
                Name = name;
                Type = type;
            }
        }
        private class AnimalQueue
        {
            LinkedList<Animal> queue = new LinkedList<Animal>();
            public void Enqueue(Animal animal)
            {
                queue.AddLast(animal);
            }
            public string Dequeue()
            {
                string name = string.Empty;
                try
                {
                    Animal animal = queue.First();
                    if (animal != null)
                    {
                        name = animal.Name;
                        queue.Remove(animal);
                    }
                }
                catch (Exception) { }
                return name;
            }
            public string DequeueDog()
            {
                string name = string.Empty;
                Animal? animal = queue.FirstOrDefault(a => a.Type == AnimalType.Dog);
                if (animal != null)
                {
                    name = animal.Name;
                    queue.Remove(animal);
                }
                return name;
            }
            public string DequeueCat()
            {
                string name = string.Empty;
                Animal? animal = queue.FirstOrDefault(a => a.Type == AnimalType.Cat);
                if (animal != null)
                {
                    name = animal.Name;
                    queue.Remove(animal);
                }
                return name;
            }
        }
    }
}
