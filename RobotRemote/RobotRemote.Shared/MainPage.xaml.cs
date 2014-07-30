using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

//Add references to System.Web.Extensions
namespace RobotRemote
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {
        private string fwd = "{\"commandList\":[{\"angle\":0,\"distance\":1}]}";
        private string back = "{\"commandList\":[{\"angle\":180,\"distance\":1}]}";
        private string right = "{\"commandList\":[{\"angle\":5,\"distance\":0}]}";
        private string left = "{\"commandList\":[{\"angle\":5,\"distance\":0}]}";
        private string stop = "{\"commandList\":[{\"angle\":0,\"distance\":0}]}";


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void stopButtonClicked(object sender, RoutedEventArgs e)
        {
            HttpRequest request = new HttpRequest(stop);
            request.sendInstructions();
        }

        private void upButtonClicked(object sender, RoutedEventArgs e)
        {
            HttpRequest request = new HttpRequest(fwd);
            request.sendInstructions();

        }

        private void leftButtonClicked(object sender, RoutedEventArgs e)
        {
            HttpRequest request = new HttpRequest(left);
            request.sendInstructions();

        }

        private void rightButtonClicked(object sender, RoutedEventArgs e)
        {
            HttpRequest request = new HttpRequest(right);
            request.sendInstructions();

        }

        private void downButtonClicked(object sender, RoutedEventArgs e)
        {
            HttpRequest request = new HttpRequest(back);
            request.sendInstructions();

        }
    }
}
