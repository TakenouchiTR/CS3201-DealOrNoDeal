using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.Foundation;
using Windows.UI;
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

        /// <summary>
        ///     The application window height
        /// </summary>
        public const int ApplicationHeight = 500;

        /// <summary>
        ///     The application window width
        /// </summary>
        public const int ApplicationWidth = 500;

        private readonly GameManager gameManager;
        private IList<Button> briefcaseButtons;
        private IList<Border> dollarAmountLabels;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DealOrNoDealPage" /> class.
        /// </summary>
        public DealOrNoDealPage()
        {
            this.InitializeComponent();
            this.initializeUiDataAndControls();
            this.gameManager = new GameManager();
        }

        #endregion

        #region Methods

        private void initializeUiDataAndControls()
        {
            this.setPageSize();

            this.briefcaseButtons = new List<Button>();
            this.dollarAmountLabels = new List<Border>();
            this.buildBriefcaseButtonCollection();
            this.buildDollarAmountLabelCollection();
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

        private void storeBriefCaseIndexInControlsTagProperty()
        {
            for (var i = 0; i < this.briefcaseButtons.Count; i++)
            {
                this.briefcaseButtons[i].Tag = i;
            }
        }

        private void briefcase_Click(object sender, RoutedEventArgs e)
        {
            var selectedBriefcase = (Button) sender;
            var briefcaseId = this.getBriefcaseID(selectedBriefcase);
            selectedBriefcase.Visibility = Visibility.Collapsed;

            if (this.gameManager.HasFirstBriefcaseClaimed())
            {
                this.gameManager.FirstBriefcaseId = briefcaseId;
                this.displayPersonalBriefcase();
            }
            else
            {
                this.handleFirstBriefcaseClick(briefcaseId);
            }

            this.updateCurrentRoundInformation();
        }

        private void handleFirstBriefcaseClick(int briefcaseId)
        {
            var prizeAmount = this.gameManager.RemoveBriefcaseFromPlay(briefcaseId);
            this.gameManager.BriefcasesRemainingInRound--;
            this.findAndGrayOutGameDollarLabel(prizeAmount);
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
            var lastBriefcaseButton = this.getLastBriefcase();
            this.hideBriefcaseButtons();
            this.showDealButtons();

            this.gameManager.FinalBriefcaseId = this.getBriefcaseID(lastBriefcaseButton);

            this.dealButton.Content = $"Open {this.gameManager.FirstBriefcaseNumber}";
            this.noDealButton.Content = $"Open {this.gameManager.FinalBriefcaseNumber}";
            this.summaryOutput.Text = $"Max. offer: {this.gameManager.MaxOffer:C} | " +
                                      $"Min. offer:  {this.gameManager.MinOffer:C}";
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
            this.updateBankerOffers();
            this.disableBriefcaseButtons();
            this.displayBankerOfferSummary();
            this.showDealButtons();
        }

        private void updateBankerOffers()
        {
            var offer = this.gameManager.GetOffer();
            this.gameManager.CurrentOffer = offer;
            this.gameManager.MaxOffer = Math.Max(offer, this.gameManager.MaxOffer);
            this.gameManager.MinOffer = Math.Min(offer, this.gameManager.MinOffer);
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            var firstBriefcasePrizeAmount =
                this.gameManager.GetPrizeAmountFromBriefcaseId(this.gameManager.FirstBriefcaseId);

            if (this.gameManager.IsOnFinalRound())
            {
                this.summaryOutput.Text =
                    $"Congratulations, you won {firstBriefcasePrizeAmount:C}";
            }
            else
            {
                this.summaryOutput.Text =
                    $"Your case contained: {firstBriefcasePrizeAmount:C}{Environment.NewLine}" +
                    $"Accepted offer: {this.gameManager.CurrentOffer:C}{Environment.NewLine}" +
                    "GAME OVER";
            }

            this.hideDealButtons();
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.gameManager.IsOnFinalRound())
            {
                var prizeAmount = this.gameManager.GetPrizeAmountFromBriefcaseId(this.gameManager.FinalBriefcaseId);
                this.summaryOutput.Text =
                    $"Congratulations, you won {prizeAmount:C}";
                this.hideDealButtons();
            }
            else
            {
                this.gameManager.MoveToNextRound();
                this.enableBriefcaseButtons();
                this.hideDealButtons();
                this.updateCurrentRoundInformation();
            }
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

        private void hideBriefcaseButtons()
        {
            foreach (var briefcaseButton in this.briefcaseButtons)
            {
                briefcaseButton.Visibility = Visibility.Collapsed;
            }
        }

        private void displayBankerOfferSummary()
        {
            this.summaryOutput.Text = $"Max. offer: {this.gameManager.MaxOffer:C} | " +
                                      $"Min. offer:  {this.gameManager.MinOffer:C}{Environment.NewLine}" +
                                      $"Current offer: {this.gameManager.CurrentOffer:C}{Environment.NewLine}" +
                                      "Deal or No Deal?";
        }

        private void displayPersonalBriefcase()
        {
            this.summaryOutput.Text = $"Your briefcase: {this.gameManager.FirstBriefcaseId}";
        }

        private void displayCurrentRoundInformation()
        {
            if (this.gameManager.IsOnFinalRound())
            {
                this.roundLabel.Text = "This is the final round.";
                this.casesToOpenLabel.Text = "Please select a case below.";
            }
            else
            {
                int casesInRound = GameManager.CalculateBriefcasesToOpenInRound(this.gameManager.CurrentRound);
                string casesInRoundWord = getSingularPluralForm("case", casesInRound);
                string casesRemainingWord = getSingularPluralForm("case", this.gameManager.BriefcasesRemainingInRound);

                this.roundLabel.Text =
                    $"Round {this.gameManager.CurrentRound}: {casesInRound} {casesInRoundWord} to open.";
                this.casesToOpenLabel.Text = $"{this.gameManager.BriefcasesRemainingInRound} {casesRemainingWord} left to open.";
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