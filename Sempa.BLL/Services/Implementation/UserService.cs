

using Azure;
using Restaurant.DAL.Entitiy;
using Restaurant.DAL.Repo.Abstractions;
using Restaurant.DAL.Repo.Implementation;
using Resturant.BLL.ModelVM.User;


namespace Resturant.BLL.Services.Implementation
{
    public class UserService : IUserService
    {
        IUserRepo UserRepo;
        public UserService()
        {
            UserRepo = new UserRepo();
        }

        public (bool, string?) Create(CreateUser dt)
        {
            try {
                if (string.IsNullOrEmpty(dt.Name))
                {
                    return (true, "Name must be required");
                }
                User user = new User(dt.Name,dt.Age,dt.Type);
                var result = UserRepo.Create(user);
                return result;
            }
            catch(Exception ex) {
                return(true, ex.Message);
            }
        }

        public (List<GetAllUser>, string?, bool) GetAll()
        {
            try
            {
                var result = UserRepo.GetAll();
                if (result.Item2 != null)
                    return (null, result.Item2, true);
                List<GetAllUser> getAllUsers = new List<GetAllUser>();
                foreach (var item in result.Item1)
                {
                    getAllUsers.Add(new() { Name = item.Name, Age = item.Age });


                }
                return (getAllUsers, null, false);
            }
            catch (Exception ex)
            {
                return (null,ex.Message, true);

            }
        }
    }
}
