using System;
using System.Collections.Generic;
using ObjectLibrary;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;


namespace FileParserNetStandard {
    
   
    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people) {
            People = new List<Person>();

            // for each row, add these indexes to People (list)
            // before adding the 3rd index, we need to convert it from a string to a long,
            // once it is a long, it should be able to convert to a datetime easily,

            foreach (List<string> p in people.Skip(1))
            {
                long l1 = long.Parse(p[3]);
                DateTime date = new DateTime(l1);

                People.Add(new Person(
                    Int32.Parse(p[0]),
                    p[1],
                    p[2],
                    date                    
                    ));
            }        
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {

            DateTime oldest = People.Select(p => p.Dob).Min();
            return People.Where(p => p.Dob == oldest).ToList();
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {
            return People.Find(p => p.Id == id).ToString();
        }

        public List<Person> GetOrderBySurname() {
            return People.OrderBy(p => p.Surname).ToList();
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {
            return People.Select(p => p.Surname)
                .Where(s => s.StartsWith(searchTerm, !caseSensitive, null))
                .Count();
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = new List<string>();

            People.OrderBy(p => p.Dob)
                .GroupBy(d => d.Dob).ToList()
                .ForEach(i => result.Add($"{i.Key}\t{i.Count()}"));

            return result;  //-- return result here
        }
    }
}