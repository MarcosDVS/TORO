using TORO.Data.Context;
using TORO.Data.Model;

namespace TORO.Authentication;

public interface IUserAccountService
{
    User? GetByUserName(string userName);
}
public class UserAccountService : IUserAccountService
{
    //private List<UserAccount> _users;

    //public UserAccountService()
    //{
       // _users = new List<UserAccount>
        //{
        //    new UserAccount{UserName = "admin", Password = "123", Role = "Administrator"},
        //    new UserAccount{UserName = "user", Password = "user", Role = "User"}
        //};
    //}

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
