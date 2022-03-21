using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NotePad
{
    class FIO
    {
        public string name;                             // имя
        public string surname;                          // фамилия
        public string lastname = null;                  // отчество
        //public NumberOfPhone number = new NumberOfPhone();

        public void GetFio()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите ваше имя(обязательно): ");
                name = Console.ReadLine().ToLower(); // имя
                Console.WriteLine("Введите вашу Фамилию(обязательно): ");
                surname = Console.ReadLine().ToLower(); // фамилия 
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || !Regex.IsMatch(name, @"[^0-9,=_&?\+#@%^*$@!]+") || !Regex.IsMatch(surname, @"[^0-9,=_&?\+#@%^*$@!]+"))
                {
                    Console.WriteLine("А вот нет уж, давай по новой!(что-то вы забыли ввести, или ввели некорректно)");
                    continue;
                }
                else 
                {
                    if (name.Length > 1) { name = char.ToUpper(name[0]) + name.Substring(1); }
                    if (surname.Length > 1) { surname = char.ToUpper(surname[0]) + surname.Substring(1); }
                    break;
                }
            }
            Console.WriteLine("Введите ваше отчество(не обязательно): ");
            lastname = Console.ReadLine().ToLower(); // отчество
            if (lastname == "") { lastname = " "; }

        }
    }
}
