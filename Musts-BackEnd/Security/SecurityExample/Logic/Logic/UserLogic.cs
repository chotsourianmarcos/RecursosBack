﻿using Data;
using Entities.Entities;
using Logic.ILogic;
using Resources.Enums;
using Resources.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly ServiceContext _serviceContext;
        public UserLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public void DeleteUser(int id)
        {
            var userToDelete = _serviceContext.Set<UserItem>()
                 .Where(u => u.Id == id).First();

            userToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<UserItem> GetAllUsers()
        {
            return _serviceContext.Set<UserItem>()
                .Where(u => u.IsActive == true)
                .ToList();
        }
        public List<UserItem> GetUsersByCriteria(UserFilter userFilter)
        {
            var resultList = _serviceContext.Set<UserItem>()
                                .Where(u => u.IsActive == true);

            if (userFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > userFilter.InsertDateFrom);
            }

            if (userFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < userFilter.InsertDateTo);
            }

            return resultList.ToList();
        }

        public int InsertUser(UserItem userItem)
        {
            if (userItem.IdRol == (int)UserEnums.Administrator)
            {
                throw new InvalidOperationException();
            };
            userItem.EncryptedToken = "Not logged yet.";
            _serviceContext.Users.Add(userItem);
            _serviceContext.SaveChanges();
            return userItem.Id;
        }

        public void UpdateUser(UserItem userItem)
        {
            _serviceContext.Users.Update(userItem);

            _serviceContext.SaveChanges();
        }
    }
}