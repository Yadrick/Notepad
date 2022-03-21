using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotePad
{
    class Post
    {
        public string post = null;                  // должность
        public string GetPost()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Должность(не обязатеьно):  ");
                Console.WriteLine("(Если не хотите указывать - пропустите поле, нажав Enter)");
                post = Console.ReadLine();
                if (post == "") { break; }

                else if (!Regex.IsMatch(post, @"[^=&?+#@%^*$@!]+"))
                {
                    Console.WriteLine("А вот нет уж, давай по новой!(Ну же, заполните данное поле корректно(без некорректных символов))");
                    continue;
                }
                else break;
            }
            return post;
        }
    }
}
