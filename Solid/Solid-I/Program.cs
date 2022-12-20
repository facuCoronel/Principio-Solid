using System;

namespace Solid_I
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }
    }
}

public class UserService : IBasicActions<User>, IEditableAction<User>
{
    public void Add(User entity)
    {
        Console.WriteLine("Agregamos el usuario");
    }

    public void Delete(User entity)
    {
        Console.WriteLine("Eliminamos al usuario");
    }

    public User Get(int Id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetList()
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }
}

public interface IBasicActions<T>
{
    public T Get(int Id);
    public List<T> GetList();
    public void Add(T entity);
}

public interface IEditableAction<T>
{
    public void Update(T entity);
    public void Delete(T entity);
}


public class User
{
    public string Name { get; set; }
    public string Password { get; set; }

}


