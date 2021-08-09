using ATI.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;

namespace ListViewTest
{

    public class ListViewModel : INotifyPropertyChanged
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

        private static Student _Selected;
        public static Student Selected
        {
            set
            {
                _Selected = value;
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
                if(System.Windows.MessageBox.Show("XML로 저장하시겠습니까?", "yes-no", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\items.xml";
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "XML file|*.xml";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        
                        path = saveFileDialog.FileName;
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
                                if (Items[i].Gender == Student.eGender.남자)
                                    gender.Value = "남자";
                                else if (Items[i].Gender == Student.eGender.여자)
                                    gender.Value = "여자";
                                people.Attributes.Append(name);
                                people.Attributes.Append(phone);
                                people.Attributes.Append(age);
                                people.Attributes.Append(gender);

                                peoples.AppendChild(people);
                            }
                            xml.AppendChild(peoples);                            
                            xml.Save(path);
                        }
                    }

                }

            }
         catch(InvalidOperationException)
            {
             
            }
        }

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML file|*.xml";
            XmlDocument xml = new XmlDocument();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\items.xml";
            if(openFileDialog.ShowDialog()==DialogResult.OK)
                 path = openFileDialog.FileName;
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

}
