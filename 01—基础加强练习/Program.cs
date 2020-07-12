using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_基础加强练习
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 请输入一个字符串，计算字符串的个数并输出
            //while (true)
            //{
            //    Console.WriteLine("请输入一个字符串");
            //    string str = Console.ReadLine();
            //    Console.WriteLine("字符串的长度是{0}",str.Length);
            //}
            #endregion

            #region 用方法实现不确定个数数字的最大值

            //Console.WriteLine("请输入4个数字");
            //int n1 = Convert.ToInt32(Console.ReadLine());
            //int n2 = Convert.ToInt32(Console.ReadLine());
            //int n3 = Convert.ToInt32(Console.ReadLine());
            //int n4 = Convert.ToInt32(Console.ReadLine());
            //int MaxNum = Maxzhi(n1, n2,n3,n4);
            //Console.WriteLine(MaxNum);
            //Console.ReadKey();
            #endregion

            #region 在字符串shuz中求长度最大的
            //string[] strName = { "龙马","迈克尔乔丹","吉普车","科比布莱恩特","机器猫"};
            //string maxName = GetMaxName(strName);
            //Console.WriteLine(maxName);
            //Console.ReadKey();

            //new Array();所有数组的父类
            #endregion

            #region 冒泡排序
            //int[] arrint={1,2,5,6,8,5,8,13,2,78,9};
            //for(int i=0;i<=arrint.Length;i++)
            //{
            //    for(int j=arrint.Length-1;j>i;j--)
            //    {
            //        if (arrint[j] > arrint[j - 1]) {
            //            int num = arrint[j];
            //            arrint[j] = arrint[j - 1];
            //            arrint[j - 1] = num;
            //        }

            //    }
            //}

            //for(int n=0;n<arrint.Length;n++)
            //{
            //    Console.WriteLine(arrint[n]);
            //}
            //Console.ReadKey();
            #endregion
        }

        private static string GetMaxName(string[] strName)
        {
            string MaxName=strName[0];
            for (int i = 1; i < strName.Length; i++)
            {
                if (strName[i].Length > MaxName.Length)
                {
                    MaxName = strName[i];
                }
            }

            return MaxName;
        }

        //不确定传几个数字
        private static int Maxzhi(params int[] pams)
        {
            //3元运算符比较2个字符
            //return (n1 > n2) ? n1 : n2;
            int max = pams[0];
            for (int i = 1; i < pams.Length; i++)
            {
                if (pams[i] > max)
                {
                    max = pams[i];
                }
            }

            return max;
        }
    }
}
