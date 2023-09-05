﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDal_0.Interfaces;
using ToDoListDomain_0.Entity_0;

namespace ToDoListDal_0.Repositories
{
    public class TaskRepository : IBaseRepository<TaskEntity>
    {
        private readonly AppDbContext _appDbContext;
        public TaskRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Create(TaskEntity entity)
        {
            await _appDbContext.Tasks.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(TaskEntity entity)
        {
            _appDbContext.Tasks.Remove(entity);
            await _appDbContext.SaveChangesAsync();

        }

        public IQueryable<TaskEntity> GetAll()
        {
            return _appDbContext.Tasks;
        }

        public async Task Update(TaskEntity entity)
        {
            _appDbContext.Tasks.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
