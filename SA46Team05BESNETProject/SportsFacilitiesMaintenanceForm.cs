using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA46Team05BESNETProject
{
    public partial class SportsFacilitiesMaintenanceForm : Form
    {
        SA46Team05BESNETProjectEntities context = new SA46Team05BESNETProjectEntities();
        BindingSource slotAvailabilityBasket = new BindingSource(); // 8 objects

        public SportsFacilitiesMaintenanceForm()
        {
            InitializeComponent();
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            TomorrowDateLabel.Text = tomorrow.ToString("dd/MM/yyyy");

            FacilitiesDataGridView.AutoGenerateColumns = false;
            FacilitiesDataGridView.DataSource = slotAvailabilityBasket; 
        }

        //List<string> facilityIDcomboboxItems = new List<string>();
        
        private void SportsFacilitiesMaintenanceForm_Load(object sender, EventArgs e)
        {
            //facilityIDcomboboxItems = FacilityIDComboBox.Items;
            /*
            facilityIDcomboboxItems.Add("T-1");
            facilityIDcomboboxItems.Add("T-2");
            facilityIDcomboboxItems.Add("T-3");
            facilityIDcomboboxItems.Add("T-4");
            facilityIDcomboboxItems.Add("B-1");
            facilityIDcomboboxItems.Add("B-2");
            facilityIDcomboboxItems.Add("B-3");
            facilityIDcomboboxItems.Add("B-4");
            facilityIDcomboboxItems.Add("TT-1");
            facilityIDcomboboxItems.Add("TT-2");
            facilityIDcomboboxItems.Add("TT-3");
            facilityIDcomboboxItems.Add("TT-4");
            facilityIDcomboboxItems.Add("BB-1");
            facilityIDcomboboxItems.Add("BB-2");
            facilityIDcomboboxItems.Add("BB-3");
            facilityIDcomboboxItems.Add("BB-4"); */

        }

        private void ActivityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FacilityIDComboBox.Items = facilityIDcomboboxItems;
            /*
            if (ActivityComboBox.Text=="Tennis")
            {
                FacilityIDComboBox.Items.Remove("B-1");
            }*/
        }

        private void CheckAvailabilityButton_Click(object sender, EventArgs e)
        {
            string s = FacilityIDComboBox.Text; 
            //FacilitiesDataGridView.DataSource = context.Availabilities.Where(x=>x.FacilityID==s).ToList();
            Availability a = context.Availabilities.First(x => x.FacilityID == s);
            //a.Slot1 =? "0900-1000";
            //??List < AvailabilityTranspose > eightSlots = new List<AvailabilityTranspose>();
            //Instantiate 8 SlotAvailability objects.
            SlotAvailability slot1 = new SlotAvailability("09:00-10:00"); slotAvailabilityBasket.Add(slot1);
            SlotAvailability slot2 = new SlotAvailability("10:00-11:00"); slotAvailabilityBasket.Add(slot2);
            SlotAvailability slot3 = new SlotAvailability("11:00-12:00"); slotAvailabilityBasket.Add(slot3);
            SlotAvailability slot4 = new SlotAvailability("12:00-13:00"); slotAvailabilityBasket.Add(slot4);
            SlotAvailability slot5 = new SlotAvailability("13:00-14:00"); slotAvailabilityBasket.Add(slot5);
            SlotAvailability slot6 = new SlotAvailability("14:00-15:00"); slotAvailabilityBasket.Add(slot6);
            SlotAvailability slot7 = new SlotAvailability("15:00-16:00"); slotAvailabilityBasket.Add(slot7);
            SlotAvailability slot8 = new SlotAvailability("16:00-17:00"); slotAvailabilityBasket.Add(slot8);
            //Get Availibility record from Avaibilities table
            slot1.IsAvailable = a.Slot1; // flag in Avaibilities table should be boolean.
            slot2.IsAvailable = a.Slot2;
            slot3.IsAvailable = a.Slot3;
            slot4.IsAvailable = a.Slot4;
            slot5.IsAvailable = a.Slot5;
            slot6.IsAvailable = a.Slot6;
            slot7.IsAvailable = a.Slot7;
            slot8.IsAvailable = a.Slot8;
        }

        class SlotAvailability
        {
            string slotNumber; //consider type Enumerations
            int? isAvailable;

            public SlotAvailability(string slot)
            {
                slotNumber = slot;
                isAvailable = 1; //1 for available, 0 for not available
            }

            public string SlotNumber
            {
                get { return slotNumber; }
            }

            public int? IsAvailable
            {
                get { return isAvailable; }
                set { isAvailable = value; }
            }
        }

        private void FacilitiesDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*doesnot work
            if (FacilitiesDataGridView.Columns[e.ColumnIndex].Name == "Availability" && e.RowIndex > -1)
            {
                DataGridViewCell cell = FacilitiesDataGridView.Rows[e.RowIndex].Cells["Availability"];
                if (cell.Value.Equals(1))
                    cell.Value = 0;
                else
                    cell.Value = 1;
            }*/
        }

        private void ChangeAvailabilityStatusButton_Click(object sender, EventArgs e)
        {
            string s = FacilitiesDataGridView.SelectedRows[0].Cells["Availability"].Value.ToString();
            if (s == "1")
            {
                FacilitiesDataGridView.SelectedRows[0].Cells["Availability"].Value = 0;
            }
            else
            {
                FacilitiesDataGridView.SelectedRows[0].Cells["Availability"].Value = 1;
            }
        }

        private void UpdateAvailiabilityButton_Click(object sender, EventArgs e)
        {
            string s = FacilityIDComboBox.Text;
            Availability a = context.Availabilities.First(x => x.FacilityID == s);
            a.Slot1 = (int)FacilitiesDataGridView.Rows[0].Cells["Availability"].Value;
            a.Slot2 = (int)FacilitiesDataGridView.Rows[1].Cells["Availability"].Value;
            a.Slot3 = (int)FacilitiesDataGridView.Rows[2].Cells["Availability"].Value;
            a.Slot4 = (int)FacilitiesDataGridView.Rows[3].Cells["Availability"].Value;
            a.Slot5 = (int)FacilitiesDataGridView.Rows[4].Cells["Availability"].Value;
            a.Slot6 = (int)FacilitiesDataGridView.Rows[5].Cells["Availability"].Value;
            a.Slot7 = (int)FacilitiesDataGridView.Rows[6].Cells["Availability"].Value;
            a.Slot8 = (int)FacilitiesDataGridView.Rows[7].Cells["Availability"].Value;

            context.SaveChanges();
        }
    }
}
