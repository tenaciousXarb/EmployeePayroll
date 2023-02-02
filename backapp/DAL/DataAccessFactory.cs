using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Employee, int, Employee> EmployeeDataAccess()
        {
            return new EmployeeRepo();
        }
        public static IRepo<Department, int, Department> DepartmentDataAccess()
        {
            return new DepartmentRepo();
        }
        public static IRepo<Admin, int, Admin> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<Transaction, int, Transaction> TransactionDataAccess()
        {
            return new TransactionRepo();
        }
        public static IRepo<Vacation, int, Vacation> VacationDataAccess()
        {
            return new VacationRepo();
        }
        public static IAuth<Admin> AdminAuthDataAccess()
        {
            return new AdminRepo();
        }
        public static IAuth<Employee> EmployeeAuthDataAccess()
        {
            return new EmployeeRepo();
        }
        public static IGet<Employee, string> EmployeeGetDataAccess()
        {
            return new EmployeeRepo();
        }
        public static ISelectedList<Transaction, int> TransactionGetSelectedDataAccess()
        {
            return new TransactionRepo();
        }
    }
}
