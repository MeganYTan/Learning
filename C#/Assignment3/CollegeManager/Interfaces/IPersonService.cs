namespace CollegeManager.Interfaces;

public interface IPersonService
{
    int CalculateAge();
    void AddAddress(string address);
    IEnumerable<string> GetAddresses();
}