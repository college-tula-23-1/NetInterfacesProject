using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace NetXmlFormatsProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument document = XDocument.Load("employees.xml");
            var root = document.Root;

            if (root is null) return;

            //foreach(var e in root.Elements())
            //{
            //    ElementPrint(e, 0);
            //}

            //var empls = root.Elements("employee")
            //                .Where(emp => Decimal.Parse(emp?.Element("salary")?.Value) >= 110000m)
            //                .Select(emp => new
            //                {
            //                    Name = emp.Element("name")?.Value,
            //                    Salary = emp.Element("salary")?.Value
            //                });

            //foreach ( var emp in empls )
            //    Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");
            //    //ElementPrint(emp, 0);
            
            var elem = root.Elements("employee")
                           .FirstOrDefault(e => Decimal.Parse(e?.Element("salary")?.Value) < 110000m);
            elem?.Remove();
            document.Save("employees.xml");
        }

        static void ElementPrint(XElement element, int level)
        {
            string tabs = new string('\t', level);

            Console.Write($"\n{tabs}Name: {element.Name}");
            if(element.Attributes().Count() != 0)
            {
                Console.Write($"\n{tabs}\tAttributes:");
                foreach (var a in element.Attributes())
                    Console.Write($"\n{tabs}\t\t{a.Name}={a.Value}");
            }
            if(element.Elements().Count() != 0)
            {
                foreach(var child in element.Elements())
                    ElementPrint(child, level + 1);
            }
            else
                Console.WriteLine($"\n{tabs}Value: {element.Value}");
        }
    }
}
