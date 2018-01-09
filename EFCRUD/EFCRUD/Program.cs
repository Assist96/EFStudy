using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 增加
            ////1、首先声明一个上下文
            SalesERPDBEntities dbContext = new SalesERPDBEntities();
            ////2、接着生命一个实体
            TblEmployee employee = new TblEmployee();
            employee.FirstName = "网";
            employee.LastName = "cai";
            employee.Salary = 200;
            //3、告诉实体自己将要进行的操作
            // dbContext.TblEmployee.Add(employee);
            dbContext.Entry<TblEmployee>(employee).State = System.Data.Entity.EntityState.Added;

            ////4、保存变化
            //dbContext.SaveChanges();

            #endregion
            #region 修改
            //1、首先声明一个上下文

            //2、接着生命一个实体
            TblEmployee employee2 = new TblEmployee();
      
            employee2.LastName = "ss";
            employee2.Salary = 20;
            employee2.EmployeeId = 8;
            //3、告诉实体自己将要进行的操作
            //  dbContext.Entry<TblEmployee>(employee2).State = System.Data.Entity.EntityState.Modified;
            dbContext.TblEmployee.Attach(employee2);//将employee附加到上下文
            dbContext.Entry<TblEmployee>(employee2).Property<string>(u => u.LastName).IsModified=true;//只修改一列
         //   dbContext.Entry<TblEmployee>(employee2).Property("FirstName").IsModified= true;//只修改一列

            //4、保存变化
            dbContext.SaveChanges();

            #endregion
            #region 删除
            //1、首先声明一个上下文
           
            //2、接着生命一个实体
            TblEmployee employee3 = new TblEmployee();
            employee3.EmployeeId = 9;
            //3、告诉实体自己将要进行的操作
            dbContext.Entry<TblEmployee>(employee3).State = System.Data.Entity.EntityState.Deleted;

            //4、保存变化
            dbContext.SaveChanges();
            #endregion
            Console.ReadKey();
        }
    }
}
