using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad
{
    class Human
    {
        //public NumberOfPhone number = new NumberOfPhone();
        public string name;                             // имя
        public string surname;                          // фамилия
        public string lastname = null;
        public long number;                             // номер телефона
        public string country;                          // страна проживания
        public DateTime date = new DateTime();          // дата рождения
        public string organization;                     // организация
        public string post;                             // должность
        public string note;                            // заметки

        FIO fio = new FIO();                                    // экземпляр с ФИО человека, содержит переменную номера, потом мы ей присваеваем значение
        NumberOfPhone numb = new NumberOfPhone();               // экземпляр, дабы записать номер
        Country count = new Country();                          // и т.д.
        DataOfBirhtday dat = new DataOfBirhtday();              //
        Organization orga = new Organization();                 //
        Post postes = new Post();                               //
        Notes notes = new Notes();                              //

        public void GetHuman()
        {
                                        
            // получаем все данные и присваиваем в поля нашего человека
            fio.GetFio();
            name = fio.name;
            surname = fio.surname;
            lastname = fio.lastname;
            this.number = numb.GetNumber();
            this.country = count.GetCountry();
            this.date = dat.GetDate();
            this.organization = orga.GetOrganization();
            this.post = postes.GetPost();
            this.note = notes.GetNotes();
        }



    }
}
