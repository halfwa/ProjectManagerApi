
using ProjectManagerApi.Data;
using ProjectManagerApi.Entities;
using ProjectManagerApi.Models.Employees;

namespace ProjectManagerApi
{
    /// <summary>
    /// ���������� ���� ������
    /// </summary>
    public static class PrepDb
    {
        /// <summary>
        /// ������������� �������� ������ � ��
        /// </summary>
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()!);
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new Project() { Name = "eShop", Description = "Just a Shop in web project", Image = "https://image1.jpeg", Link = "https://eShop.com" },
                    new Project() { Name = "CRM", Description = "Just a CRM project", Image = "https://image2.jpeg", Link = "https://preview-crm.ru" }
                );


                context.SaveChanges();
            }


            if (!context.Employees.Any())
            {
                var pos1 = new Position() { Title = "Backend", Description = "��������� � backend ���������� �������" };
                var pos2 = new Position() { Title = "Frontend", Description = "��������� � frontend ���������� �������" };
                var pos3 = new Position() { Title = "TeamLead", Description = "������� ����������� �� �������" };

                context.Positions.AddRange(pos1, pos2, pos3 );

                context.SaveChanges();

                var emp1 = new Employee() { PositionId = pos1.Id, FirstName = "����", LastName = "�������", Patronymic = "����������", Photo = "https://photo1.jpeg" };
                var emp2 = new Employee() { PositionId = pos2.Id, FirstName = "�������", LastName = "�����", Patronymic = "���������", Photo = "https://photo2.jpeg" };
                var emp3 = new Employee() { PositionId = pos3.Id, FirstName = "�����", LastName = "������", Patronymic = "��������", Photo = "https://photo3.jpeg" };

                context.Employees.AddRange(emp1, emp2, emp3);

                context.SaveChanges();
            }

            if (!context.Services.Any())
            {
                context.Services.AddRange(
                    new Service() { Name = "���������� CRM", Description = "���������� CRM ��� ����", Image = "https://service-image-1.jpeg" },
                    new Service() { Name = "���������� Api", Description = "���������� Api ���������� ��� ����", Image = "https://service-image-2.jpeg" },
                    new Service() { Name = "���������� WebShop", Description = "���������� WebShop ��� ����", Image = "https://service-image-3.jpeg" }
                );
                
                context.SaveChanges();
            }
        }
    }
}