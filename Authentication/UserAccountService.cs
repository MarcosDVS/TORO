using TORO.Data.Context;
using TORO.Data.Model;

namespace TORO.Authentication;

public interface IUserAccountService
{
    User? GetByUserName(string userName);
}
public class UserAccountService : IUserAccountService
{

    #region Constructor y mienbro privado
    private MyDbContext _database;

    public UserAccountService(MyDbContext database)
    {
        _database = database;
    }
    #endregion
    public User? GetByUserName(string userName)
    {
        return _database.Users.FirstOrDefault(x => x.Email == userName);
    }
}
