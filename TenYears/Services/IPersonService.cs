using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenYears.Models;

namespace TenYears.Services
{
    /// <summary>
    /// This is how you get to the stories
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Get a person by his/her local id on 10yea.rs
        /// Typically used for retrieving based on Url
        /// </summary>
        /// <param name="id">his/her 10yea.rs id</param>
        /// <returns>A person (hopefully)</returns>
        Person Get(string id);

        /// <summary>
        /// Get a person by his/her id on a social network
        /// Typically used to get a persons own page after authenticating
        /// </summary>
        /// <param name="remoteId">his/her id on the social network in question</param>
        /// <param name="socialNetwork">the social network</param>
        /// <returns>A person if this isn't the first visit</returns>
        Person Get(string remoteId, SocialNetworks socialNetwork);

        /// <summary>
        /// Get a list of person from part of the name
        /// Typically used for finding a friend or celeb.
        /// </summary>
        /// <param name="partOfName">Your search query - like madonn</param>
        /// <returns>A list of persons with matching names</returns>
        IEnumerable<Person> Search(string partOfName);

        /// <summary>
        /// Save a person with timeline and all
        /// </summary>
        /// <param name="person">The person to save</param>
        /// <returns>The same person, possibly with an id added</returns>
        Person Save(Person person);
    }
}
