using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace NoobasStudio.Behaviors
{
    public class FadeWindowBehavior : Behavior<Window>
    {
        public FadeWindowBehavior()
        {
            _fadeInStoryboard = new Storyboard
            {
                Duration = TimeSpan.FromSeconds(2),
                Children =
                {
                    new DoubleAnimation
                    {
                        To = 1
                    }
                }
            };


            Storyboard.SetTargetProperty(_fadeInStoryboard, new PropertyPath(UIElement.OpacityProperty));
        }

        private readonly Storyboard _fadeInStoryboard;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Opacity = 0;
            AssociatedObject.Loaded += OnWindowLoaded;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            _fadeInStoryboard.Begin(AssociatedObject);
        }
    }
}
