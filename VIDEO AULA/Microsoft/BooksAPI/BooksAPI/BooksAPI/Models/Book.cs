using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Genre { get; set; }

        public DateTime PublishDate { get; set; }

        public string Description { get; set; }

        //ONE TO ONE
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }


        //Option pour transmettre les données à la place de créer un DTO.
        //public override string ToString()
        //{
        //    //return base.ToString();
        //    return this.Title       + "\n" +
        //           this.Genre       + "\n" +
        //           this.PublishDate + "\n" +
        //           this.Price       + "\n" +
        //           this.Description + "\n" +
        //           this.Author.Name + "\n"
        //           ;
        //}

    }
}