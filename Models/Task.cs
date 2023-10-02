﻿namespace TaskAPIProject.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Created { get; set;}

        public DateTime? Due { get; set;}

        public TaskStatus status { get; set; }
    }
}
