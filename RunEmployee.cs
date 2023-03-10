namespace RunEmployee {

    internal class Employee {
        private string? name;
        public string? getName => name;

        public void setName(string? name) => this.name = name;
    }

    internal class FullTimeEmployee : Employee {

        private static readonly Dictionary<double, FullTimeEmployee> salaryToEmployee = new();

        public FullTimeEmployee(string? name, double salary) {

            setName(name);
            setMonthlySalary(salary);

            Console.WriteLine($"Name: {getName}");
            Console.WriteLine($"Salary: {getMonthlySalary}");
        }

        private double monthlySalary;
        public double getMonthlySalary => monthlySalary;
        public void setMonthlySalary(double monthlySalary) {
            this.monthlySalary = monthlySalary;
        }
    }

    internal class PartTimeEmployee : Employee {
        public PartTimeEmployee(string? name, double ratePerHour, int hoursWorked) {

            setName(name);

            this.ratePerHour = ratePerHour;
            this.hoursWorked = hoursWorked;

            setWage(this.ratePerHour, this.hoursWorked);

            Console.WriteLine($"Name: {getName}");
            Console.WriteLine($"Wage: {getWage()}");
        }

        private double ratePerHour;

        private int hoursWorked;

        private double wage;

        public void setWage(double ratePerHour, double hoursWorked) {
            wage = ratePerHour * hoursWorked;
        }

        public double getWage() => wage;
    }

    internal class RunEmployee {
        static void Main() {

            Console.WriteLine("What is your name?");
            string? answer_name = Console.ReadLine();

            Console.WriteLine("Are you a Full-Time(F) or Part-Time Employee(P):");

            switch (Console.ReadLine()) {
                case "f":
                case "F": {
                        Console.WriteLine("What is your monthly salary?");
                        _ = new FullTimeEmployee(answer_name, Convert.ToDouble(Console.ReadLine()));
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

                        _ = new PartTimeEmployee(answer_name, rate, hoursWorked);
                        break;
                    }
                default: {
                        Console.WriteLine("You've entered the wrong value, goodbye");
                        return;
                    }
            }

        }
    }
}