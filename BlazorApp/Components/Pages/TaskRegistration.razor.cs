using BlazorApp.Entites;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorApp.Components.Pages
{
    public partial class TaskRegistration
    {
        private RadzenDataGrid<TaskItem>? grid;
        private List<TaskItem> tasks = new List<TaskItem>();
        private TaskItem newTask = new TaskItem(Entites.TaskStatus.未着手, DateTime.Now, string.Empty, string.Empty);

        private async void AddTask()
        {
            Task<TaskItem> getTaskItem = Task.Run(AddTaskItem);
            Task<List<TaskItem>> getTask = Task.Run(getTasks);

            var TI = await getTaskItem;
            var T = await getTask;

            T.Add(TI);
            sessionState.State = T;
            NavigationManager.NavigateTo("/");
        }

        private async void CancelTask()
        {
            await Task.Yield();
            NavigationManager.NavigateTo("/");
        }

        private TaskItem AddTaskItem()
        {
            return new TaskItem(newTask.Status, newTask.DueDate, newTask.Title, newTask.Content);
        }

        bool sessionExsists => sessionState.HasState;

        private List<TaskItem> getTasks()
        {
            if (sessionExsists)
            {
                tasks = sessionState.State!;
            }

            return tasks;
        }
    }
}
