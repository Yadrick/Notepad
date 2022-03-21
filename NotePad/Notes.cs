using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotePad
{
    class Notes
    {
      
        public string notes; // заметки
        public string GetNotes()
        {
            Console.Clear();
            Console.WriteLine("Введите заметки(по желанию):  ");
            notes = Console.ReadLine();
            return notes;
        }

    }
}
