using BlazorApp.Entites;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace BlazorApp.Components.Pages;

public partial class Home
{
    bool sessionExsists => sessionState.HasState;

    protected override void OnInitialized()
    {
        if (sessionExsists)
        {
            tasks = sessionState.State!;
        }
        tasks.Sort();
    }

    async Task LoadTasks()
    {
        await Task.Yield();

        if (sessionExsists)
        {
            sessionState.State = tasks;
        }

        return;
    }

    private RadzenDataGrid<TaskItem>? grid;
    private List<TaskItem> tasks =
    [
        new TaskItem(Entites.TaskStatus.完了, DateTime.Now.AddDays(1), "タスク1", "内容1"),
        new TaskItem(Entites.TaskStatus.仕掛中, DateTime.Now.AddDays(2), "タスク2", "内容2"),
        new TaskItem(Entites.TaskStatus.未着手, DateTime.Now.AddDays(3), "タスク3", "内容3\n改行")
    ];

    private async void OnButtonClick()
    {
        await Task.Yield();
        sessionState.State = tasks;
        NavigationManager.NavigateTo("/registration");
    }
}
