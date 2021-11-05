using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XamarinForms.Charts;
using T806443.Models;
using Xamarin.Forms;

namespace T806443 {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }
    }

    class LandAreaDataAdapter : BindableObject, IPieSeriesData, IChangeableSeriesData {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: nameof(ItemsSource),
            returnType: typeof(BindingList<LandAreaItem>),
            declaringType: typeof(LandAreaDataAdapter),
            propertyChanged: OnItemsSourcePropertyChanged
        );

        static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            if (!(bindable is LandAreaDataAdapter adapter))
                return;
            adapter.OnItemsSourceChanged(oldValue as BindingList<LandAreaItem>, newValue as BindingList<LandAreaItem>);
        }

        public event DataChangedEventHandler DataChanged;

        public IReadOnlyList<LandAreaItem> ItemsSource {
            get => (IReadOnlyList<LandAreaItem>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public int GetDataCount() => (ItemsSource == null) ? 0 : ItemsSource.Count;
        public object GetKey(int index) => ItemsSource[index];
        public string GetLabel(int index) => ItemsSource[index].CountryName;
        public double GetValue(int index) => ItemsSource[index].Area;

        void OnItemsSourceChanged(BindingList<LandAreaItem> oldCollection, BindingList<LandAreaItem> newCollection) {
            if (oldCollection != null)
                oldCollection.ListChanged -= CollectionChanged;
            if (newCollection != null)
                newCollection.ListChanged += CollectionChanged;
            DataChanged?.Invoke(this, DataChangedEventArgs.Reset());
        }
        void CollectionChanged(object sender, ListChangedEventArgs e) {
            DataChanged?.Invoke(this, DataChangedEventArgs.Reset());
        }
    }

    public class TempSensorDataAdapter : BindableObject, IXYSeriesData, IChangeableSeriesData
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: nameof(ItemsSource),
            returnType: typeof(BindingList<SensorValue>),
            declaringType: typeof(TempSensorDataAdapter),
            propertyChanged: OnItemsSourcePropertyChanged
        );

        static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is TempSensorDataAdapter adapter))
                return;
            adapter.OnItemsSourceChanged(oldValue as BindingList<SensorValue>, newValue as BindingList<SensorValue>);
        }

        public event DataChangedEventHandler DataChanged;

        public IReadOnlyList<SensorValue> ItemsSource
        {
            get => (IReadOnlyList<SensorValue>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public int GetDataCount() => (ItemsSource == null) ? 0 : ItemsSource.Count;
        SeriesDataType IXYSeriesData.GetDataType() => SeriesDataType.DateTime;
        public object GetKey(int index) => ItemsSource[index];
        public DateTime GetLabel(int index) => ItemsSource[index].Timestamp;
        public double GetNumericArgument(int index) => ItemsSource[index].Value;
        public string GetQualitativeArgument(int index) => throw new NotImplementedException();
        public DateTime GetDateTimeArgument(int index) => ItemsSource[index].Timestamp;
        double IXYSeriesData.GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index)
        {
            switch (valueType)
            {
                case DevExpress.XamarinForms.Charts.ValueType.Value:
                    return ItemsSource[index].Value;
            }
            return 0.0;
        }

        void OnItemsSourceChanged(BindingList<SensorValue> oldCollection, BindingList<SensorValue> newCollection)
        {
            if (oldCollection != null)
                oldCollection.ListChanged -= CollectionChanged;
            if (newCollection != null)
                newCollection.ListChanged += CollectionChanged;
            DataChanged?.Invoke(this, DataChangedEventArgs.Reset());
        }

        void CollectionChanged(object sender, ListChangedEventArgs e)
        {
            DataChanged?.Invoke(this, DataChangedEventArgs.Reset());
        }
    }

}
