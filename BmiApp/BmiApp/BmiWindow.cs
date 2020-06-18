using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bmi
{
    public partial class BmiWindow : Form
    {
        public BmiWindow()
        {
            InitializeComponent();
            doUpdate();
        }

        private void dLength_TextChanged(object sender, EventArgs e)
        {
            doUpdate();
        }

        private void dWeight_TextChanged(object sender, EventArgs e)
        {
            doUpdate();
        }

        private void doUpdate()
        {
            if (dLength.Text.Trim() == "")
            {
                dDescription.Text = "Ingen längd";
                return;
            }
            double length;
            if (false == double.TryParse(dLength.Text, out length))
            {
                dDescription.Text = "Inmatad läng är inte en siffra";
                return;
            }

            if (dWeight.Text.Trim() == "")
            {
                listWeight(length);
            }
            else
            {
                double weight;
                if (false == double.TryParse(dWeight.Text.Trim(), out weight))
                {
                    dDescription.Text = "Vikt är inte en siffra";
                    return;
                }

                if (dAge.Text.Trim() == "")
                {
                    displayBmi(length, weight);

                }
                else
                {
                    displayEnergy(length, weight);
                }
            }
        }

        private void displayEnergy(double length, double weight)
        {
            double age;
            if (false == double.TryParse(dAge.Text.Trim(), out age))
            {
                dDescription.Text = "Ålder är inte en siffra";
                return;
            }

            double energyrest = dMale.Checked
                ? 66.5 + (13.75 * weight) + (5.003 * length) - (6.775 * age)
                : 655.1 + (9.563 * weight) + (1.850 * length) - (4.676 * age);
            double energy = energyrest * (dActivity.Value / 100.0);
            dDescription.Text = "Enerrgiförbrukning = " + s(energy);
        }

        private void displayBmi(double length, double weight)
        {
            double lim = length / 100;
            double lims = lim * lim;
            double bmi = weight / lims;
            dDescription.Text = "Bmi = " + s(bmi) + Environment.NewLine + classifyBmi(bmi);
        }

        private string classifyBmi(double bmi)
        {
            if( bmi < 17.50 ) return "Undervikt";
            if( bmi < 18.50 ) return "Lite Undervikt";
            if( bmi < 24.99 ) return "Normalvikt";
            if (bmi < 29.99) return "Övervikt";
            return "Fetma";
        }

        private static string nl = Environment.NewLine;

        private void listWeight(double length)
        {
            double lim = length / 100;
            double lims = lim * lim;
            
            
            dDescription.Text = "Undervikt: mindre än " + s(17.50 * lims) + nl
             + "Lite Undervikt: mindre än " + s(18.50 * lims) + nl
             + "Normalvikt: " + s(18.50 * lims) + "–" + s(24.99 * lims) + nl
             + "Övervikt: " + s(25.00 * lims) + "–" + s(lims * 29.99) + nl
             + "Fetma: Mer än " + s(lims * 30.00);
        }

        private string s(double p)
        {
            return String.Format("{0:0.0}", p);
        }

        private void dMale_CheckedChanged(object sender, EventArgs e)
        {
            doUpdate();
        }

        private void dActivity_ValueChanged(object sender, EventArgs e)
        {
            doUpdate();
        }

        private void dAge_TextChanged(object sender, EventArgs e)
        {
            doUpdate();
        }
    }
}
