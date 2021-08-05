using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewTest
{
    public class StudentList : ObservableCollection<Student>
    {

        public StudentList()
        {
            Add(new Student() { Name = "범범조조", Age = 28, Phone = "010-2345-2222" , Gender = Student.eGender.남자 });
            Add(new Student() { Name = "안정환", Age = 23, Phone = "210-2345-2222", Gender = Student.eGender.남자 });
            Add(new Student() { Name = "아이유", Age = 20, Phone = "310-2345-2222", Gender = Student.eGender.여자 });
            Add(new Student() { Name = "수지", Age = 30, Phone = "332-2345-2222", Gender = Student.eGender.여자 });
        }
        public void AddList()
        {
            Add(new Student() { Name = "아이유", Age = 20, Phone = "310-2345-2222", Gender = Student.eGender.여자});
        }
    }

    public class Student
    {
        public enum eGender
        {
            남자,
            여자
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public eGender Gender 
        {
            get;
            set; 
        }
        public string Phone { get; set; }
    }
}
