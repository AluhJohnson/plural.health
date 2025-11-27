using Microsoft.AspNetCore.Mvc;
using plural.health.Infrastructure.ViewModel;

namespace plural.health.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            var list = new List<AppointmentViewModel>
            {
                new AppointmentViewModel {
                    Id = 1,
                    PatientName = "Akpopodion Endurance",
                    PatientCode = "HOSP29384756",
                    Gender = "Male",
                    Age = "21yrs",
                    Clinic = "Neurology",
                    WalletBalance = 120000,
                    AppointmentTime = new DateTime(2025, 9, 22, 11, 30, 0),
                    Status = "Processing",
                    StatusColor = "warning",
                    ProfileImage = "/images/user1.png"
                },
                new AppointmentViewModel {
                    Id = 2,
                    PatientName = "Boluwatife Olusola",
                    PatientCode = "HOSP87654321",
                    Gender = "Female",
                    Age = "30yrs",
                    Clinic = "Ear, Nose & Throat",
                    WalletBalance = 230500,
                    AppointmentTime = new DateTime(2025, 9, 22, 17, 30, 0),
                    Status = "Not arrived",
                    StatusColor = "danger",
                    ProfileImage = "/images/user2.png"
                },
                // … Add more items like the screenshot
            };

            return View(list);
        }
    }
}
