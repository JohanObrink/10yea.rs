using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenYears.Models;
using MongoDB.Driver;
using FluentMongo.Linq;

namespace TenYears.Services.MongoServices
{
    public class MongoPersonService : IPersonService
    {
        private readonly MongoDatabase database;

        public MongoPersonService(MongoDatabase database)
        {
            this.database = database;
        }

        /// <summary>
        /// Get a person by his/her local id on 10yea.rs
        /// Typically used for retrieving based on Url
        /// </summary>
        /// <param name="id">his/her 10yea.rs id</param>
        /// <returns>A person (hopefully)</returns>
        public Person Get(string id)
        {
            return database
                .GetCollection<Person>("persons")
                .AsQueryable()
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get a person by his/her id on a social network
        /// Typically used to get a persons own page after authenticating
        /// </summary>
        /// <param name="remoteId">his/her id on the social network in question</param>
        /// <param name="socialNetwork">the social network</param>
        /// <returns>A person if this isn't the first visit</returns>
        public Person Get(string remoteId, SocialNetworks socialNetwork)
        {
            Func<Person, string> selector;

            switch (socialNetwork)
            {
                case SocialNetworks.Facebook:
                    selector = x => x.FacebookId;
                    break;
                case SocialNetworks.GooglePlus:
                    selector = x => x.GooglePlusId;
                    break;
                case SocialNetworks.Twitter:
                    selector = x => x.TwitterHandle;
                    break;
                default:
                    throw new Exception("Impossible SocialNetwork Exception");
            }

            return database
                .GetCollection<Person>("persons")
                .AsQueryable()
                .FirstOrDefault(x => selector.Invoke(x) == remoteId);
        }

        /// <summary>
        /// Get a list of person from part of the name
        /// Typically used for finding a friend or celeb.
        /// </summary>
        /// <param name="partOfName">Your search query - like madon</param>
        /// <returns>A list of persons with matching names</returns>
        public IEnumerable<Person> Search(string partOfName)
        {
            return database
                .GetCollection<Person>("persons")
                .AsQueryable()
                .Where(x => x.Name.ToLower().Contains(partOfName.ToLower()));
        }

        /// <summary>
        /// Save a person with timeline and all
        /// </summary>
        /// <param name="person">The person to save</param>
        /// <returns>The same person, possibly with an id added</returns>
        public Person Save(Person person)
        {
            var result = database
                .GetCollection<Person>("persons")
                .Save(person);

            return person;
        }
    }
}