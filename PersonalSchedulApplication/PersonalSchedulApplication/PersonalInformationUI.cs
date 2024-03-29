﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalSchedulApplication
{
    public partial class PersonalInformationUI : Form
    {
        public PersonalInformationUI()
        {
            InitializeComponent();
        }

        Task aTask = new Task();
        private void saveButton_Click(object sender, EventArgs e)
        {
           

            aTask.Title = titleTextBox.Text;
            aTask.StartTime = Convert.ToDateTime(startTimeTextBox.Text);
            aTask.EndTime = Convert.ToDateTime(endTimeTextBox.Text);

            MessageBox.Show(aTask.SaveInDatabase());


            






        }

        

        private void PersonalInformationUI_Load(object sender, EventArgs e)
        {
            
            
            todayLebel.Text = System.DateTime.Now.ToString();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            listOfTask.Items.Clear();
            foreach (var task in aTask.getData())
            {
                listOfTask.Items.Add(task.Title+"--"+task.StartTime+"-to-"+task.EndTime);
                
            }



        }
    }
}
