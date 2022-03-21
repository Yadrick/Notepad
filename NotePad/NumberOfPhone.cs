using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad
{
    class NumberOfPhone
    {
        public long number;

        public long GetNumber()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Введенный вами номер телефона будет вашим уникальным ИДЕНТИФИКАТОРОМ, по которому вы сможете редактировать запись." +
                    " Вводите обязательно свой номер!");
                Console.WriteLine("Введите, пожалуйста, ваш номер телефона(обязательно, только цифры): ");
                if (long.TryParse(Console.ReadLine(), out number) && number.ToString().Length == 11)
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("А вот нет уж, давай по новой!(Доступна только последовательность из 11 цифр)");
                Console.WriteLine();
            }
            return number;
        }
        
    }
}
