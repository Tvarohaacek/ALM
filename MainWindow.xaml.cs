using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace spirala_input
{
    public partial class MainWindow : Window
    {
        private int size = 50;
        private int gap = 1;
        private Rectangle[,] map; // 2D pole pro obdélníky
        private int StartX = 0;
        private int StartY = 0;

        private enum Direction { Right, Down, Left, Up };
        private Direction dir = Direction.Right;

        public MainWindow()
        {
            InitializeComponent();
            CreateGridWithSquares(size);
        }

        private void CreateGridWithSquares(int gridSize)
        {
            
            mainGrid.Children.Clear();

            UniformGrid uniformGrid = new UniformGrid
            {
                Rows = gridSize,
                Columns = gridSize
            };

            map = new Rectangle[gridSize, gridSize]; 

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Rectangle rect = new Rectangle
                    {
                        Fill = Brushes.Black,
                        Stroke = Brushes.White
                    };

                    
                    map[i, j] = rect;

                    
                    uniformGrid.Children.Add(rect);
                }
            }

            
            mainGrid.Children.Add(uniformGrid);
        }

        private void UpdateGrid_Click(object sender, RoutedEventArgs e)
        {
            // Získání hodnot ze sliderů
            size = (int)sizeSlider.Value;
            gap = (int)gapSlider.Value;

            
            mainGrid.Children.Clear();
            map = new Rectangle[size, size]; 
            CreateGridWithSquares(size);

            // Reset pozic
            StartX = 0;
            StartY = 0;

            
            Spiral();
        }

        private void Spiral()
        {
            int currentGap = 0; 
            int iteration = -1;
            Direction dir = Direction.Right;

            while (currentGap * 2 < size)
            {
                switch (dir)
                {
                    case Direction.Right:
                        for (int x = StartX; x < size - currentGap; x++)
                        {
                            SetSquareColor(StartY, x, Brushes.Red);
                            StartX = x;
                        }
                        dir = Direction.Down;
                        iteration++;
                        break;
                    case Direction.Down:
                        for (int y = StartY; y < size - currentGap; y++)
                        {
                            SetSquareColor(y, StartX, Brushes.Red);
                            StartY = y;
                        }
                        dir = Direction.Left;
                        iteration++;
                        break;
                    case Direction.Left:
                        for (int x = StartX; x >= currentGap; x--)
                        {
                            SetSquareColor(StartY, x, Brushes.Red);
                            StartX = x;
                        }
                        dir = Direction.Up;
                        iteration++;
                        break;
                    case Direction.Up:
                        for (int y = StartY; y >= currentGap; y--)
                        {
                            SetSquareColor(y, StartX, Brushes.Red);
                            StartY = y;
                        }
                        dir = Direction.Right;
                        iteration++;
                        break;
                    default:
                        break;
                }
                if (iteration % 2 == 0)
                {

                    //if (gap > 1)
                    //{
                    //    currentGap += (gap / 2 + 1);
                    //}
                    //else
                        currentGap += gap;
                    
                    
                }
            }
        }

        private void SetSquareColor(int row, int col, Brush color)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                if (map[row, col] != null) 
                {
                    map[row, col].Fill = color; 
                }
            }
        }
    }
}
