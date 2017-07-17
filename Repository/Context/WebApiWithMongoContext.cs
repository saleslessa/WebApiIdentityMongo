
using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiWithMongo.Models;

namespace WebApiWithMongo.Repository
{
    public class WebApiWithMongoContext
    {   
        public MongoClient mongoClient {get;}

        public IMongoDatabase database{get;}

        public WebApiWithMongoContext(IOptions<ConnectionStrings> connectionStrings) 
        {
            try 
            { 
                var ConnectionString = connectionStrings.Value.Connection.ToString();

                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString)); 
                //if (connectionStrings.Value.IsSSL) 
                //{ 
                //    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 }; 
                //} 
                this.mongoClient = new MongoClient(settings); 
                this.database = mongoClient.GetDatabase(connectionStrings.Value.Database.ToString());
            } 
            catch (Exception ex) 
            { 
                throw new Exception("Can not access to db server.", ex); 
            } 
        } 
    }
}