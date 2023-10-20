//�������
//�������� MVC ���������� � ����� ��������������. � ������������� ������ ������������
//���������, ������� ���������� � ����� ������������.

//������� 1
//�������� MVC ���������� � ����� ��������������. � ������������� ������ ������������
//���������, ������� ���������� � ����� ������������. �������� ��� ����� ����������
//��������� ��������� � ������������� ���� �������� �������� � ���������������� �����.
//��� ���������� ������ � ������������� ���������� �� ����� �����������.

//������� 2
//�������� MVC ���������� ������� ���������� �����, ������� ����� ���������� email
//���������. � ����� �������� ���� ������ � ����������, ����, ���������. ��� ��������
//��������� ����������������� �� �����-�� �������� �������. ���� ���������� ������
//���������� ��������� ��������� ������� ����� ��������� �������. ������ ��� ��������
//����������� � ������� �������� � ���� ������������.
//����� ������������� ����� ������ ������ �� ���� � ���� appsettings.json
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