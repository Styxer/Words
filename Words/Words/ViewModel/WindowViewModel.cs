using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Words
{

    /// <summary>
    /// view model for the custom flat window
    /// </summary>
   public  class WindowViewModel : BaseViewModel
    {

        #region Private Members

        private Window mWindow;
        
        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;
     

        #endregion

        #region Public Props

        public int ResizeBorder { get; set; } = 6;

        public int TitleHeight { get; set; } = 42;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        public CornerRadius WindowCornderRadius { get { return new CornerRadius(OuterMarginSize); } }

        public GridLength TitleHeightGridLenght { get { return new GridLength(TitleHeight + ResizeBorder); } }




        #endregion

        #region Defualt ctor
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //litsen out for window resizning

            mWindow.StateChanged += (sender, e) =>
            {
                //fire events for all props that are affected by a reize
                OnPropertyChanges(nameof(ResizeBorderThickness));
                OnPropertyChanges(nameof(OuterMarginSize));
                OnPropertyChanges(nameof(OuterMarginSizeThickness));
                OnPropertyChanges(nameof(WindowRadius));
                OnPropertyChanges(nameof(WindowCornderRadius));
                
            };
        } 
        #endregion
    }
}
