﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using Bit.KeyConnector.Models;
using JsonFlatFileDataStore;
using MongoDB.Driver;

namespace Bit.KeyConnector.Repositories.Mongo
{
    public class UserKeyRepository : BaseRepository<UserKeyModel>, IUserKeyRepository
    {
        public UserKeyRepository(KeyConnectorSettings settings)
            : base(settings, "UserKey")
        { }

        public virtual async Task CreateAsync(UserKeyModel item)
        {
            await Collection.InsertOneAsync(item);
        }

        public virtual Task<UserKeyModel> ReadAsync(Guid id)
        {
            return Collection.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        public virtual Task<List<UserKeyModel>> ReadAllAsync()
        {
            return Collection.Find(d => true).ToListAsync();
        }

        public virtual async Task UpdateAsync(UserKeyModel item)
        {
            await Collection.ReplaceOneAsync(d => d.Id == item.Id, item);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await Collection.DeleteOneAsync(d => d.Id == id);
        }
    }
}
