using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFmodelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            DataModelContainer dbContext = new DataModelContainer();
            #region 添加
            //UserInfo user = new UserInfo();
            //user.UserInfoName = "张三";
            //dbContext.UserInfo.Add(user);


            //OrderInfo order1 = new OrderInfo();
            //order1.Content = "订单1";
            //dbContext.OrderInfo.Add(order1);

            //OrderInfo order2 = new OrderInfo();
            //order2.Content = "订单2";
            //dbContext.OrderInfo.Add(order2);


            ////关联三个实体

            ////1、用户添加订单
            //user.OrderInfo.Add(order1);
            ////2、通过订单指定用户
            //order2.UserInfo = user;
            //// order2.UserInfoId = user.Id;


            //dbContext.SaveChanges();
            #endregion
            #region 修改
            //UserInfo user2 = new UserInfo();
            //user2.UserInfoName = "赵武";
            //user2.Id = 1;
            //dbContext.Entry<UserInfo>(user2).State = System.Data.Entity.EntityState.Modified;
            //dbContext.SaveChanges();
            #endregion
            #region linq查询
            //var linq = from u in dbContext.UserInfo
            //           where u.Id > 0
            //           select u;
            //foreach (var item in linq)
            //{
            //    Console.WriteLine(item.Id + "   " + item.UserInfoName + "  ");
            //}
            #region 两种延迟加载
            ////1、
            //var linq2 = from u in linq
            //            where u.UserInfoName.Contains("赵")
            //            select u;
            //foreach (var item in linq2)
            //{
            //    Console.WriteLine(item.Id + "   " + item.UserInfoName + "  ");
            //}

            ////2、
            //foreach (var item in linq)
            //{
            //    foreach (var item2 in item.OrderInfo)
            //    {
            //        Console.WriteLine(item2.Id + "   " + item2.Content + "  " + "\r\n" + item.UserInfoName);
            //    }
            //}
            #endregion

            #endregion

            #region lamda查询
            //var data = dbContext.UserInfo.Where(u => u.Id > 0);
            //foreach (var item in data)
            //{
            //    Console.WriteLine(item.Id + "   " + item.UserInfoName + "  ");
            //}
            #endregion

            #region 分页查询
            //var data = dbContext.UserInfo
            //    .Where(u => u.Id > 0)
            //    .OrderBy<UserInfo, int>(u => u.Id)
            //    //.OrderByDescending降序
            //    .Skip<UserInfo>(5 * (3 - 1))////Skip(10)
            //    .Take<UserInfo>(5);
            #endregion

            #region 查询部分列数据
            //var data =( from u in dbContext.UserInfo
            //           where u.Id > 0
            //           orderby u.Id descending
            //           select u).Skip(10).Take(5);
            //var datapart = from u in dbContext.UserInfo
            //               select new { u.Id, u.UserInfoName, OrderCounts = u.OrderInfo.Count };
            //foreach (var item in datapart)
            //{
            //    Console.WriteLine(item.UserInfoName+"  "+item.OrderCounts+"   "+item.Id);
            //}

            var data = dbContext.UserInfo.Where(u => u.Id > 0).Select(u => new { u.Id, u.UserInfoName, OrderCounts = u.OrderInfo.Count });
            foreach (var item in data)
            {
                Console.WriteLine(item.UserInfoName + "  " + item.OrderCounts + "   " + item.Id);
            }
            #endregion
            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}
