﻿using Microsoft.EntityFrameworkCore;
using training_track_backend.Models;

namespace training_track_backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User?> CreateUser(User user)
        {
            await _appDbContext.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>?> GetAllUsers()
        {
            return await _appDbContext.Users.Include(u => u.Trainings).ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _appDbContext.Users.Include(u => u.Trainings).FirstAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _appDbContext.Users.FirstAsync(u => u.Email == email);
        }

        public async Task<int> GetMaxId()
        {
            return await _appDbContext.Users.AnyAsync() ? await _appDbContext.Users.MaxAsync(i => i.Id) : 0;
        }
    }
}
