using Console = System.Console;
using myList;

namespace main {
    class main {
        static void Main(string[] args) {
            myList<int> list = new myList<int>();
            myList<int> list2 = new myList<int>(1);
            myList<int> list3 = new myList<int>(1);
            list.add(123);
            list.add(444);
            list3.add(123);
            list3.add(456);
            list3.add(751);
            list3.add(751);
            list3.add(751);
            list3.add(751);
            for (int i = 0;i<list3.Length;++i)
                Console.WriteLine(list3[i]);
            //show removeAll 751
            list3.removeAll(751);           
            Console.WriteLine("------------");
            for (int i = 0; i < list3.Length; ++i)
                Console.WriteLine(list3[i]);
            Console.WriteLine("------------");
            //show copyto
            list.copyTo(list2);
            //show if out of index
            list2[12] = 12;
            //show equals
            Console.WriteLine(list.Equals(list3));
            Console.Read();
        }
    }
}
