using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Task> tasks = new List<Task>();
        while (true)
        {
            Console.WriteLine("\nTo-Do List:");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Remove Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewTasks(tasks);
                    break;
                case "2":
                    AddTask(tasks);
                    break;
                case "3":
                    MarkTaskAsCompleted(tasks);
                    break;
                case "4":
                    RemoveTask(tasks);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void ViewTasks(List<Task> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void AddTask(List<Task> tasks)
    {
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        tasks.Add(new Task(description));
        Console.WriteLine("Task added.");
    }

    static void MarkTaskAsCompleted(List<Task> tasks)
    {
        ViewTasks(tasks);
        if (tasks.Count > 0)
        {
            Console.Write("Enter the task number to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks[taskNumber - 1].MarkAsCompleted();
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
    }

    static void RemoveTask(List<Task> tasks)
    {
        ViewTasks(tasks);
        if (tasks.Count > 0)
        {
            Console.Write("Enter the task number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine("Task removed.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
    }
}
