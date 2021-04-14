using BibleVerseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Data
{
    public interface VerseDataInterface
    {
        public int Insert(VerseModel Verse);
        /**
        * VerseBusinessInterface.Get
        * <summary>Method to return all Bible Verses in the database</summary>
        * 
        * <returns>Verses - List<VerseModel>: A list of verse models</returns>
        */
        public List<VerseModel> Get();
        /**
         * VerseBusinessInterface.Update
         * <summary>Method to update any of the verses properties</summary>
         * 
         * <param>Verse - VerseModel: model containing all properties of a verse</param>
         * <returns>Verse - VerseModel: model containing all properties of a verse</returns>
         */
        public VerseModel GetById(int Id);
        /**
         * VerseBusinessInterface.Delete
         * <summary>Method to delete a verse from the database</summary>
         * 
         * <param>Id - int: the number associated with the verse in the database</param>
         * <returns>NumOfRows - int: The number of rows affected within the database</returns>
         */
        public VerseModel Update(VerseModel Verse);
        /**
         * VerseBusinessInterface.Search
         * <summary>Method to search all the verses to a specificied search parameter</summary>
         * 
         * <param>SerachParam - String: a string of what the user is trying to find</param>
         * <returns>Verses - List<VerseModel>: A list of verse models</returns>
         */
        public int Delete(int Id);
        /**
         * VerseBusinessInterface.Search
         * <summary>Method to search all the verses to a specificied search parameter</summary>
         * 
         * <param>SerachParam - String: a string of what the user is trying to find</param>
         * <returns>Verses - List<VerseModel>: A list of verse models</returns>
         */
        public List<VerseModel> Search(string Book, int Chapter, int Verse);
        /**
         * VerseBusinessInterface.SearchTestament
         * <summary>Method to search all the verses to a specificied search parameter based on testament</summary>
         * 
         * <param>SerachParam - String: a string of what the user is trying to find</param>
         * <returns>Verses - List<VerseModel>: A list of verse models</returns>
         */
        public List<VerseModel> SearchTestament(string SerachParam);
        /**
         * VerseBusinessInterface.SearchChapter
         * <summary>Method to search all the verses to a specificied search parameter based on Chapter</summary>
         * 
         * <param>SerachParam - int: a int of what the user is trying to find</param>
         * <returns>Verses - List<VerseModel>: A list of verse models</returns>
         */
        public List<VerseModel> SearchChapter(int SerachParam);
        /**
         * VerseBusinessInterface.SearchBook
         * <summary>Method to search all the verses to a specificied search parameter based on Book</summary>
         * 
         * <param>SerachParam - String: a string of what the user is trying to find</param>
         * <returns>Verses - List<VerseModel>: A list of verse models</returns>
         */
        public List<VerseModel> SearchBook(string SerachParam);
        /**
         * VerseBusinessInterface.Search
         * <summary>Method to search all the verses to a specificied search parameter based on Verse</summary>
         * 
         * <param>SerachParam - int: a integer of what the user is trying to find</param>
         * <returns>Verses - List<VerseModel>: A list of verse models</returns>
         */
        public List<VerseModel> SearchVerse(int SerachParam);
    }
}
