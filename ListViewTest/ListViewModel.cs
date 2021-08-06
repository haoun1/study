using ATI.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;

namespace ListViewTest
{

    public class ListViewModel : INotifyPropertyChanged, IcloseWindows
    {




        private StudentList _Items;
        public StudentList Items
        {
            set
            {
                _Items = value;
            }
            get
            {
                return _Items;
            }
        }

        private Student _Selected;
        public Student Selected
        {
            set
            {
                _Selected = value;
                OnPropertyChanged("Selected");
            }
            get
            {
                return _Selected;
            }
        }

        private int _Index;
        public int Index
        {
            set
            {
                _Index = value;
            }
            get
            {
                return _Index;
            }
        }

        private static Student _returnstu;
        public static Student returnstu
        {
            get
            {
                return _returnstu;
            }
            set
            {
                _returnstu = value;
            }
        }

        public ICommand commandNew
        {
            get
            {
                return new RelayCommand(ClickNew);
            }
        }


        private void ClickNew()
        {
            _Items = new StudentList();
            _Items.AddList();
            OnPropertyChanged("Items");
        }

        public ICommand commandAdd
        {
            get
            {
                return new RelayCommand(ClickAdd);
            }
        }


        private void ClickAdd()
        {
            if (_Items != null)
            {
                _Items.AddList();
                OnPropertyChanged("Items");
            }
        }

        public ICommand ListItemClick
        {
            get
            {
                return new RelayCommand(ClickList);
            }
        }

        
        

        private void ClickList()
        {
            if (Selected != null)
            {
                Dialog dialog = new Dialog();
                dialog.ShowDialog();
                Items[Index] = _returnstu;
                OnPropertyChanged("Items");
            }


        }

        public ICommand DeleteList
        {
            get
            {
                return new RelayCommand(ListDelete);
            }
        }

        private void ListDelete()
        {
            try 
            { 
            Items.RemoveAt(Index);
            }
            catch(ArgumentOutOfRangeException) 
            { 
            }
        }

        public ICommand Submit
        {
            get
            {
                return new RelayCommand(submit);

            }
        }

        private void submit()
        {
            int tempAge = 0;
            Student.eGender tempGen=Student.eGender.남자;
            //if (InGender == true)
            //    tempGen = Student.eGender.남자;
            //else if (InGender == false)
            //    tempGen = Student.eGender.여자;
            //else
            //    tempGen = Student.eGender.남자;

            try
            {
                tempAge = Convert.ToInt32(InAge);
            }
            catch (Exception)
            {
                tempAge = 0;
            }

            _returnstu = new Student { Name = InName, Age = tempAge, Phone = InPhone, Gender = tempGen };
                OnPropertyChanged("returnstu");
            }
        
        //버튼과 연결하여 종료시키는 릴레이커맨드
        private RelayCommand _closeCommand;
        public RelayCommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand(CloseWindow));
        void CloseWindow()//프로그램을 종료 할 때 발생하는 동작에 대해 정의합니다.
        {         
            Close?.Invoke();
        }


        public ICommand save_xml
        {
            get
            {
                return new RelayCommand(save);
            }
        }
        private void save()
        {
            try {
                MessageBox.Show("바탕화면에 XML로 저장완료!!");
                XmlDocument xml = new XmlDocument();
                XmlNode peoples = xml.CreateElement("peoples");
                
                if (Items != null)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        XmlNode people = xml.CreateElement("people");
                        XmlAttribute name = xml.CreateAttribute("name");
                        XmlAttribute phone = xml.CreateAttribute("phone");
                        XmlAttribute age = xml.CreateAttribute("age");
                        XmlAttribute gender = xml.CreateAttribute("gender");

                        name.Value = Items[i].Name;
                        phone.Value = Items[i].Phone;
                        age.Value = Items[i].Age.ToString();
                        gender.Value = Items[i].Gender.ToString();

                        people.Attributes.Append(name);
                        people.Attributes.Append(phone);
                        people.Attributes.Append(age);
                        people.Attributes.Append(gender);

                        peoples.AppendChild(people);
                    }
                    xml.AppendChild(peoples);
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\items.xml";
                    xml.Save(path);
                }
            }
         catch(InvalidOperationException e)
            {
             
            }
        }

        public Action Close { get; set; }

        public bool CanClose() //false이면 창을 닫을 수 없게 설정됩니다.
        {            
            return true;
        }
        //------------------------------------------

        public ListViewModel()
        {
            XmlDocument xml = new XmlDocument();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\items.xml";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                xml.Load(path);
                XmlNode peoples = xml.SelectSingleNode("/peoples");
                Student stu;
                string xmlName;
                string xmlPhone;
                string xmlAge;
                Student.eGender xmlGender = Student.eGender.남자;
                _Items = new StudentList();
                foreach (XmlNode people in peoples)
                {
                    xmlName = people.Attributes[0].Value;
                    xmlPhone = people.Attributes[1].Value;
                    xmlAge = people.Attributes[2].Value;
                    if (people.Attributes[3].Value == "남자")
                        xmlGender = Student.eGender.남자;
                    else if (people.Attributes[3].Value == "여자")
                        xmlGender = Student.eGender.여자;
                    stu = new Student() { Name = xmlName, Age = Convert.ToInt32(xmlAge), Gender = xmlGender, Phone = xmlPhone };
                    _Items.AddList(stu);
                }
            }
        }

        public ICommand xml
        {
            get
            {
                return new RelayCommand(xmlLoad);
            }
        }
        private void xmlLoad()
        {
            XmlDocument xml = new XmlDocument();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\items.xml";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                xml.Load(path);
                XmlNode peoples = xml.SelectSingleNode("/peoples");
                Student stu;
                string xmlName;
                string xmlPhone;
                string xmlAge;
                Student.eGender xmlGender = Student.eGender.남자;
                _Items = new StudentList();
                foreach (XmlNode people in peoples)
                {
                    xmlName = people.Attributes[0].Value;
                    xmlPhone = people.Attributes[1].Value;
                    xmlAge = people.Attributes[2].Value;
                    if (people.Attributes[3].Value == "남자")
                        xmlGender = Student.eGender.남자;
                    else if (people.Attributes[3].Value == "여자")
                        xmlGender = Student.eGender.여자;
                    stu = new Student() { Name = xmlName, Age = Convert.ToInt32(xmlAge), Gender = xmlGender, Phone = xmlPhone };
                    _Items.AddList(stu);
                }
                OnPropertyChanged("Items");
            }
        }


        string start = "ttetet";
        public string p_start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
                OnPropertyChanged("start");

            }
        }
      

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


    }//viewmodel 끝

    interface IcloseWindows
    {
        Action Close { get; set; }

        bool CanClose();
    }

    //xaml에서 이 class의 EnableWindowClosing = true로 설정합니다.
    public class WindowCloser
    {
        public static bool GetEnableWindowClosing(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableWindowClosingProperty);
        }

        public static void SetEnableWindowClosing(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableWindowClosingProperty, value);
        }
        
        // Using a DependencyProperty as the backing store for EnableWindowClosing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableWindowClosingProperty =
            DependencyProperty.RegisterAttached("EnableWindowClosing", typeof(bool), typeof(WindowCloser), new PropertyMetadata(false, OnEnableWindowClosingChanged));
        //이 프로퍼티의 이름은 EnableWindowClosing입니다. 타입은 bool이고 WindowCloser클래스에서 사용합니다. 이값의 기본값은 false이고, true로 변경되면 프로그램은 OnEnableWindowClosingChanged를 호출합니다.


        private static void OnEnableWindowClosingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                window.Loaded += (s1, e1) =>
                {
                    if (window.DataContext is IcloseWindows vm) // window.DataContext는 xaml에서 ListViewTest.ListViewModel로 지정 한 것인데, 이 ListViewModel이 IcloseWindows 인터페이스를 상속했는지, 아닌지 여부를 확인하는 코드
                    {
                        vm.Close += () =>
                        {
                            try
                            {
                                window.Close();
                            }
                            catch(InvalidOperationException)
                            {

                            }
                        };

                        window.Closing += (s2, e2) =>
                        {
                            e2.Cancel = !vm.CanClose(); //CanClose는 true를 반환하고, !true = false이므로 e2.Cancel=false가 되므로 
                        };
                    }
                };
            }
        }
    }//----------------------------------------------------------------------------------------------------------
}
