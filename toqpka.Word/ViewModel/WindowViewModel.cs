
using System.Windows;
using System.Windows.Input;

namespace toqpka.Word
{
    /// <summary>
    /// Model for custom window -__-
    /// </summary>
    public class WindowViewModel: BaseViewModel
    {

        #region Private Member
        /// <summary>
        /// The win this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// shadow around th window
        /// </summary>
        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;

        #endregion

        #region Public Propetris


        /// <summary>
        /// The smallest window 
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        public double WindowMinimumHeight { get; set; } = 400;

        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        ///  size of the resize border
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// pading of inner content main win
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }

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

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

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

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The Height of the title bar  
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLenght { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Commands
        /// <summary>
        ///  minimize wind
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        ///  maximize wind
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        ///  close wind
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// def construct
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //listen out for win changed
            mWindow.StateChanged += (sender , e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };


            // Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());

            // Fix window resize with NONE
            var resizer = new WindowResizer(mWindow);
        }

        #endregion

        #region Private Helper
        /// <summary>
        /// Get mouse mosition on screen
        /// </summary>
        private Point GetMousePosition()
        {
            // Rel position mouse
            var position = Mouse.GetPosition(mWindow);

            // Add win cords
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion
    }
}
 