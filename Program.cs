using System.Globalization;

// Flowchart - https://excalidraw.com/#json=55T5ILeLN9LSF7yzyUeLV,ZfA2Vnv4o5zYV4fgiCgcUg

namespace CS_Basic_Oppgave_2_Customisert_God_Morgen_program
{
    class Program
    {
        static void Main()
        {
            Console.Clear();

            Console.WriteLine("Please enter your name, age and some hobbies, and comma separate them like this:");
            Console.WriteLine("Erlend, 24, Coding, Videogames, Music");

            var personInfo = Console.ReadLine();

            while (string.IsNullOrEmpty(personInfo))
            {
                Console.WriteLine("Please enter your name, age and some hobbies, and comma separate them like this:");
                Console.WriteLine("Erlend, 24, Coding, Videogames, Music");
                personInfo = Console.ReadLine();
            }

            var commaSeperatedData = personInfo.Split(",").Select(p => p.Trim()).ToArray();

            Person person = new Person
            {
                Name = commaSeperatedData[0],
            };

            if (int.TryParse(commaSeperatedData[1], out int age)) person.Age = age;

            if (commaSeperatedData.Length > 2) person.Hobbies.AddRange(commaSeperatedData[2..]);

            CheckTime(person);
        }

        public class Person
        {
            public required string Name;
            public int Age;
            public List<string> Hobbies = [];
        }

        public static void CheckTime(Person person)
        {

            // ! TEST CUSTOM TIME OF THE DAY
            // int customHour = 8;
            // int customMinute = 30;
            // string customAmPmIndicator = "AM";

            // DateTime customDateObject = DateTime.ParseExact($"{customHour}:{customMinute} {customAmPmIndicator}", "h:m tt", CultureInfo.InvariantCulture);

            // int hour = customDateObject.Hour;
            // string amPmIndicator = customDateObject.ToString("tt", CultureInfo.InvariantCulture);

            DateTime time = DateTime.Now;
            int hour = time.Hour;
            string amPmIndicator = time.ToString("tt", CultureInfo.InvariantCulture);

            string hobbiesList = string.Join(", ", person.Hobbies);

            if (hour < 12 && amPmIndicator == "AM")
            {
                Console.WriteLine($"Good morning, {person.Name}. You are {person.Age} and have these hobbies: {hobbiesList}");
            }
            else if (hour >= 12 && hour < 17 && amPmIndicator == "PM")
            {
                Console.WriteLine($"Good afternoon, {person.Name}. You are {person.Age} and have these hobbies: {hobbiesList}");
            }
            else if (hour >= 17 && hour < 21 && amPmIndicator == "PM")
            {
                Console.WriteLine($"Good evening, {person.Name}. You are {person.Age} and have these hobbies: {hobbiesList}");
            }
            else
            {
                Console.WriteLine($"Good night, {person.Name}. You are {person.Age} and have these hobbies: {hobbiesList}");
            }
        }
    }
}
