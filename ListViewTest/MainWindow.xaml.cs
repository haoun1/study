using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ListViewTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;

            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

            double windowWidth = this.Width;

            double windowHeight = this.Height;

            this.Left = (screenWidth / 2) - (windowWidth / 2);

            this.Top = (screenHeight / 2) - (windowHeight / 2);

        }

        //private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if(DataContext is IcloseWindows vm)
        //    {
        //        vm.Close += () =>
        //        {
        //            this.Close();
        //        };

        //        Closing += (s1, e1) =>
        //         {
        //             e1.Cancel = !vm.CanClose();
        //         };
        //    }
        //}


        //private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{

        //    StudentList SaveItems = ListViewModel.StaticItems;
        //    XmlDocument xml = new XmlDocument();
        //    XmlNode peoples = xml.CreateElement("peoples");

        //    for (int i = 0; i < 5; i++)
        //    {
        //        XmlNode people = xml.CreateElement("people");
        //        XmlAttribute name = xml.CreateAttribute("name");
        //        XmlAttribute phone = xml.CreateAttribute("phone");
        //        XmlAttribute age = xml.CreateAttribute("age");
        //        XmlAttribute gender = xml.CreateAttribute("gender");

        //        name.Value = "이하운";
        //        phone.Value = "leehaoun";
        //        age.Value = "11";
        //        gender.Value = "남자";

        //        people.Attributes.Append(name);
        //        people.Attributes.Append(phone);
        //        people.Attributes.Append(age);
        //        people.Attributes.Append(gender);

        //        peoples.AppendChild(people);
        //    }
        //    xml.AppendChild(peoples);
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\items.xml";
        //    xml.Save(path);

        //}
    }
}
