using HurmatullinSystemForInstitute.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace HurmatullinSystemForInstitute.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static Worker currentUser;
        public static List<Worker> Workers { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();
            Workers = new List<Worker>(DBConnection.Entity.Worker.ToList());
            currentUser = Workers.FirstOrDefault(x => x.login == login && x.password == password);
            if (currentUser != null && currentUser.idRole==2)
            {
                NavigationService.Navigate(new ExamsPage());
            }
            else if (currentUser != null && currentUser.idRole == 1)
            {
                NavigationService.Navigate(new DepartmentsPage());
            }
            else if (currentUser != null && currentUser.idRole == 3)
            {
                NavigationService.Navigate(new EmployeesPage());
            }
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SpecializationsPage());
        }

        private void QrCodeBt_Click(object sender, RoutedEventArgs e)
        {
            // Ссылка на XL таблицу
            string soucer_xl = "https://docs.google.com/spreadsheets/d/1yGppfv2T5KPtFWzNq25RjlLyerbe-OjY_jnT04ON9iI/edit?usp=drivesdk";
            // Создание переменной библиотеки QRCoder
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            // Присваеваем значиения
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);
            // переводим в Qr
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            /// Создание картинки
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                imageQr.Source = bitmapimage;
            }
        }
    }
}
