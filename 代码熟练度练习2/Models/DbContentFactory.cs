using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace 代码熟练度练习2.Models
{
    public class DbContentFactory
    {
        public static JHcoTextDemoEntities GetCurrentDbContent()
        {
            //return new JHcoTextDemoEntities();
            //一次请求共有一个上下文
            JHcoTextDemoEntities db = CallContext.GetData("DbContext") as JHcoTextDemoEntities;
            if (db == null)
            {
                db = new JHcoTextDemoEntities();
                CallContext.SetData("DbContext",db);
            }
            return db;
        }
    }
}