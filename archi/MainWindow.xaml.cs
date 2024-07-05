
using System.Globalization;
using System.Windows;

namespace archi
{
    public class ProjectController
    {
        private ProjectModel model;
        private MainWindow view;
        public ProjectController(ProjectModel model, MainWindow view)
        {
            this.model = model;
            this.view = view;
            LoadProjects();
        }
        public void LoadProjects()
        {
            view.ProjectsListBox.Items.Clear();
            foreach(var project in model.GetProjects())
            {
                view.ProjectsListBox.Items.Add($"{project.Id}: {project.ProjectName}, Architect: {project.Architect}, {project.Status} - {project.FinishDate}");
            }
        }
        public void AddProject(string name, string architect, string status, DateTime finishDate)
        {
            var newProject = new Project
            {
                Id = model.GetProjects().Count + 1,
                ProjectName = name,
                Architect = architect,
                Status = status,
                FinishDate = finishDate
            };
            model.AddProject(newProject);
            LoadProjects();
        }
        public void UpdateProject(string name, string architect, string status, DateTime finishDate, int id)
        {
            var updateProject = new Project
            {
                ProjectName = name,
                Architect = architect,
                Status = status,
                FinishDate = finishDate
            };
            model.UpdateProject(updateProject, id);
            LoadProjects();
        }
        public void DeleteProject(int orderId)
        {
            model.DeleteProject(orderId);
            LoadProjects();
        }
        
    }
    public partial class MainWindow : Window
    {
        private readonly ProjectController controller;
        
        public MainWindow()
        {
            InitializeComponent();
            var model = new ProjectModel();
            controller = new ProjectController(model, this);
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            controller.AddProject(PjNameTextBox.Text, ArchitectTextBox.Text, StatusTextBox.Text, FinishDateTextBox.SelectedDate ?? DateTime.Today);
        }

        private void UpdateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            controller.UpdateProject(PjNameTextBox.Text, ArchitectTextBox.Text, StatusTextBox.Text, FinishDateTextBox.SelectedDate ??  DateTime.Today, int.Parse(IdTextBox.Text));
        }

        private void DeleteProjectButton_Click(object sender, RoutedEventArgs e)
        {   
            controller.DeleteProject(int.Parse(IdTextBox.Text));
            
        }
    }
}