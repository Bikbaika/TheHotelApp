﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheHotelApp.Data;
using TheHotelApp.Models;
using TheHotelApp.ViewModels;

namespace TheHotelApp.Services
{
    public class GenericHotelService<TEntity> : IGenericHotelService<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<TEntity> DbSet;

        public GenericHotelService(ApplicationDbContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }
        public async Task CreateItemAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task EditItemAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllItemsAsync()
        {
            return await DbSet.ToArrayAsync();
        }

        public async Task<TEntity> GetItemByIdAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await DbSet.FindAsync(id);
        }

       // public async Task<TEntity> GetItemByIdAsync(Guid? id)
      //  {
       //     if (id == null)
       //     {
        //        return null;
       //     }

      //      return await DbSet.FindAsync(id);
       // }

        public async Task<IEnumerable<TEntity>> SearchForAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.Where(expression).ToArrayAsync();
        }
        public RoomsAdminIndexViewModel GetAllRoomsAndRoomTypes()
        {

            var rooms = _context.Rooms.ToList();
            var roomtypes = _context.RoomTypes.ToList();

            var RoomsAdminIndeViewModel = new RoomsAdminIndexViewModel
            {
                Rooms = rooms,
                RoomTypes = roomtypes
            };
            return RoomsAdminIndeViewModel;
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypesAsync()
        {
            return await _context.RoomTypes.ToArrayAsync();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms.Include(x => x.RoomType);
        }
    }
}
