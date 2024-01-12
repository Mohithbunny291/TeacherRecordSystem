// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using TeacherRecordSystem;

class Program
{
    static void Main()
    {
        List<Teacher> teachers = FileManager.ReadTeachers();

        while (true)
        {
            Console.WriteLine("1. Add Teacher  2. Update Teacher  3. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddTeacher(teachers);
                    break;
                case 2:
                    UpdateTeacher(teachers);
                    break;
                case 3:
                    FileManager.WriteTeachers(teachers);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void AddTeacher(List<Teacher> teachers)
    {
        Console.Write("Enter Teacher ID: ");
        int id = int.Parse(Console.ReadLine());

        if (teachers.Any(t => t.ID == id))
        {
            Console.WriteLine("Teacher with the same ID already exists.");
            return;
        }

        Console.Write("Enter Teacher Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Class and Section: ");
        string classAndSection = Console.ReadLine();

        teachers.Add(new Teacher { ID = id, Name = name, ClassAndSection = classAndSection });

        Console.WriteLine("Teacher added successfully.");
    }

    static void UpdateTeacher(List<Teacher> teachers)
    {
        Console.Write("Enter Teacher ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Teacher teacherToUpdate = teachers.Find(t => t.ID == id);

        if (teacherToUpdate == null)
        {
            Console.WriteLine("Teacher not found.");
            return;
        }

        Console.Write("Enter new Teacher Name: ");
        teacherToUpdate.Name = Console.ReadLine();

        Console.Write("Enter new Class and Section: ");
        teacherToUpdate.ClassAndSection = Console.ReadLine();

        Console.WriteLine("Teacher updated successfully.");
    }
}
