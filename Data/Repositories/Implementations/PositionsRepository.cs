using ProjectManagerApi.Models.Employees;
using ProjectManagerApi.Data.Repository;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Dtos.Services;
using ProjectManagerApi.Entities;
using ProjectManagerApi.Dtos.Employees.Positions;

namespace ProjectManagerApi.Data.Repositories.Implementations
{
    public class PositionsRepository : Repository<Position>
    {
        public PositionsRepository(AppDbContext db) : base(db) { }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await GetAsync(id);
        }
        public async Task<Position> GetPositionByTitleAsync(string title)
        {
            return await Set.FirstOrDefaultAsync(s => s.Title == title);
        }

        public async Task<bool> CreatePositionAsync(Position position)
        {
            return await CreateAsync(position);
        }

        public async Task<bool> UpdatePositionAsync(Position position, PositionUpdateDto positionUpdateDto)
        {
            position.Title = positionUpdateDto.Title;
            position.Description = positionUpdateDto.Description;

            return await UpdateAsync(position);
        }

        public async Task<bool> DeletePositionsAsync()
        {
            return await DeleteAllAsync();
        }
        public async Task<bool> DeletePositionAsync(Position position)
        {
            return await DeleteAsync(position);
        }
    }
}
