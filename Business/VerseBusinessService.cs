using BibleVerseApp.Data;
using BibleVerseApp.Models;
using BibleVerseApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Business
{
    /**
     * Bryce Schisseur
     * April 4 2021
     * CST-247
     * 
     * <summary>Implemented instance of the business service class and methods</summary>
     */
    public class VerseBusinessService : VerseBusinessInterface
    {
        //Connection to the data services
        public VerseDataInterface VerseService { get; set; }

        /**
         * VerseBusinessService.VerseBusinessService
         * 
         * <summary>Constructor to inject the data service instance at run time</summary>
         * 
         * <param>dataService - VerseDataInterface: varible to access the data service methods</param>
         */
        public VerseBusinessService(VerseDataInterface dataService)
        {
            VerseService = dataService;
        }

        /**
         * <see>Busniess.VerseBusinessInterface.Insert</see>
         */
        public int Insert(VerseModel Verse)
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.Insert: \n With Parameter: " + Verse.ToString());
            return VerseService.Insert(Verse);
        }
        /**
         * <see>Busniess.VerseBusinessInterface.Get</see>
         */
        public List<VerseModel> Get()
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.Get");
            return VerseService.Get();
        }
        /**
         * <see>Busniess.VerseBusinessInterface.GetById</see>
         */
        public VerseModel GetById(int Id)
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.GetById: \n With Parameter: " + Id);
            return VerseService.GetById(Id);
        }
        /**
         * <see>Busniess.VerseBusinessInterface.Update</see>
         */
        public VerseModel Update(VerseModel Verse)
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.Update: \n With Parameter: " + Verse.ToString());
            return VerseService.Update(Verse);
        }
        /**
         * <see>Busniess.VerseBusinessInterface.Delete</see>
         */
        public int Delete(int Id)
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.Delete: \n With Parameter: " + Id);
            return VerseService.Delete(Id);
        }
        /**
         * <see>Busniess.VerseBusinessInterface.Search</see>
         */
        public List<VerseModel> Search(string Book, int Chapter, int Verse)
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.Search: \n With Parameter: " + Book + " " + Chapter + " " + Verse);
            return VerseService.Search(Book, Chapter, Verse);
        }
        /**
         * <see>Busniess.VerseBusinessInterface.SearchTestament</see>
         */
        public List<VerseModel> SearchTestament(string SerachParam)
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.SearchTestament: \n With Parameter: " + SerachParam);
            return VerseService.SearchTestament(SerachParam);
        }

        /**
         * <see>Busniess.VerseBusinessInterface.SearchChapter</see>
         */
        public List<VerseModel> SearchChapter(int SerachParam)
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.SearchChapter: \n With Parameter: " + SerachParam);
            return VerseService.SearchChapter(SerachParam);
        }

        /**
         * <see>Busniess.VerseBusinessInterface.SearchBook</see>
         */
        public List<VerseModel> SearchBook(string SerachParam)
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.SearchBook: \n With Parameter: " + SerachParam);
            return VerseService.SearchBook(SerachParam);
        }

        /**
         * <see>Busniess.VerseBusinessInterface.SearchVerse</see>
         */
        public List<VerseModel> SearchVerse(int SerachParam)
        {
            MyLogger.GetInstance().Info("Entering VerseBusinessService.SearchVerse: \n With Parameter: " + SerachParam);
            return VerseService.SearchVerse(SerachParam);
        }
    }
}
