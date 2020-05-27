using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using DesignAndAnimationLab.Demos.LikeButtons;
using DesignAndAnimationLab.Demos;

// The Blank Window item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DesignAndAnimationLabWinUIDesktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        TabView view;
        public MainWindow()
        {
            this.InitializeComponent();
          
            view = new TabView() { VerticalAlignment = VerticalAlignment.Stretch };
            view.TabItems.Add(new TabViewItem { Header = "Twitter Like Button", Content = new MattHenleysLikeButton() { VerticalAlignment = VerticalAlignment.Center } });
            view.TabItems.Add(new TabViewItem { Header = "Walking Cat", Content = new WalkingCat() { VerticalAlignment = VerticalAlignment.Center } });
            view.TabItems.Add(new TabViewItem { Header = "Transparent Cube", Content = new TransparentCube() { VerticalAlignment = VerticalAlignment.Center } });
            this.Content = view;
            view.SizeChanged += View_SizeChanged;
        }

        private void View_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            (view.TabItems[0] as TabViewItem).Header = e.NewSize.Height.ToString();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
