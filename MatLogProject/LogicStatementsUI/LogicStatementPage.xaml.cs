using LogicStatements;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LogicStatementsUI
{
    /// <summary>
    /// Логика взаимодействия для LogicStatementPage.xaml
    /// </summary>
    public partial class LogicStatementPage : Page
    {

        private FormulaChecker Checker = new FormulaChecker();

        public LogicStatementPage()
        {
            InitializeComponent();
        }

        private void GetAxioms(object sender, EventArgs args)
        {
            var formulas = GetFormulas();
            if (formulas == null)
                return;
            var axioms = (from f in formulas select new Axiom(f.ToString())).ToArray();

            Checker.UpdateAxioms(axioms);

            axiomsTextBox.Text = string.Empty;
            var num = 1;
            foreach (var axiom in axioms)
            {
                axiomsTextBox.Text += $"{num.ToString()}. " + axiom + Environment.NewLine;
                num++;
            }
           
        }

        private void GetHypotheses(object sender, EventArgs args)
        {
            var hypotheses = GetFormulas();
            if (hypotheses == null)
                return;

            Checker.UpdateHypotheses(hypotheses.ToArray());

            hypothesesTextBox.Text = string.Empty;
            var num = 1;
            foreach (var hypothese in hypotheses)
            {
                hypothesesTextBox.Text += $"{num.ToString()}. " + hypothese + Environment.NewLine;
                num++;
            }
        }

        private void GetProof(object sender,EventArgs args)
        {
            if(!Checker.IsAxiomOrHypothesesWasEnter())
            {
                MessageBox.Show("Введите аксиомы или гипотезы!");
                return;
            }

            var proof = GetFormulas();
            if (proof == null)
                return;

            outPutTextBox.Text = Checker.CheckWay(proof.ToArray()).ToString();
            saveBtn.Visibility = Visibility.Visible;           
        }

        private List<Formula> GetFormulas()
        {           
            var dialog = new OpenFileDialog() 
            { 
                InitialDirectory = Directory.GetCurrentDirectory()
            };
            dialog.Filter = "TXT|*.txt";
            if (dialog.ShowDialog() == true)
            {
                using (var stream = new StreamReader(dialog.FileName))
                {
                    var formulas = new List<Formula>();
                    while (!stream.EndOfStream)
                    {
                        try
                        {
                            var str = stream.ReadLine();
                            var currentAxiom = new Formula(str);
                            formulas.Add(currentAxiom);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(ex.Message + " " + (formulas.Count + 1));
                            return null;

                        }
                    }

                    if (formulas.Count == 0)
                    {
                        MessageBox.Show("Формулы не  найдены.");
                        return null;
                    }
                    saveBtn.Visibility = Visibility.Hidden;
                    return formulas;
                }
            }
            return null;
        }

        private void Save(object sender, EventArgs args)
        {
            var dialog = new SaveFileDialog()
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                CreatePrompt = true,
                OverwritePrompt = true

            };
            dialog.Filter = "TXT|*.txt";
            if (dialog.ShowDialog() == true)
            {
                using (var stream = new StreamWriter(dialog.FileName))
                {
                    stream.Write(outPutTextBox.Text);
                }
            }
        }
    }
}
