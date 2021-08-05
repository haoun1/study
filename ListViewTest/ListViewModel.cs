using ATI.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;




namespace ListViewTest
{

    public class ListViewModel : INotifyPropertyChanged
    {

        private static string _InName;
        public static string InName
        {
            set { _InName = value; }
            get
            {
                return _InName;
            }
        }

        private static string _InAge;
        public static string InAge
        {
            set { _InAge = value; }
            get
            {
                return _InAge;
            }
        }

        private static string _InPhone;
        public static string InPhone
        {
            set { _InPhone = value; }
            get
            {
                return _InPhone;
            }
        }

        private static string _InGender;
        public static string InGender
        {
            set { _InGender = value; }
            get
            {
                return _InGender;
            }
        }

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

        private static StudentList _StaticItems;
        public static StudentList StaticItems
        {
            set
            {
                _StaticItems = value;
            }
            get
            {
                return _StaticItems;
            }
        }

        private Student _Selected;
        public Student Selected
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
                InName = Items[Index].Name;
                InAge = Items[Index].Age.ToString();
                InPhone = Items[Index].Phone;
                if (Items[Index].Gender == Student.eGender.남자)
                    InGender = "남";
                else if (Items[Index].Gender == Student.eGender.여자)
                    InGender = "여";
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
            Items.RemoveAt(2);
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
            Student.eGender tempGen;
            if (InGender == "남")
                tempGen = Student.eGender.남자;
            else if (InGender == "여")
                tempGen = Student.eGender.여자;
            else
                tempGen = Student.eGender.남자;

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
            StaticItems = _Items;
            OnPropertyChanged("Staticitems");
        }

        //버튼과 연결하여 종료시키는 릴레이커맨드
        private RelayCommand _closeCommand;
        public RelayCommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand(CloseWindow));
        void CloseWindow()
        {
            Close?.Invoke();
        }

        public Action Close { get; set; }

        public bool CanClose()
        {
            return false;
        }
        //

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


    }

    interface IcloseWindows
    {
        Action Close { get; set; }

        bool CanClose();
    }

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

        private static void OnEnableWindowClosingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                window.Loaded += (s1, e1) =>
                {
                    if (window.DataContext is IcloseWindows vm)
                    {
                        vm.Close += () =>
                        {
                            window.Close();
                        };

                        window.Closing += (s2, e2) =>
                        {
                            e2.Cancel = !vm.CanClose();
                        };
                    }
                };
            }
        }
    }
}
