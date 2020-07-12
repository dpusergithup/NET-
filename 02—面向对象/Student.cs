using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_面向对象
{
    public class Student
    {
        public string Name { get; set; }
        public int  Age { get; set; }

        public Student()
        { 
        }
        //构造函数重载
        public Student(string name)
        {
            this.Name = name;
        }
    }
}
