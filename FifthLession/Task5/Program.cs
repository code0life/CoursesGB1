using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task5
{
    public class Program
    {
        //Список задач (ToDo-list):
        //написать приложение для ввода списка задач;
        //задачу описать классом ToDo с полями Title и IsDone;
        //на старте, если есть файл tasks.json/xml/bin(выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
        //если задача выполнена, вывести перед её названием строку «[x]»;
        //вывести порядковый номер для каждой задачи;
        //при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
        //записать актуальный массив задач в файл tasks.json/xml/bin.

        public class ToDoList
        {
            public string name;
            public List<ToDo> list;

            public ToDoList()
            {
                name = "empty";
                list = new List<ToDo>();
            }
            public ToDoList(string _name)
            {
                name = _name;
            }
            public void ChangeName(string _name)
            {
                name = _name;
            }
            public List<ToDo> GetTasks()
            {
                return list;
            }
            public void AddTask(string _name)
            {
                ToDo task = new ToDo(_name);
                list.Add(task);
            }
            public void RenameTask(int id, string _name)
            {
                list[id].ChangeName(_name);
            }
            public void ChangeTask(int id)
            {
                list[id].Revert(); ;
            }
            public void DeleteTask(int id)
            {
                list.RemoveAt(id);
            }
        }
        public class ToDo
        {
            public string Title;
            public bool IsDone;
            public ToDo(string _Title, bool _IsDone = false)
            {
                Title = _Title;
                IsDone = _IsDone;
            }
            public ToDo()
            {
            }
            public void Revert()
            {
                IsDone = !IsDone;
            }
            public bool Complite()
            {
                return IsDone;
            }
            public string GetName()
            {
                return Title;
            }
            public void ChangeName(string _name)
            {
                Title = _name;
            }

        }

        static void Main()
        {
            string filename = @"tasks.xml";
            string path = Directory.GetCurrentDirectory();
            bool isLoop = true;
            string nameToDo = "";

            if (CheckFile(Path.Combine(path, filename)))
            {
                Console.WriteLine("Файл существует, загружаем данные.");
            }
            else
            {
                Console.WriteLine($"Первый запуск программы. Хотите создать файл? (Y-Да, N-Нет)");
                string question = Console.ReadLine();
                if (question == "N")
                {
                    Console.WriteLine("Осуществляется выход с программы.");
                    return;
                }

                Console.WriteLine("Какое имя вы хотите задать для списка задач?");
                nameToDo = Console.ReadLine();
                Console.WriteLine($"Создаётся файл '{filename}' по пути '{path}' с названием списка задач: {nameToDo}");
                CreateFile(filename, path, nameToDo);
            }

            ToDoList list = GetFile(filename, path);
            ShowList(list);

            while (isLoop)
            {
                Console.WriteLine("\nВыберите действие:\n" +
                    "Введите '1' если хотите переименовать список;\n" +
                    "Введите '2' если хотите добавить новую задачу в список;\n" +
                    "Введите '3' если хотите переименовать задачу из списка;\n" +
                    "Введите '4' если хотите сменить состояние задачи;\n" +
                    "Введите '5' если хотите удалить задачу из списка;\n" +
                    "Введите '0' если хотите выйти из программы\n");
                string str = Console.ReadLine();
                int num;
                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || !int.TryParse(str, out num) || (num < 0 || num > 5))
                {
                    Console.WriteLine("Ошибка. Некорректная строка.");
                    ShowList(list);
                    continue;
                }
                if (num == 0)
                {
                    SaveFile(filename, path, list);
                    Console.WriteLine("Завершение работы программы.");
                    return;
                }
                else if(num == 1)
                {
                    Console.WriteLine("Выберите новое название ToDo списка:");
                    string name = Console.ReadLine();
                    list.ChangeName(name);
                }
                else if (num == 2)
                {
                    Console.WriteLine("Введите название новый задачи:");
                    string name = Console.ReadLine();
                    list.AddTask(name);
                }
                else if (num == 3)
                {
                    Console.WriteLine("Введите номер задачи для переименования:");
                    str = Console.ReadLine();
                    int number;

                    if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || !int.TryParse(str, out number) || (number < 1 || number > list.GetTasks().Count + 1))
                    {
                        Console.WriteLine("Ошибка. Некорректная строка.");
                        ShowList(list);
                        continue;
                    }
                    Console.WriteLine($"Введите новое название для задачи:'{list.GetTasks()[number-1].GetName()}'");
                    str = Console.ReadLine();

                    list.RenameTask(number-1, str);
                }
                else if (num == 4)
                {
                    Console.WriteLine("Введите номер задачи для смены её состояния:");
                    str = Console.ReadLine();
                    int number;

                    if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || !int.TryParse(str, out number) || (number < 1 || number > list.GetTasks().Count + 1))
                    {
                        Console.WriteLine("Ошибка. Некорректная строка.");
                        ShowList(list);
                        continue;
                    }
                    list.ChangeTask(number - 1);
                }
                else if (num == 5)
                {
                    Console.WriteLine("Введите номер задачи для удаления её из списка:");
                    str = Console.ReadLine();
                    int number;

                    if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || !int.TryParse(str, out number) || (number < 1 || number > list.GetTasks().Count + 1))
                    {
                        Console.WriteLine("Ошибка. Некорректная строка.");
                        ShowList(list);
                        continue;
                    }
                    list.DeleteTask(number - 1);
                }
                SaveFile(filename, path, list);
                ShowList(list);
            }
        }

        public static bool CheckFile(string path)
        {
            return File.Exists(path) ? true : false;
        }
        public static void CreateFile(string name, string path, string nameToDo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ToDoList));
            try
            {
                using (FileStream file = new FileStream(Path.Combine(path, name), FileMode.Create, FileAccess.Write))
                {
                    ToDoList list = new ToDoList(nameToDo);
                    serializer.Serialize(file, list);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}");
            }
        }

        public static ToDoList GetFile(string name, string path)
        {
            //Хотя наверное с большим массивом данных проще работать с XmlDocument, не знаю что лучше или надёжнее или правильнее
            ToDoList list = new ToDoList();
            XmlSerializer serializer = new XmlSerializer(typeof(ToDoList));
            try
            {
                using (FileStream file = new FileStream(Path.Combine(path, name), FileMode.Open, FileAccess.Read))
                {
                    list = (ToDoList)serializer.Deserialize(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}");
            }

            return list;
        }
        public static ToDoList SaveFile(string name, string path, ToDoList list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ToDoList));
            try
            {
                using (FileStream file = new FileStream(Path.Combine(path, name), FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(file, list);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}");
            }

            return list;
        }
        public static void ShowList(ToDoList list)
        {
            ShowLine();
            Console.WriteLine($"Название списка задач: '{list.name}'\n");

            List<ToDo> tasks = list.GetTasks();
            if (tasks.Count > 0)
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    string state = tasks[i].Complite() ? "[x]" : "[ ]";
                    Console.WriteLine($"{state} {i+1}. {tasks[i].Title}");
                }
            }
            else
            {
                Console.WriteLine($" Список задач пуст!");
            }
            ShowLine();
        }
        public static void ShowLine()
        {
            Console.WriteLine("============================================================================================");
        }
    }
}
