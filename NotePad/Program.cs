using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotePad
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> listFamilia = new List<string>();                          // список фамилий
            List<string> listName = new List<string>();                             // список имен
            List<string> listOtchestvo = new List<string>();                        // список отчеств
            List<long> listNumbers = new List<long>();                              // список номеров телефонов
            List<string> listCountrys = new List<string>();                         // список стран
            List<string> listDates = new List<string>();                            // список дат рождений
            List<string> listOrganizations = new List<string>();                    // список организаций
            List<string> listPosts = new List<string>();                            // список должностей
            List<string> listNotes = new List<string>();                            // список Заметок   
            List<int> count = new List<int>();                                      // счетчик записей
            int chislo = 0;

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в Телефонную книгу");
                Console.WriteLine("Если вы хотите занести свои данные, то нажмите цифру 1");                        // сделано
                Console.WriteLine("Если хотите изменить запись, то нажмите цифру 2");                               // сдлано
                Console.WriteLine("Если хотите удалить запись, то для выбора записи нажмите цифру 3");              // НЕОБХОДИМО БУДЕТ ДОБАВИТЬ ИЗМЕНЕНИЕ СЧЕТЧИКА ЗАПИСЕЙ
                Console.WriteLine("Для просмотра всех учетных записей с краткой информацией - цифра 4");            // сделано
                Console.WriteLine("Чтобы просмотреть полную информацию о каждой записи - цифра 5");                 //
                Console.WriteLine("Чтобы закончить работу с Телефонной книгой, нажмите 0");                         // сделано

                // ПРОВЕРКА НА ВВЕДЕНИЕ ЦИФРЫ
                int perehod;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out perehod) && perehod < 6 && perehod >= 0)
                    {
                        break;
                    }
                    Console.WriteLine("А вот нет уж, давай по новой!(что - то вы ввели не тоо!)");
                }
                //-------------------------------------------------- Если хотим закрыть программу внизу проверка
                if(perehod == 0) { break; }

                // если решили создать учетную запись, то вызываем метод, который создает человека, и засовываем полученные данные в соответствующие списки
                //--------------------------------------------------------------------------------------------------------------------
                if (perehod == 1)
                {
                    Console.Clear();
                    Human hum = new Human();
                    NumberOfPhone nnnnumber = new NumberOfPhone(); // это экземпляр нужен для перезапииси номера, если такой уже есть в тел. книге
                    hum.GetHuman();
                    listFamilia.Add(hum.surname);
                    listName.Add(hum.name);
                    listOtchestvo.Add(hum.lastname);
                    while (true)
                    {
                        if (listNumbers.Contains(hum.number) == false) { listNumbers.Add(hum.number); break; }
                        else 
                        {
                            Console.WriteLine("Введёный ранее вами номер уже зарегестрирован. Введите незарегестрированный номер для регистрации новой записи.");
                            hum.number = nnnnumber.GetNumber(); 
                        }
                    }     
                    
                    listCountrys.Add(hum.country);                                                      // страны проживания

                    // необязательные поля
                    if (hum.date.ToShortDateString() == DateTime.MinValue.ToShortDateString()) { listDates.Add(null); }   // Если дату решили не вводить, то добавляется null
                    else listDates.Add(hum.date.ToShortDateString());                                           // Если ввели, то записываем в формате 10.10.2010

                    listOrganizations.Add(hum.organization);                                                                // Место Работы
                    listPosts.Add(hum.post);                                                                                // Должность
                    listNotes.Add(hum.note);                                                                                // Заметки
                    chislo++;  count.Add(chislo);                                                                           // увеличиваем счетчик на 1
                    Console.WriteLine($"Поздравляем! Теперь количество зарегестрированных людей в телефонной книге: {count.Count} ");
                    Console.WriteLine("Для перехода в главное меню нажмите любую кнопку...");
                    Console.ReadKey();
                    continue;
                } // блок добавления записи---------------------------------------------------------------------------------------

                // действия для изменения записи-------------------------------------------------------------------------
                if (perehod == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Для выхода в главное меню, нажмите 0");   
                    Console.WriteLine("Если хотите изменить запись, то ввеедите Ваш уникальный идентификатор(номер телефона)");
                    long proba;
                    while (true)
                    {
                        if ((long.TryParse(Console.ReadLine(), out proba) && listNumbers.Contains(proba)) || proba == 0)
                        {
                            break;
                        }
                        Console.WriteLine("А вот нет уж, давай по новой!(Запись некорректна или данного идентификатора не существует!)");
                    }
                    if(proba == 0) { continue; }
                    int i = listNumbers.IndexOf(proba);
                    // делаю цикл, чтобы можно было все изменить за один присест
                    while (true) {
                        Console.Clear();
                        Console.WriteLine("Ваши данные на настоящий момент:");
                        Console.WriteLine($"1. Имя - {listName[i]}\tФамилия - {listFamilia[i]}\tОтчество - {listOtchestvo[i]}");
                        Console.WriteLine($"2. Номер телефона - {listNumbers[i]}\n3. Страна - {listCountrys[i]}\n4. Дата рождения - {listDates[i]}");
                        Console.WriteLine($"5. Организация - {listOrganizations[i]}\n6. Должность - {listPosts[i]} ");
                        Console.WriteLine($"7. Прочие заметки: {listNotes[i]}");
                        Console.WriteLine();
                        Console.WriteLine("Для редактирования выберите соответствующую цифру(1-7): ");
                        Console.WriteLine("Для выхода в главное меню, нажмите 0");

                        int red;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out red) && red < 8 && red >= 0)
                            {
                                break;
                            }
                            Console.WriteLine("А вот нет уж, давай по новой!(нужно ввести корректную цифру!)");
                        }
                        if (red == 0) { break; }                                                                    // ВЫХОД В ГЛАВНОЕ МЕНЮ
                        //  изменяем ФИО
                        if (red == 1)
                        {
                            Console.WriteLine();
                            FIO fio = new FIO();
                            fio.GetFio();
                            listName[i] = fio.name; listFamilia[i] = fio.surname; listOtchestvo[i] = fio.lastname;
                            Console.WriteLine($" Теперь: Имя - {listName[i]}\tФамилия - {listFamilia[i]}\tОтчество - {listOtchestvo[i]}\nНажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        // Для изменения номер телефона
                        if (red == 2)
                        {
                            Console.WriteLine();
                            NumberOfPhone number = new NumberOfPhone();
                            number.GetNumber();
                            listNumbers[i] = number.number; 
                            Console.WriteLine($" Теперь: Номер телефона - {listNumbers[i]}\nНажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        // Для изменения Страны
                        if (red == 3)
                        {
                            Console.WriteLine();
                            Country country = new Country();
                            country.GetCountry();
                            listCountrys[i] = country.country;
                            Console.WriteLine($" Теперь: Страна - {listCountrys[i]}\nНажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        // Для изменения Даты Рождения
                        if (red == 4)
                        {
                            Console.WriteLine();
                            DataOfBirhtday date = new DataOfBirhtday();
                            date.GetDate();

                            if (date.date.ToShortDateString() == DateTime.MinValue.ToShortDateString()) { listDates[i] = null; }
                            else listDates[i] = date.date.ToShortDateString();

                            Console.WriteLine($" Теперь: Дата рождения - {listDates[i]}\nНажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        // Для изменения Организации
                        if (red == 5)
                        {
                            Console.WriteLine();
                            Organization orga = new Organization();
                            orga.GetOrganization();
                            listOrganizations[i] = orga.organization;
                            Console.WriteLine($" Теперь: Организация - {listOrganizations[i]}\nНажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        // Для изменения Должности
                        if (red == 6)
                        {
                            Console.WriteLine();
                            Post post = new Post();
                            post.GetPost();
                            listPosts[i] = post.post;
                            Console.WriteLine($" Теперь: Должность - {listPosts[i]}\nНажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        // Для изменения Заметок
                        if (red == 7)
                        {
                            Console.WriteLine();
                            Notes note = new Notes();
                            note.GetNotes();
                            listNotes[i] = note.notes;
                            Console.WriteLine($" Теперь: Заметки: {listNotes[i]}\nНажмите любую клавишу...");
                            Console.ReadKey();
                        }
                    }
                }   //----------------------------------------------------------------------------------------Блок изменения записи


                //Удалить запись
                if (perehod == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Для выхода в главное меню, нажмите 0");
                    Console.WriteLine("Вы решили удалить запись из телефонной книги");
                    Console.WriteLine("Введите, пожалуйста,  уникальный идентификатор записи(номер телефона): ");

                    long proba; // запишем сюда идентификатор-номер 
                    while (true)
                    {
                        if ((long.TryParse(Console.ReadLine(), out proba) && listNumbers.Contains(proba)) || proba == 0)
                        {
                            break;
                        }
                        Console.WriteLine("А вот нет уж, давай по новой!(Запись некорректна или данного идентификатора не существует!)");
                    }
                    if(proba == 0) { continue; }
                    int i = listNumbers.IndexOf(proba); // порядковый номер в списке

                    Console.WriteLine("Ваши данные на настоящий момент:");
                    Console.WriteLine($"1. Имя - {listName[i]}\tФамилия - {listFamilia[i]}\tОтчество - {listOtchestvo[i]}");
                    Console.WriteLine($"2. Номер телефона - {listNumbers[i]}\n3. Страна - {listCountrys[i]}\n4. Дата рождения - {listDates[i]}");
                    Console.WriteLine($"5. Организация - {listOrganizations[i]}\n6. Должность - {listPosts[i]} ");
                    Console.WriteLine($"7. Прочие заметки: {listNotes[i]}");
                    Console.WriteLine();
                    Console.WriteLine("Вы точно хотите удалить свою запись? Введите да/нет");

                    while (true)
                    {
                        string soglasie = Console.ReadLine();
                        if (!Regex.IsMatch(soglasie, @"[^0-9,=_&?\+#@%^*$@!]+"))
                        {
                            Console.WriteLine("А вот нет уж, давай по новой!(Ну же, заполните данное поле корректно(без цифр и некорректных символов))");
                            continue;
                        }
                        if (soglasie != "да" || soglasie != "нет") { Console.WriteLine("Введите да/нет"); }
                        if(soglasie == "да" || soglasie == "нет") 
                        { 
                            if(soglasie == "нет") { break; }
                            if(soglasie == "да")
                            {
                                listName.RemoveAt(i); listFamilia.RemoveAt(i); listOtchestvo.RemoveAt(i);
                                listNumbers.RemoveAt(i);
                                listCountrys.RemoveAt(i);
                                listDates.RemoveAt(i);
                                listOrganizations.RemoveAt(i); listPosts.RemoveAt(i);
                                listNotes.RemoveAt(i);
                                count.RemoveAt(count.Count-1);
                                Console.WriteLine("Всё, ваша запись удалена (\nДля перехода в главное меню нажмите любую клавишу...");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }


                }//------------------------------------------
                
                // просмотреть все учетные записи в кратком содержании
                if (perehod == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Список всех записей в кратком содержании: ");
                    Console.WriteLine();
                    Console.WriteLine("№. Фамилия имя - номер телефона");
                    for (int i = 0; i < count.Count; i++)
                    {
                        Console.WriteLine($"{count[i]}. {listFamilia[i]} {listName[i]} - {listNumbers[i]}");
                    }
                    Console.WriteLine("Для выхода в главное меню нажмите 0");
                    int red;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out red) && red == 0)
                        {
                            break;
                        }
                        Console.WriteLine("А вот нет уж, давай по новой!(нужно ввести корректную цифру!)");
                    }
                    if (red == 0) { continue; }
                }//----------------------------------------------------------------просмотр всех записей в кратком содержании

                // просмотреть все учетные записи в полном содержании
                if (perehod == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Список всех записей: ");
                    Console.WriteLine();

                    for (int i = 0; i < count.Count; i++)
                    {
                        Console.WriteLine($"{count[i]}. {listFamilia[i]}{char.ToUpper(listName[i][0])}.{char.ToUpper(listOtchestvo[i][0])}.\t - \t{listNumbers[i]}\t - \t{listCountrys[i]}\t - " +
                            $"\t{listDates[i]}\t - \t{listOrganizations[i]}({listPosts[i]})");
                        Console.WriteLine($"Заметки: {listNotes[i]}");
                        Console.WriteLine("__________________________________________________________________________________________________________________");
                    }


                    Console.WriteLine("Для выхода в главное меню нажмите 0");
                    int red;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out red) && red == 0)
                        {
                            break;
                        }
                        Console.WriteLine("А вот нет уж, давай по новой!(нужно ввести корректную цифру!)");
                    }
                    if (red == 0) { continue; }
                }//----------------------------------------------------------------------------------просмотр всех записей


            }// -----------------------------------------------------------------Граница выполнения всех команд и функционала Тел.Книги


           


            


        }// граница Main
    }// граница class Program
}// Граница NotePad
