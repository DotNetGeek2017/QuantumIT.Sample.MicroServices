﻿using System;
using System.Collections.Generic;

namespace QuantumIT.Sample.Microservices.Interface.ORM
{
    public interface IDBHelper
    {
        string ConstructColumsForInsert<T>();
        string ConstructColumsForInsert<T>(string[] ignoreColumns);
        string ConstructParamsForInsert<T>();
        string ConstructParamsForInsert<T>(string[] ignoreColumns);
        string ConstructColumsForUpdate<T>(string[] ignoreColumns);
        string ConstructColumsForUpdateWithoutCOALESCE<T>(string[] ignoreColumns);
        string ConstructColumsForUpdateWithKeys<T>(string[] columns);
        string GetPrimaryKeyAutoGenerated<T>();
        string GetPrimaryKeyAutoGenerated(Type T);
        IDictionary<string, Tuple<Type, bool>> GetAllForeignKeys<T>();

        Object GetKeyValue<T>(T entity, string keyName);
    }
}
