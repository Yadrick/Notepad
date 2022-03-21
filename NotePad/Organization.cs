using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotePad
{
    class Organization
    {
        public string organization = null;
        public string GetOrganization()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Место работы(не обязательно):  ");
                Console.WriteLine("(Если не хотите указывать - пропустите поле, нажав Enter)");         
                organization = Console.ReadLine();
                if (organization == "") { break; }

                else if (!Regex.IsMatch(organization, @"[^=&?+#@%^*$@!]+"))
                {
                    Console.WriteLine("А вот нет уж, давай по новой!(Ну же, заполните данное поле корректно(без некорректных символов))");
                    continue;
                }
                else break;
            }
            return organization;
        }
    }
}
