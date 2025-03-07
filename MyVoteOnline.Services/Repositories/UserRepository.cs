﻿using Microsoft.EntityFrameworkCore;
using MyVoteOnline.Services.Interfaces;
using MyVotOnline.DataBaseLayer.DataContext;
using MyVotOnline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVoteOnline.Services.Repositories
{
	public class UserRepository(VoteContext context) : IUserRepository
	{
		private readonly VoteContext _context = context;

		public  int AddUser(UserModel user)
		{
			int userId = 0;
			using (var transaction = _context.Database.BeginTransaction())
			{
			
				try
				{
					User user1 = new User
					{
						FullName = user.FullName,
						Email = user.Email,
						PasswordHash = user.PasswordHash,
						RoleId = user.RoleId,
						WardId = user.WardId,
						CreatedAt = DateTime.UtcNow
					};
					_context.Users.Add(user1);
					_context.Entry(user1).State = EntityState.Added;
					_context.SaveChanges();
					userId = user1.UserId;
					transaction.Commit();
				}
				catch(Exception ex)
				{
					userId = 0;
					transaction.RollbackAsync();
				}
			}
			return userId;
		}
	}
}
