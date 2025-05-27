using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NetXmlFormatsProject
{
    static class Examples
    {
        public static void XmlWelcomeExample()
        {
            Employee employee = new Employee()
            {
                FirstName = "Bobby",
                LastName = "Smith",
                BirthDate = DateTime.Now.AddYears(-30),
                Salary = 120000
            };

            //XmlSerializer serializer = new XmlSerializer(typeof(Employee));

            //using(FileStream stream = new FileStream("employee.xml", FileMode.OpenOrCreate))
            //{
            //    serializer.Serialize(stream, employee);
            //}

            XmlDocument document = new XmlDocument();
            document.Load("employee.xml");

            XmlElement? root = document.DocumentElement;
            if (root is not null)
            {
                foreach (XmlElement element in root)
                {
                    Console.WriteLine($"{element.Name} - {element.InnerText}");
                    foreach (XmlAttribute attribute in element.Attributes)
                        Console.WriteLine($"\t{attribute.Name} - {attribute.Value}");
                }

            }
        }

        public static void XmlAppendElementsExample()
        {
            var employees = InitEmployees();

            XmlDocument document = new XmlDocument();

            XmlElement root = document.CreateElement("employees");
            document.AppendChild(root);

            foreach (var employee in employees)
            {
                var employeeElement = document.CreateElement("employee");

                // append first name
                var firstName = document.CreateElement("name");
                var firstNameType = document.CreateAttribute("type");

                firstName.AppendChild(document.CreateTextNode(employee.FirstName));
                firstNameType.Value = "first";

                firstName.Attributes.Append(firstNameType);

                employeeElement.AppendChild(firstName);

                // append last name
                var lastName = document.CreateElement("name");
                var lastNameType = document.CreateAttribute("type");

                lastName.AppendChild(document.CreateTextNode(employee.LastName));
                lastNameType.Value = "last";

                lastName.Attributes.Append(lastNameType);
                employeeElement.AppendChild(lastName);

                root.AppendChild(employeeElement);
            }

            document.Save("employees.xml");
        }

        public static void XmlRemoveElementsExample()
        {
            XmlDocument documnet = new XmlDocument();
            documnet.Load("employees.xml");
            var root = documnet.DocumentElement;

            var firstElement = root?.FirstChild;
            if (firstElement is not null)
                root?.RemoveChild(firstElement);

            documnet.Save("employees.xml");
        }

        public static List<Employee> InitEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "Bobby",
                    LastName = "Smith",
                    BirthDate = DateTime.Now.AddYears(-30),
                    Salary = 120000
                },
                new Employee()
                {
                    FirstName = "Jimmy",
                    LastName = "Wathson",
                    BirthDate = DateTime.Now.AddYears(-28),
                    Salary = 100000
                },
                new Employee()
                {
                    FirstName = "Poppy",
                    LastName = "Bruck",
                    BirthDate = DateTime.Now.AddYears(-25),
                    Salary = 130000
                },
            };

            return employees;
        }

        public static void XmlLinqCreateExample()
        {
            var employees = Examples.InitEmployees();

            XDocument document = new();
            XElement root = new XElement("employees");
            document.Add(root);

            foreach (var e in employees)
            {
                //var element = new XElement("employee");
                //var firstName = new XElement("name", e.FirstName);
                //var firstNameType = new XAttribute("type", "first");
                //firstName.Attributes().Append(firstNameType);
                //element.Elements().Append(firstName);

                var element = new XElement("employee",
                                new XElement("name", e.FirstName,
                                    new XAttribute("type", "first")),
                                new XElement("name", e.LastName,
                                    new XAttribute("type", "last")),
                                new XElement("birth_date",
                                    new XElement("year", e.BirthDate.Year),
                                    new XElement("month", e.BirthDate.Month),
                                    new XElement("day", e.BirthDate.Day)),
                                new XElement("salary", e.Salary,
                                    new XAttribute("currency", "ruble"))
                                );

                root.Add(element);
            }

            document.Save("employees.xml");
        }
    }
}
