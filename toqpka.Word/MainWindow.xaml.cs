using Microsoft.Win32;
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
using Editor.BL;
using System.IO;

namespace toqpka.Word
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public interface IMainForm
    {
        string Content { get; set; }
        string FilePath { get; }
        event EventHandler FileOpenClick;
        event EventHandler ContentChanged;
    }
    public partial class MainWindow : Window, IMainForm
    {
                
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new WindowViewModel(this);
            btnOpenFile.Click += new RoutedEventHandler(butOpenFile_Click);
            btnAccept.Click += new RoutedEventHandler(butAcceptFil);
            mainContent.TextChanged += mainContent_textChanged;
        }

        #region throw events

        private void mainContent_textChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        }

        #endregion

        public string Content
        {
            get { return mainContent.Text; }
            set { mainContent.Text = value; }
        }

        public string FilePath
        {
            get { return pathGG.Text; }
        }
        public event EventHandler FileOpenClick;
        public event EventHandler ContentChanged;

        // READ file!

        private void butOpenFile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            OpenFileDialog dlg = new OpenFileDialog
            {   
                Filter = "Текстовые файлы|*.txt|Все файлы|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                pathGG.Text = dlg.FileName;


                var tempTaskFile = new FileManager();
                var tempTaskMess = new Messages();
                try
                {
                    string filePath = dlg.FileName;
                    bool isExist = tempTaskFile.IsExist(filePath);


                    if (!isExist)
                    {
                        tempTaskMess.ShowExclamation("файл не существует");
                        return;
                    }

                    using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default))
                    {
                        string content;
                        while ((content = sr.ReadLine()) != null)
                        {   
                            mainContent.Text += content;
                            mainContent.Text += "\n";
                        }
                    }
                }
                catch (Exception ex)
                {
                    tempTaskMess.ShowError(ex.Message);
                }



                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }

        }

        // ADDD  Filter!

        private void butAcceptFil(object sender, EventArgs e)
        {
            var filtr1_text = TextBoxFilt1.Text;
            var filtr2_text = TextBoxFilt2.Text;
            var filtr3_text = TextBoxFilt3.Text;
            var filtr4_text = TextBoxFilt4.Text;
            var filtr1 = filtrList1.Text;
            var filtr2 = filtrList2.Text;
            var filtr3 = filtrList3.Text;
            var filtr4 = filtrList4.Text;

            String[] s = mainContent.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //TextBoxFilt4.Text = s[1];

            int i = -1;
            int j = 0;
            int k = 0;
            int prev;

            int size = s.Length;
            TextBoxFilt3.Text = size.ToString();
        }
    }
}

