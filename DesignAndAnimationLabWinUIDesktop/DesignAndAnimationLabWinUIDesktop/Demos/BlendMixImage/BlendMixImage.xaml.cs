﻿using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace DesignAndAnimationLab.Demos
{
    public sealed partial class BlendMixImage : UserControl
    {
        public BlendMixImage()
        {
            this.InitializeComponent();


            ElementCompositionPreview.SetElementChildVisual(Background, CreateVisual("sea.jpg"));
            ElementCompositionPreview.SetElementChildVisual(Background2, CreateVisual("sea2.jpg"));
        }

        private SpriteVisual CreateVisual(string imageName)
        {
            var compositor = Window.Current.Compositor;
            var (foreground, foregroundBrush) = CreateBrush(imageName, Colors.Cyan);
            var (background, backgroundBrush) = CreateBrush(imageName, Colors.Red);
            foregroundBrush.Offset = new Vector2(10, 0);

            var brush = CreateBrush(foreground, background, BlendEffectMode.Darken);

            var imageVisual = compositor.CreateSpriteVisual();
            imageVisual.Brush = brush;
            imageVisual.Size = new Vector2(800, 384);
            return imageVisual;

        }

        private (CompositionBrush compositionBrush, CompositionSurfaceBrush compositionSurfaceBrush) CreateBrush(string imageName, Color color)
        {
            var compositor = Window.Current.Compositor;
            var loadedSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/Images/" + imageName));
            var compositionSurfaceBrush = compositor.CreateSurfaceBrush();
            compositionSurfaceBrush.Surface = loadedSurface;
            var compositionBrush = CreateBrush(compositionSurfaceBrush, compositor.CreateColorBrush(color), BlendEffectMode.Lighten);
            return (compositionBrush, compositionSurfaceBrush);
        }

        private CompositionBrush CreateBrush(CompositionBrush foreground, CompositionBrush background, BlendEffectMode blendEffectMode)
        {
            var compositor = Window.Current.Compositor;
            var effect = new BlendEffect()
            {
                Mode = blendEffectMode,
                Foreground = new CompositionEffectSourceParameter("Main"),
                Background = new CompositionEffectSourceParameter("Tint"),
            };
            var effectFactory = compositor.CreateEffectFactory(effect);
            var compositionBrush = effectFactory.CreateBrush();
            compositionBrush.SetSourceParameter("Main", foreground);
            compositionBrush.SetSourceParameter("Tint", background);

            return compositionBrush;
        }
    }
}
