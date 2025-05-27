using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text1 = "это строка с текстом. в строке много текста";
            Regex regex1 = new Regex("текст");
            MatchCollection matchCollection1 = regex1.Matches(text1);

            Console.WriteLine(matchCollection1.Count);
            foreach (Match match in matchCollection1)
            {
                Console.WriteLine($"{match.Index} {match.Value} {match.Length}");
                Console.WriteLine(match.ToString());
            }


            string text2 = "Цены: 100 руб., 200 руб., 300 руб.";
            Regex regex2 = new Regex(@"\d{3} руб");
            MatchCollection matchCollection2 = regex2.Matches(text2);
            foreach (Match match in matchCollection2)
            {
                Console.WriteLine(match.ToString() );  
            }

            string text3 = "Я рад, что у меня радостное настроение. Какая радость! парад";
            Regex regex3 = new Regex(@"\w*р.д\w*");
            MatchCollection matchCollection3 = regex3.Matches(text3);
            foreach (Match match in matchCollection3)
            {
                Console.WriteLine(match.ToString() );
            }

            string phone1 = "25-70-89";
            string phone2 = "123-45-678";
            string phonePattern = @"^\d{2}-\d{2}-\d{2}";
            bool phoneMatch1 = Regex.IsMatch(phone1, phonePattern);
            bool phoneMatch2 = Regex.IsMatch(phone2, phonePattern);
            Console.WriteLine(phoneMatch1.ToString() );
            Console.WriteLine(phoneMatch2.ToString() );

            string names = "Иван Алексей Петр Игорь Сергей Анатолий И";
            //Regex regexNames = new Regex(@"[И|П]\w+");
            Regex regexNames = new Regex(@"[А-И]\w+");
            MatchCollection matchesNames = regexNames.Matches(names);
            foreach (Match match in matchesNames)
            {
                Console.WriteLine(match.ToString());
            }

            string colorPattern = @"^#[0-9a-fA-F]{6}$";
            bool colorMatch1 = Regex.IsMatch("#12AD5E", colorPattern);
            bool colorMatch2 = Regex.IsMatch("#12ab5c", colorPattern);
            bool colorMatch3 = Regex.IsMatch("#12GD5E", colorPattern);
            Console.WriteLine(colorMatch1.ToString() );
            Console.WriteLine(colorMatch2.ToString() );
            Console.WriteLine(colorMatch3.ToString() );

            string mobilePhonePattern = @"^(\+7|8)[\s-]?\d{3}[\s-]?\d{3}[\s-]?\d{2}[\s-]?\d{2}$";
            bool mobilePhoneMatch1 = Regex.IsMatch("+79807412563", mobilePhonePattern);
            bool mobilePhoneMatch2 = Regex.IsMatch("8 980 741 25 63", mobilePhonePattern);
            bool mobilePhoneMatch3 = Regex.IsMatch("+7-980-741-25-63", mobilePhonePattern);

            Console.WriteLine(mobilePhoneMatch1);
            Console.WriteLine(mobilePhoneMatch2);
            Console.WriteLine(mobilePhoneMatch3);

            string text4 = "Это \n  строка  \t  с кучей   пробелов";
            string pattern4 = @"\s+";
            string target4 = " ";

            Regex regex4 = new Regex(pattern4);
            string result4 = regex4.Replace(text4, target4);
            Console.WriteLine(result4);

            // (910) 505-2222
            string text5 = "9105052222";
            Regex regex5 = new Regex(@"(\d{3})(\d{3})(\d{2})(\d{2})");
            Match match5 = regex5.Match(text5);
            Console.WriteLine(match5.ToString());
            Console.WriteLine(match5.Groups[1].ToString());
            Console.WriteLine(match5.Groups[2].ToString());
            Console.WriteLine(match5.Groups[3].ToString());

            string result5 = regex5.Replace(text5, "($1)$2-$3-$4");
            Console.WriteLine(result5);
        }
    }
}
