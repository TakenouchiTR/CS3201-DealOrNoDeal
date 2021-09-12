using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using DealOrNoDeal.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DealOrNoDeal.View
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DealOrNoDealPage
    {
        #region Data members

        private const string SkipTag = "Skip";
        /// <summary>
        ///     The application window height
        /// </summary>
        public const int ApplicationHeight = 500;
        /// <summary>
        ///     The application window width
        /// </summary>
        public const int ApplicationWidth = 500;

        private GameManager gameManager;
        private IList<Button> briefcaseButtons;
        private IList<Button> gameTypeButtons;
        private IList<Border> dollarAmountLabels;
        private IList<StackPanel> briefcaseButtonRows;

        #endregion

        #region Properties

        private StackPanel centerBriefcaseButtonRow => this.briefcaseButtonRows[this.briefcaseButtonRows.Count / 2];

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DealOrNoDealPage" /> class.
        /// </summary>
        public DealOrNoDealPage()
        {
            this.InitializeComponent();
            this.initializeUiDataAndControls();
            this.hideBriefcaseButtons();
        }
        #endregion

        #region Methods

        private void initializeUiDataAndControls()
        {
            this.setPageSize();

            this.briefcaseButtons = new List<Button>();
            this.gameTypeButtons = new List<Button>();
            this.dollarAmountLabels = new List<Border>();
            this.briefcaseButtonRows = new List<StackPanel>();
            this.buildBriefcaseButtonCollection();
            this.buildDollarAmountLabelCollection();
            this.buildGameTypeButtonCollection();
            this.buildBriefcaseRowCollection();
        }
        
        private static bool shouldSkipDollarAmountLabel(Border dollarAmountLabel)
        {
            return dollarAmountLabel.Tag != null && dollarAmountLabel.Tag.ToString() == SkipTag;
        }

        private void setPageSize()
        {
            ApplicationView.PreferredLaunchViewSize = new Size {Width = ApplicationWidth, Height = ApplicationHeight};
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        private void buildDollarAmountLabelCollection()
        {
            this.dollarAmountLabels.Clear();

            this.dollarAmountLabels.Add(this.label0Border);
            this.dollarAmountLabels.Add(this.label1Border);
            this.dollarAmountLabels.Add(this.label2Border);
            this.dollarAmountLabels.Add(this.label3Border);
            this.dollarAmountLabels.Add(this.label4Border);
            this.dollarAmountLabels.Add(this.label5Border);
            this.dollarAmountLabels.Add(this.label6Border);
            this.dollarAmountLabels.Add(this.label7Border);
            this.dollarAmountLabels.Add(this.label8Border);
            this.dollarAmountLabels.Add(this.label9Border);
            this.dollarAmountLabels.Add(this.label10Border);
            this.dollarAmountLabels.Add(this.label11Border);
            this.dollarAmountLabels.Add(this.label12Border);
            this.dollarAmountLabels.Add(this.label13Border);
            this.dollarAmountLabels.Add(this.label14Border);
            this.dollarAmountLabels.Add(this.label15Border);
            this.dollarAmountLabels.Add(this.label16Border);
            this.dollarAmountLabels.Add(this.label17Border);
            this.dollarAmountLabels.Add(this.label18Border);
            this.dollarAmountLabels.Add(this.label19Border);
            this.dollarAmountLabels.Add(this.label20Border);
            this.dollarAmountLabels.Add(this.label21Border);
            this.dollarAmountLabels.Add(this.label22Border);
            this.dollarAmountLabels.Add(this.label23Border);
            this.dollarAmountLabels.Add(this.label24Border);
            this.dollarAmountLabels.Add(this.label25Border);
        }

        private void buildBriefcaseButtonCollection()
        {
            this.briefcaseButtons.Clear();

            this.briefcaseButtons.Add(this.case0);
            this.briefcaseButtons.Add(this.case1);
            this.briefcaseButtons.Add(this.case2);
            this.briefcaseButtons.Add(this.case3);
            this.briefcaseButtons.Add(this.case4);
            this.briefcaseButtons.Add(this.case5);
            this.briefcaseButtons.Add(this.case6);
            this.briefcaseButtons.Add(this.case7);
            this.briefcaseButtons.Add(this.case8);
            this.briefcaseButtons.Add(this.case9);
            this.briefcaseButtons.Add(this.case10);
            this.briefcaseButtons.Add(this.case11);
            this.briefcaseButtons.Add(this.case12);
            this.briefcaseButtons.Add(this.case13);
            this.briefcaseButtons.Add(this.case14);
            this.briefcaseButtons.Add(this.case15);
            this.briefcaseButtons.Add(this.case16);
            this.briefcaseButtons.Add(this.case17);
            this.briefcaseButtons.Add(this.case18);
            this.briefcaseButtons.Add(this.case19);
            this.briefcaseButtons.Add(this.case20);
            this.briefcaseButtons.Add(this.case21);
            this.briefcaseButtons.Add(this.case22);
            this.briefcaseButtons.Add(this.case23);
            this.briefcaseButtons.Add(this.case24);
            this.briefcaseButtons.Add(this.case25);

            this.storeBriefCaseIndexInControlsTagProperty();
        }
        
        private void buildGameTypeButtonCollection()
        {
            this.gameTypeButtons.Clear();

            this.gameTypeButtons.Add(this.fiveRoundButton);
            this.gameTypeButtons.Add(this.sevenRoundButton);
            this.gameTypeButtons.Add(this.sevenRoundSyndicatedButton);
            this.gameTypeButtons.Add(this.tenRoundButton);
            this.gameTypeButtons.Add(this.tenRoundSyndicatedButton);

            storeGameTypeInControlsTagProperty();
        }

        private void buildBriefcaseRowCollection()
        {
            this.briefcaseButtonRows.Add(this.briefcaseRow0);
            this.briefcaseButtonRows.Add(this.briefcaseRow1);
            this.briefcaseButtonRows.Add(this.briefcaseRow2);
            this.briefcaseButtonRows.Add(this.briefcaseRow3);
            this.briefcaseButtonRows.Add(this.briefcaseRow4);
        }

        private void storeBriefCaseIndexInControlsTagProperty()
        {
            for (var i = 0; i < this.briefcaseButtons.Count; i++)
            {
                this.briefcaseButtons[i].Tag = i;
            }
        }

        private void storeGameTypeInControlsTagProperty()
        {
            for (var i = 0; i < this.gameTypeButtons.Count; i++)
            {
                this.gameTypeButtons[i].Tag = (GameType) i;
            }
        }

        private void briefcase_Click(object sender, RoutedEventArgs e)
        {
            var selectedBriefcase = (Button) sender;
            var briefcaseId = this.getBriefcaseID(selectedBriefcase);
            selectedBriefcase.Visibility = Visibility.Collapsed;

            if (this.gameManager.IsOnFinalRound())
            {
                handleFinalBriefcaseClick(briefcaseId);
            }
            else if (this.gameManager.HasFirstBriefcaseClaimed())
            {
                var prizeAmount = this.gameManager.RemoveBriefcaseFromPlay(briefcaseId);
                this.gameManager.BriefcasesRemainingInRound--;
                this.findAndGrayOutGameDollarLabel(prizeAmount);
                this.updateCurrentRoundInformation();
            }
            else
            {
                this.handleFirstBriefcaseClick(briefcaseId);
            }
        }

        private void gameTypeButton_Click(object sender, RoutedEventArgs e)
        {
            var gameTypeButton = (Button)sender;
            var gameType = this.getGameTypeFromButton(gameTypeButton);

            this.hideGameTypeButtons();
            this.showBriefcaseButtons();

            this.gameManager = new GameManager(gameType);
            if (this.gameManager.GameType == GameType.FiveRound)
            {
                this.setupFiveRoundGame();
            }
            else
            {
                this.setupSevenOrTenRoundGame();
            }
            this.setDollarAmountLabelValues(this.gameManager.GameType);
            this.displayGameTypeMessage();
        }

        private void setupFiveRoundGame()
        {
            this.hideUnusedBriefcaseButtons();
            this.hideUnusedDollarAmountLabels();

            var rowCounts = new int[] { 5, 4, 4, 5, 0 };
            this.placeBriefcaseButtons(rowCounts);
        }

        private void setupSevenOrTenRoundGame()
        {
            var rowCounts = new int[] { 6, 5, 5, 5, 5 };
            this.placeBriefcaseButtons(rowCounts);
        }

        private void displayGameTypeMessage()
        {
            switch (this.gameManager.GameType)
            {
                case GameType.FiveRound:
                    this.roundLabel.Text = "Welcome to Quickplay!";
                    break;
                case GameType.SevenRoundStandard:
                    this.roundLabel.Text = "Welcome to 7 Round!";
                    break;
                case GameType.SevenRoundSyndicated:
                    this.roundLabel.Text = "Welcome to 7 Round (Syndicated)!";
                    break;
                case GameType.TenRoundSyndicated:
                    this.roundLabel.Text = "Welcome to DonD (Syndicated)!";
                    break;
            }
        }

        private void hideUnusedBriefcaseButtons()
        {
            for (int i = this.gameManager.TotalBriefcases; i < this.briefcaseButtons.Count; ++i)
            {
                this.briefcaseButtons[i].Visibility = Visibility.Collapsed;
            }
        }

        private void hideUnusedDollarAmountLabels()
        {
            int[] indices = new int[] { 0, 1, 11, 12, 13, 14, 24, 25 };
            foreach (var index in indices)
            {
                this.dollarAmountLabels[index].Background = new SolidColorBrush(Colors.Black);
                this.dollarAmountLabels[index].Tag = SkipTag;
                if (this.dollarAmountLabels[index].Child is TextBlock prizeLabel)
                {
                    prizeLabel.Text = $"{-1:C0}";
                }
            }
        }

        private void placeBriefcaseButtons(int[] rowCounts)
        {
            this.removeBriefcaseButtonsFromParent();
            for (int rowIndex = 0, buttonIndex = 0; rowIndex < rowCounts.Length; ++rowIndex)
            {
                var currentRow = this.briefcaseButtonRows[rowIndex];

                for (var i = 0; i < rowCounts[rowIndex]; ++i, ++buttonIndex)
                {
                    currentRow.Children.Add(this.briefcaseButtons[buttonIndex]);
                }
            }
        }

        private void setDollarAmountLabelValues(GameType gameType)
        {
            //Todo Make this for efficient
            var prizeAmounts = PrizeManager.GetPrizesForGameType(gameType);

            for (int prizeIndex = 0, labelIndex = 0; prizeIndex < prizeAmounts.Length; ++prizeIndex, ++labelIndex)
            {
                var prizeAmount = prizeAmounts[prizeIndex];
                while (shouldSkipDollarAmountLabel(this.dollarAmountLabels[labelIndex]))
                {
                    ++labelIndex;
                }

                if (this.dollarAmountLabels[labelIndex].Child is TextBlock prizeLabel)
                {
                    prizeLabel.Text = $"{prizeAmount:C0}";
                }
            }
        }

        private void removeBriefcaseButtonsFromParent()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                if (briefcaseButton.Parent is StackPanel buttonPanel)
                {
                    buttonPanel.Children.Remove(briefcaseButton);
                }
            }
        }

        private void handleFirstBriefcaseClick(int briefcaseId)
        {
            this.gameManager.FirstBriefcaseId = briefcaseId;
            this.displayFirstBriefcaseChosen();
            this.updateCurrentRoundInformation();
        }

        private void handleFinalBriefcaseClick(int briefcaseId)
        {
            this.displayChosenBriefcase(briefcaseId);

            this.hideBriefcaseButtons();

            //Todo make this smaller
            int firstBriefcasePrizeAmount =
                this.gameManager.GetPrizeAmountFromBriefcaseId(this.gameManager.FirstBriefcaseId);
            int finalBriefcasePrizeAmount =
                this.gameManager.GetPrizeAmountFromBriefcaseId(this.gameManager.FinalBriefcaseId);

            this.findAndGrayOutGameDollarLabel(firstBriefcasePrizeAmount);
            this.findAndGrayOutGameDollarLabel(finalBriefcasePrizeAmount);
            
            promptToRestartGame();
        }

        private void findAndGrayOutGameDollarLabel(int amount)
        {
            foreach (var currDollarAmountLabel in this.dollarAmountLabels)
            {
                if (grayOutLabelIfMatchesDollarAmount(amount, currDollarAmountLabel))
                {
                    break;
                }
            }
        }

        private static bool grayOutLabelIfMatchesDollarAmount(int amount, Border currDollarAmountLabel)
        {
            var matched = false;

            if (currDollarAmountLabel.Visibility == Visibility.Collapsed)
            {
                return false;
            }

            if (currDollarAmountLabel.Child is TextBlock dollarTextBlock)
            {
                var labelAmount = int.Parse(dollarTextBlock.Text, NumberStyles.Currency);
                if (labelAmount == amount)
                {
                    currDollarAmountLabel.Background = new SolidColorBrush(Colors.Gray);
                    matched = true;
                }
            }

            return matched;
        }

        private int getBriefcaseID(Button selectedBriefCase)
        {
            return (int) selectedBriefCase.Tag;
        }

        private GameType getGameTypeFromButton(Button gameTypeButton)
        {
            return (GameType) gameTypeButton.Tag;
        }
        
        private void updateCurrentRoundInformation()
        {
            this.displayCurrentRoundInformation();

            if (this.gameManager.HasOpenedAllBriefcasesInRound())
            {
                this.setupEndOfRound();
            }

            if (this.gameManager.IsOnFinalRound())
            {
                this.setupFinalRound();
            }
        }

        private void setupFinalRound()
        {
            var firstBriefcaseButton = this.getButtonById(this.gameManager.FirstBriefcaseId);
            var lastBriefcaseButton = this.getLastBriefcase();
            this.gameManager.FinalBriefcaseId = this.getBriefcaseID(lastBriefcaseButton);
            this.hideBriefcaseButtons();

            placeLastTwoButtons(firstBriefcaseButton, lastBriefcaseButton);

            firstBriefcaseButton.Visibility = Visibility.Visible;
            lastBriefcaseButton.Visibility = Visibility.Visible;

            this.summaryOutput.Text =
                $"Offers: Min: {this.gameManager.MinOffer:C}; Max: {this.gameManager.MaxOffer:C}{Environment.NewLine}" +
                $"\tAvg. offer: {this.gameManager.AverageOffer:C}{Environment.NewLine}";

        }

        private void placeLastTwoButtons(Button firstBriefcaseButton, Button lastBriefcaseButton)
        {
            int firstBriefcaseId = getBriefcaseID(firstBriefcaseButton);
            int lastBriefcaseId = getBriefcaseID(lastBriefcaseButton);

            if (firstBriefcaseId < lastBriefcaseId)
            {
                this.moveBriefcaseButtonToCenterRow(firstBriefcaseButton);
                this.moveBriefcaseButtonToCenterRow(lastBriefcaseButton);
            }
            else
            {
                this.moveBriefcaseButtonToCenterRow(lastBriefcaseButton);
                this.moveBriefcaseButtonToCenterRow(firstBriefcaseButton);
            }
        }

        private void moveBriefcaseButtonToCenterRow(Button briefcaseButton)
        {
            if (briefcaseButton.Parent is StackPanel buttonPanel)
            {
                buttonPanel.Children.Remove(briefcaseButton);
                this.centerBriefcaseButtonRow.Children.Add(briefcaseButton);
            }
        }

        private Button getButtonById(int targetId)
        {
            foreach (var button in this.briefcaseButtons)
            {
                int buttonId = (int) button.Tag;
                if (buttonId == targetId)
                {
                    return button;
                }
            }

            return null;
        }

        private Button getLastBriefcase()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                if (briefcaseButton.Visibility == Visibility.Visible)
                {
                    return briefcaseButton;
                }
            }

            return null;
        }

        private void setupEndOfRound()
        {
            this.gameManager.HandleEndOfRound();
            this.disableBriefcaseButtons();
            this.displayBankerOfferSummary();
            this.showDealButtons();
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            var firstBriefcasePrizeAmount =
            this.gameManager.GetPrizeAmountFromBriefcaseId(this.gameManager.FirstBriefcaseId);
        
            this.summaryOutput.Text =
                $"Your case contained: {firstBriefcasePrizeAmount:C}{Environment.NewLine}" +
                $"Accepted offer: {this.gameManager.CurrentOffer:C}{Environment.NewLine}" +
                "GAME OVER";

            this.hideDealButtons();

            this.promptToRestartGame();
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {
            this.gameManager.MoveToNextRound();
            this.enableBriefcaseButtons();
            this.hideDealButtons();
            this.updateCurrentRoundInformation();
        }

        private void disableBriefcaseButtons()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                briefcaseButton.IsEnabled = false;
            }
        }

        private void enableBriefcaseButtons()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                briefcaseButton.IsEnabled = true;
            }
        }

        private void showDealButtons()
        {
            this.dealButton.Visibility = Visibility.Visible;
            this.noDealButton.Visibility = Visibility.Visible;
        }

        private void hideDealButtons()
        {
            this.dealButton.Visibility = Visibility.Collapsed;
            this.noDealButton.Visibility = Visibility.Collapsed;
        }

        private void showBriefcaseButtons()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                briefcaseButton.Visibility = Visibility.Visible;
            }
        }

        private void hideBriefcaseButtons()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                briefcaseButton.Visibility = Visibility.Collapsed;
            }
        }

        private void showGameTypeButtons()
        {
            foreach (var gameTypeButton in this.gameTypeButtons)
            {
                gameTypeButton.Visibility = Visibility.Visible;
            }
        }

        private void hideGameTypeButtons()
        {
            foreach (var gameTypeButton in this.gameTypeButtons)
            {
                gameTypeButton.Visibility = Visibility.Collapsed;
            }
        }

        private void displayChosenBriefcase(int briefcaseId)
        {
            int prizeAmount = this.gameManager.GetPrizeAmountFromBriefcaseId(briefcaseId);

            this.summaryOutput.Text =
                $"Congratulations, you won {prizeAmount:C}";
        }

        private void displayBankerOfferSummary()
        {
            this.summaryOutput.Text = 
                $"Offers: Min: {this.gameManager.MinOffer:C}; Max: {this.gameManager.MaxOffer:C}{Environment.NewLine}" +
                $"\tAvg. offer: {this.gameManager.AverageOffer:C}{Environment.NewLine}" +              
                $"Cur. offer: {this.gameManager.CurrentOffer:C}; Deal or No Deal?";
        }

        private void displayFirstBriefcaseChosen()
        {
            this.summaryOutput.Text = $"Your briefcase: {this.gameManager.FirstBriefcaseId}";
        }

        private void displayCurrentRoundInformation()
        {
            if (this.gameManager.IsOnFinalRound())
            {
                this.displayFinalRoundInformation();
            }
            else
            {
                int casesInRound = this.gameManager.GetBriefcasesToOpenInRound(this.gameManager.CurrentRound);
                string casesInRoundWord = getSingularPluralForm("case", casesInRound);
                string casesRemainingWord = getSingularPluralForm("case", this.gameManager.BriefcasesRemainingInRound);

                this.roundLabel.Text =
                    $"Round {this.gameManager.CurrentRound}: {casesInRound} {casesInRoundWord} to open.";
                this.casesToOpenLabel.Text = $"{this.gameManager.BriefcasesRemainingInRound} {casesRemainingWord} left to open.";
            }
        }

        private void displayFinalRoundInformation()
        {
            this.roundLabel.Text = "This is the final round.";
            this.casesToOpenLabel.Text = "Please select your final case.";
        }

        private async void promptToRestartGame()
        {
            ContentDialog restartDialog = new ContentDialog() {
                Title = "Restart game?",
                Content = $"Thank you for playing!{Environment.NewLine}" +
                          "Would you like to play again?",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No"
            };

            var dialogResult = await restartDialog.ShowAsync();

            if (dialogResult == ContentDialogResult.Primary)
            {
                this.resetGame();
            }
            else
            {
                Application.Current.Exit();
            }
        }

        private void resetGame()
        {
            this.roundLabel.Text = "Welcome to Deal or No Deal!";
            this.casesToOpenLabel.Text = "Please select your case.";
            this.summaryOutput.Text = String.Empty;

            this.resetDollarAmountLabelColors();
            if (this.gameManager.GameType == GameType.FiveRound)
            {
                this.showHiddenDollarAmountLabels();
            }
            this.setDollarAmountLabelValues(GameType.TenRoundStandard);

            this.enableBriefcaseButtons();
            this.hideBriefcaseButtons();
            this.showGameTypeButtons();
        }

        private void resetDollarAmountLabelColors()
        {
            foreach (var dollarAmountLabel in this.dollarAmountLabels)
            {
                dollarAmountLabel.Background = new SolidColorBrush(Colors.Yellow);
            }
        }

        private void showHiddenDollarAmountLabels()
        {
            foreach (var dollarLabel in this.dollarAmountLabels)
            {
                if (dollarLabel.Tag != null && dollarLabel.Tag.ToString() == SkipTag)
                {
                    dollarLabel.Tag = null;
                    dollarLabel.Background = new SolidColorBrush(Colors.Yellow);
                }
            }
        }

        private static string getSingularPluralForm(string item, int amount)
        {
            //Does not handle "es", but it's not necessary for the current needs of the project
            if (amount == 1)
            {
                return item;
            }
            return item + "s";
        }
        #endregion
    }
}