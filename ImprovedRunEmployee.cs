namespace ImprovedRunEmployee {

    internal interface IEmployee {

        public string? Name { get; set; }
        public double Salary { get; set; }
    }

    internal class FullTime : IEmployee {
        internal FullTime(string name, double salary) {
            Name = name;
            Salary = salary;
        }

        public string? Name { get; set; }
        public double Salary { get; set; }
    }

    internal class PartTime : IEmployee {
        internal PartTime(string name, double ratePerHour, int hoursWorked) {
            Name = name;
            RatePerHour = ratePerHour;
            HoursWorked = hoursWorked;
        }

        public double RatePerHour { get; set; }
        public int HoursWorked { get; set; }
        public string? Name { get; set; }

        public double Salary {

            get => RatePerHour * HoursWorked;

            set {
                // just discard.
                // we don't need this coz the value is calculated by multiplying Rate and Hours Worked.
                _ = value;
            }
        }
    }

    internal class ImprovedRunEmployee {
        public static void Improved_Version() {
            Console.WriteLine("What is your name?");
            string? answer_name = Console.ReadLine();

            answer_name ??= string.Empty;

            Console.WriteLine("Are you a Full-Time(F) or Part-Time Employee(P):");

            switch (Console.ReadLine()) {
                case "f":
                case "F": {
                        Console.WriteLine("What is your monthly salary?");
                        DisplayEmployee(new FullTime(answer_name!, Convert.ToDouble(Console.ReadLine())));

                        break;
                    }
                case "p":
                case "P": {
                        Console.WriteLine("What is your rate per hour and hours you've worked for the month? Answer both separated by a space:");
                        string? answer = Console.ReadLine();
                        string[] answers = answer!.Split(' ');

                        if (answers.Length != 2) {
                            Console.WriteLine("You've entered the wrong value, goodbye");
                            break;
                        }

                        double rate = Convert.ToDouble(answers[0]);

                        int hoursWorked = Convert.ToInt32(answers[1]);

                        DisplayEmployee(new PartTime(answer_name!, rate, hoursWorked));
                        break;
                    }
                default: {
                        Console.WriteLine("You've entered the wrong value, goodbye");
                        return;
                    }
            }

        }

        private static void DisplayEmployee(IEmployee employee) {
            Console.WriteLine($"Name: {employee.Name}\nSalary: {employee.Salary}");
        }
    }
}
