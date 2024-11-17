namespace HorseRacingGame
{
    public partial class Form1 : Form
    {
        private Random random; // generate Random Number for animal steps
        private int finishLinex; // X-cordinate of finish Line
        private List<string> finishhOrder;// list to store animal name in order they finished the race
        private List<PictureBox> pictureBoxes; // store animal boxes that show animals
        private List<string> finishedAnimals; // List to keep track of animals who have completed


        public Form1()
        {
            InitializeComponent();
            btnStart.Click += btnStart_Click;// Event handler for Start button click
            timer1.Tick += timer1_Tick;// Event handler for timer tick event
            finishhOrder = new List<string>();
            random = new Random();
            pictureBoxes = new List<PictureBox> { Buffelo, Chimpanzi, Lion };// List of picture boxes representing the animals
            finishedAnimals = new List<string>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            finishLinex = label2.Left; // set finish line position according label2 position
            label1.Text = "Animal Racing"; // show text when we run that program
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Reset all animals' positions to the starting point
            foreach (var animal in pictureBoxes) 
            {
                animal.Left = 14; 
            }

            label1.Text = "Race is ON...!";
            finishhOrder.Clear(); // clear finish order list
            timer1.Start(); // start Timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateLeadingAnimal(); // Update Leading Animal's Position

            foreach(var animal in pictureBoxes)
            {
                if (animal == null) continue; // Check animal is not null

                int step = random.Next(5, 30); // generate animal random steps
                animal.Left += step;

                // Check animal.Name is not null and check for finish line crossing
                if (animal.Left >= finishLinex && !finishedAnimals.Contains(animal.Name) && !string.IsNullOrEmpty(animal.Name))
                {
                    finishhOrder.Add(animal.Name); // Add to finish order
                    finishedAnimals.Add(animal.Name); // Add to finished animals list

                    // Check if the race is finished or if it is a tie
                    if (finishedAnimals.Count > 1)
                    {
                        // If two or more animals have finished at the same time, it's a tie
                        RaceFinishedTie(); // Call this method when Race is Tie
                        return;
                    }
                    else
                    {
                        // Only one animal finished, normal race finish
                        RaceFinished(animal); // Call this method when race is Finished
                        return;
                    }
                }

            }

        }

        private void UpdateLeadingAnimal()
        {
            PictureBox leadingAnimal = null; // Create variable to store the leading animal
            int maxPosition = 0; // Create variable to store the maximum position

            foreach (var animal in pictureBoxes)
            {
                if(finishhOrder.Contains(animal.Name))  // Skip animals that have already finished
                    continue;

                // if current animal position is greater than maxPosition then update the leader
                if (animal.Left > maxPosition)
                {
                    maxPosition = animal.Left;
                    leadingAnimal = animal; 
                }
            }

            //if leading animal is found , so label is updated with leading animal
            if (leadingAnimal != null)
            {
                label1.Text = "Leading Animal: " + leadingAnimal.Name; 
            }
        }

        private void RaceFinishedTie()
        {
            timer1.Stop(); // Stop the race
            MessageBox.Show("The race is a tie!", "Race Result"); // Show the tie message
            label1.Text = "Race is a Tie!"; // Update label with tie message
        }

        private void RaceFinished(PictureBox winner)
        {
            timer1.Stop();// Stop the race
            MessageBox.Show($"{winner.Name} wins this Race!", "Result of Race");// Show the Winnner Animal message on Message Box
            label1.Text = winner.Name + "is the Winner";// Update label with winner Animal Name message
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {

            timer1.Stop();// Stop the Timer

            //// Reset all animals' positions to the starting point
            foreach (var animal in pictureBoxes)
            {
                animal.Left = 14;
            }
            label1.Text = "Click Strat Button to Begin Race"; // Update the Label when click on Reset Button
            finishhOrder.Clear();// Clear the finish order list
            finishedAnimals.Clear();  // Clear the finished animals list
        }

       
    }
}
