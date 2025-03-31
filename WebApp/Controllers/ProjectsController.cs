using Business.Services;
using Domain.Models.ProjectData;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ProjectsController(IProjectService projectService) : Controller
{
    private readonly IProjectService _projectService = projectService;

    public async IActionResult Index()
    {
        var model = new ProjectsViewModel
        {
            Projects = await _projectService.GetProjectsAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async IActionResult Add(AddProjectViewModel model)
    {
        var addProjectFormData = model.MapTo<AddProjectFormData>();
        
        var result = await _projectService.CreateProjectAsync(addProjectFormData);

        return View();
    }


    [HttpPost]
    public IActionResult Update(UpdateProjectViewModel model)
    {
        return View();
    }


    [HttpPost]
    public IActionResult Delete(string id)
    {
        return View();
    }

}
