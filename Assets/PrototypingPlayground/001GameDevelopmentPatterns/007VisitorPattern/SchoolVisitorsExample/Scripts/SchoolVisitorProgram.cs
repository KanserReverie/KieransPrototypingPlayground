using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.SchoolVisitorsExample
{
    public class SchoolVisitorProgram : MonoBehaviour
    {
        private Doctor doctor;
        private School school;
        private Salesman salesman;
        private HairDresser hairDresser;
        private void Start()
        {
            school = new School();
            doctor = new Doctor("James");
            salesman = new Salesman("John");
            hairDresser = new HairDresser("Sally");
        }

        public void DoctorVisit()
        {
            school.PerformOperation(doctor);
        }

        public void SalesmanVisit()
        {
            school.PerformOperation(salesman);
        }

        public void HairdresserVisit()
        {
            school.PerformOperation(hairDresser);
        }
    }
}
