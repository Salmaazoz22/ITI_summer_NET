using Restaurant.DAL.Entitiy;
using Resturant.BLL.ModelVM.User;

namespace Resturant.BLL.Services.Abstraction
{
    public interface IUserService
    {
        (List<GetAllUser>, string?, bool)GetAll();
        (bool, string?) Create(CreateUser user);
            }
}


