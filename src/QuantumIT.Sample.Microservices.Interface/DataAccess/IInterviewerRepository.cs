namespace QuantumIT.Sample.Microservices.Interface.DataAccess
{
    public interface IInterviewerRepository<T>:IRepository<T> where T : class
    {
    }
}
