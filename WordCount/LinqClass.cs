using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace WordCount
{
    public class LinqClass<T>
    {
        public T testMen;
        public T testProp { get; set; }
        public T testMeth(T var)
        {
            return var;
        }
    }

    public class LinqClass: WorkOrder
    {
        public static void Querylinq()
        {
            #region
            testOrder testOrder = new testOrder();
            testOrder.test wrkor = new testOrder.test();
            wrkor.methodtest();
            var test = "";
            #endregion



            #region
            var ob = new std();
            ob.Main();

            var obsf = new std(1);

            string sun = "bssdddfsfdfbbsbs";
            var re = sun.Split(new string[] { "bs","sf"},StringSplitOptions.None);

            abs obx = new std(1);

            abs obAbs = new std();
            std obstd = new std();
           // std obstda = new abs(); // compile error 

            var r = obAbs.abp;
            var rr = obstd.abp;

            var stu1 = new Student() { StudentID = 1};
            var stu2 = new Student() { StudentID = 1};

            var obj = stu1.Equals(stu2);
            var obj1 = object.ReferenceEquals(stu1,stu2);
            #endregion


            #region LinQ
            // Student collection
            IList<Student> studentList = new List<Student>()
        {new Student()
        {StudentID = 1, @class ="A", StudentName = "John", Age = 13}, new Student()
        {StudentID = 2, @class ="A", StudentName = "Moin", Age = 21}, new Student()
        {StudentID = 3, @class ="B", StudentName = "Bill", Age = 18}, new Student()
        {StudentID = 4, @class ="B", StudentName = "Ram", Age = 20}, new Student()
        {StudentID = 5, @class ="A", StudentName = "Ron", Age = 15}};

        IList<Standard> standardList = new List<Standard>() {
        new Standard(){ StudentID = 1, StandardName="Standard 1"},
        new Standard(){ StudentID = 2, StandardName="Standard 2"},
        new Standard(){ StudentID = 3, StandardName="Standard 3"}
        };



        IList<WorkOrder> workOrders = new List<WorkOrder>()
        {new WorkOrder()
        { WorkDescription= "A",WorkOrderNumber=1}, new WorkOrder()
        { WorkDescription= "A",WorkOrderNumber=2}, new WorkOrder()
        { WorkDescription= "A",WorkOrderNumber=3} };

            IList<PlannedWork> plans = new List<PlannedWork>()
        {new PlannedWork()
        { ScheduledDate= "Ab",WorkOrderNumber=1}, new PlannedWork()
        { ScheduledDate= "Ac",WorkOrderNumber=2}, new PlannedWork()
        { ScheduledDate= "Ad",WorkOrderNumber=3} };


            var q = from s in studentList
                    where s.Age > 12
                    select s;
            var sse = from s in studentList
                      select s;
            var de = from s in studentList
                     group s by s.@class into se
                     select new
                     {
                         ser = se.Key,
                         av = se.Average(x => x.Age)
                     };
            var jn = from w in workOrders
                     join p in plans
                     on w.WorkOrderNumber equals p.WorkOrderNumber
                     select new
                     {
                         w.WorkOrderNumber,
                         w.WorkDescription,
                         p.ScheduledDate
                     };

            var sdThenby = studentList.Where(s => s.Age > 10).OrderBy(c => c.@class).ThenBy(a => a.Age);//sort by class then by age
            var sdord = studentList.Where(s => s.Age > 10).OrderBy(c => c.@class).OrderBy(a => a.Age);//sort by age only (overwrite sort by class)
            var sd = studentList.Where(s => s.Age > 16);//list count change according to condn, return IEnumerable<T>
            var st = studentList.Select(s => s.Age > 16); //list count same, return IEnumerable<bool>
            var sq = studentList.Where(s => s.Age > 16).GroupBy(s => s.@class);
            var sw = studentList.GroupBy(p => p.@class).Select(k => new { l = k.Key, m = k.Average(x => x.Age) });
            var sj = workOrders.Where(h => plans.Count(x => x.WorkOrderNumber == h.WorkOrderNumber) > 15);
            var stdr = studentList.OrderByDescending(x => x.Age).TakeWhile(z => z.Age > 15);
            var stdrSk = studentList.OrderByDescending(x => x.Age).SkipWhile(z => z.Age > 15);
            var stdic = studentList.ToDictionary(x => x.StudentID);
            var stdics = studentList.ToDictionary(x => x.StudentID, z => z.StudentName);
            var lamss = studentList.Where(s => s.Age > 18).GroupBy(s => s.@class).SelectMany(x => x).ToArray();
            var lamsAvg = studentList.GroupBy(t => new { cla = t.@class })
                           .Select(g => new
                           {
                               Average = g.Average(p => p.Age),
                               ID = g.Key.cla
                           }).OrderBy(x => x.Average);
            var innerJoin = studentList.Join(// outer sequence 
                        standardList,  // inner sequence 
                        student => student.StudentID,    // outerKeySelector
                        standard => standard.StudentID,  // innerKeySelector
                        (student, standard) => new  // result selector
                                {
                            StudentName = student.StudentName,
                            StandardName = standard.StandardName
                        });
            /*
			var query =
				contacts.AsEnumerable().Join(orders.AsEnumerable(),
				order => order.Field<Int32>("ContactID"),
				contact => contact.Field<Int32>("ContactID"),
				(contact, order) => new
				{
					ContactID = contact.Field<Int32>("ContactID"),
					SalesOrderID = order.Field<Int32>("SalesOrderID"),
					FirstName = contact.Field<string>("FirstName"),
					Lastname = contact.Field<string>("Lastname"),
					TotalDue = order.Field<decimal>("TotalDue")
				});

            var s = studenlist.Join(standardList
                    student => student.Id,
                    sandard => standard.Id,
                    (student,sandard) => 
                    {
                         student =>student.Name,
                         sandard =>sandard.Name
                    });

			*/
            // LINQ Query Syntax to find out teenager students
            var teenAgerStudent =
                from s in studentList
                orderby s.Age
                select s;
            Console.WriteLine("Teen age Students:");
            foreach (Student std in teenAgerStudent)
            {
                Console.WriteLine(std.StudentName);
            }
            var lam = studentList.Where(s => s.Age > 18).GroupBy(s => s.@class).SelectMany(x => x).ToArray();

            Console.WriteLine("Teen age Students: lamda");
            foreach (var std in lam)
            {
                Console.WriteLine(std.StudentName);
            }

            var teamAverageScores = from player in studentList
                                    group player by player.@class into playerGroup
                                    select new
                                    {
                                        Team = playerGroup.Key,
                                        AverageScore = playerGroup.Average(x => x.Age),
                                    };

            Console.WriteLine("Teen age Students: lamda");
            foreach (var std in teamAverageScores)
            {
                Console.WriteLine("{0} : {1}", std.Team, std.AverageScore);
            }

            var lamAvg = studentList.GroupBy(t => new { cla = t.@class })
                           .Select(g => new
                           {
                               Average = g.Average(p => p.Age),
                               ID = g.Key.cla
                           });
            Console.WriteLine("Teen age Students: lamda");
            foreach (var std in lamAvg)
            {
                Console.WriteLine(std.ID + " " + std.Average);
            }

            var avg = studentList.Average(s => s.Age);


            var saq = from w in workOrders
                      join p in plans
                      on w.WorkOrderNumber equals p.WorkOrderNumber
                      select new
                      {
                          w.WorkOrderNumber,
                          p.ScheduledDate,
                          w.WorkDescription
                      };



            var query = from order in workOrders
                        join plan in plans
                             on order.WorkOrderNumber equals plan.WorkOrderNumber
                        select new
                        {
                            order.WorkOrderNumber,
                            order.WorkDescription,
                            plan.ScheduledDate
                        };
            Console.WriteLine("Teen age Students: work");
            foreach (var std in query)
            {
                Console.WriteLine(std);
            }



            //max group avg
            //https://stackoverflow.com/questions/38667302/finding-the-max-of-average-in-linq

            #endregion


        }



        public static void concurrTask()
        {

            var coll = new ConcurrentQueue<int>();
            coll.Enqueue(1);
            coll.Enqueue(2);
            coll.Enqueue(3);
            coll.Enqueue(4);
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; ++i)
                {
                    coll.Enqueue(i);
                    Thread.Sleep(200);
                }
            }, cancellationToken.Token);

            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(300);
                foreach (var item in coll)
                {
                    cancellationToken.Cancel();

                    Console.WriteLine(item);
                    Thread.Sleep(150);
                }
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ex) // No exception
            {
                Console.WriteLine(ex.Flatten().Message);
            }
        }


    }
    public class testOrder
    {
        string s = "asd";
         public testOrder() {
            Console.WriteLine("testOrder cons");
        }
         void methodtestOrder()
        {

            Console.WriteLine("testOrder meth");
        }

        public class test
        {
                testOrder tes = new testOrder();
            public test()
            { 
            Console.WriteLine("test cons");
            }
            public void methodtest()
            {
                tes.methodtestOrder();
                Console.WriteLine("test meth");
            }

        }
        public int WorkOrderNumber { get; set; }
        public string WorkDescription { get; set; }
    }
    public class WorkOrder
    {
        public int WorkOrderNumber { get; set; }
        public string WorkDescription { get; set; }
    }
    class PlannedWork
    {
        public int WorkOrderNumber { get; set; }
        public string ScheduledDate { get; set; }
    }
    public class Standard
    {
        public int StudentID
        {
            get;
            set;
        }
        public string StandardName { get; set; }

    }
    public interface Istudent
    {
        int StudentID { get; set; }
    }
    public abstract class abs
    {
        public abstract int abp { get; set; }

        static abs()
        {
            Console.WriteLine("abs stat");
        }
        public abs()
        {
            Console.WriteLine("abs con");
        }

        public abs(int i)
        { 
            Console.WriteLine(i + "abs cons para");

        }
    }

    public class std : abs
    {
        static std()
        { 
            Console.WriteLine("std stat");
        }
        public std()
        { 
            Console.WriteLine("std con");
        }
        public std(int i)
        {
            Console.WriteLine(i + "std con para");
        }

        public override int abp
        {
            get => 1; set
            {
                int value1 = value;
            }
        }

        public async Task Main()
        {
            this.method();
            //Console.ReadKey();
        }

        public async Task method()
        {
            Console.WriteLine("test");
        }
       // public override int StudentID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
    public class Student : Istudent, IEquatable
    {
        public virtual int StudentID
        {
            get;
            set;
        }

        public string StudentName
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }
        public string @class
        {
            get;
            set;
        }
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
                return false;

            Student p = obj as Student;
            if ((System.Object)p == null)
                return false;

            return (StudentID == p.StudentID) && (StudentName == p.StudentName);
        }

        public bool Equals(Student p)
        {
            if ((object)p == null)
                return false;

            return (StudentID == p.StudentID) && (StudentName == p.StudentName);
        }

        public override int GetHashCode()
        {
            return StudentID.GetHashCode() ^ StudentName.GetHashCode();
        }
    }
}