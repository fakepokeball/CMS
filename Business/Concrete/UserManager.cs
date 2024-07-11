using AutoMapper;
using Business.BusinessRules;
using Business.Requests.User;
using Business.Responses.User;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UserManager
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;


    public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userDal = userDal;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public GetUserListResponse GetList(GetUserListRequest request)
    {
        IList<User> userList = _userDal.GetList();

        GetUserListResponse response = _mapper.Map<GetUserListResponse>(userList);

        return response;
    }

    public GetUserByIdResponse GetById(GetUserByIdRequest request)
    {
        User? user = _userDal.Get(predicate: u => u.Id == request.Id);

        _userBusinessRules.CheckIfUserExists(user);

        var response = _mapper.Map<GetUserByIdResponse>(user);

        return response;
    }

    public AddUserResponse Add(AddUserRequest request)
    {
        
        _userBusinessRules.CheckIfUserNameExists(request.UserName);
        _userBusinessRules.CheckIfUserEmailExists(request.Email);


        User? userToAdd = _mapper.Map<User>(request);

        User addedUser = _userDal.Add(userToAdd);

        AddUserResponse response = _mapper.Map<AddUserResponse>(addedUser);

        return response;
    }

    public UpdateUserResponse Update(UpdateUserRequest request)
    {
        User? userToUpdate = _userDal.Get(predicate: u => u.Id == request.Id);

        _userBusinessRules.CheckIfUserExists(userToUpdate);
        _userBusinessRules.CheckIfUserNameExists(request.UserName);
        _userBusinessRules.CheckIfUserEmailExists(request.Email);

        userToUpdate = _mapper.Map(request, userToUpdate);

        User updatedUser = _userDal.Update(userToUpdate!);

        UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(
            updatedUser
        );

        return response;
    }

    public DeleteUserResponse Delete(DeleteUserRequest request)
    {
        User? userToDelete = _userDal.Get(predicate: u => u.Id == request.Id);

        _userBusinessRules.CheckIfUserExists(userToDelete);

        User deletedUser = _userDal.Delete(userToDelete!);

        DeleteUserResponse response = _mapper.Map<DeleteUserResponse>(
            deletedUser
        );

        return response;
    }
}
