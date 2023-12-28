
using ProjectManagerApi.Data;
using ProjectManagerApi.Entities;
using ProjectManagerApi.Models.Employees;

namespace ProjectManagerApi
{
    /// <summary>
    /// Подготовка базы данных
    /// </summary>
    public static class PrepDb
    {
        /// <summary>
        /// Инициализация тестовых данных в БД
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
                var pos1 = new Position() { Title = "Backend", Description = "Участвует в backend разработке проекта" };
                var pos2 = new Position() { Title = "Frontend", Description = "Участвует в frontend разработке проекта" };
                var pos3 = new Position() { Title = "TeamLead", Description = "Старший разработчик на проекте" };

                context.Positions.AddRange(pos1, pos2, pos3 );

                context.SaveChanges();

                var emp1 = new Employee() { PositionId = pos1.Id, FirstName = "Иван", LastName = "Большов", Patronymic = "Васильевич", Photo = "https://photo1.jpeg" };
                var emp2 = new Employee() { PositionId = pos2.Id, FirstName = "Алексей", LastName = "Белый", Patronymic = "Андреевич", Photo = "https://photo2.jpeg" };
                var emp3 = new Employee() { PositionId = pos3.Id, FirstName = "Вадим", LastName = "Песков", Patronymic = "Иванович", Photo = "https://photo3.jpeg" };

                context.Employees.AddRange(emp1, emp2, emp3);

                context.SaveChanges();
            }

            if (!context.Services.Any())
            {
                context.Services.AddRange(
                    new Service() { Name = "Разработка CRM", Description = "Разработка CRM под ключ", Image = "https://service-image-1.jpeg" },
                    new Service() { Name = "Разработка Api", Description = "Разработка Api интеграций под ключ", Image = "https://service-image-2.jpeg" },
                    new Service() { Name = "Разработка WebShop", Description = "Разработка WebShop под ключ", Image = "https://service-image-3.jpeg" }
                );
                
                context.SaveChanges();
            }
        }
    }
}