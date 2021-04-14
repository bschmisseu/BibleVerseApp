using BibleVerseApp.Business;
using BibleVerseApp.Data;
using BibleVerseApp.Models;
using BibleVerseApp.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Controllers
{
    /**
     * Bryce Schisseur
     * April 4 2021
     * CST-247
     * 
     * <summary>Controller to setup up actions and directions from any users request having to do with verses</summary>
     */
    public class VerseController : Controller
    {
        //Object of the businesss service to access all business and data service methods
        public VerseBusinessInterface VerseService { get; set; }

        public VerseController(VerseBusinessInterface verseBusiness)
        {
            VerseService = verseBusiness;
        }

        /**
         * VerseController.Index
         * 
         * <summary>Method to display the list of verses</summary>
         * 
         * <returns>Index page with list of all verses</returns>
         */
        public IActionResult Index()
        {
            MyLogger.GetInstance().Info("Entering VerseController.Index");
            return View(VerseService.Get());
        }

        /**
         * VerseController.Create
         * 
         * <summary>Method to display a form to enter a verse</summary>
         * 
         * <returns>Create Page</returns>
         */
        public IActionResult Create()
        {
            MyLogger.GetInstance().Info("Entering VerseController.Create");
            return View();
        }

        /**
         * VerseController.ProccessCreate
         * 
         * <summary>Method called once a form was submited to add a verse</summary>
         * 
         * <param>Verse - VerseModel: model containing all the properties of a verse</param>
         * 
         * <returns>Index Page with the updated list of verses</returns>
         */
        public IActionResult ProcessCreate(VerseModel Verse)
        {
            MyLogger.GetInstance().Info("Entering VerseController.ProcessCreate: \n With Paramenter: " + Verse.ToString());
            VerseService.Insert(Verse);
            return View("Index", VerseService.Get());
        }

        /**
         * VerseController.Detials
         * 
         * <summary>With a given Id this method will direct the user to the full verse page</summary>
         * 
         * <param>Id of the verse that is associated within the database</param>
         * 
         * <returns>Index Page with the updated list of verses</returns>
         */
        public IActionResult Details(int Id)
        {
            MyLogger.GetInstance().Info("Entering VerseController.Detials: \n With Paramenter: " + Id);
            return View(VerseService.GetById(Id));
        }

        /**
         * VerseController.Serach
         * 
         * <summary>Given a search parameter and a category a refined list will be retured</summary>
         * 
         * <param>A String or integer that is used to compare the specified category within the database</param>
         * <param>Specificed category of what the user would like to search</param>
         * 
         * <returns>Index page with a finded list of verses</returns>
         */
        public IActionResult Search(String SearchParam, String Option)
        {
            MyLogger.GetInstance().Info("Entering VerseController.Serach: \n With Paramenter: " + SearchParam + " and " + Option);
            //Converting the String to an integer
            int SeletedOption = int.Parse(Option);

            List<VerseModel> verses;

            //If Book was selected
            if (SeletedOption == 3)
            {
                MyLogger.GetInstance().Info("Leaving VerseController.Serach to SearchBook");
                verses = VerseService.SearchBook(SearchParam);
            }

            //If testamment was selected
            else if(SeletedOption == 1)
            {
                MyLogger.GetInstance().Info("Leaving VerseController.Serach to Testament");
                verses = VerseService.SearchTestament(SearchParam);
            }

            //If Chapter was selected
            else if(SeletedOption == 2)
            {
                MyLogger.GetInstance().Info("Leaving VerseController.Serach to Chapter");
                verses =  VerseService.SearchChapter(int.Parse(SearchParam));
            }

            //If Verse was selected
            else if (SeletedOption == 4)
            {
                MyLogger.GetInstance().Info("Leaving VerseController.Serach to SerachVerse");
                verses = VerseService.SearchVerse(int.Parse(SearchParam));
            }

            //If nothing was selected then it was search everything
            else
            {
                MyLogger.GetInstance().Info("Leaving VerseController.Serach to SerachAll");
                String[] split = SearchParam.Split(' ', ':');

                return View("Index", VerseService.Search(split[0], int.Parse(split[1]), int.Parse(split[2])));
            }

            if (verses.Count <= 0)
            {
                return View("NotFound");
            }
            else
            {
                return View("Index", verses);
            }
        }
    }
}
