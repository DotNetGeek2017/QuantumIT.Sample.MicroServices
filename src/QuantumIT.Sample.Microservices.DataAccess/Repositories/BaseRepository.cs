﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantumIT.Sample.Microservices.DataAccess.Validation;
using QuantumIT.Sample.Microservices.Interface.DataAccess;
using QuantumIT.Sample.Microservices.Interface.ORM;

namespace QuantumIT.Sample.Microservices.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
   where T : class
    {
        protected IRulesEngine<T> _rulesEngine;
        protected readonly IDBProvider _idbProvider;
        protected readonly IDBHelper _dbHelper;
        public Type TableType
        {
            get
            {
                return typeof(T);
            }
        }

        protected BaseRepository(IDBProvider idbProvider, IRulesEngine<T> rulesengine, IDBHelper dbHelper)
        {
            _idbProvider = idbProvider;
            _rulesEngine = rulesengine;
            _dbHelper = dbHelper;
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await _idbProvider.GetAsync<T>().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<T>> GetByQueryAsync(string query, object param = null)
        {
            return await _idbProvider.GetAsync<T>(query, param).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<T>> GetByIdRangeAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return null;

            return await GetByQueryAsync($"select * from {TableType.Name} where ({_dbHelper.GetPrimaryKeyAutoGenerated<T>()} IN @Ids) and Enabled=True", new { Ids = ids.ToArray() }).ConfigureAwait(false);
        }


        public virtual async Task<T> GetByIdAsync(int id, string keyName)
        {
            return await _idbProvider.GetByIdAsync<T>(id.ToString(), keyName).ConfigureAwait(false);
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            return await AddAsync(entity, null).ConfigureAwait(false);
        }

        public virtual async Task<int> AddAsync(T entity, List<string> ignoreFields)
        {
            entity = _rulesEngine.AddEntity(entity);

            if (ignoreFields == null)
                ignoreFields = new List<string>();

            ignoreFields.Add("ModifiedOn");
            ignoreFields.Add("ModifiedBy");

            return await _idbProvider.AddAsync<T>(entity, ignoreFields?.ToArray()).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<IDataValidationFailure>> CanAddAsync(T entity)
        {
            var foreignKeys = _dbHelper.GetAllForeignKeys<T>();
            var dataValidationFailures = new List<IDataValidationFailure>();
            if (foreignKeys == null || !foreignKeys.Any())
                return dataValidationFailures;

            var str = new StringBuilder();
            var qualifiedForeignTypes = new List<Type>();
            foreach (var keyValuePair in foreignKeys)
            {
                if (!keyValuePair.Value.Item2)
                {
                    qualifiedForeignTypes.Add(keyValuePair.Value.Item1);
                    str.Append($"select * from {keyValuePair.Value.Item1.Name} where {keyValuePair.Key}=@{keyValuePair.Key} and Enabled=True;");
                }
                else
                {
                    var foreignKeyValue = _dbHelper.GetKeyValue<T>(entity, keyValuePair.Key);
                    if (foreignKeyValue != null)
                    {
                        qualifiedForeignTypes.Add(keyValuePair.Value.Item1);
                        str.Append($"select * from {keyValuePair.Value.Item1.Name} where {keyValuePair.Key}=@{keyValuePair.Key} and Enabled=True;");
                    }
                }
            }

            var result = await _idbProvider.QueryMultiple(str.ToString(), entity, qualifiedForeignTypes);

            foreach (var keyValuePair in result)
            {
                if (keyValuePair.Value != null)
                    continue;

                var primaryKey = _dbHelper.GetPrimaryKeyAutoGenerated(keyValuePair.Key);
                dataValidationFailures.Add(new DataValidationFailure { Name = primaryKey, ErrorMessage = $"Invalid {primaryKey}" });
            }

            return dataValidationFailures;
        }

        public async Task<IDictionary<Type, IEnumerable<object>>> QueryMultiple(string query, object parameters, IEnumerable<Type> returnTypes)
        {
            return await _idbProvider.QueryMultiple(query, parameters, returnTypes);
        }

        public virtual async Task<IEnumerable<IDataValidationFailure>> CanUpdateAsync(T entity)
        {
            return await CanAddAsync(entity).ConfigureAwait(false);
        }

        public virtual async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            return await AddRangeAsync(entities, null).ConfigureAwait(false);
        }

        public virtual async Task<int> AddRangeAsync(IEnumerable<T> entities, List<string> ignoreParameters)
        {
            entities = _rulesEngine.AddEntities(entities);

            if (ignoreParameters == null)
                ignoreParameters = new List<string>();

            ignoreParameters.Add("ModifiedOn");
            ignoreParameters.Add("ModifiedBy");

            return await _idbProvider.AddRangeAsync<T>(entities, ignoreParameters?.ToArray()).ConfigureAwait(false);
        }

        public virtual async Task<int> AddRangeWithQueryAsync(string query, IEnumerable<T> entities, List<string> ignoreParameters)
        {
            entities = _rulesEngine.AddEntities(entities);

            if (ignoreParameters == null)
                ignoreParameters = new List<string>();


            ignoreParameters.Add("ModifiedOn");
            ignoreParameters.Add("ModifiedBy");

            return await _idbProvider.AddRangeWithQueryAsync<T>(query, entities, ignoreParameters?.ToArray()).ConfigureAwait(false);
        }


        public virtual async Task<int> UpdateAsync(T entity)
        {
            return await UpdateAsync(entity, null).ConfigureAwait(false);
        }

        public virtual async Task<int> UpdateAsync(T entity, List<string> ignoreParameters)
        {
            return await UpdateAsync(entity, ignoreParameters, false);
        }


        public virtual async Task<int> UpdateAsync(T entity, List<string> ignoreParameters, bool Coalsce)
        {
            entity = _rulesEngine.UpdateEntity(entity);

            if (ignoreParameters == null)
                ignoreParameters = new List<string>();

            ignoreParameters.Add("CreatedBy");
            ignoreParameters.Add("CreatedOn");
            ignoreParameters.Add("Enabled");

            if (!Coalsce)
            {
                return await _idbProvider.UpdateAsync<T>(entity, ignoreParameters?.ToArray()).ConfigureAwait(false);
            }
            else
            {
                return await _idbProvider.UpdateWithoutCOALSCEAsync<T>(entity, ignoreParameters?.ToArray()).ConfigureAwait(false);
            }
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null || !entities.Any()) return 0;

            var key = _dbHelper.GetPrimaryKeyAutoGenerated<T>();

            if (string.IsNullOrWhiteSpace(key))
                throw new Exception($"Model Identity column must be decorated with Attribute [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]");

            return await UpdateRangeAsync(entities, new[] { key }).ConfigureAwait(false);
        }


        public virtual async Task<int> UpdateRangeAsync(IEnumerable<T> entities, string[] byKeys)
        {
            return await UpdateRangeAsync(entities, byKeys, null).ConfigureAwait(false);
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<T> entities, string[] byKeys, List<string> ignoreParameters)
        {
            entities = _rulesEngine.UpdateEntities(entities);

            if (ignoreParameters == null)
                ignoreParameters = new List<string>();

            ignoreParameters.Add("CreatedBy");
            ignoreParameters.Add("CreatedOn");
            ignoreParameters.Add("Enabled");

            return await _idbProvider.UpdateRangeAsync<T>(entities, byKeys, ignoreParameters?.ToArray()).ConfigureAwait(false);
        }

        public virtual async Task<int> RemoveAsync(int id)
        {
            return await _idbProvider.DeleteAsync<T>(id).ConfigureAwait(false);
        }

        public virtual Task<int> RemoveRangeAsync(IEnumerable<int> ids)
        {
            return Task.FromResult(-1);
        }

        public virtual Task<IEnumerable<T>> GetWithQuery<Q, S, T>(string query, Func<Q, S, T> map, object param, string splitOn)
        {
            return _idbProvider.GetByQuery(query, map, param, splitOn);
        }

        public virtual Task<IEnumerable<T>> GetWithQuery<Q, R, S, T>(string query, Func<Q, R, S, T> map, object param, string splitOn)
        {
            return _idbProvider.GetByQuery(query, map, param, splitOn);
        }
    }

}
