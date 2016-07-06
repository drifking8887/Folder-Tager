using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.IO;


namespace FolderTagCreator
{
    public class Helper
    {
        public static String dateFormat = "M/d/yyyy";
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, uint wMsg, uint wParam, uint lParam);

        public static void Save(Exception msg)
        {
            MessageBox.Show(msg.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Update(Exception msg)
        {
            MessageBox.Show(msg.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Delete(Exception msg)
        {
            MessageBox.Show(msg.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Nodata(Exception msg)
        {
            MessageBox.Show(msg.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static string DeleteRec
        {
            get { return "Are you sure want to delete this record ?"; }
        }

        public static string Edit
        {
            get { return "Are you sure, you want to edit this"; }
        }

        public static string UpdateRec
        {
            get { return "Record updated successfully"; }
        }

        public static string UpdateRecq
        {
            get { return "Are you sure want to Edit this record?"; }
        }

        public static string CancelRec
        {
            get { return "Are you sure, you want to cancel this record"; }
        }

        public static string SaveRec
        {
            get { return "Record(s) saved successfully"; }
        }



        public static IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
        //------------------------Clear Labels -------------------------------------------
        public static void ClearLabel(params Label[] LabelArray)
        {
            try
            {
                foreach (Label label in LabelArray)
                    label.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public static void showError(Exception msg)
        {
            MessageBox.Show(msg.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool showConfirm(string msg)
        {
            return MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
        //------------------------Text Boxes----------------------------------------
        #region TextBox Controler
        public static void EnableTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                {
                    TBox.ReadOnly = false;
                    if (TBox.Enabled == false)
                    {
                        TBox.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void DisableTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void EnabledEnableTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DisableDisableTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void LockTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UnLockTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SetTextBoxToZero(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SetLableToZero(params Label[] lableArray)
        {
            try
            {
                foreach (Label LbText in lableArray)
                    LbText.Text = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //------------------------Clear Text Boxes----------------------------------------
        public static void ClearTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool EmptyTextBox(ErrorProvider ErpProvid, params TextBox[] TextBoxArray)
        {
            ErpProvid.Clear();
            bool boolTextEmpty = false;
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                {
                    if (TBox.Text.Trim().CompareTo("") == 0)
                    {
                        ErpProvid.SetError(TBox, "This field cannot be empty!");
                        boolTextEmpty = true;
                    }
                }
                return boolTextEmpty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return boolTextEmpty;
            }
        }



        public static void GotFocusColorTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.BackColor = Color.Aqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void LostFocusColorTextBox(params TextBox[] TextBoxArray)
        {
            try
            {
                foreach (TextBox TBox in TextBoxArray)
                    TBox.BackColor = Color.LightBlue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion
        //-------------------------------------------------------------------------
        #region MaskBox Controler
        public static void EnableMaskBox(params MaskedTextBox[] MaskBoxArray)
        {
            try
            {
                foreach (MaskedTextBox MaskBox in MaskBoxArray)
                    MaskBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static void DisableMaskBox(params MaskedTextBox[] MaskBoxArray)
        {
            try
            {
                foreach (MaskedTextBox MaskBox in MaskBoxArray)
                    MaskBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static void ClearMaskBox(params MaskedTextBox[] MaskBoxArray)
        {
            try
            {
                foreach (MaskedTextBox MaskBox in MaskBoxArray)
                    MaskBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void SetMaskBoxToZero(params MaskedTextBox[] MaskBoxArray)
        {
            try
            {
                foreach (MaskedTextBox MaskBox in MaskBoxArray)
                    if (MaskBox.Text == string.Empty)
                        MaskBox.Text = MaskBox.Mask;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static bool EmptyMaskBox(ErrorProvider ErpProvid, params MaskedTextBox[] MaskBox)
        {
            bool boolMaskBoxEmpty = false;
            try
            {
                foreach (MaskedTextBox MskBox in MaskBox)
                {
                    if (MskBox.Text.CompareTo("") == 0)
                    {
                        ErpProvid.SetError(MskBox, "This field cannot be empty!");
                        boolMaskBoxEmpty = true;
                    }
                }
                return boolMaskBoxEmpty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return boolMaskBoxEmpty;
            }

        }
        #endregion
        #region GroupBoxControler
        //------------------------Disable Group Boxes -----------------------------------
        public static void DisableGroupBOx(params GroupBox[] GroupBoxArray)
        {
            try
            {
                foreach (GroupBox GrpBox in GroupBoxArray)
                    GrpBox.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //------------------------Enable Group Boxes -----------------------------------
        public static void EnableGroupBOx(params GroupBox[] GroupBoxArray)
        {
            try
            {
                foreach (GroupBox GrpBox in GroupBoxArray)
                    GrpBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //-----------------------Disable Check Boxes ---------------------------------
        #endregion
        #region CheckBox Controler
        public static void DisableCheckBox(params CheckBox[] CheckBoxArray)
        {
            try
            {
                foreach (CheckBox chkBox in CheckBoxArray)
                    chkBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void UncheckChkBox(params CheckBox[] CheckBoxArray)
        {
            try
            {
                foreach (CheckBox chkBox in CheckBoxArray)
                    chkBox.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //-----------------------Enable Check Boxes-----------------------------------
        public static void EnableeCheckBox(params CheckBox[] CheckBoxArray)
        {
            try
            {
                foreach (CheckBox chkBox in CheckBoxArray)
                    chkBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region ComboBox Cotroler
        //-------------------------Combo Boxes --------------------------------------
        public static void DiasableComboBox(params ComboBox[] ComboBoxArray)
        {
            try
            {
                foreach (ComboBox cmbBox in ComboBoxArray)
                    cmbBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void EnableComboBox(params ComboBox[] ComboBoxArray)
        {
            try
            {
                foreach (ComboBox cmbBox in ComboBoxArray)
                    cmbBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static bool EmptyComboBox(ErrorProvider ErpProvid, params ComboBox[] ComboBoxArray)
        {
            bool boolComboEmpty = false;
            try
            {
                foreach (ComboBox ComBox in ComboBoxArray)
                {
                    if (ComBox.Text.CompareTo("") == 0)
                    {
                        ErpProvid.SetError(ComBox, "This field cannot be empty!");
                        boolComboEmpty = true;
                    }
                }
                return boolComboEmpty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return boolComboEmpty;
            }
        }

        public static void SetComboBoxIndexMinus1(params ComboBox[] ComboBoxArray)
        {
            try
            {
                foreach (ComboBox CBox in ComboBoxArray)
                    CBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        //-----------------VALIDATE THE INPUT IS NUMERIC----------------------------
        public static void CheckNumeric(Object O, KeyPressEventArgs e)
        {
            if (Regex.Match(e.KeyChar.ToString(), "^[0-9.]$").Success)//ALLOW NUMBERS AND DECIMALS
                e.Handled = false;
            else if (e.KeyChar.ToString() == "\b")//ALLOW BACKSPACE
                e.Handled = false;
            else
                e.Handled = true;
        }



        public static void UnlockControl(Control frm, bool value)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is GroupBox || ctrl is Panel || ctrl is TabControl)
                {
                    UnlockControl(ctrl, value);
                }
                if (ctrl is TextBox || ctrl is ComboBox || ctrl is CheckBox || ctrl is RadioButton || ctrl is MaskedTextBox)
                {
                    ctrl.Enabled = value;

                }


            }
        }

        public static void ClearControls(Control frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is GroupBox || ctrl is Panel || ctrl is TabControl || ctrl is TabPage)
                {
                    ClearControls(ctrl);
                }
                if (ctrl is TextBox || ctrl is ComboBox || ctrl is CheckBox || ctrl is RadioButton || ctrl is MaskedTextBox)
                {
                    ctrl.Text = "";
                }

            }
        }

        public static bool AlreadyEntered(DataGridView Grid, int SerchColumn, string FindCode)
        {
            bool Found = false;

            for (int x = 0; x <= Grid.RowCount; x++)
            {
                if (Grid[SerchColumn, x].Value.ToString() == FindCode)
                {
                    Found = true;
                    goto LoopEnd;
                }
            }
        LoopEnd:
            return Found;
        }

        //public static void ClearControl(Control ctl)
        //{
        //    foreach (Control C in ctl.Controls)
        //    {
        //        try
        //        {

        //            if (C is TextBox)
        //            {
        //                if (C is NCCServer.UserControls.ucTextBox_Numeric)
        //                {
        //                    NCCServer.UserControls.ucTextBox_Numeric numTextBox = (NCCServer.UserControls.ucTextBox_Numeric)C;
        //                    C.Text = "0";
        //                }
        //                else
        //                {
        //                    C.Text = "";
        //                }
        //            }
        //            else if (C is ComboBox)
        //            {
        //                C.Text = "";
        //            }
        //            else if (C is DateTimePicker)
        //            {
        //                DateTimePicker DTP = (DateTimePicker)C;
        //                DTP.Value = DateTime.Now;
        //            }

        //            else if (C is GroupBox)
        //            {
        //                ClearControl(C);
        //            }
        //            else if (C is CheckBox)
        //            {
        //                CheckBox chkBox = (CheckBox)C;
        //                chkBox.Checked = false;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw new Exception(C.Name);
        //        }

        //    }
        //}
        private static void ClearGroupBox(Control ctl)
        {
            foreach (Control C in ctl.Controls)
            {

                if (C is TextBox)
                {
                    C.Text = "";
                }
                else if (C is ComboBox)
                {
                    C.Text = "";
                }
                else if (C is DateTimePicker)
                {
                    DateTimePicker DTP = (DateTimePicker)C;
                    DTP.Value = DateTime.Now;
                }

            }
        }
        public static void DisableControl(Control clt)
        {
            foreach (Control C in clt.Controls)
            {
                if (C is TextBox)
                {
                    clt.Enabled = false;
                }
                else if (C is ComboBox)
                {
                    clt.Enabled = false;
                }
                else if (C is CheckBox)
                {
                    C.Enabled = false;
                }
                else if (C is DataGrid)
                {
                    C.Enabled = false;
                }
                //else if (C is GroupBox)
                //{
                //    DisableGroupBox(C);
                //}
            }
        }
        public static void DisableGroupBox(Control clt)
        {
            foreach (Control C in clt.Controls)
            {
                if (C is TextBox)
                {
                    C.Enabled = false;
                }
                else if (C is ComboBox)
                {
                    C.Enabled = false;
                }
                else if (C is CheckBox)
                {
                    C.Enabled = false;
                }
            }
        }
        public static void EnableControl(Control clt)
        {
            foreach (Control C in clt.Controls)
            {
                if (C is TextBox)
                {
                    clt.Enabled = true;
                }
                else if (C is ComboBox)
                {
                    clt.Enabled = true;
                }
                else if (C is CheckBox)
                {
                    C.Enabled = true;
                }
                else if (C is GroupBox)
                {
                    EnableGroupBox(C);
                }
            }
        }
        private static void EnableGroupBox(Control clt)
        {
            foreach (Control C in clt.Controls)
            {
                if (C is TextBox)
                {
                    C.Enabled = true;
                }
                else if (C is ComboBox)
                {
                    C.Enabled = true;
                }
                else if (C is CheckBox)
                {
                    C.Enabled = true;
                }
            }
        }

        public static bool ValidateIntegers(ErrorProvider ErrProvider, params TextBox[] TextBoxArray)
        {
            ErrProvider.Clear();
            bool boolValInt = true;

            try
            {
                foreach (TextBox TBox in TextBoxArray)
                {
                    int IntVal;
                    if (int.TryParse(TBox.Text, out IntVal))
                    {
                        if (Convert.ToInt32(TBox.Text) < 0)
                        {
                            ErrProvider.SetError(TBox, "Please enter positive value.");
                            boolValInt = false;
                        }
                    }
                    else
                    {
                        ErrProvider.SetError(TBox, "Invalid Value.");
                        boolValInt = false;
                    }
                }
                return boolValInt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool ValidateDecimals(ErrorProvider ErrProvider, params TextBox[] TextBoxArray)
        {
            ErrProvider.Clear();
            bool boolVal = false;

            try
            {
                foreach (TextBox TBox in TextBoxArray)
                {
                    decimal DecVal;
                    if (decimal.TryParse(TBox.Text, out DecVal))
                    {
                        if (Convert.ToDecimal(TBox.Text) < 0)
                        {
                            ErrProvider.SetError(TBox, "Please enter positive value.");
                            boolVal = true;
                        }
                    }
                    else
                    {
                        ErrProvider.SetError(TBox, "Invalid Value.");
                        boolVal = true;
                    }
                }
                return boolVal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool ValidateIntegersDataGridView(DataGridView gvControl, params int[] IntegerArray)
        {
            bool boolValInt = true;

            try
            {
                foreach (DataGridViewRow gvRow in gvControl.Rows)
                {
                    foreach (int IntCol in IntegerArray)
                    {
                        if (gvRow.Cells[IntCol].Value != null)
                        {
                            int IntVal;
                            if (int.TryParse(gvRow.Cells[IntCol].Value.ToString(), out IntVal))
                            {
                                if (Convert.ToInt32(gvRow.Cells[IntCol].Value) < 0)
                                {
                                    boolValInt = false;
                                    goto Outer;
                                }
                            }
                            else
                            {
                                boolValInt = false;
                                goto Outer;
                            }
                        }
                        else
                        {
                            boolValInt = false;
                            goto Outer;
                        }
                    }
                }
            Outer:
                Application.DoEvents();

                return boolValInt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }



        public static bool ValidateDecimalDataGridView(DataGridView gvControl, params int[] IntegerArray)
        {
            bool boolValInt = true;

            try
            {
                foreach (DataGridViewRow gvRow in gvControl.Rows)
                {
                    foreach (int IntCol in IntegerArray)
                    {
                        if (gvRow.Cells[IntCol].Value != null)
                        {
                            Decimal IntVal;
                            if (Decimal.TryParse(gvRow.Cells[IntCol].Value.ToString(), out IntVal))
                            {
                                if (Convert.ToInt32(gvRow.Cells[IntCol].Value) < 0)
                                {
                                    boolValInt = false;
                                    goto Outer;
                                }
                            }
                            else
                            {
                                boolValInt = false;
                                goto Outer;
                            }
                        }
                        else
                        {
                            boolValInt = false;
                            goto Outer;
                        }
                    }
                }
            Outer:
                Application.DoEvents();

                return boolValInt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                Object mail = new System.Net.Mail.MailAddress(email);
                return false;
            }
            catch
            {
                return true;
            }
        }


        public static void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }


        public static void setDateFormat()
        {
            try
            {
                RegistryKey myKey = Registry.CurrentUser.OpenSubKey("Control Panel\\International", true);
                myKey.SetValue("sShortDate", Helper.dateFormat, RegistryValueKind.String);
                //Instant refresh registry
                const int HWND_BROADCAST = 0xffff;
                const int WM_WININICHANGE = 0x001a, WM_SETTINGCHANGE = WM_WININICHANGE, INI_INTL = 1;
                SendMessage(HWND_BROADCAST, WM_SETTINGCHANGE, 0, INI_INTL);
            }
            catch { }

        }


        public static Boolean isInternetActive()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        public static long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }

        public static FileInfo GetDirectoryImage(string p, string Image)
        {

            string[] a = Directory.GetFiles(p, Image);
            FileInfo info = null;
            long b = 0;
            foreach (string name in a)
            {
                  info = new FileInfo(name);
                  break;
            }
            return info;
        }

    }
}
