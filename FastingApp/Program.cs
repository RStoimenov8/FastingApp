class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the app
            FastingApp app = new FastingApp();

            // Start the app
            app.Start();
        }
    }

    class FastingApp
    {
        private DateTime fastStartTime;
        private DateTime fastEndTime;
        private TimeSpan fastingPeriod;
        private List<TimeSpan> completedFasts;
        private TimeSpan longestFast;
        private int longestStreak;
        private int currentStreak;

        public FastingApp()
        {
            completedFasts = new List<TimeSpan>();
            longestFast = TimeSpan.Zero;
            longestStreak = 0;
            currentStreak = 0;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Fasting App!");

            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Set fast start time");
                Console.WriteLine("2. Set fast end time");
                Console.WriteLine("3. Set fast reminder alarm");
                Console.WriteLine("4. View fasting stats");
                Console.WriteLine("5. View fasting goal tracking graph");
                Console.WriteLine("6. Select a fast");
                Console.WriteLine("7. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SetFastStartTime();
                        break;
                    case "2":
                        SetFastEndTime();
                        break;
                    case "3":
                        SetFastReminderAlarm();
                        break;
                    case "4":
                        ViewFastingStats();
                        break;
                    case "5":
                        ViewGoalTrackingGraph();
                        break;
                    case "6":
                        SelectFast();
                        break;
                    case "7":
                        Console.WriteLine("Thank you for using the Fasting App!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void SetFastStartTime()
        {
            Console.WriteLine("Enter the fast start time (e.g., 08:00 AM):");
            string startTimeString = Console.ReadLine();

            if (DateTime.TryParse(startTimeString, out DateTime startTime))
            {
                fastStartTime = startTime;
                Console.WriteLine("Fast start time set successfully.");
            }
            else
            {
                Console.WriteLine("Invalid time format. Please try again.");
            }
        }

        private void SetFastEndTime()
        {
            Console.WriteLine("Enter the fast end time (e.g., 12:00 PM):");
            string endTimeString = Console.ReadLine();

            if (DateTime.TryParse(endTimeString, out DateTime endTime))
            {
                fastEndTime = endTime;
                Console.WriteLine("Fast end time set successfully.");

                // Calculate fasting period
                fastingPeriod = fastEndTime - fastStartTime;

                // Update completed fasts
                completedFasts.Add(fastingPeriod);

                // Update longest fast
                if (fastingPeriod > longestFast)
                {
                    longestFast = fastingPeriod;
                }

                // Update streaks
                if (currentStreak == 0)
                {
                    // First completed fast
                    currentStreak = 1;
                    longestStreak = 1;
                }
                else
                {
                    currentStreak++;
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }
            else
            {
                Console.WriteLine("Invalid time format. Please try again.");
            }
        }

        private void SetFastReminderAlarm()
        {
             Console.WriteLine("Enter the time for the fast reminder alarm (e.g., 10:00 AM):");
             string alarmTimeString = Console.ReadLine();

             if (DateTime.TryParse(alarmTimeString, out DateTime alarmTime))
             {
                TimeSpan alarmSpan = alarmTime.TimeOfDay;
                // Set the reminder alarm logic here using the alarmSpan
                Console.WriteLine("Fast reminder alarm set successfully.");
             }
        else
        {
            Console.WriteLine("Invalid time format. Please try again.");
        }
    }

        private void ViewFastingStats()
        {
            Console.WriteLine("Fasting Stats:");
            Console.WriteLine("Completed fasts: " + completedFasts.Count);
            Console.WriteLine("7 day fast average: " + Calculate7DayFastAverage());
            Console.WriteLine("Longest fast: " + longestFast.TotalHours + " hours");
            Console.WriteLine("Longest streak: " + longestStreak + " days");
            Console.WriteLine("Current streak: " + currentStreak + " days");
        }

        private double Calculate7DayFastAverage()
        {
            if (completedFasts.Count == 0)
                return 0.0;

            double totalHours = 0.0;

            // Calculate the total fasting hours for the last 7 completed fasts
            int count = Math.Min(completedFasts.Count, 7);
            for (int i = completedFasts.Count - 1; i >= completedFasts.Count - count; i--)
            {
                totalHours += completedFasts[i].TotalHours;
            }

            return totalHours / count;
        }

        private void ViewGoalTrackingGraph()
        {
            Console.WriteLine("Goal Tracking Graph:");
            // Display the fasting goal tracking graph logic here
            Console.WriteLine("Not implemented yet.");
        }

        private void SelectFast()
        {
            Console.WriteLine("Select a fast:");
            Console.WriteLine("1. Circadian Rhythm");
            Console.WriteLine("2. 16:8");
            Console.WriteLine("3. 18:6");
            Console.WriteLine("4. 20:4");
            Console.WriteLine("5. 36-hour fast");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("You selected Circadian Rhythm fast.");
                    break;
                case "2":
                    Console.WriteLine("You selected 16:8 fast.");
                    break;
                case "3":
                    Console.WriteLine("You selected 18:6 fast.");
                    break;
                case "4":
                    Console.WriteLine("You selected 20:4 fast.");
                    break;
                case "5":
                    Console.WriteLine("You selected 36-hour fast.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

