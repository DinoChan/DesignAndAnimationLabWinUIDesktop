﻿using DesignAndAnimationLab.Demos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignAndAnimationLab.Demos.LikeButtons;

namespace DesignAndAnimationLab
{
    public class ExampleDefinition
    {
        public ExampleDefinition(string name, Type control) : this(name, control, null)
        {
        }

        public ExampleDefinition(string name, Type control, Uri inspiredBy)
        {
            Name = name;
            Control = control;
            InspiredBy = inspiredBy;
        }

        public string Name { get; private set; }
        public Type Control { get; private set; }

        public Uri InspiredBy { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }

        public string ThumbnailWide
        {
            get { return "ms-appx:///Thumbnails/" + ThumbnailFilename(""); }
        }

        public string ThumbnailNarrow
        {
            get { return "ms-appx:///Thumbnails/" + ThumbnailFilename(""); }
        }

        public string ThumbnailFilename(string suffix)
        {
            return Name.Replace(" ", "") + suffix + ".png";
        }
    }


    public class ExampleDefinitions
    {
        public static ExampleDefinition[] Definitions { get; } = {
          new ExampleDefinition("Twitter Like Button", typeof(MattHenleysLikeButton)),
          new ExampleDefinition("Walking Cat", typeof(WalkingCat)),
          new ExampleDefinition("Transparent Cube", typeof(TransparentCube)),

            //// Visual demos.
            //new ExampleDefinition("Burning Text", typeof(BurningTextExample)),
            //new ExampleDefinition("Mandelbrot", typeof(Mandelbrot)),
            //new ExampleDefinition("Game of Life", typeof(GameOfLife)),
            //new ExampleDefinition("Camera Effect", typeof(CameraEffectExample)),
            //new ExampleDefinition("Video Effect", typeof(BasicVideoEffectExample)),
            //new ExampleDefinition("Particle System", typeof(ParticleExample)),
            //new ExampleDefinition("Sprite Sheets", typeof(SpriteSheets)),
            //new ExampleDefinition("Vector Art", typeof(VectorArt)),

            //// Show capabilities of the API.
            //new ExampleDefinition("Effects", typeof(EffectsExample)),
            //new ExampleDefinition("Custom Effects", typeof(CustomEffects)),
            //new ExampleDefinition("Geometry Operations", typeof(GeometryOperations)),
            //new ExampleDefinition("Layers", typeof(LayersExample)),
            //new ExampleDefinition("Ink", typeof(InkExample)),
            //new ExampleDefinition("Shapes", typeof(ShapesExample)),
            //new ExampleDefinition("Stroke Styles", typeof(StrokeStyles)),
            //new ExampleDefinition("Arc Options", typeof(ArcOptions)),
            //new ExampleDefinition("SVG", typeof(SvgExample)),
            //new ExampleDefinition("Gradient Mesh", typeof(GradientMeshExample)),
            //new ExampleDefinition("Histogram", typeof(HistogramExample)),
            //new ExampleDefinition("Text Layouts", typeof(TextLayouts)),
            //new ExampleDefinition("Text Outlines", typeof(TextOutlines)),
            //new ExampleDefinition("Custom Fonts", typeof(CustomFonts)),
            //new ExampleDefinition("Text Directions", typeof(TextDirectionsExample)),
            //new ExampleDefinition("Subscript And Superscript", typeof(SubscriptSuperscript)),
            //new ExampleDefinition("Typography", typeof(TypographyExample)),
            //new ExampleDefinition("Glyph Rotation", typeof(GlyphRotation)),
            //new ExampleDefinition("Font Metrics", typeof(FontMetrics)),
            //new ExampleDefinition("Custom Text Layouts", typeof(CustomTextLayouts)),

            //// Show how to use the API.
            //new ExampleDefinition("Custom Control", typeof(CustomControlExample)),
            //new ExampleDefinition("Virtual Control", typeof(VirtualControlExample)),
            //new ExampleDefinition("Animated Control", typeof(AnimatedControlExample)),
            //new ExampleDefinition("Virtual Bitmap", typeof(VirtualBitmapExample)),
            //new ExampleDefinition("Direct3D Interop", typeof(Direct3DInteropExample)),
            //new ExampleDefinition("Keyboard Input", typeof(KeyboardInputExample)),
            //new ExampleDefinition("Background Task", typeof(BackgroundTaskExample)),
            //new ExampleDefinition("Printing", typeof(PrintingExample)),

            //// Tests for internal use by the Win2D team.
            //new ExampleDefinition("Image Source Update Region", typeof(ImageSourceUpdateRegion)),
            //new ExampleDefinition("DPI", typeof(DpiExample)),
            //new ExampleDefinition("Effect Region Mapping", typeof(EffectRegionMapping)),
            //new ExampleDefinition("Control Transforms", typeof(ControlTransforms)),
            //new ExampleDefinition("DrawImage Emulations", typeof(DrawImageEmulations)),
            //new ExampleDefinition("Bitmap Rotation", typeof(BitmapRotation)),
            //new ExampleDefinition("SpriteBatch Performance", typeof(SpriteBatchPerf)),
            //new ExampleDefinition("Developer Tools", typeof(DeveloperTools)),
            //new ExampleDefinition("About", typeof(About)),
        };
    }
}
