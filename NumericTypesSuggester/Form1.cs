using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltimateCSharpMasterClass;
using ValidateNumberEtc;


namespace NumericTypesSuggester
{
    public partial class Form1 : Form
    {
        ITypesSuggester Suggester { get; } = new NumericsTypeSuggester();

        public event EventHandler EventHandler;


        private List<KeyValuePair<Type, MaxMinTypeDescription>>? SuggestedTypesUndoLastChangeCache { get; set; } = new List<KeyValuePair<Type, MaxMinTypeDescription>>();

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_EventHandler(object sender, int e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void OnMinTextChanged(object sender, EventArgs e)
        {

        }

        public bool TextIsValidated(string senderText) //få in elementet genom sender! slipp dubbla condition checks
        {
            BigInteger parsedmax;
            BigInteger parsedmin;

            if (BigInteger.TryParse(senderText, out parsedmax) == false)
            {
                if (MaxTextBox.Text != "" && MinTextBox.Text != "")
                {
                    if (!senderText.Contains("-") && senderText[0] == '-')
                    {
                        return true;
                    }
                }
                return false;
            }
            if(MaxTextBox.Text == "" || MaxTextBox.Text == "")
            {
                return false;
            }
            if (BigInteger.Parse(MaxTextBox.Text) > BigInteger.Parse(MinTextBox.Text))
            {
                return true;
            }

            return false;
            //if (BigInteger.TryParse(MaxTextBox.Text, out parsedmax) == false || BigInteger.TryParse(MaxTextBox.Text, out parsedmin) == false)
            //{
            //    if (MaxTextBox.Text != "")
            //    {
            //        if (!MaxTextBox.Text.Contains("-") && MaxTextBox.Text[0] == '-')
            //        {
            //            return true;
            //        }
            //    }
            //    return false;
            //}
            //if (BigInteger.Parse(MaxTextBox.Text) > BigInteger.Parse(MinTextBox.Text))
            //{
            //    return true;
            //}

            //return false;
        }



        private void Preccise_CheckedChange(object sender, EventArgs e)
        {

        }

        private void GetResult()
        {

            BigInteger parsedvaluemin;
            BigInteger parsedvaluemax;
            string uservaluemin = MinTextBox.Text;
            string uservaluemax = MaxTextBox.Text;

            //methods needed for assignment 
            BigInteger.TryParse(uservaluemin, out parsedvaluemin);
            BigInteger.TryParse(uservaluemax, out parsedvaluemax);

            label7.Text = Suggester.FindSmallestNumericType(parsedvaluemin, parsedvaluemax, checkOnlyIntegral.Checked, checkIsPrecise.Checked);

        }

       
        private void OnFormElementInteraction(object sender, EventArgs e)
        {
            GetResult();
        }
          

        private void OnFormElementInteraction(object sender, KeyPressEventArgs e)
        {
            if (!TextIsValidated(((TextBox)sender).Text))
            {
                MinTextBox.BackColor = Color.Red;
                label7.Text = "not enough data";                //SuggestedType.Text = "not enough data";
            }
            
            
            GetResult();

        }
    }
}