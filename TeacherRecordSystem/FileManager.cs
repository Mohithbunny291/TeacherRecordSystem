// FileManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TeacherRecordSystem;

public class FileManager
{
    private const string FilePath = "teachers.txt";

    public static List<Teacher> ReadTeachers()
    {
        List<Teacher> teachers = new List<Teacher>();

        try
        {
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);

                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    teachers.Add(new Teacher
                    {
                        ID = int.Parse(data[0]),
                        Name = data[1],
                        ClassAndSection = data[2]
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading data: {ex.Message}");
        }

        return teachers;
    }

    public static void WriteTeachers(List<Teacher> teachers)
    {
        try
        {
            string[] lines = teachers.Select(t => $"{t.ID},{t.Name},{t.ClassAndSection}").ToArray();
            File.WriteAllLines(FilePath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing data: {ex.Message}");
        }
    }
}
