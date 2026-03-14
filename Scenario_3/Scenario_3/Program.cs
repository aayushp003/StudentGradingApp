using System;
using System.IO;
class StudentGrading
{
    static void Main(string[] args)
    {
        while (true)
        {
            ShowMenu();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("1. Create a new student record");
        Console.WriteLine("2. Enter marks for the student");
        Console.WriteLine("3. Update a student record");
        Console.WriteLine("4. View a student record");
        Console.WriteLine("5. Quit the program\n");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CreateStudent();
                break;
            case 2:
                EnterMarks();
                break;
            case 3:
                UpdateStudent();
                break;
            case 4:
                ViewStudent();
                break;
            case 5:
                QuitProgram();
                break;
            default:
                Console.WriteLine("Invalid Choice!");
                break;
        }
    }

    static void CreateStudent()
    {
        Random rand = new Random();
        int studentNumber = rand.Next(10000000, 99999999);
        string FilePath = studentNumber + ".txt";
        if (File.Exists(FilePath))
        {
            studentNumber = rand.Next(10000000, 99999999);
            FilePath = studentNumber + ".txt";
        }
        else
        {
            Console.WriteLine("\nEnter the student's name: ");
            string studentName = Console.ReadLine();
            string data = "Student Number:" + studentNumber + "\nStudent Name:" + studentName + "\n";
            File.WriteAllText(FilePath, data);
            Console.WriteLine("Student record added successfully!\n");
        }
    }

    static void EnterMarks()
    {
        Console.WriteLine("\nEnter the student number: ");
        string studentNumber = Console.ReadLine();
        string FilePath = studentNumber + ".txt";
        if (File.Exists(FilePath))
        {
            int[] marks = new int[6];
            for (int i = 0; i < 6; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Enter the student's marks in subject {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int mark) && mark >= 0 && mark <= 100)
                    {
                        marks[i] = mark;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid marks. Try again!");
                    }
                }
            }
            double average = 0;
            foreach (int m in marks)
                average += m;
            average /= 6;
            string result = (average >= 40) ? "The student has passed!\n" : "The student has failed!\n";
            string marksData = "\nMarks:";
            foreach (int m in marks)
                marksData += m + " ";
            marksData += $"\nAverage: {average:F2}\nResult: {result}\n";
            File.AppendAllText(FilePath, marksData);
            Console.WriteLine("Marks added successfully!");
            Console.WriteLine($"Average: {average:F2} | Result: {result}");
        }
        else {
            Console.WriteLine("Student record not found!\n");
        }
    }

    static void UpdateStudent()
    {
        Console.WriteLine("\nEnter the student number: ");
        string studentNumber = Console.ReadLine();
        string FilePath = studentNumber + ".txt";
        if (File.Exists(FilePath))
        {
            int[] marks = new int[6];
            Console.WriteLine("Updating the student's record...");
            for (int i = 0; i < 6; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Enter the student's marks in subject {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int mark) && mark >= 0 && mark <= 100)
                    {
                        marks[i] = mark;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid marks. Try again!");
                    }
                }
            }
            double average = 0;
            foreach (int m in marks)
                average += m;
            average /= 6;
            string result = (average >= 40) ? "The student has passed!/n" : "The student has failed!/n";
            string marksData = "\nUpdated Marks:";
            foreach (int m in marks)
                marksData += m + " ";
            marksData += $"\nAverage: {average:F2}\nResult: {result}\n";
            File.AppendAllText(FilePath, marksData);
            Console.WriteLine("Marks updated successfully!");
            Console.WriteLine($"Average: {average:F2} | Result: {result}");
        }
        else
        {
            Console.WriteLine("Student record not found!/n");
        }
    }

    static void ViewStudent()
    {
        Console.WriteLine("Enter the number of student that you want to view: ");
        string studentNumber = Console.ReadLine();
        string FilePath = studentNumber + ".txt";
        if (File.Exists(FilePath))
        {
            string studentData = File.ReadAllText(FilePath);
            Console.WriteLine("\nStudent Record: ");
            Console.WriteLine(studentData);
        }
        else
        {
            Console.WriteLine("\nThe student record doesn't exist!");
        }
    }
    static void QuitProgram()
    {
        Environment.Exit(0);
    }
}