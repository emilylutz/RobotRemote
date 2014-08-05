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
        private HttpRequest request = new HttpRequest();

        private static string FWD = "{\"commandList\":[{\"angle\":0,\"distance\":1}]}";
        private static string BACK = "{\"commandList\":[{\"angle\":0,\"distance\":-1}]}";
        private static string RIGHT = "{\"commandList\":[{\"angle\":35,\"distance\":0}]}";
        private static string LEFT = "{\"commandList\":[{\"angle\":-35,\"distance\":0}]}";
        private static string STOP = "{\"commandList\":[{\"angle\":0,\"distance\":0}]}";


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void stopButtonClicked(object sender, RoutedEventArgs e)
        {
            request.sendInstructions(STOP);
        }

        private void upButtonClicked(object sender, RoutedEventArgs e)
        {
            request.sendInstructions(FWD);
        }

        private void leftButtonClicked(object sender, RoutedEventArgs e)
        {
            request.sendInstructions(LEFT);
        }

        private void rightButtonClicked(object sender, RoutedEventArgs e)
        {
            request.sendInstructions(RIGHT);
        }

        private void downButtonClicked(object sender, RoutedEventArgs e)
        {
            request.sendInstructions(BACK);
        }
    }
}
