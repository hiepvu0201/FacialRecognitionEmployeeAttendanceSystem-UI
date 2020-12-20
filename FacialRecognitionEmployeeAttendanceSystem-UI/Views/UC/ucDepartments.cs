using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacialRecognitionEmployeeAttendanceSystem_UI.Repository;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC
{
    public partial class ucDepartments : UserControl
    {
        ShiftsRepository _shiftsRepository = new ShiftsRepository();
        public ucDepartments()
        {
            InitializeComponent();
        }

        private void ucDepartments_Load(object sender, EventArgs e)
        {
            LoadShiftComboBoxAsysnc();
        }

        public async Task LoadShiftComboBoxAsysnc()
        {
            List<Shifts> listShift = await _shiftsRepository.GetList();
            foreach (Shifts item in listShift)
            {
                cbbShift.Items.Add(item.id + "." + item.shiftName);
            }
        }
    }
}
