

namespace archi
{
    public class Project
    {
        public int Id {  get; set; }
        public string ProjectName { get; set; }
        public string Architect {  get; set; }
        public string Status { get; set; }
        public DateTime FinishDate { get; set; }
    }

    public class ProjectModel
    {
        private List<Project> projects = new List<Project> ();
        public List<Project> GetProjects()
        {
            return projects;
        }
        public void AddProject(Project project)
        {
            projects.Add(project);
        }
        
        public void UpdateProject(Project project, int id)
        {
            var existingProject = projects.FirstOrDefault(o => o.Id == id);
            if (existingProject != null)
            {
                existingProject.ProjectName = project.ProjectName;
                existingProject.Architect = project.Architect;
                existingProject.Status = project.Status;
                existingProject.FinishDate = project.FinishDate;
            }
        }
        public void DeleteProject(int id)
        {
            var project = projects.FirstOrDefault(o => o.Id == id);
            if(project != null)
            {
                projects.Remove(project);
            }
        }
        

        
    }
}
