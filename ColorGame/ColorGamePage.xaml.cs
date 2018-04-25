using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


/**
 * Class: CIST 2381 | Mobile App Development
 * Quarter: Spring 2018
 * Instructor: Steve Prettyman and Kaleigh Kendrick
 * Description: Major Project
 * Date: 4/25/18
 * @author Miguel Quintana
 * @version 1.0
 * 
 * By turning in this code, I Pledge:
 *  1. That I have completed the programming assignment independently.
 *  2. I have not copied the code from a student or any source.
 *  3. I have not given my code to any student.
 *
 */


namespace ColorGame
{
    public partial class ColorGamePage : ContentPage
    {
        Random random = new Random();
        Color randomColorCorrect;
        BoxView[] boxViews;

        public ColorGamePage()
        {
            InitializeComponent();
            boxViews = new BoxView[] { boxview0, boxview1, boxview2, boxview3 };
            initializeGame();
        }

        public void initializeGame(){
            for (int i = 0; i < 3; i++)
            {
                boxViews[i].IsVisible = true;
            }
            randomColorCorrect = generateRandomColor();

            int correctBox = random.Next(0, 3);

            for (int i = 0; i < 3; i++)
            {
                if (correctBox == i)
                {
                    boxViews[i].Color = randomColorCorrect;
                    continue;
                }

                boxViews[i].Color = generateRandomColor();
            }


            string rgbText = "rgb(" + Math.Floor(randomColorCorrect.R * 256) + ", " + Math.Floor(randomColorCorrect.G * 256) + ", " + Math.Floor(randomColorCorrect.B * 256) + ")";

            guessColorLabel.Text = rgbText;
        }

        //Resets Game
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            tryAgainLabel.IsVisible = false;
            correctLabel.IsVisible = false;

            for (int i = 0; i < 3; i++){
                boxViews[i].IsVisible = true;
            }
            randomColorCorrect = generateRandomColor();

            int correctBox = random.Next(0, 3);

            for (int i = 0; i < 3; i++){
                if(correctBox == i){
                    boxViews[i].Color = randomColorCorrect;
                    continue;
                }

                boxViews[i].Color = generateRandomColor();
            }


            string rgbText = "rgb(" + Math.Floor(randomColorCorrect.R * 256)+ ", " + Math.Floor(randomColorCorrect.G * 256) + ", " + Math.Floor(randomColorCorrect.B * 256) + ")";

            guessColorLabel.Text = rgbText;
        }

        public void OnBoxViewTapped(object sender, EventArgs args)
        {
            BoxView tappedBoxView = (BoxView)sender;

            int index = Array.IndexOf(boxViews, tappedBoxView);

            if(tappedBoxView.Color != randomColorCorrect){
                tappedBoxView.IsVisible = false;
                tryAgainLabel.IsVisible = true;
            }else{
                for (int i = 0; i < 3; i++)
                {
                    if(boxViews[i].Color != randomColorCorrect)
                    {
                        boxViews[i].IsVisible = false;
                    }
                }
                tryAgainLabel.IsVisible = false;
                correctLabel.IsVisible = true;
            }

            System.Diagnostics.Debug.WriteLine(tappedBoxView.Color);

        }

        public Color generateRandomColor(){

            var randomRed = random.Next(0, 256);
            var randomBlue = random.Next(0, 256);
            var randomGreen = random.Next(0, 256);


            return Color.FromRgb(randomRed, randomBlue, randomGreen);
        }
    }
}
