using UI.Contracts.Controllers;
using UI.Contracts.Services;
using UI.Contracts.Views;
using UI.Controllers;
using UI.Services;
using UI.Views;

IStaffService staffService = new StaffService();
IStaffController staffController = new StaffController(staffService);
IJobPostService jobPostService = new JobPostService();
IJobPostController jobPostController = new JobPostController(jobPostService, staffService, staffController);
IApplicantService applicantService = new ApplicantService();
IApplicationService applicationService = new ApplicationService();
IApplicantController applicantController = new ApplicantController(applicantService, jobPostService, applicationService);
IApplicantView applicantView = new ApplicantView(applicantController);
IStaffView staffView = new StaffView(staffController, jobPostController, applicantController);


var mainMenu = new MainMenu(staffView, applicantView);

await mainMenu.ShowMainMenu();