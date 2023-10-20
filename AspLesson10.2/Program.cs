//Задание
//Создайте MVC приложений с одним представлением. В представлении должно отображаться
//сообщение, которое находиться в файле конфигурации.

//Задание 1
//Создайте MVC приложений с одним представлением. В представлении должно отображаться
//сообщение, которое находиться в файле конфигурации. Сделайте так чтобы приложение
//обновляло сообщение в представлении если значение менялось в конфигурационном файле.
//Для обновления данных в представлении приложение не нужно перегружать.

//Задание 2
//Создайте MVC приложение котором реализуйте форму, которая будет отправлять email
//сообщение. В форме сделайте поля вводов – получатель, тема, сообщение. Для отправки
//сообщения зарегистрируйтесь на каком-то почтовом сервере. Ваше приложение должно
//отправлять сообщения пользуясь данными этого почтового сервера. Данные для отправки
//подключения к серверу вынесите в файл конфигурации.
//Перед використанням треба змінити пароль та логін в файлі appsettings.json
using AspLesson10._2.Models;
using AspLesson10._2.Services;

namespace AspLesson10._2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Configuration.AddJsonFile("appsettings.json", false, reloadOnChange: true);
            builder.Services.Configure<SmtpSetting>(builder.Configuration.GetSection("SmtpSettings"));
            builder.Services.AddTransient<SmtpMailSender>();
            var app = builder.Build();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.Run();
        }
    }
}