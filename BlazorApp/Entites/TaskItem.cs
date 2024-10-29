using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Entites
{
    public class TaskItem : IComparable<TaskItem>
    {
        [Required]
        public TaskStatus Status { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; } = string.Empty; // Initialize to avoid null

        public TaskItem(TaskStatus status, DateTime dueDate, string title, string content)
        {
            Status = status;
            DueDate = dueDate;
            Title = title;
            Content = content;
        }

        public int CompareTo(TaskItem? other)
        {
            if (other == null) return 1;

            int statusComparison = this.Status.CompareTo(other.Status);
            if (statusComparison != 0)
                return statusComparison;

            return this.DueDate.CompareTo(other.DueDate);
        }
    }
}
