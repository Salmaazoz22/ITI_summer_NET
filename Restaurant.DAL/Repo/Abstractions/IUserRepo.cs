


namespace Restaurant.DAL.Repo.Abstractions
{
  public interface IUserRepo
    {
       ( bool,string?) Create(User user);
        (List<User> ,string?) GetAll();
        (User,string? )GetById(int UserId);
        public (List<User>, string?) GetAll(Expression<Func<User, bool>> filter);


    }
}
