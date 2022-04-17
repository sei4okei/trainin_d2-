using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace trainin_d1
{
    internal class Program
    {
        private static List<Person> DB = new List<Person>();

        static void Main()
        {
            switch (ReadLine())
            {
                case "1":
                    AddNewRecord();
                    Main();
                    break;

                case "2":
                    ReadAllRecords();
                    Main();
                    break;

                case "3":
                    DeleteRecord();
                    Main();
                    break;

                case "4":
                    EditRecord();
                    Main();
                    break;

                default:
                    Main();
                    break;
            }
        }
        private static IEnumerator<int> sequence = Enumerable.Range(1, int.MaxValue).GetEnumerator();

        public static void DeleteRecord()
        {
            var userDeletedRecord = ReadLine();
            DB.RemoveAt(Convert.ToInt32(userDeletedRecord)-1);
            DB[0].ID = 1;
            while (true)
            {
                for (int i = 0; i < DB.Count - 1; i++)
                {
                    if (DB[i+1].ID - 1 != DB[i].ID)
                    {
                        DB[i + 1].ID = DB[i].ID + 1;
                    }
                }
                break;
            }
        }

        public static void EditRecord()
        {
            var userEditedRecord = Convert.ToInt32(ReadLine()) - 1;

            WriteLine(DB[userEditedRecord].Name);
            DB[userEditedRecord].Name = ReadLine();
            WriteLine(DB[userEditedRecord].SurName);
            DB[userEditedRecord].SurName = ReadLine();
            WriteLine(DB[userEditedRecord].Age);
            DB[userEditedRecord].Age = ReadLine();
            WriteLine(DB[userEditedRecord].Perfomance);
            DB[userEditedRecord].Perfomance = ReadLine();
        }

        public static void AddNewRecord()
        {
            var userName = ReadLine();
            var userSurName = ReadLine();
            var userAge = ReadLine();
            var userPerfomance = ReadLine();
            if (DB.Count() == sequence.Current)
            {
                sequence.MoveNext();
            }
            var id = sequence.Current;
            var person = new Person
            {
                ID = id,
                Name = userName,
                SurName = userSurName,
                Age = userAge,
                Perfomance = userPerfomance
            };
            DB.Add(person);
        }

        public static void ReadAllRecords()
        {
            WriteLine($"ID\t Имя\t Фамилия\t Возраст\t Увлечения");
            foreach (var person in DB)
            {
                WriteLine($"{person.ID}\t{person.Name}\t{person.SurName}\t{person.Age}\t{person.Perfomance}");
            }
        }
    }

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Age { get; set; }
        public string Perfomance { get; set; }
    }
}
