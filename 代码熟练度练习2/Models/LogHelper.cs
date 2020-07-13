using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace 代码熟练度练习2.Models
{
    public class LogHelper
    {
        //定义一个静态集合队列来保存异常信息
        public static Queue<string> ExceptionStringQueue = new Queue<string>();
        //定义一个委托
        public static Action<string> WriteLogAction;
        static LogHelper()
        {
            WriteLogAction = WriteLogToFile;
            //WriteLogAction += WriteLogTowry;

            //启动一个线程不停的从队列中获取错误信息写到日志文件里面去
            ThreadPool.QueueUserWorkItem(o => {
                lock (ExceptionStringQueue)
                {
                    string str = ExceptionStringQueue.Dequeue();
                    //把异常信息写到日志文件里面去
                    //执行委托方法，把异常信息写到委托方法里面去
                    WriteLogAction(str);
                }
            });
        }

        //把信息写到文件里
        public static void WriteLogToFile(string txt)
        {
            //TODO:把信息写到文件里
            //System.IO.File.WriteAllText(@"D:\我的工作\C#项目练习\日常练习\JHco.OA\JHco.OA.UI.Portal\LogSaves\", txt);
        }

        //把信息写到其他地方
        //public static void WriteLogTowry(string txt)
        //{
        //}

        //把错误信息写到队列
        public static void WriteLof(string exceptionText)
        {
            //多条错误信息同时写入问题（多线程访问问题）
            //枷锁
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);
            }
        }
    }
}