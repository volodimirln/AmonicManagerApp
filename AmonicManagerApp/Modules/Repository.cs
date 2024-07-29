using AmonicManagerApp.Data;
using AmonicManagerApp.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmonicManagerApp.Modules
{
    public class Repository
    {
        private static Model model = new Model();
        public static int status = 0;
        public static async Task SaveRepository() 
        {
            model.Database.CreateIfNotExists();
            if (model.Roles.Count() == 0)
            {
                await SetRoles();
                status += 9;
            }
            if (model.Countries.Count() == 0)
            {
                await SetCountries();
                status += 9;
            }
            if (model.Users.Count() == 0)
            {
                await SetUsers();
                status += 9;

            }
            if (model.Passwords.Count() == 0)
            {
                await SetPasswords();
                status += 9;
            }
            if (model.Airports.Count() == 0)
            {
                await SetAirports();
                status += 9;
            }
            if (model.Directions.Count() == 0)
            {
                await SetDirections();
                status += 9;
            }
            if (model.Planes.Count() == 0)
            {
                await SetPlanes();
                status += 9;
            }
            if (model.Terminals.Count() == 0)
            {
                await SetTerminals();
                status += 9;
            }
            if (model.TerminalsInDirections.Count() == 0)
            {
                await SetTerminalsInDirections();
                status += 9;
            }
            if (model.Flyings.Count() == 0)
            {
                await SetFlyings();
                status += 9;
            }

            if (model.Pricings.Count() == 0)
            {
                await SetPricings();
                status += 9;

            }
            if (model.Tickets.Count() == 0)
            {
                await SetTickets();
                status += 9;
            }
        }

        public static async Task SetRoles()
        {
            if (model.Roles.Count() == 0)
            {
                model.Roles.Add(new Role() { Title = "Менеджер", AccessRight = "111" });
                model.Roles.Add(new Role() { Title = "Клиент", AccessRight = "000" });
                model.Roles.Add(new Role() { Title = "Администратор", AccessRight = "222" });
                await model.SaveChangesAsync();
            }
        }
        public static async Task SetCountries()
        {
            if (model.Countries.Count() == 0)
            {
                model.Countries.Add(new Country() { Name = "Республика Армения", Code = "AM" });
                model.Countries.Add(new Country() { Name = "Республика Беларусь", Code = "BY" });
                model.Countries.Add(new Country() { Name = "Республика Казахстан", Code = "KZ" });
                model.Countries.Add(new Country() { Name = "Кыргызстан", Code = "KG" });
                model.Countries.Add(new Country() { Name = "Республика Молдова", Code = "MD" });
                model.Countries.Add(new Country() { Name = "Российская Федерация", Code = "RU" });
                model.Countries.Add(new Country() { Name = "Республика Таджикистан", Code = "TJ" });
                model.Countries.Add(new Country() { Name = "Республика Узбекистан", Code = "UZ" });
                await model.SaveChangesAsync();
            }
        }
        public static async Task SetUsers()
        {
            model = new Model();
            if (model.Users.Count() == 0)
            {
                model.Users.Add(new User() { CountryId = 1, PassportId="8493", PassportNumber="843928404", Login = "artemov@amonic.ru", Surname = "Артемов", Name = "Иван", Patronymic = "Матвеевич", Telephone = "84501196940", RoleId = 3, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 2, PassportId = "8493", PassportNumber = "834982", Login = "cvetkov@amonic.ru", Surname = "Цветкова", Name = "Виктория", Patronymic = "Данииловна", Telephone = "84332515803", RoleId = 2, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 3, PassportId = "7384", PassportNumber = "09475", Login = "egorov@amonic.ru", Surname = "Егоров", Name = "Дмитрий", Patronymic = "Александрович", Telephone = "84742020888", RoleId = 3, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 4, PassportId = "34892", PassportNumber = "094732", Login = "vasilieva@amonic.ru", Surname = "Васильева", Name = "Александра", Patronymic = "Матвеевна", Telephone = "84467285152", RoleId = 1, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 5, PassportId = "438", PassportNumber = "58239402", Login = "kojevnikov@amonic.ru", Surname = "Кожевников", Name = "Данила", Patronymic = "Святославович", Telephone = "84853986831", RoleId = 2, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 6, PassportId = "3498", PassportNumber = "374829", Login = "volkov@amonic.ru", Surname = "Волков", Name = "Лев", Patronymic = "Егорович", Telephone = "84303283874", RoleId = 3, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 7, PassportId = "8493", PassportNumber = "49389294", Login = "iliin@amonic.ru", Surname = "Ильин", Name = "Кирилл", Patronymic = "Львович", Telephone = "84600668543", RoleId = 1, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 8, PassportId = "02843", PassportNumber = "83940281", Login = "dmitriev@amonic.ru", Surname = "Дмитриев", Name = "Георгий", Patronymic = "Арсентьевич", Telephone = "84205044098", RoleId = 2, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 8, PassportId = "8439", PassportNumber = "9344382", Login = "smirnova@amonic.ru", Surname = "Смирнова", Name = "Александра", Patronymic = "Марковна", Telephone = "84991745894", RoleId = 3, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 7, PassportId = "7384", PassportNumber = "923848", Login = "fokin@amonic.ru", Surname = "Фокин", Name = "Пётр", Patronymic = "Никитич", Telephone = "84716626045", RoleId = 1, Active = true, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 6, PassportId = "0437", PassportNumber = "23849298", Login = "somova@amonic.ru", Surname = "Сомова", Name = "София", Patronymic = "Артёмовна", Telephone = "84150968800", RoleId = 2, Active = false, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 5, PassportId = "3483", PassportNumber = "92384204", Login = "goncharova@amonic.ru", Surname = "Гончаров", Name = "Семён", Patronymic = "Артёмович", Telephone = "84722143913", RoleId = 3, Active = false, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 4, PassportId = "2389", PassportNumber = "29482901", Login = "sokolova@amonic.ru", Surname = "Соколова", Name = "Анна", Patronymic = "Гордеевна", Telephone = "84420808779", RoleId = 1, Active = false, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 3, PassportId = "432", PassportNumber = "294829402", Login = "sergeev@amonic.ru", Surname = "Сергеев", Name = "Юрий", Patronymic = "Алексеевич", Telephone = "84753226332", RoleId = 2, Active = false, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                model.Users.Add(new User() { CountryId = 2, PassportId = "234", PassportNumber = "28420285", Login = "shevcova@amonic.ru", Surname = "Шевцова", Name = "Василиса", Patronymic = "Константиновна", Telephone = "84816682221", RoleId = 3, Active = false, AddDate = DateTime.Now, ChangeDate = DateTime.Now });
                await model.SaveChangesAsync();
            }
        }
        public static async Task SetPasswords()
        {
            model = new Model();
            if (model.Passwords.Count() == 0)
            {
                model.Passwords.Add(new Password() { UserId = 1, HashPassword = "9854d901af45e43aec93d9f4ab180dcb", Active = true, AddDate = DateTime.Now });//v3bfjx
                model.Passwords.Add(new Password() { UserId = 2, HashPassword = "21021dfd19f0ffd05d97dc1b5a07bffc", Active = true, AddDate = DateTime.Now });//?M~w1Z
                model.Passwords.Add(new Password() { UserId = 3, HashPassword = "430b099209b650dd714e86193d4950f3", Active = true, AddDate = DateTime.Now });//98|R$g
                model.Passwords.Add(new Password() { UserId = 4, HashPassword = "e01e02f5fa348c4edd2ac52125829338", Active = true, AddDate = DateTime.Now });//P}q}J$
                model.Passwords.Add(new Password() { UserId = 5, HashPassword = "973ee1febd6f8b39e5153815d627ca48", Active = true, AddDate = DateTime.Now });//udU~$H
                model.Passwords.Add(new Password() { UserId = 6, HashPassword = "ebffa1785db4298ce1ca8d0f01bff742", Active = true, AddDate = DateTime.Now });//Ggw7L*
                model.Passwords.Add(new Password() { UserId = 7, HashPassword = "e5a803aaaf90e11751bcdbf49609b59d", Active = true, AddDate = DateTime.Now });//1DTt8x
                model.Passwords.Add(new Password() { UserId = 8, HashPassword = "2d58c6d31d1ebd189a1d957b7859b6eb", Active = true, AddDate = DateTime.Now });//NEJEPz
                model.Passwords.Add(new Password() { UserId = 9, HashPassword = "48a1cf3311f75ce1994dac49c75f0192", Active = true, AddDate = DateTime.Now });//NORASv
                model.Passwords.Add(new Password() { UserId = 10, HashPassword = "3d71aedc93e04066938d02a787d6e529", Active = true, AddDate = DateTime.Now });//{b#kw6
                model.Passwords.Add(new Password() { UserId = 11, HashPassword = "30573e6c6e69a9e24bd534c36a9b581b", Active = true, AddDate = DateTime.Now });//XgYr}w
                model.Passwords.Add(new Password() { UserId = 12, HashPassword = "4a0411531f5d0b456e3027189f89c99e", Active = true, AddDate = DateTime.Now });//WnoB%|
                model.Passwords.Add(new Password() { UserId = 13, HashPassword = "d76b1762d1ac4676b9d366a120e82614", Active = true, AddDate = DateTime.Now });//efd1Jb
                model.Passwords.Add(new Password() { UserId = 14, HashPassword = "60a5f3a127e3e056bea788cc25bbfe21", Active = true, AddDate = DateTime.Now });//Z0|8v8
                model.Passwords.Add(new Password() { UserId = 15, HashPassword = "bc910557921b805035c878bf8df00422", Active = true, AddDate = DateTime.Now });//R%V{%A
                await model.SaveChangesAsync();
                // 6ZhM60 %
            }
        }
        public static async Task SetAirports()
        {
            model = new Model();
            if (model.Airports.Count() == 0)
            {
                model.Airports.Add(new Airport() { Title = "Хитроу", Country = "Великобритания", City = "Лондон", Code = "LHR" });
                model.Airports.Add(new Airport() { Title = "Ханеда", Country = "Япония", City = "Токио", Code = "HND" });
                model.Airports.Add(new Airport() { Title = "Дубай", Country = "ОАЭ", City = "Дубай", Code = "DXB" });
                model.Airports.Add(new Airport() { Title = "О'Хара", Country = "США", City = "Чикаго", Code = "ORD" });
                model.Airports.Add(new Airport() { Title = "Беэр-Шева", Country = "Израиль", City = "Беэр-Шева", Code = "BEV" });
                model.Airports.Add(new Airport() { Title = "Шереметьево", Country = "Россия", City = "Москва", Code = "SVO" });
                model.Airports.Add(new Airport() { Title = "Франкфурт", Country = "Германия", City = "Франкфурт", Code = "FRA" });
                model.Airports.Add(new Airport() { Title = "Сидней", Country = "Австралия", City = "Сидней", Code = "SYD" });
                model.Airports.Add(new Airport() { Title = "Пекин-Капиталь", Country = "Китай", City = "Пекин", Code = "PEK" });
                model.Airports.Add(new Airport() { Title = "Индира Ганди", Country = "Индия", City = "Дели", Code = "DEL" });
                model.Airports.Add(new Airport() { Title = "Джона Кеннеди", Country = "США", City = "Нью-Йорк", Code = "JFK" });
                model.Airports.Add(new Airport() { Title = "Шанхай-Пудонг", Country = "Китай", City = "Шанхай", Code = "PVG" });
                model.Airports.Add(new Airport() { Title = "Ататюрк", Country = "Турция", City = "Стамбул", Code = "IST" });
                model.Airports.Add(new Airport() { Title = "Лос-Анджелес", Country = "США", City = "Лос-Анджелес", Code = "LAX" });
                model.Airports.Add(new Airport() { Title = "Кингсфорд-Смит", Country = "Австралия", City = "Сидней", Code = "SYD" });
                await model.SaveChangesAsync();
            }
        }
        public static async Task SetDirections()
        {
            model = new Model();
            if (model.Directions.Count() == 0)
            {
                model.Directions.Add(new Direction() { Active = true, Title = "Международное направление", FlightTime = 360 });
                model.Directions.Add(new Direction() { Active = true, Title = "Международное направление", FlightTime = 360 });
                model.Directions.Add(new Direction() { Active = true, Title = "Международное направление", FlightTime = 360 });
                model.Directions.Add(new Direction() { Active = true, Title = "Международное направление", FlightTime = 360 });
                model.Directions.Add(new Direction() { Active = true, Title = "Международное направление", FlightTime = 360 });
                model.Directions.Add(new Direction() { Active = true, Title = "Международное направление", FlightTime = 360 });
                model.Directions.Add(new Direction() { Active = true, Title = "Международное направление", FlightTime = 360 });
                model.Directions.Add(new Direction() { Active = true, Title = "Международное направление", FlightTime = 360 });
                await model.SaveChangesAsync();
            }
        }
        public static async Task SetPlanes()
        {
            model = new Model();
            if (model.Planes.Count() == 0)
            {
                model.Planes.Add(new Plane() { TailNumber = "F-WWAQ", DateOfIssue = new DateTime(1984, 09, 27), Type = "Среднемагистральный", NumberOfFlights = 250, FlightHours = 958, ReleaseCompany = "Airbus", Model = "A320", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "F-WWAQ", DateOfIssue = new DateTime(1984, 09, 27), Type = "Среднемагистральный", NumberOfFlights = 250, FlightHours = 958, ReleaseCompany = "Airbus", Model = "A320", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "N101SY", DateOfIssue = new DateTime(2012, 05, 18), Type = "Дальнемагистральный", NumberOfFlights = 180, FlightHours = 1250, ReleaseCompany = "Boeing", Model = "787-8", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "VT-ALJ", DateOfIssue = new DateTime(2007, 03, 03), Type = "Дальнемагистральный", NumberOfFlights = 310, FlightHours = 2150, ReleaseCompany = "Boeing", Model = "777-300ER", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "VP-BVZ", DateOfIssue = new DateTime(2016, 11, 22), Type = "Среднемагистральный", NumberOfFlights = 120, FlightHours = 680, ReleaseCompany = "Airbus", Model = "A321neo", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "B-2049", DateOfIssue = new DateTime(2015, 08, 11), Type = "Среднемагистральный", NumberOfFlights = 190, FlightHours = 1100, ReleaseCompany = "Boeing", Model = "737-800", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "SU-GCY", DateOfIssue = new DateTime(2019, 06, 30), Type = "Среднемагистральный", NumberOfFlights = 90, FlightHours = 430, ReleaseCompany = "Airbus", Model = "A220-300", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "D-AIXL", DateOfIssue = new DateTime(2018, 04, 24), Type = "Среднемагистральный", NumberOfFlights = 140, FlightHours = 800, ReleaseCompany = "Airbus", Model = "A319neo", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "N748CK", DateOfIssue = new DateTime(2001, 10, 17), Type = "Грузовой", NumberOfFlights = 320, FlightHours = 2750, ReleaseCompany = "Boeing", Model = "747-400ERF", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "G-OJMR", DateOfIssue = new DateTime(1997, 07, 09), Type = "Среднемагистральный", NumberOfFlights = 420, FlightHours = 3200, ReleaseCompany = "Airbus", Model = "A330-300", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "B-6055", DateOfIssue = new DateTime(2014, 12, 02), Type = "Среднемагистральный", NumberOfFlights = 270, FlightHours = 1450, ReleaseCompany = "Boeing", Model = "737-700", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "OE-LBP", DateOfIssue = new DateTime(2017, 02, 14), Type = "Среднемагистральный", NumberOfFlights = 180, FlightHours = 950, ReleaseCompany = "Airbus", Model = "A320neo", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "N58031", DateOfIssue = new DateTime(2016, 09, 08), Type = "Среднемагистральный", NumberOfFlights = 210, FlightHours = 1300, ReleaseCompany = "Boeing", Model = "737-900ER", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "VP-BBN", DateOfIssue = new DateTime(2013, 11, 29), Type = "Дальнемагистральный", NumberOfFlights = 270, FlightHours = 1850, ReleaseCompany = "Boeing", Model = "777-200LR", Active = true });
                model.Planes.Add(new Plane() { TailNumber = "C-GHPQ", DateOfIssue = new DateTime(2004, 06, 12), Type = "Грузовой", NumberOfFlights = 390, FlightHours = 2800, ReleaseCompany = "Airbus", Model = "A330-200F", Active = true });
                await model.SaveChangesAsync();
            }

        }
        public static async Task SetTerminals()
        {
            model = new Model();
            if (model.Terminals.Count() == 0)
            {
                model.Terminals.Add(new Terminal() { Title = "A", Type = "Пассажирский", AiroportId = 1, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "B", Type = "Пассажирский", AiroportId = 1, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "C", Type = "Пассажирский", AiroportId = 2, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "D", Type = "Пассажирский", AiroportId = 2, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "E", Type = "Пассажирский", AiroportId = 3, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "F", Type = "Пассажирский", AiroportId = 3, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "G", Type = "Пассажирский", AiroportId = 4, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "H", Type = "Пассажирский", AiroportId = 4, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "I", Type = "Пассажирский", AiroportId = 5, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "J", Type = "Пассажирский", AiroportId = 5, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "K", Type = "Пассажирский", AiroportId = 6, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "L", Type = "Пассажирский", AiroportId = 6, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "M", Type = "Пассажирский", AiroportId = 7, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "N", Type = "Пассажирский", AiroportId = 7, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "O", Type = "Пассажирский", AiroportId = 8, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "P", Type = "Пассажирский", AiroportId = 8, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "Q", Type = "Пассажирский", AiroportId = 9, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "R", Type = "Пассажирский", AiroportId = 9, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "S", Type = "Пассажирский", AiroportId = 10, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "T", Type = "Пассажирский", AiroportId = 10, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "U", Type = "Пассажирский", AiroportId = 11, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "V", Type = "Пассажирский", AiroportId = 11, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "W", Type = "Пассажирский", AiroportId = 12, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "X", Type = "Пассажирский", AiroportId = 12, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "Y", Type = "Пассажирский", AiroportId = 13, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "Z", Type = "Пассажирский", AiroportId = 13, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "F", Type = "Пассажирский", AiroportId = 14, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "D", Type = "Пассажирский", AiroportId = 14, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "S", Type = "Пассажирский", AiroportId = 15, TypeReception = "Международный" });
                model.Terminals.Add(new Terminal() { Title = "T", Type = "Пассажирский", AiroportId = 15, TypeReception = "Международный" });
                await model.SaveChangesAsync();
            }
        }
        public static async Task SetTerminalsInDirections()
        {
            model = new Model();
            if (model.TerminalsInDirections.Count() == 0)
            {
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 1, TerminalId = 1, TypeLandings = "Отправление" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 1, TerminalId = 3, TypeLandings = "Прибытие" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 2, TerminalId = 2, TypeLandings = "Отправление" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 2, TerminalId = 4, TypeLandings = "Прибытие" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 3, TerminalId = 5, TypeLandings = "Отправление" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 3, TerminalId = 7, TypeLandings = "Прибытие" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 4, TerminalId = 6, TypeLandings = "Отправление" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 4, TerminalId = 8, TypeLandings = "Прибытие" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 5, TerminalId = 9, TypeLandings = "Отправление" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 5, TerminalId = 11, TypeLandings = "Прибытие" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 6, TerminalId = 10, TypeLandings = "Отправление" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 6, TerminalId = 12, TypeLandings = "Прибытие" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 7, TerminalId = 13, TypeLandings = "Прибытие" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 7, TerminalId = 15, TypeLandings = "Отправление" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 8, TerminalId = 14, TypeLandings = "Прибытие" });
                model.TerminalsInDirections.Add(new TerminalsInDirection() { DirectionId = 8, TerminalId = 16, TypeLandings = "Отправление" });
                await model.SaveChangesAsync();
            }
        }
        public static async Task SetFlyings()
        {
            model = new Model();
            if (model.Flyings.Count() == 0)
            {
                model.Flyings.Add(new Flying() { PlaneId = 1, FlyingNumber ="TY 0989", DirectonId = 1, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) }); ;
                model.Flyings.Add(new Flying() { PlaneId = 2, FlyingNumber = "Yi 3424", DirectonId = 2, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 3, FlyingNumber = "JF 34U2", DirectonId = 3, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 4, FlyingNumber = "FN 34U8", DirectonId = 4, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 5, FlyingNumber = "SN 3429", DirectonId = 5, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 6, FlyingNumber = "SC 3433", DirectonId = 6, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 7, FlyingNumber = "SF 2749", DirectonId = 7, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 8, FlyingNumber = "DF 0927", DirectonId = 8, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 9, FlyingNumber = "FD 2729", DirectonId = 1, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 10, FlyingNumber = "DS 0989", DirectonId = 2, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 11, FlyingNumber = "GF 2454", DirectonId = 3, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 12, FlyingNumber = "FD 3424", DirectonId = 4, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 13, FlyingNumber = "AS 3424", DirectonId = 5, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 14, FlyingNumber = "FG 3424", DirectonId = 6, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                model.Flyings.Add(new Flying() { PlaneId = 15, FlyingNumber = "DF 2849", DirectonId = 1, NumberOfSeats = 75, TypeFlying = "Международный", Restrictions = "Нет", Canceled = false, Completed = false, FlyingDate = DateTime.Today, DateTimeDeparture = DateTime.Now, DateTimeArrival = DateTime.Now.AddMinutes(new Random().Next(180, 600)) });
                await model.SaveChangesAsync();
            }
        }
        public static async Task SetPricings()
        {
            model = new Model();
            if (model.Pricings.Count() == 0)
            {
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 1, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 1, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 1, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 1, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 2, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 2, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 3, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 3, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 4, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 4, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 5, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 5, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 6, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 6, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 7, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 7, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 8, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 8, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 9, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 9, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 10, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 10, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 11, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 11, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 12, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 12, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 13, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 13, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 14, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 14, Price = 17500, Place = "65" });
                model.Pricings.Add(new Pricing() { Class = "Эконом", FlyingId = 15, Price = 7500, Place = "25" });
                model.Pricings.Add(new Pricing() { Class = "Бизнес", FlyingId = 15, Price = 17500, Place = "65" });
                await model.SaveChangesAsync();
            }
        }
        public static async Task SetTickets()
        {
            model = new Model();
            if (model.Tickets.Count() == 0)
            {
                model.Tickets.Add(new Ticket() { PricingId = 1, NumberPlace = "31A", UserId = 2, DateSale = DateTime.Now });
                model.Tickets.Add(new Ticket() { PricingId = 2, NumberPlace = "39A", UserId = 5, DateSale = DateTime.Now });
                model.Tickets.Add(new Ticket() { PricingId = 3, NumberPlace = "65A", UserId = 8, DateSale = DateTime.Now });
                model.Tickets.Add(new Ticket() { PricingId = 4, NumberPlace = "39A", UserId = 11, DateSale = DateTime.Now });
                model.Tickets.Add(new Ticket() { PricingId = 5, NumberPlace = "75A", UserId = 14, DateSale = DateTime.Now });
                await model.SaveChangesAsync();
            }
        }
    }
}
