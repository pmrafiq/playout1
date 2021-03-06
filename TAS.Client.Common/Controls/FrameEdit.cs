using System;
using System.Windows;
using System.Windows.Controls;
using TAS.Common;

namespace TAS.Client.Common.Controls
{
    public class FrameEdit: TextBox
    {
        public static readonly DependencyProperty TimecodeProperty =
            DependencyProperty.Register(
            "Timecode",
            typeof(TimeSpan),
            typeof(FrameEdit),
            new FrameworkPropertyMetadata(TimeSpan.Zero, OnTimecodeChanged) { BindsTwoWayByDefault = true });

        public static readonly DependencyProperty VideoFormatProperty =
            DependencyProperty.Register(
                "VideoFormat",
                typeof(TVideoFormat),
                typeof(FrameEdit),
                new PropertyMetadata(TVideoFormat.Other, OnTimecodeChanged));

        private static void OnTimecodeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as FrameEdit)._updateText();
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            var text = (string)GetValue(TextProperty);
            long frames;
            if (long.TryParse(text, out frames))
                SetValue(TimecodeProperty, frames.SmpteFramesToTimeSpan(VideoFormat));
            base.OnTextChanged(e);
        }

        private void _updateText()
        {
            Text = Timecode.ToSmpteFrames(VideoFormat).ToString();
        }

        public TimeSpan Timecode
        {
           get { return (TimeSpan)GetValue(TimecodeProperty); }
            set
            {
                if (value != Timecode)
                {
                    SetValue(TimecodeProperty, value);
                    _updateText();
                }
            }
        }

        public TVideoFormat VideoFormat
        {
            private get
            {
                return (TVideoFormat)GetValue(VideoFormatProperty);
            }
            set
            {
                if (value != VideoFormat)
                {
                    SetValue(VideoFormatProperty, value);
                    _updateText();
                }
            }
        }
    }
}
