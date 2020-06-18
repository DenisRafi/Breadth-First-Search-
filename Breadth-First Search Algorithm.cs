/*
Breadth-First Search Algorithm

Breadth-first search is an algorithm for traversing or 
searching tree or graph data structures. It starts at the tree root,
and explores all of the neighbor nodes at the present depth prior to 
moving on to the nodes at the next depth level.
 
By Denis Rafi
*/
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        public class Employee
        {
            public Employee(string name)
            {
                this.name = name;
            }
            public string name { get; set; }
            public List<Employee> Employees
            {
                get
                {
                    return EmployeesList;
                }
            }
            public void isEmployeeOf(Employee p)
            {
                EmployeesList.Add(p);
            }
            List<Employee> EmployeesList = new List<Employee>();
            public override string ToString()
            {
                return name;
            }
        }
        public class BreadthFirstAlgorithm
        {
            public Employee BuildEmployeeGraph()
            {
                Employee Denis = new Employee("Denis");
                Employee Ava = new Employee("Ava");
                Employee Rafi = new Employee("Rafi");
                Denis.isEmployeeOf(Ava);
                Denis.isEmployeeOf(Rafi);
                Employee Mia = new Employee("Mia");
                Employee Amelia = new Employee("Amelia");
                Employee Logan = new Employee("Logan");
                Employee Mike = new Employee("Mike");
                Ava.isEmployeeOf(Mia);
                Ava.isEmployeeOf(Logan);
                Rafi.isEmployeeOf(Amelia);
                Rafi.isEmployeeOf(Mike);
                return Denis;
            }
            public Employee Search(Employee root, string nameToSearchFor)
            {
                Queue<Employee> Q = new Queue<Employee>();
                HashSet<Employee> S = new HashSet<Employee>();
                Q.Enqueue(root);
                S.Add(root);
                while (Q.Count > 0)
                {
                    Employee e = Q.Dequeue();
                    if (e.name == nameToSearchFor)
                        return e;
                    foreach (Employee friend in e.Employees)
                    {
                        if (!S.Contains(friend))
                        {
                            Q.Enqueue(friend);
                            S.Add(friend);
                        }
                    }
                }
                return null;
            }
            public void Traverse(Employee root)
            {
                Queue<Employee> traverseOrder = new Queue<Employee>();
                Queue<Employee> Q = new Queue<Employee>();
                HashSet<Employee> S = new HashSet<Employee>();
                Q.Enqueue(root);
                S.Add(root);
                while (Q.Count > 0)
                {
                    Employee e = Q.Dequeue();
                    traverseOrder.Enqueue(e);
                    foreach (Employee emp in e.Employees)
                    {
                        if (!S.Contains(emp))
                        {
                            Q.Enqueue(emp);
                            S.Add(emp);
                        }
                    }
                }
                while (traverseOrder.Count > 0)
                {
                    Employee e = traverseOrder.Dequeue();
                    Console.WriteLine(e);
                }
            }
        }
        static void Main()
        {
            Console.Title = ("Breadth-First Search Algorithm");
            BreadthFirstAlgorithm b = new BreadthFirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n-----");
            b.Traverse(root);
            Console.WriteLine("\nSearch in Graph\n-----");
            Employee e = b.Search(root, "Denis");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Rafi");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Emma");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            Console.ReadKey();
        }
    }
}
