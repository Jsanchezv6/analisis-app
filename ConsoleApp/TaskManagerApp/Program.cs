using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        IDataStorage dataStorage = new DataStorage();
        ITaskManager taskManager = new TaskManager(dataStorage);
        ConcurrentTaskManager concurrentTaskManager = new ConcurrentTaskManager(taskManager);

        while (true)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Modificar tarea");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Ver tareas pendientes");
            Console.WriteLine("5. Ver tareas completadas");
            Console.WriteLine("6. Salir");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Write("Descripción: ");
                    string description = Console.ReadLine();
                    int id = new Random().Next(1, 1000); // Generar un ID aleatorio
                    concurrentTaskManager.AddTaskConcurrently(new Task(id, description, false));
                    break;

                case "2":
                    Console.Write("ID de la tarea: ");
                    int modifyId = int.Parse(Console.ReadLine());
                    Console.Write("Nueva descripción: ");
                    string newDescription = Console.ReadLine();
                    Console.Write("¿Está completada? (true/false): ");
                    bool isCompleted = bool.Parse(Console.ReadLine());
                    concurrentTaskManager.ModifyTaskConcurrently(modifyId, newDescription, isCompleted);
                    break;

                case "3":
                    Console.Write("ID de la tarea: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    concurrentTaskManager.DeleteTaskConcurrently(deleteId);
                    break;

                case "4":
                    var pendingTasks = taskManager.GetPendingTasks();
                    Console.WriteLine("Tareas pendientes:");
                    foreach (var task in pendingTasks)
                    {
                        Console.WriteLine($"{task.Id}: {task.Description}");
                    }
                    break;

                case "5":
                    var completedTasks = taskManager.GetCompletedTasks();
                    Console.WriteLine("Tareas completadas:");
                    foreach (var task in completedTasks)
                    {
                        Console.WriteLine($"{task.Id}: {task.Description}");
                    }
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
