using CommunityToolkit.Mvvm.ComponentModel;
using Entity.Models;
using Entity.Services;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using Interfaces.Services;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace UI.Wpf
{
    public partial class MainWindowViewModel : ObservableObject
    {

        private readonly ITrackingService _trackingService;

        [ObservableProperty]
        private ObservableCollection<GMapMarker> markers;

        [ObservableProperty]
        private ObservableCollection<SoldierDto> soldiers;

        private List<(Sensor, GMapMarker)> sensors;

        public MainWindowViewModel(ITrackingService trackingService)
        {
            this._trackingService = trackingService;

            this.InitializeMap();
        }


        private void InitializeMap()
        {
            Markers = new ObservableCollection<GMapMarker>();
            Soldiers = new ObservableCollection<SoldierDto>();

            this.sensors = new List<(Sensor, GMapMarker)>();
        }

        public async Task InitializeMarkers()
        {

            var sensors = this._trackingService.GetActiveSensorsAsync();

            if (sensors.ErrorList?.Any() ?? false)
            {
                MessageBox.Show(sensors.ErrorList.FirstOrDefault()?.Message);
                return;
            }

            await foreach (var sensor in sensors.Result)
            {
                var coordinates = this.GetSensorCoordinates(sensor);

                var marker = new GMapMarker(new PointLatLng(coordinates.lat, coordinates.lon))
                {
                    Shape = new System.Windows.Shapes.Ellipse
                    {
                        Width = 20,
                        Height = 20,
                        Stroke = System.Windows.Media.Brushes.Red,
                        StrokeThickness = 3
                    }
                };

                marker.Shape.MouseLeftButtonDown += async (s, e) => await PositionClicked(s, e);

                Markers.Add(marker);

                this.sensors.Add((sensor, marker));
            }
        }

        private async Task PositionClicked(object s, MouseButtonEventArgs e)
        {
            this.Soldiers.Clear();

            var marker = ((System.Windows.Shapes.Ellipse)s).DataContext as GMapMarker;

            var sensor = this.sensors.FirstOrDefault(x => x.Item2.Position == marker.Position).Item1;

            var soldier = await this._trackingService.GetSoldierInfoAsync(sensor.SoldierId);

            this.Soldiers.Add(soldier.Result);
        }

        private (double lat, double lon) GetSensorCoordinates(Sensor sensor)
        {
            var latestPosition = this.GetLatestPosition(sensor);

            var lat = this.ToDouble(latestPosition.Latitude);
            var lon = this.ToDouble(latestPosition.Longitude);

            return (lat, lon);
        }

        private Position GetLatestPosition(Sensor sensor)
        {
            return sensor?.Positions?.OrderByDescending(p => p.Time)?.FirstOrDefault();
        }

        private double ToDouble(decimal value)
        {
            return Convert.ToDouble(value, new CultureInfo("en-US"));
        }
    }
}
