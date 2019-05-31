﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheHotelApp.Models;
using TheHotelApp.ViewModels;

namespace TheHotelApp.Services
{
   public interface IGenericHotelService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllItemsAsync();

        Task<TEntity> GetItemByIdAsync(string id);

        //Task<TEntity> GetItemByIdAsync(Guid? id);

        Task<IEnumerable<TEntity>> SearchForAsync(Expression<Func<TEntity, bool>> expression);

        Task CreateItemAsync(TEntity entity);

        Task EditItemAsync(TEntity entity);

        Task DeleteItemAsync(TEntity entity);

        //This section contains methods particular to specific controllers
        #region Specific Controller Methods          

        RoomsAdminIndexViewModel GetAllRoomsAndRoomTypes();

        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();

        IEnumerable<Room> GetAllRooms();

        #endregion
    }
}
