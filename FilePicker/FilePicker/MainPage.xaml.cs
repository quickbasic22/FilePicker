using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;

namespace FilePicker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnChooseFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                var customFileType =
    new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
    {
        { DevicePlatform.Android, new[] { "application/comics" } }
    });
                var options = new PickOptions
                {
                    PickerTitle = "Please select a comic file",
                    FileTypes = customFileType,
                };
                var file = await Xamarin.Essentials.FilePicker.PickMultipleAsync();

                if (customFileType != null)
                {
                    var fileInfo = file.ToList();
                    foreach (var item in fileInfo)
                    {
                        LabelInfo.Text += "\n" + item.FileName + "\n";
                        LabelInfo.Text += "\n" + item.ContentType + "\n";
                        LabelInfo.Text += "\n" + item.FullPath + "\n";
                    }
                    
                }
               
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            
        }
    }
}
