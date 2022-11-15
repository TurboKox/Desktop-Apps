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

namespace Tic_Tac_Toe
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttons[0] = Btn0;
            buttons[1] = Btn1;
            buttons[2] = Btn2;
            buttons[3] = Btn3;
            buttons[4] = Btn4;
            buttons[5] = Btn5;
            buttons[6] = Btn6;
            buttons[7] = Btn7;
            buttons[8] = Btn8;
        }

        private void SwapTurns()
        {
            circleTurn = !circleTurn;
            TurnTextBlock.Text = circleTurn ? "Kolej: O | Ilosc ruchow: " + moves : "Kolej: X | Ilosc ruchow: " + moves;
        }

        private void PlaceMark(Button btn, string currentTurn)
        {
            if (playWithBot)
            {
                if (!gameOver && circleTurn && btn.Content == null)
                {
                    moves++;
                    btn.Content = currentTurn;
                    SwapTurns();
                    CheckWin(currentTurn);
                    AIPlaceMark();
                }
            }
            else
            {
                if (!gameOver && btn.Content == null)
                {
                    moves++;
                    btn.Content = currentTurn;
                    SwapTurns();
                    CheckWin(currentTurn);
                }
            }
        }

        private async void AIPlaceMark()
        {
            circleTurn = false;
            int ms = 300;
            await Task.Delay(ms);
            if (moves < 8 && !gameOver)
            {
                Random randomGenerator = new Random();
                int randomNumber;
                do
                {
                    randomNumber = randomGenerator.Next(0, 8);
                }
                while (buttons[randomNumber].Content != null);
                buttons[randomNumber].Content = "X";
                moves++;
                SwapTurns();
                CheckWin("X");
            }
        }

        private void CheckWin(string currentTurn)
        {
            for (int i = 0; i < winningCombinations.Length; i++)
            {
                if ((string)buttons[winningCombinations[i][0]].Content == currentTurn &&
                    (string)buttons[winningCombinations[i][1]].Content == currentTurn &&
                    (string)buttons[winningCombinations[i][2]].Content == currentTurn)
                {
                    SolidColorBrush bg = new SolidColorBrush();
                    bg.Color = Color.FromArgb(255, 43, 210, 247);
                    buttons[winningCombinations[i][0]].Background = bg;
                    buttons[winningCombinations[i][1]].Background = bg;
                    buttons[winningCombinations[i][2]].Background = bg;
                    TurnTextBlock.Text = currentTurn + " wygral!";
                    gameOver = true;
                    break;
                }
            }
        }

        private void CheckDraw()
        {
            bool hasMark = true;
            for (int i = 0; i < 9; i++)
            {
                if (buttons[i].Content == null)
                    hasMark = false;
            }

            if (hasMark && !gameOver)
            {
                gameOver = true;
                TurnTextBlock.Text = "Remis!";
            }
        }

        private void Restart()
        {
            moves = 0;
            SolidColorBrush bg = new SolidColorBrush();
            bg.Color = Color.FromArgb(255, 156, 249, 236);
            gameOver = false;
            circleTurn = true;
            TurnTextBlock.Text = "Kolej: O | Ilosc ruchow: 0";
            for (int i = 0; i < 9; i++)
            {
                buttons[i].Content = null;
                buttons[i].Background = bg;
            }
        }

        private void FunctionInit(Button btn)
        {
            string currentTurn = circleTurn ? "O" : "X";
            PlaceMark(btn, currentTurn);
            CheckDraw();
        }

        private void Btn0Click(object sender, RoutedEventArgs e)
        {
            FunctionInit(Btn0);
        }

        private void Btn1Click(object sender, RoutedEventArgs e)
        {
            FunctionInit(Btn1);
        }

        private void Btn2Click(object sender, RoutedEventArgs e)
        {
            FunctionInit(Btn2);
        }

        private void Btn3Click(object sender, RoutedEventArgs e)
        {
            FunctionInit(Btn3);
        }

        private void Btn4Click(object sender, RoutedEventArgs e)
        {
            FunctionInit(Btn4);
        }

        private void Btn5Click(object sender, RoutedEventArgs e)
        {
            FunctionInit(Btn5);
        }

        private void Btn6Click(object sender, RoutedEventArgs e)
        {
            FunctionInit(Btn6);
        }

        private void Btn7Click(object sender, RoutedEventArgs e)
        {

            FunctionInit(Btn7);
        }

        private void Btn8Click(object sender, RoutedEventArgs e)
        {

            FunctionInit(Btn8);
        }
        private void BtnRestartClick(object sender, RoutedEventArgs e)
        {
            Restart();
        }
        private void BtnChoice_Click(object sender, RoutedEventArgs e)
        {
            Restart();
            playWithBot = !playWithBot;
            Button btn = (Button)sender;
            if (playWithBot)
                btn.Content = "Graj we 2";
            else
                btn.Content = "Graj z botem";
        }

        private Button[] buttons = new Button[9];

        private bool circleTurn = true;
        private int moves = 0;
        private bool gameOver = false;
        private bool playWithBot = false;

        private int[][] winningCombinations = {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
        };

    }
}
