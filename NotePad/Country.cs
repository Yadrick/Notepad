using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NotePad
{
    class Country
    {
        public string country;
        public string GetCountry()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Страна, в которой вы проживаете: ");
                country = Console.ReadLine();

                if (!Regex.IsMatch(country, @"[^0-9,=_&?\+#@%^*$@!]+"))
                {
                    Console.WriteLine("А вот нет уж, давай по новой!(Ну же, заполните данное поле корректно(без цифр и некорректных символов))");
                    continue;
                }
                else break;
            }
            return country;
        }
    }
}
