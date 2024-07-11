using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class UserBusinessRules
{
    private readonly IUserDal _userDal;

    public UserBusinessRules(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public void CheckIfUserExists(User user)
    {
        bool isExists = _userDal.Get(u => u.Id == user.Id) is not null;
        if (isExists)
        {
            throw new Exception("User already exists.");
        }
    }

    public void CheckIfUserNameExists(string userName)
    {
        bool isExists = _userDal.Get(u => u.UserName == userName) is not null;
        if (isExists)
        {
            throw new Exception("User name already in use.");
        }
    }
    public void CheckIfUserEmailExists(string email)
    {
        bool isExists = _userDal.Get(u => u.Email == email) is not null;
        if (isExists)
        {
            throw new Exception("This mail already exists. Try to Sign in instead.");
        }
    }
}
