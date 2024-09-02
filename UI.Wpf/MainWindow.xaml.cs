using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Interfaces.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {

        }

        public MainWindow(ITrackingService trackingService)
        {
            this.DataContext = new MainWindowViewModel(trackingService);

            InitializeComponent();
            InitializeMap();

            var viewModel = (MainWindowViewModel)DataContext;

            this.ContentRendered += async (s, e) => await OnContentRendered(s, e);
            viewModel.Markers.CollectionChanged += Markers_CollectionChanged;

            SyncMarkers(viewModel.Markers);

        }

        private async Task OnContentRendered(object sender, EventArgs e)
        {
            await ((MainWindowViewModel)DataContext).InitializeMarkers();
        }

        private void Markers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SyncMarkers((ObservableCollection<GMapMarker>)sender);
        }

        private void SyncMarkers(ObservableCollection<GMapMarker> markers)
        {
            foreach (var marker in markers)
            {
                this.MyMap.Markers.Add(marker);
            }
        }

        private void InitializeMap()
        {
            MyMap.MapProvider = GMapProviders.GoogleMap;
            MyMap.Position = new PointLatLng(37.7749, -122.4194); // Example: San Francisco
            MyMap.MinZoom = 2;
            MyMap.MaxZoom = 17;
            MyMap.Zoom = 10;
            MyMap.ShowCenter = false;
        }
    }
}