using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotePad
{
    class DataOfBirhtday
    {
        public DateTime date;
        public string probnikY;
        public string probnikM;
        public string probnikD;

        public DateTime GetDate()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите дату вашего рождения(поле не обязательное): ");
                Console.WriteLine("Введите в формате День \"Enter\" Месяц \"Enter\" Год");
                Console.WriteLine("При введении некорректной даты, вас попросят перезаписать или присвоится наиболее близкая дата по значению");
                Console.WriteLine("(Если не хотите указывать - пропустите поле, нажав Enter)");
                probnikD = Console.ReadLine();
                
                if (probnikD == "") { date = new DateTime(0001, 01, 01); ; break; }
                probnikM = Console.ReadLine();
                probnikY = Console.ReadLine();
                if(!Regex.IsMatch(probnikD, @"[а-яА-Яa-zA-Z^=&?+#@%^*$@!]+") && !Regex.IsMatch(probnikM, @"[а-яА-Яa-zA-Z^=&?+#@%^*$@!]+") && !Regex.IsMatch(probnikY, @"[а-яА-Яa-zA-Z^=&?+#@%^*$@!]+"))
                {   
                    if (Convert.ToInt32(probnikY) < 0) { probnikY = "0"; }
                    if (Convert.ToInt32(probnikY) >= 10000) { probnikY = "9999"; }
                    if (Convert.ToInt32(probnikM) < 1) { probnikM = "1"; }
                    if (Convert.ToInt32(probnikM) > 12) { probnikM = "12"; }
                    if (Convert.ToInt32(probnikD) > 31) { probnikD = "28"; }
                    if (Convert.ToInt32(probnikD) < 1) { probnikD = "1"; }
                    date = new DateTime(Convert.ToInt32(probnikY), Convert.ToInt32(probnikM), Convert.ToInt32(probnikD));
                    break;
                }
            }
            return date;
        }
    }
}
