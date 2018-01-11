using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeOnlyModel dbContext = new CodeOnlyModel();
            //UserInfo user = new UserInfo();
            //user.UserInfoName = "水牛";
            //dbContext.UserInfo.Add(user);
            //UserInfo user2 = new UserInfo();
            //user2.UserInfoName = "水木";
            //dbContext.UserInfo.Add(user2);


            UserInfo user2 = new UserInfo();
            user2.UserInfoName = "大鸟";
            user2.Id = 4;
            dbContext.Entry<UserInfo>(user2).State = System.Data.Entity.EntityState.Modified;


            dbContext.SaveChanges();

            Console.WriteLine("END...");
            Console.ReadKey();
        }
    }
}
