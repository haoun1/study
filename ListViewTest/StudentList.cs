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
        }
        public void AddList(Student student)
        {
            Add(new Student() { Name = student.Name, Age = student.Age, Phone = student.Phone, Gender = student.Gender });
        }
        public void AddList()
        {
            Add(new Student() { Name = "아이유", Age = 20, Phone = "1234-5678", Gender = Student.eGender.여자});
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
