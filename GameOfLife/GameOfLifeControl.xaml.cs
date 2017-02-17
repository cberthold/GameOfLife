using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class GameOfLifeControl : UserControl
    {
        const int BLOCK_SIZE = 50;
        const int PIXEL_SIZE = 10;
        WriteableBitmap writeableBmp;

        public GameOfLifeControl()
        {
            InitializeComponent();

            Cells = new List<Cell>();
            CellMapping = new Dictionary<Point, Cell>();
            BuildBoard();
            SetupImage();
            DrawFirstGeneration();

        }

        private void SetupImage()
        {
            var widthAndHeight = BLOCK_SIZE * PIXEL_SIZE;

            image.Width = widthAndHeight;
            image.Height = widthAndHeight;
            writeableBmp = BitmapFactory.New(widthAndHeight, widthAndHeight);
            image.Source = writeableBmp;
        }

        private void DrawImage()
        {
            using (writeableBmp.GetBitmapContext())
            {
                writeableBmp.Clear(Colors.White);

                foreach (var cell in Cells)
                {
                    // swap here to prevent additional loop
                    cell.SwapIsAlive();

                    if (!cell.IsAlive)
                    {
                        continue;
                    }

                    var position = cell.Position;



                    var lowerRight = new Point(position.X * PIXEL_SIZE, position.Y * PIXEL_SIZE);
                    var upperLeft = new Point(lowerRight.X - (PIXEL_SIZE - 1), lowerRight.Y - (PIXEL_SIZE - 1));

                    writeableBmp.DrawRectangle((int)upperLeft.X, (int)upperLeft.Y, (int)lowerRight.X, (int)lowerRight.Y, Colors.Red);
                }
            }
        }

        private void DrawFirstGeneration()
        {

            var seed = -1;
            var random = new Random(seed);

            for (var i = 0; i < 12; i++)
            {
                var nextX = random.Next(1, BLOCK_SIZE);
                var nextY = random.Next(1, BLOCK_SIZE);

                seed = nextX * nextY + seed;
                random = new Random(seed);

                var point = new Point(nextX, nextY);

                var nextShape = random.Next(1, 10);
                DrawRandomShape(nextShape, point);
               
            }

            foreach (var cell in Cells)
            {
                cell.CheckRules();
            }
            
            DrawImage();
        }

        private void DrawRandomShape(int shape, Point point)
        {
            switch(shape)
            {
                case 1:
                    DrawBeehive(point);
                    break;
                case 2:
                    DrawGlider(point);
                    break;
                case 3:
                    DrawBlinker(point);
                    break;
                case 4:
                    DrawPentaDecathlon(point);
                    break;
                case 5:
                    DrawLightWeightSpaceShip(point);
                    break;
                case 6:
                    DrawRPentomino(point);
                    break;
                case 7:
                    DrawAcorn(point);
                    break;
                case 8:
                    DrawDiehard(point);
                    break;
            }
        }

        private void DrawAcorn(Point point)
        {
            var cell = CellMapping[point];

            cell.SetNextIsAlive(true)
                .MarkEastAlive()
                .North
                .MarkNorthAlive()
                .SouthEast
                .MarkEastAlive()
                .MarkSouthEastAlive()
                .MarkEastAlive()
                .MarkEastAlive();
        }


        private void DrawDiehard(Point point)
        {
            var cell = CellMapping[point];

            cell.SetNextIsAlive(true)
                .MarkEastAlive()
                .MarkSouthAlive()
                .East
                .East
                .East
                .MarkEastAlive()
                .MarkEastAlive()
                .MarkEastAlive()
                .NorthWest
                .MarkNorthAlive();

        }
        private void DrawRPentomino(Point point)
        {
            var cell = CellMapping[point];

            cell
                .MarkSouthAlive()
                .MarkSouthEastAlive()
                .MarkNorthAlive()
                .MarkNorthAlive()
                .MarkEastAlive();

        }

        private void DrawLightWeightSpaceShip(Point point)
        {
            var cell = CellMapping[point];

            var row1 = cell
                .MarkEastAlive()
                .MarkEastAlive();

            var row2 = cell
                .MarkSouthAlive()
                .MarkEastAlive()
                .MarkEastAlive()
                .MarkEastAlive();

            var row3 = cell
                .South
                .MarkSouthAlive()
                .MarkEastAlive()
                .East
                .MarkEastAlive()
                .MarkEastAlive();

            var row4 = cell
                .South
                .South
                .South
                .East
                .MarkEastAlive()
                .MarkEastAlive();

        }

        private void DrawPentaDecathlon(Point point)
        {
            var cell = CellMapping[point];
            
            var col1 = cell.MarkWestAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive();

            var col2 = cell.SetNextIsAlive(true)
                .South
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .South
                .MarkSouthAlive();

            var col3 = cell.MarkEastAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive();
        }

        private void DrawBlinker(Point point)
        {
            var cell = CellMapping[point];

            cell.SetNextIsAlive(true);

            cell.MarkEastAlive()
                .MarkEastAlive();
        }

        private void DrawGlider(Point point)
        {
            var cell = CellMapping[point];

            cell.SetNextIsAlive(true);

            cell.MarkEastAlive()
                .MarkEastAlive()
                .MarkNorthAlive()
                .MarkNorthWestAlive();
        }

        private void DrawBeehive(Point point)
        {
            var cell = CellMapping[point];

            cell.SetNextIsAlive(true);

            cell.MarkNorthEastAlive()
                .MarkEastAlive()
                .MarkSouthEastAlive();

            cell.MarkSouthEastAlive()
                .MarkEastAlive()
                .MarkNorthEastAlive();
        }

        public async Task DrawNextGenerationAsync()
        {
            foreach (var cell in Cells)
            {
                cell.CheckRules();
            }

            await Dispatcher.InvokeAsync(() =>
            {
                DrawImage();
            });

        }

        private void BuildBoard()
        {
            Cell north = null;
            Cell nextNorth = null;


            // north to south
            for (var y = 1; y <= BLOCK_SIZE; y++)
            {
                Cell west = null;

                // west to 
                for (var x = 1; x <= BLOCK_SIZE; x++)
                {
                    var cell = CreateCell(x, y);
                    cell.SetWesternNeighbor(west);
                    west = cell;

                    if (x == 1)
                    {
                        cell.SetNorthernNeighbor(north);
                        nextNorth = cell;
                    }

                    // wrap the east and west edges
                    if(x == BLOCK_SIZE)
                    {
                        CellMapping[new Point(1, y)].SetWesternNeighbor(cell);
                    }

                    // wrap the north and south edges
                    if(y == BLOCK_SIZE)
                    {
                        CellMapping[new Point(x, 1)].SetNorthernNeighbor(cell);
                    }

                }
                north = nextNorth;
                
            }

            var last = Cells.LastOrDefault();
        }

        public Cell CreateCell(int x, int y)
        {
            var cell = new Cell(x, y);
            Cells.Add(cell);
            CellMapping.Add(cell.Position, cell);
            return cell;
        }

        public List<Cell> Cells { get; private set; }
        public Dictionary<Point, Cell> CellMapping { get; private set; }
    }
}
