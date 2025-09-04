





using System.Linq.Expressions;

namespace Restaurant.DAL.Repo.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly RestaurantDbContext Db;
        public UserRepo(){
            Db= new RestaurantDbContext();
            }
        public (bool, string?) Create(User user)
        {
            try
            {
                var  result = Db.Users.Add(user);
                Db.SaveChanges();
                if (result.Entity.Id > 0)
                    return( false,null);
                return (true,"There is a problem in Db");
            }
            catch (Exception ex)
            {

              return (true,ex.Message);
            }
        }

       

        public (List<User>, string?) GetAll()
        {
            try
            {

                var result = Db.Users.ToList();

                if (result.Count==0)

                    return (null, "There is no data");
                return (result, null);


            }
            catch (Exception ex)
            {
                return (null, ex.Message);

            }
        }

        public (List<User>, string?) GetAll(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public (User, string?) GetById(int UserId)
        {
            throw new NotImplementedException();
        }

      
    }
}
