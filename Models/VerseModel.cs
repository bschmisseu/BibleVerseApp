using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Models
{
    /**
     * Bryce Schmisseur
     * April 13 2021
     * CST-247
     * 
     * <summary>Model to hold all the properties of a verse</summary>
     */
    public class VerseModel
    {
        //Number Id that is assocaited with the verse in the database
        public int Id { get; set; }
        //Either new or old testament
        [StringLength(3, MinimumLength = 2)]
        [Required]
        public String Testament { get; set; }
        //The book in the bible
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public String Book { get; set; }
        //The chapter number of the verse
        [Range(1, 50)]
        [Required]
        public int ChapNum { get; set; }
        //The verse number
        [Range(1, 300)]
        [Required]
        public int VerseNum { get; set; }
        //The text of the verse
        [Required]
        public String Text { get; set; }
        //Override of the ToString method
        public override string ToString()
        {
            return "Id: " + Id + " Testament: " + Testament + " Book: " + Book + " Chapter Number: " + ChapNum + " Verse Number: " + VerseNum + " Text: " + Text;
        }
    }
}
