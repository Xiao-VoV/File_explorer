using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 文件浏览
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        FolderBrowserDialog m_Dialog = new FolderBrowserDialog();   //new一个文件夹
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = m_Dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel) return;

            string m_Dir = m_Dialog.SelectedPath.Trim();
            textbox1.Text = m_Dir;
           // TextBox_TextChanged = m_Dir;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textbox2.Text = "";
            string m_Dir = m_Dialog.SelectedPath.Trim();

            if (m_Dir.Length != 0)    //判断用户是否选择了一个文件夹
            {
                string[] files = System.IO.Directory.GetFiles(m_Dir, "*.*");     //获取m_Dir目录下的所有文件
                foreach (string s in files)           //循环输出结果
                {
                    System.IO.FileInfo fi = null;
                    try
                    {
                        fi = new System.IO.FileInfo(s);  //将文件依次赋给fi
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                    textbox2.Text += m_Dir + "\\" + fi.Name;
                    textbox2.Text += Environment.NewLine;
                }
            }
            else
            {
                textbox2.Text += "请先选择一个文件夹";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textbox2.Text = "";
            string m_Dir = m_Dialog.SelectedPath.Trim();

            if (m_Dir.Length != 0)    //判断用户是否选择了一个文件夹
            {
                string[] files = System.IO.Directory.GetDirectories(m_Dir, "*.*");     //获取m_Dir目录下的所有子文件夹
                foreach (string s in files)           //循环输出结果
                {
                    System.IO.FileInfo fi = null;
                    try
                    {
                        fi = new System.IO.FileInfo(s);  //将文件依次赋给fi



                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }

                    textbox2.Text += m_Dir + "\\" + fi.Name;
                    textbox2.Text += Environment.NewLine;
                }
            }
            else
            {
                textbox2.Text += "请先选择一个文件夹";
            }
        }
    }
}
