using System;
using System.Collections.Generic;

namespace ConsoleAppDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Yazdelegate del = new Yazdelegate(Yaz);
            //del += YazHello;

            //del();

            //Yazdelegate del = () => { Console.Write("Selam"); };
            //del();
            User user = new User(1, "Ali", 12);
            FilterDelegate filter = new FilterDelegate(FirstOrDefaultBool);
            var users = GetUsers();
            DeleteDelegate deleteDelegate = new DeleteDelegate((User u) => { users.Remove(user); });
            
            User u=FirstOrDefaultCustom(filter);


        }

        public delegate  void Yazdelegate();
        public delegate  bool FilterDelegate(User user);
        public delegate void DeleteDelegate(User user);
        public static void Yaz()
        {
            Console.WriteLine("Selam");
        }
        public static void YazHello()
        {
            Console.WriteLine("Hello");
        }

        public static List<User> GetUsers()
        {
            return new List<User>() {
              new User(1,"Ali",15),
              new User(2,"Veli",17),
              new User(3,"Pirveli",19)
            };
        }
        public static bool FirstOrDefaultBool(User user)
        {
            if (user.Name=="Ali")
            {
                return true;
            }
            return false;
        }
        public static User FirstOrDefaultCustom(FilterDelegate filter)
        {
            var users = GetUsers();
            User user=null;

            foreach (var u in users)
            {
                if (filter(u))
                {
                    user = u;
                    break;
                }
            }
            return user;
        }
    }




    public class User
    {
        public User(int id,string name,int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
