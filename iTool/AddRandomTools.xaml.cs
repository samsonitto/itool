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
using System.Windows.Shapes;

namespace iTool
{
    /// <summary>
    /// Interaction logic for AddRandomTools.xaml
    /// </summary>
    public partial class AddRandomTools : Window
    {
        public AddRandomTools()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Do you really want to generate and add to database {txtToolAmount.Text} random tools?", "Add random tools to database", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Generate();
                lblInfo.Content = $"You have added {txtToolAmount.Text} random tools into database";
            }
            else
            {
                lblInfo.Content = $"You did not do shit";
            }
            
        }

        private void Generate()
        {
            List<int> userIDs = DB.GetUserIDsFromMysql();
            List<string> conditions = new List<string>() { "Poor", "Ok", "Good", "Pristine" };
            List<string> categories = new List<string>() { "Hionta", "Hitsauskoneet", "Juottaminen", "Käsityökalut", "Leikkaustyökalut", "Leikkuuterät", "Mittavälineet", "Paineilma", "Poranterät", "Työkalujen säilyttäminen", "Työpajan varustus", "Työstökoneet", "Sähkötyökalut" };
            List<string> toolNames = new List<string>() { "Saha", "Vasara", "Ruuvimeisseli", "Porakone", "Hiontaterä", "Kirves", "Miekka", "Työkaluboksi", "Pora", "Rautasaha", "Moottorisaha", "Ruoholeikkuri", "Jakoavain", "Pihdit", "Jeesusteippi", "Mittanauha", "Rakennuskynä", "Lapio", "Vatupassi", "Lumikola", "Laasta", "Pensseli"};
            float[] f1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            float[] f2 = { 0.1F, 0.2F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 0.9F };
            List<int> toolCategoryIDs = DB.GetToolCategoryIDs();
            Random rand = new Random();

            for (int i = 0; i < int.Parse(txtToolAmount.Text) ; i++)
            {
                int userID = userIDs[rand.Next(userIDs.Count)];
                string tName = toolNames[rand.Next(toolNames.Count)];
                string tCondition = conditions[rand.Next(conditions.Count)];
                int tCategory = toolCategoryIDs[rand.Next(toolCategoryIDs.Count)];
                float tPrice = f1[rand.Next(f1.Length)] + f2[rand.Next(f2.Length)];
                string tDescription = LoremIpsum(3,8,1,2,1);
                string toolImage = "";
                var p = tPrice;
                DB.AddAToolToMysql(tName,tCategory,tDescription,userID,tCondition,p,toolImage);
            }
        }

        static string LoremIpsum(int minWords, int maxWords, int minSentences, int maxSentences, int numParagraphs)
        {

            var words = new[] { "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat" };

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                //result.Append("<p>");
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                //result.Append("</p>");
            }

            return result.ToString();
        }
    }
}
