using System;
using System.Collections.Generic;

namespace Visitor
{
    //The common use of this pattern is to send functions similar to hierarchical objects.
    //Paying company employees can be given as an example.
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager {Name = "engin", Salary = 1000};
            Manager manager2 = new Manager {Name = "salih", Salary = 900};

            Worker worker = new Worker {Name = "derin", Salary = 800};
            Worker worker2 = new Worker {Name = "ali", Salary = 800};
            manager.Subordinates.Add(manager2);
            manager2.Subordinates.Add(worker2);

            OrganisationalStructure organisationalStructure=new OrganisationalStructure(manager);
            PayrollVisitor payrollVisitor=new PayrollVisitor();
            PayRise payRise=new PayRise();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payRise);

            Console.ReadLine();

        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;
        // firstemployee the place in the hierarchy to begin payment.
        public OrganisationalStructure(EmployeeBase FirstEmployee)
       
        {
            Employee = FirstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }

    class Manager:EmployeeBase
    {
        public Manager()
        {
            Subordinates=new List<EmployeeBase>();
        }

        public List<EmployeeBase> Subordinates { get; set; }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker:EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);

    }

    class PayrollVisitor:VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}",manager.Name,manager.Salary);
        }
    }

    class PayRise:VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to  {1}", manager.Name, manager.Salary*(decimal) 1.2);
        }
    }
}
