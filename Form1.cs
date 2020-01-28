using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace VPserialize
{
    public partial class Form1 : Form
    {
        [Serializable]
        public class employee
        {
            private string fname,lname;
            private DateTime date;
            private string dept;
            private int salary;

            public string EmpName
            {
                set { fname = value; }
                get { return fname; }
            }
            public string EmpLName
            {
                set { lname = value; }
                get { return lname; }
            }
            public DateTime EmpDOB
            {
                set { date = value; }
                get { return date; }
            }
            public int EmpSalary
            {
                set { salary = value; }
                get { return salary; }
            }
           
            public string EmpDept
            {
                set { dept = value; }
                get { return dept; }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSer_Click(object sender, EventArgs e)
        {
            employee emp = new employee { EmpName = tbFname.Text,
                EmpLName=tbLname.Text,
                EmpDOB = dpDOB.Value, 
                EmpDept = tbDept.Text, 
                EmpSalary = Convert.ToInt32(tbSal.Text) };

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream("employee.binary", FileMode.Create, FileAccess.Write);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, emp);
                    lblSInfo.Text = "Object Serialized";
                    
                }
            }

            catch
            {
                lblSInfo.Text = "An error has occured";
            }

        }

        private void btnDeser_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsin = new FileStream("employee.binary", FileMode.Open, FileAccess.Read);
            try
            {
                using (fsin)
                {
                    emp = (employee)bf.Deserialize(fsin);
                    lblSInfo.Text = "Object Deserialized";
                    rtbInfo.Text=""+emp.EmpName+" "+emp.EmpLName+"\n"+emp.EmpDOB+" \n"+emp.EmpDept+" \n"+emp.EmpSalary.ToString()+"";
                    tbFname.Text = "";
                    tbLname.Text ="";
                    tbDept.Text = "";
                    tbSal.Text = "";
                }

            }

            catch
            {
                lblSInfo.Text = "An error has occured";

            }

        }
    }
}
