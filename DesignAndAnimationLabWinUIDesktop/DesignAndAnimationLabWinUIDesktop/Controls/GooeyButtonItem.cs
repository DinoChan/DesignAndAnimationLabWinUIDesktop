﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace DesignAndAnimationLab
{
    [ContentProperty(Name = "Content")]
    public sealed class GooeyButtonItem : Button
    {
        private Brush background;
        private long brushColorToken = -1;
        private long brushOpacityToken = -1;
        private bool isAnimating = false;

        public GooeyButtonItemProperty ItemProperty { get; }

        public GooeyButtonItem()
        {
            this.DefaultStyleKey = typeof(GooeyButtonItem);
            ItemProperty = new GooeyButtonItemProperty();
            this.Loaded += OnLoaded;
            this.SizeChanged += OnSizeChanged;
            RegisterPropertyChangedCallback(BackgroundProperty, OnBackgroundChanged);
            RegisterPropertyChangedCallback(OpacityProperty, OnOpacityChanged);
        }

        #region Override Methods

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #endregion Override Methods

        #region Event Methods

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateItemPropertyCore();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            OnGooeyButtonItemPropertyChanged();
        }

        #region Update Property

        private void OnOpacityChanged(DependencyObject sender, DependencyProperty dp)
        {
            OnGooeyButtonItemPropertyChanged();
        }

        private void OnBackgroundChanged(DependencyObject sender, DependencyProperty dp)
        {
            if (background is SolidColorBrush oldSolid)
            {
                if (brushColorToken > -1)
                {
                    oldSolid.UnregisterPropertyChangedCallback(SolidColorBrush.ColorProperty, brushColorToken);
                }
                if (brushOpacityToken > -1)
                {
                    oldSolid.UnregisterPropertyChangedCallback(SolidColorBrush.OpacityProperty, brushOpacityToken);
                }
                background = null;
            }
            if (sender.GetValue(dp) is SolidColorBrush newSolid)
            {
                background = newSolid;
                brushColorToken = newSolid.RegisterPropertyChangedCallback(SolidColorBrush.ColorProperty, OnBrushColorChanged);
                brushOpacityToken = newSolid.RegisterPropertyChangedCallback(SolidColorBrush.OpacityProperty, OnBrushOpacityChanged);
            }
            OnGooeyButtonItemPropertyChanged();
        }


        private void OnBrushColorChanged(DependencyObject sender, DependencyProperty dp)
        {
            OnGooeyButtonItemPropertyChanged();
        }

        private void OnBrushOpacityChanged(DependencyObject sender, DependencyProperty dp)
        {
            OnGooeyButtonItemPropertyChanged();
        }

        #endregion Update Property


        #endregion Event Methods

        #region Event

        public event GooeyButtonItemPropertyChangedEventHandler GooeyButtonItemPropertyChanged;

        private void OnGooeyButtonItemPropertyChanged()
        {
            UpdateItemPropertyCore();
            GooeyButtonItemPropertyChanged?.Invoke(this, new GooeyButtonItemPropertyChangedEventArgs(ItemProperty));
        }


        #endregion Event

        #region Dependency Properties

        public double Win2DTranslateX
        {
            get { return (double)GetValue(Win2DTranslateXProperty); }
            set { SetValue(Win2DTranslateXProperty, value); }
        }

        public static readonly DependencyProperty Win2DTranslateXProperty =
            DependencyProperty.Register("Win2DTranslateX", typeof(double), typeof(GooeyButtonItem), new PropertyMetadata(0d, (s, a) =>
            {
                if (s is GooeyButtonItem sender)
                {
                    if (a.NewValue != a.OldValue)
                    {
                        sender.ItemProperty.TranslateX = (double)a.NewValue;
                    }
                }
            }));

        public double Win2DTranslateY
        {
            get { return (double)GetValue(Win2DTranslateYProperty); }
            set { SetValue(Win2DTranslateYProperty, value); }
        }

        public static readonly DependencyProperty Win2DTranslateYProperty =
            DependencyProperty.Register("Win2DTranslateY", typeof(double), typeof(GooeyButtonItem), new PropertyMetadata(0d, (s, a) =>
            {
                if (s is GooeyButtonItem sender)
                {
                    if (a.NewValue != a.OldValue)
                    {
                        sender.ItemProperty.TranslateY = (double)a.NewValue;
                    }
                }
            }));

        #endregion Dependency Properties

        #region Methods

        private void UpdateItemPropertyCore()
        {
            Color? color = null;
            var opacity = Opacity;
            if (Background is SolidColorBrush brush)
            {
                color = brush.Color;
                opacity *= brush.Opacity;
            }
            ItemProperty.BackgroundColor = color;
            ItemProperty.Opacity = opacity;
            ItemProperty.Radius = Math.Min(ActualWidth, ActualHeight) / 2;
        }

        #endregion Methods

        #region Nested Class

        public delegate void GooeyButtonItemPropertyChangedEventHandler(GooeyButtonItem sender, GooeyButtonItemPropertyChangedEventArgs args);

        public class GooeyButtonItemProperty
        {
            public Color? BackgroundColor { get; set; }

            public double Opacity { get; set; }

            public double Radius { get; set; }

            public double TranslateX { get; set; }

            public double TranslateY { get; set; }
        }

        public class GooeyButtonItemPropertyChangedEventArgs : EventArgs
        {
            internal GooeyButtonItemPropertyChangedEventArgs(GooeyButtonItemProperty property)
            {
                Property = property;
            }

            public GooeyButtonItemProperty Property { get; }
        }

        #endregion Nested Class

    }
}
