using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    /*
     * Calculate pay amount based on hours worked and hourly rate.
     * 37.5 hours constitute full week work.
     * Employees who works more that full week gets paid “time and  a half” 
     * for overtime hours
     * Author: Jolanta
     * When: March 2023
     */
    public partial class Form1 : Form
    {
        // class-level declarations
        const decimal FULL_WEEK = 37.5m;
        const decimal OT_RATE = 1.5m;
        public Form1()
        {
            InitializeComponent();
        }

        // at the start, hide panel with overtime controls
        private void Form1_Load(object sender, EventArgs e)
        {
            pnlOvertime.Visible = false;
        }

        // calculate pay amount based on hours worked and hourly pay
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // local declarations
            decimal hours;      // input - hours worked
            decimal rate;       // input - hourly rate
            decimal regularPay; // straight time pay
            decimal otPay;      // overtime pay
            decimal payAmount;  // output - total pay amount

            // get hours and rate
            hours = Convert.ToDecimal(txtHours.Text);
            rate = Convert.ToDecimal(txtRate.Text);

            // calculate pay amount
            if (hours <= FULL_WEEK) // no overtime
            {
                regularPay = hours * rate;
                otPay = 0;        
                pnlOvertime.Visible = false;
            }
            else // hours > FULL_WEEK - overtime applies
            {
                regularPay = FULL_WEEK * rate; 
                otPay = (hours - FULL_WEEK) * rate * OT_RATE;    
                pnlOvertime.Visible = true;
            }
            payAmount = regularPay + otPay;

            // display results
            txtRegular.Text = regularPay.ToString("c");
            txtOvertime.Text = otPay.ToString("c");
            txtPay.Text = payAmount.ToString("c");
        }

        
    }
}
