using System;


namespace Generic_Delegate
{
    // public delegate void MyDelegate(object o);


    class Source
    {
        // public event MyDelegate Run;
        public event Action<object> Run;

        public void Start()
        {
            Console.WriteLine("RUN");
            if (Run != null) Run(this);
        }
    }


    class Observer1 // Наблюдатель 1
    {
        public void Do(object o)
        {
            Console.WriteLine("Первый. Принял, что объект {0} побежал", o);
        }
    }

    class Observer2 // Наблюдатель 2
    {
        public void Do(object o)
        {
            Console.WriteLine("Второй. Принял, что объект {0} побежал", o);
        }
    }



    class Program
    {


        static void Main(string[] args)
        {
            Action<object> mesTag;

            Source s = new Source();
            Observer1 o1 = new Observer1();
            Observer2 o2 = new Observer2();
            //MyDelegate d1 = new MyDelegate(o1.Do);
            mesTag = o1.Do;
            s.Run += mesTag;
            s.Run += o2.Do;
            s.Start();
            s.Run -= mesTag;
            s.Start();
            Console.ReadKey();

        }
    }
}
