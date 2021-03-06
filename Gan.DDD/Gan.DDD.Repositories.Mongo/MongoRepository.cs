﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace Gan.DDD.Repositories.Mongo
{
    public class MongoRepository<TEntity>:IMongoRepository<TEntity>
        where TEntity:NoSqlEntity
    {
        /// <summary>
        /// 创建数据库链接
        /// </summary>
        private MongoClient _server;
        /// <summary>
        /// 获得数据库
        /// </summary>
        private IMongoDatabase _database;
        /// <summary>
        /// 操作的集合（数据表）
        /// </summary>
        private IMongoCollection<TEntity> _table;
        /// <summary>
        /// 实体键，对应MongoDB的_id
        /// </summary>
        private const string EntityKey = "Id";
        /// <summary>
        /// 服务器地址和端口
        /// </summary>
        private static readonly string _connectionStringHost = ConfigurationManager.AppSettings["MongoDB_Host"];
        /// <summary>
        /// 数据库名称
        /// </summary>
        private static readonly string _dbName = ConfigurationManager.AppSettings["MongoDB_DbName"];
        /// <summary>
        /// 用户名
        /// </summary>
        private static readonly string _userName = ConfigurationManager.AppSettings["MongoDB_UserName"];
        /// <summary>
        /// 密码
        /// </summary>
        private static readonly string _password = ConfigurationManager.AppSettings["MongoDB_Password"];

        public MongoRepository()
        {
            _server = new MongoClient(ConnectionString());
            _database = _server.GetDatabase(_dbName);
            _table = _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        private static string ConnectionString()
        {
            var database = _dbName;
            var userName = _userName;
            var password = _password;
            var authentication = string.Empty;
            var host = string.Empty;
            if (string.IsNullOrWhiteSpace(userName))
            {
                authentication = string.Concat(userName,":",password,'@');

            }
            database = database ?? "Test";
            if (string.IsNullOrWhiteSpace(_connectionStringHost))
            {
                throw new ArgumentNullException("请配置MongoDB_Host节点");
            }
            return string.Format("mongodb://{0}{1}/{2}", authentication, _connectionStringHost, database);
        }

        private BsonDocumentFilterDefinition<TEntity> GeneratorMongoQuery<U>(U template)
        {
            var qType = typeof(U);
            var outter = new BsonDocument();
            var simpleQuery = new BsonDocument();
            foreach (var item in qType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (item.PropertyType.IsClass && item.PropertyType != typeof(string))
                {
                    foreach (var sub in item.PropertyType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        if (sub.PropertyType.IsClass && sub.PropertyType != typeof(string))
                        {
                            foreach (var subInner in sub.PropertyType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                            {
                                if (subInner.PropertyType.IsClass && subInner.PropertyType != typeof(string))
                                {
                                    foreach (var subItemInner in subInner.PropertyType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                                    {
                                        simpleQuery.Add(new BsonElement(item.Name + "." + sub.Name + "." + subInner.Name + "." + subItemInner.Name, BsonValue.Create(subItemInner.GetValue(subInner.GetValue(sub.GetValue(item.GetValue(template)))))));
                                    }
                                }
                                else
                                {
                                    simpleQuery.Add(new BsonElement(item.Name + "." + sub.Name + "." + subInner.Name + ".", BsonValue.Create(subInner.GetValue(sub.GetValue(item.GetValue(template))))));
                                }

                            }
                        }
                        else
                        {
                            simpleQuery.Add(new BsonElement(item.Name + "." + sub.Name, BsonValue.Create(sub.GetValue(item.GetValue(template)))));
                        }

                    }
                }
                else
                {
                    simpleQuery.Add(new BsonElement(item.Name, BsonValue.Create(item.GetValue(template))));
                }
            }
            return new BsonDocumentFilterDefinition<TEntity>(simpleQuery);
        }
        
    }
}
