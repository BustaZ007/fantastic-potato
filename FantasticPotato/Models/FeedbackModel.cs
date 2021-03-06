﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasticPotato.Models
{
    [Table("Feedbacks")]
    public class FeedbackModel
    {
        public FeedbackModel(int id, int bookId, int userId, string text, int rating)
        {
            Id = id;
            BookId = bookId;
            UserId = userId;
            DateOfWriting = DateTime.Now;
            Text = text;
            Rating = rating;
        }

        public FeedbackModel()
        {
        }

        [Key] public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime DateOfWriting { get; set; }
        [ForeignKey("BookId")] public BookModel Book { get; set; }
        [ForeignKey("UserId")] public UserModel User { get; set; }
    }
}