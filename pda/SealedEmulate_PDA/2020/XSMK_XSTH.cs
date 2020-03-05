using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SealedEmulate_PDA.Dal;
using SealedEmulate_PDA.Model;

namespace SealedEmulate_PDA._2020
{
    public partial class XSMK_XSTH : Form
    {
        public XSMK_XSTH()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ����ҳ - ��ʼ��DataTable
        /// </summary>
        private DataTable Page3Data = new DataTable();
        /// <summary>
        /// ����ҳ - �ͻ�����
        /// </summary>
        private string CardCode = "";
        /// <summary>
        /// ����ҳ - �ͻ�����
        /// </summary>
        private string CardName = "";
        /// <summary>
        /// ����ҳ - ���۶���
        /// </summary>
        private string xsdd = "";
        /// <summary>
        /// ����ҳ - ���۶����к�
        /// </summary>
        private string xsddhh = "";

        #region Load
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XSMK_XSTH_Load(object sender, EventArgs e)
        {
            Page3Data.Columns.Add("#");
            Page3Data.Columns.Add("���ϱ���");
            Page3Data.Columns.Add("��������");
            Page3Data.Columns.Add("����");
            Page3Data.Columns.Add("�ֿ����");
            Page3Data.Columns.Add("�ֿ�����");
            Page3Data.Columns.Add("��λ��ʶ");
            Page3Data.Columns.Add("��λ����");
            Page3Data.Columns.Add("�������");
            Page3Data.Columns.Add("�������");
            Page3Data.Columns.Add("�����к�");
            Page3Data.Columns.Add("��������");
            Page3Data.Columns.Add("����");
            Page3Data.Columns.Add("�кϼ�");
            Page3Data.Columns.Add("�ͻ�����");
            Page3Data.Columns.Add("�ͻ�����");
            Page3Data.Columns.Add("���۶���");
            Page3Data.Columns.Add("���۶����к�");
            Page3Data.Rows.Clear();

            #region �������п�λ�ֿ�
            string sql2 = "EXEC SAP_NEW_OWHS_BIN";
            DataTable page2Data = SqlHelper.GetDataTable(sql2, CommandType.Text);
            this.page2Whs.DataSource = page2Data;
            this.page2Whs.DisplayMember = "WhsName";
            this.page2Whs.ValueMember = "WhsCode";
            #endregion

            page1DocEntry.Focus();
        }
        #endregion



        #region ����ҳ
        /// <summary>
        /// ���۽����س�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page1DocEntry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(this.page1DocEntry.Text.Trim(), @"^[1-9]\d*$"))
                    {
                        #region ����ҳ��ɨ��ҳ������ҳ�������
                        //1
                        this.page1Grid.DataSource = null;
                        //2 
                        CardCode = "";
                        CardName = "";
                        page2QuanTity = 0;
                        page1LineNum = "";
                        page2AbsEntry = "";

                        this.page2BarCode.Text = "";
                        this.page2ItemCode.Text = "";
                        this.page2ItemName.Text = "";
                        this.page2ItemBatch.Text = "";
                        this.page2BinCode.Text = "";
                        this.page2Qty.Text = "";
                        //3
                        this.page3Grid.DataSource = null;
                        #endregion
                        int page1DocEntry = int.Parse(this.page1DocEntry.Text.Trim());
                        string sql1 = "exec SAP_NEW_XSTH_LOAD " + page1DocEntry;
                        DataTable page1Data = SqlHelper.GetDataTable(sql1, CommandType.Text);
                        if (page1Data != null && page1Data.Rows.Count > 0)
                        {
                            #region ����ҳ���ñ�����ʽ��������
                            DataGridTableStyle page1Mydata = new DataGridTableStyle();
                            GridColumnStylesCollection page1Mycol = null;
                            this.page1Grid.DataSource = page1Data;
                            page1Mydata.MappingName = page1Data.TableName;
                            this.page1Grid.TableStyles.Clear();
                            this.page1Grid.TableStyles.Add(page1Mydata);
                            page1Mycol = this.page1Grid.TableStyles[0].GridColumnStyles;
                            page1Mycol["#"].Width = 0;
                            page1Mycol["���ϱ���"].Width = 80;
                            page1Mycol["��������"].Width = 80;
                            page1Mycol["�к�"].Width = 0;
                            page1Mycol["�ͻ�����"].Width = 0;
                            page1Mycol["�ͻ�����"].Width = 0;
                            page1Mycol["���۶���"].Width = 0;
                            page1Mycol["���۶����к�"].Width = 0;
                            CardCode = page1Data.Rows[0]["�ͻ�����"].ToString();
                            CardName = page1Data.Rows[0]["�ͻ�����"].ToString();
                            xsdd = page1Data.Rows[0]["���۶���"].ToString();
                            xsddhh = page1Data.Rows[0]["���۶����к�"].ToString();
                            #endregion

                            #region ����ҳ ���ݶ������س���
                            DataTable page3Data = Page3Data;
                            DataGridTableStyle page3Mydata = new DataGridTableStyle();
                            GridColumnStylesCollection page3Mycol = null;
                            this.page3Grid.DataSource = page3Data;
                            page3Mydata.MappingName = page3Data.TableName;
                            this.page3Grid.TableStyles.Clear();
                            this.page3Grid.TableStyles.Add(page3Mydata);
                            page3Mycol = this.page3Grid.TableStyles[0].GridColumnStyles;
                            page3Mycol["#"].Width = 0;
                            page3Mycol["���ϱ���"].Width = 80;
                            page3Mycol["��������"].Width = 80;
                            page3Mycol["�ֿ�����"].Width = 0;
                            page3Mycol["��λ��ʶ"].Width = 0;
                            page3Mycol["�������"].Width = 0;
                            page3Mycol["�����к�"].Width = 0;
                            page3Mycol["��������"].Width = 0;
                            page3Mycol["����"].Width = 0;
                            page3Mycol["�кϼ�"].Width = 0;
                            page3Mycol["�ͻ�����"].Width = 0;
                            page3Mycol["�ͻ�����"].Width = 0;
                            page3Mycol["���۶���"].Width = 0;
                            page3Mycol["���۶����к�"].Width = 0;
                            #endregion

                            //��ת��ɨ��ҳ
                            tabControl1.SelectedIndex = 2;//�ȳ�ʼ��һ��ҳǩ,����ҳǩ3���ܸ���;������bug
                            tabControl1.SelectedIndex = 1;
                        }
                        else
                        {
                            MessageBox.Show("�ö����ѹرջ��߲�����...", "��ʾ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("���붩����Ų��Ϸ�!", "����");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����");
            }
        }
        #endregion



        #region ɨ��ҳ

        /// <summary>
        /// ɨ��ҳ - ������ʣ������������
        /// </summary>
        private double page2QuanTity = 0;
        /// <summary>
        /// ����ҳ - ��¼�����к�
        /// </summary>
        private string page1LineNum = "";
        /// <summary>
        /// ��λ��ʶ��
        /// </summary>
        private string page2AbsEntry = "";

        /// <summary>
        /// ������Ϣ�س�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page2BarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.page1DocEntry.Text.Trim() == "")
                    {
                        MessageBox.Show("���۽�������Ϊ��", "����");
                        return;
                    }
                    string page2BarCode = this.page2BarCode.Text.Trim();
                    if (page2BarCode == "")
                    {
                        return;
                    }
                    if (page2BarCode.IndexOf(',') == -1)
                    {
                        MessageBox.Show("��ά������ʽ����ȷ", "����");
                        return;//ƥ������Ϊ�������һ��,��
                    }
                    #region ɨ��ҳ���
                    page2QuanTity = 0;
                    page1LineNum = "";
                    page2AbsEntry = "";

                    this.page2ItemCode.Text = "";
                    this.page2ItemName.Text = "";
                    this.page2ItemBatch.Text = "";
                    this.page2BinCode.Text = "";
                    this.page2Qty.Text = "";
                    #endregion
                    string page2ItemCode = page2BarCode.Split(',')[0].Trim();
                    string page2ItemName = page2BarCode.Split(',')[1].Trim();
                    string page2ItemBatch = page2BarCode.Split(',')[2].Trim();
                    //�ж϶���ҳ���Ϻͳ�������
                    DataTable page1Data = (DataTable)page1Grid.DataSource;//����ҳ
                    DataRow[] page1Rows = page1Data.Select("���ϱ���='" + page2ItemCode + "'");
                    if (page1Rows.Length > 0)
                    {
                        DataRow page1Row = page1Rows[0];
                        page2QuanTity = (Convert.ToDouble(page1Row["ʣ������"].ToString()) - Convert.ToDouble(page1Row["�������"].ToString()));
                        if (page2QuanTity == 0)
                        {
                            MessageBox.Show("���������˻����", "��ʾ");
                            this.page2BarCode.Text = "";
                            this.page2BarCode.Focus();
                            return;
                        }
                        //У�������Ƿ�Ϊ��������
                        string sql = "SELECT COUNT(*) Num FROM [dbo].[Bar_XSMK_XSJH] WHERE IsImport=1 AND SalesRecDoc=" + this.page1DocEntry.Text.Trim() + " AND ItemCode='" + page2ItemCode + "' AND ItemBatch='" + page2ItemBatch + "'";
                        int num = int.Parse(SqlHelper.ExecuteScalar(sql, CommandType.Text).ToString());
                        if (num == 0)
                        {
                            MessageBox.Show("���������۽��������β�ƥ��.", "��ʾ");
                            this.page2BarCode.Text = "";
                            this.page2BarCode.Focus();
                            return;
                        }
                        //ɨ��ҳ��ֵ
                        this.page2ItemCode.Text = page2ItemCode;
                        this.page2ItemName.Text = page2ItemName;
                        this.page2ItemBatch.Text = page2ItemBatch;
                        this.page2Whs.SelectedValue = page1Row["�ֿ�"].ToString();
                        this.page2BinCode.Focus();
                        page1LineNum = page1Row["�к�"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("ɨ�����������۶�����ƥ��", "��ʾ");
                        this.page2BarCode.Text = "";
                        this.page2BarCode.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����");
            }
        }
        /// <summary>
        /// �ֿⷢ���仯 - ��տ�λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page2Whs_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.page2BinCode.Text = "";
            this.page2BinCode.Focus();
        }
        /// <summary>
        /// ��λ�س�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page2BinCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string page2WhsCodeText = "";
                string page2BinCodeText = "";
                string page2BinCode = this.page2BinCode.Text.Trim();
                if (page2BinCode == "")
                {
                    return;
                }
                if (page2BinCode.IndexOf(',') == -1)
                {
                    #region �ֶ�����
                    page2BinCodeText = page2BinCode;
                    page2WhsCodeText = this.page2Whs.SelectedValue.ToString();
                    string sql = "exec SAP_NEW_OWHS_OnBinCode '" + page2WhsCodeText + "','" + page2BinCodeText + "'";
                    DataTable whsBinDt = SqlHelper.GetDataTable(sql, CommandType.Text);
                    if (whsBinDt != null && whsBinDt.Rows.Count > 0)
                    {
                        DataTable page3Data = (DataTable)page3Grid.DataSource;//����ҳ
                        DataRow[] checkWhsRows = page3Data.Select("�����к�='" + page1LineNum + "'");
                        if (checkWhsRows.Length > 0)
                        {
                            string whsCode = checkWhsRows[0]["�ֿ����"].ToString().Trim();
                            if (page2WhsCodeText != whsCode)
                            {
                                //�����ʱ���ŵ���,���������ϲ���ѡ�����������ϲֿ�
                                this.page2BinCode.Text = "";
                                MessageBox.Show("ֻ��ѡ��˲ֿ⣺" + checkWhsRows[0]["�ֿ�����"].ToString().Trim(), "��ʾ");
                            }
                            else
                            {
                                page2AbsEntry = whsBinDt.Rows[0][0].ToString();
                                this.page2Qty.Focus();
                            }
                        }
                        else
                        {
                            page2AbsEntry = whsBinDt.Rows[0][0].ToString();
                            this.page2Qty.Focus();
                        }
                    }
                    else
                    {
                        this.page2BinCode.Text = "";
                        MessageBox.Show("�����λ��ά�벻��ȷ", "��ʾ");
                    }
                    #endregion
                }
                else
                {
                    #region ɨ��
                    page2BinCodeText = page2BinCode.Split(',')[1];
                    page2WhsCodeText = page2BinCode.Split(',')[0];
                    string sql = "exec SAP_NEW_OWHS_OnBinCode '" + page2WhsCodeText + "','" + page2BinCodeText + "'";
                    DataTable whsBinDt = SqlHelper.GetDataTable(sql, CommandType.Text);
                    if (whsBinDt != null && whsBinDt.Rows.Count > 0)
                    {
                        DataTable page3Data = (DataTable)page3Grid.DataSource;//����ҳ
                        DataRow[] checkWhsRows = page3Data.Select("�����к�='" + page1LineNum + "'");
                        if (checkWhsRows.Length > 0)
                        {
                            string whsCode = checkWhsRows[0]["�ֿ����"].ToString().Trim();
                            if (page2WhsCodeText != whsCode)
                            {
                                //�����ʱ���ŵ���,���������ϲ���ѡ�����������ϲֿ�
                                this.page2BinCode.Text = "";
                                MessageBox.Show("ֻ��ѡ��˲ֿ⣺" + checkWhsRows[0]["�ֿ�����"].ToString().Trim(), "��ʾ");
                            }
                            else
                            {
                                this.page2Whs.SelectedValue = page2WhsCodeText;
                                this.page2BinCode.Text = page2BinCode;
                                page2AbsEntry = whsBinDt.Rows[0][0].ToString();
                                this.page2Qty.Focus();
                            }
                        }
                        else
                        {
                            this.page2Whs.SelectedValue = page2WhsCodeText;
                            this.page2BinCode.Text = page2BinCode;
                            page2AbsEntry = whsBinDt.Rows[0][0].ToString();
                            this.page2Qty.Focus();
                        }
                    }
                    else
                    {
                        this.page2BinCode.Text = "";
                        MessageBox.Show("��λ��ά����ϵͳ�в����ڴ˿�λ", "��ʾ");
                    }
                    #endregion
                }
            }
        }
        /// <summary>
        /// ����������ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page2BtnAdd_Click(object sender, EventArgs e)
        {
            if ((this.page2BarCode.Text.Trim() == "") && (this.page2Qty.Text.Trim() == ""))
            {
                return;
            }

            string page1DocEntry = this.page1DocEntry.Text.Trim();
            string page2ItemCode = this.page2ItemCode.Text.Trim();
            string page2ItemName = this.page2ItemName.Text.Trim();
            string page2ItemBatch = this.page2ItemBatch.Text.Trim();
            string page2WhsCode = this.page2Whs.SelectedValue.ToString();
            string page2WhsName = this.page2Whs.Text.Trim();
            string page2BinCode = this.page2BinCode.Text.Trim();
            string page2BinCodeText = "";
            if (page2BinCode.IndexOf(',') == -1)
            {
                //�ֶ�����
                page2BinCodeText = page2BinCode;
            }
            else
            {
                //ɨ��
                page2BinCodeText = page2BinCode.Split(',')[1];
            }
            double page2Qty = Convert.ToDouble(this.page2Qty.Text.Trim());
            if (CardCode == "" || page2ItemCode == "" || page2AbsEntry == "")
            {
                MessageBox.Show("����ɨ�����ϻ�ɨ���λ", "����");
                return;
            }
            else if (page2Qty > page2QuanTity)
            {
                MessageBox.Show("ʣ���˻�����Ϊ��" + page2QuanTity, "����");
                return;
            }
            else
            {
                DataTable page3Data = (DataTable)page3Grid.DataSource;//����ҳ
                DataRow[] checkWhsRows = page3Data.Select("�����к�='" + page1LineNum + "'");
                if (checkWhsRows.Length > 0)
                {
                    string whsCode = checkWhsRows[0]["�ֿ����"].ToString().Trim();
                    if (page2WhsCode != whsCode)
                    {
                        //�����ʱ���ŵ���,���������ϲ���ѡ�����������ϲֿ�
                        MessageBox.Show("ֻ��ѡ��˲ֿ⣺" + checkWhsRows[0]["�ֿ�����"].ToString().Trim(), "��ʾ");
                    }
                    else
                    {
                        DataRow[] page3Rows = page3Data.Select("�����к�='" + page1LineNum + "' and ����='" + page2ItemBatch + "' and ��λ��ʶ='" + page2AbsEntry + "'");
                        if (page3Rows.Length > 0)
                        {
                            //����������� 8
                            int rowLine = int.Parse(page3Rows[0]["#"].ToString());
                            double qty = double.Parse(page3Rows[0]["�������"].ToString()) + page2Qty;
                            page3Grid[rowLine, 8] = qty.ToString();
                        }
                        else
                        {
                            DataRow page3Row = page3Data.NewRow();
                            //�Ƿ�Ϊ����
                            int count = page3Data.Rows.Count == 0 ? 0 : page3Data.Rows.Count;
                            page3Row["#"] = count.ToString();
                            page3Row["���ϱ���"] = page2ItemCode;
                            page3Row["��������"] = page2ItemName;
                            page3Row["����"] = page2ItemBatch;
                            page3Row["�ֿ����"] = page2WhsCode;
                            page3Row["�ֿ�����"] = page2WhsName;
                            page3Row["��λ��ʶ"] = page2AbsEntry;
                            page3Row["��λ����"] = page2BinCodeText;
                            page3Row["�������"] = page2Qty.ToString();
                            page3Row["�������"] = page1DocEntry;
                            page3Row["�����к�"] = page1LineNum;
                            page3Row["�ͻ�����"] = CardCode;
                            page3Row["�ͻ�����"] = CardName;
                            page3Row["���۶���"] = xsdd;
                            page3Row["���۶����к�"] = xsddhh;
                            page3Data.Rows.Add(page3Row);
                            page3Grid.DataSource = page3Data;
                        }
                    }
                }
                else
                {
                    DataRow page3Row = page3Data.NewRow();
                    //�Ƿ�Ϊ����
                    int count = page3Data.Rows.Count == 0 ? 0 : page3Data.Rows.Count;
                    page3Row["#"] = count.ToString();
                    page3Row["���ϱ���"] = page2ItemCode;
                    page3Row["��������"] = page2ItemName;
                    page3Row["����"] = page2ItemBatch;
                    page3Row["�ֿ����"] = page2WhsCode;
                    page3Row["�ֿ�����"] = page2WhsName;
                    page3Row["��λ��ʶ"] = page2AbsEntry;
                    page3Row["��λ����"] = page2BinCodeText;
                    page3Row["�������"] = page2Qty.ToString();
                    page3Row["�������"] = page1DocEntry;
                    page3Row["�����к�"] = page1LineNum;
                    page3Row["�ͻ�����"] = CardCode;
                    page3Row["�ͻ�����"] = CardName;
                    page3Row["���۶���"] = xsdd;
                    page3Row["���۶����к�"] = xsddhh;
                    page3Data.Rows.Add(page3Row);
                    page3Grid.DataSource = page3Data;
                }
                //���¶���ҳʣ���������
                DataTable page1Data = (DataTable)page1Grid.DataSource;//����ҳ
                int page1RowLine = int.Parse(page1Data.Select("�к�='" + page1LineNum + "'")[0]["#"].ToString());
                double page1Qty = Convert.ToDouble(page1Grid[page1RowLine, 5].ToString()) + page2Qty;
                page1Grid[page1RowLine, 5] = page1Qty.ToString();
                #region ɨ��ҳ���
                page2QuanTity = 0;
                page1LineNum = "";
                page2AbsEntry = "";
                this.page2BarCode.Text = "";
                this.page2ItemCode.Text = "";
                this.page2ItemName.Text = "";
                this.page2ItemBatch.Text = "";
                this.page2BinCode.Text = "";
                this.page2Qty.Text = "";
                #endregion
                this.page2BarCode.Focus();
            }
        }
        #endregion
         


        #region ����ҳ
        /// <summary>
        /// ɾ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page3BtnDel_Click(object sender, EventArgs e)
        {
            DataTable page3Data = (DataTable)page3Grid.DataSource;//����ҳ  
            int page3RowSelectIndex = this.page3Grid.CurrentRowIndex;
            if (page3RowSelectIndex != -1)
            {
                double page3Qty = Convert.ToDouble(this.page3Grid[page3RowSelectIndex, 8].ToString());
                string page3ItemCode = this.page3Grid[page3RowSelectIndex, 1].ToString();
                //���¶���ҳ
                DataTable page1Data = (DataTable)page1Grid.DataSource;
                DataRow[] page1Rows = page1Data.Select("���ϱ���='" + page3ItemCode + "'");
                int page1RowSelectIndex = int.Parse(page1Rows[0]["#"].ToString());
                double page1Qty = (Convert.ToDouble(page1Rows[0]["�������"].ToString())) - page3Qty;
                this.page1Grid[page1RowSelectIndex, 5] = page1Qty;
                //���¹���ҳ
                page3Data.Rows.RemoveAt(page3RowSelectIndex);
                page3Grid.Refresh();
                MessageBox.Show("ɾ���ɹ�", "��ʾ");
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page3BtnAdd_Click(object sender, EventArgs e)
        {
            string dateTimeStr = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            List<string> sql = new List<string>();
            //�������м��
            DataTable page3Data = (DataTable)page3Grid.DataSource;//����ҳ
            if (page3Data.Rows.Count > 0)
            {
                foreach (DataRow row in page3Data.Rows)
                {
                    sql.Add(string.Format("insert into [dbo].[Bar_XSMK_XSTH] (CardCode,CardName,DocEntry,LineNum,ItemCode,ItemName,ItemBatch,Qty,Price,LineTotal,WhsCode,WhsName,AbsEntry,BinCode,InWhsQty,UserSign,DocEntryFlag,IsAuthor,AuthorName) values ('{0}','{1}',{2},{3},'{4}','{5}','{6}',{7},{8},{9},'{10}','{11}',{12},'{13}',{14},'{15}','{16}','{17}','{18}')", row["�ͻ�����"].ToString(), row["�ͻ�����"].ToString(), row["�������"].ToString(), row["�����к�"].ToString(), row["���ϱ���"].ToString(), row["��������"].ToString(), row["����"].ToString(), 0, 0, 0, row["�ֿ����"].ToString(), row["�ֿ�����"].ToString(), row["��λ��ʶ"].ToString(), row["��λ����"].ToString(), row["�������"].ToString(), ConnModel.userName, dateTimeStr, 'N', ' '));
                }
                //����SAP�Զ����ֶ�
                DataTable page1Data = (DataTable)page1Grid.DataSource;//����ҳ
                foreach (DataRow row in page1Data.Rows)
                {
                    double page1Qty = Convert.ToDouble(row["�������"].ToString());
                    if (page1Qty > 0)
                    {
                        sql.Add(string.Format("UPDATE {0}.. DLN1 SET U_THQty ={1},U_THLineStatus = CASE WHEN Quantity = {1} THEN 'C' ELSE 'O' END WHERE DocEntry = {2} AND LineNum = {3}", ConnModel.commonDB, (double.Parse(row["��������"].ToString()) + double.Parse(row["�������"].ToString()) - double.Parse(row["ʣ������"].ToString())), this.page1DocEntry.Text.Trim(), row["�к�"].ToString()));
                        sql.Add(string.Format("UPDATE {0}.. RDR1 SET U_XSQty =U_XSQty -{1},U_XSLineStatus =  'O' WHERE DocEntry = {2} AND LineNum = {3}", ConnModel.commonDB, (double.Parse(row["��������"].ToString()) + double.Parse(row["�������"].ToString()) - double.Parse(row["ʣ������"].ToString())), row["���۶���"].ToString(), row["���۶����к�"].ToString()));
                    }
                }
                if (SqlHelper.ExecuteSqlTran(sql) > 0)
                {
                    #region ���ɨ��ҳ�����������ص���һ��ҳǩ
                    //1
                    this.page1DocEntry.Text = "";
                    this.page1Grid.DataSource = null;
                    CardCode = "";
                    CardName = "";
                    //2
                    page2QuanTity = 0;
                    page1LineNum = "";
                    page2AbsEntry = "";

                    this.page2BarCode.Text = "";
                    this.page2ItemCode.Text = "";
                    this.page2ItemName.Text = "";
                    this.page2ItemBatch.Text = "";
                    this.page2BinCode.Text = "";
                    this.page2Qty.Text = "";
                    //3
                    this.page3Grid.DataSource = null;
                    this.Page3Data.Rows.Clear();
                    //4 ���ص���һ��ҳǩ
                    tabControl1.SelectedIndex = 0;
                    #endregion


                    //����API����ϵͳ����
                    //string url = "XSGL_XSTH/Import";
                    //string ps = "{DocEntryFlag:'" + dateTimeStr + "'}";
                    //string valStr = HttpHelper.HttpPost(url, ps);
                    //if (valStr.Split(':')[0].ToString() == "0")
                    //{
                    //    MessageBox.Show("OK");
                    //}
                    //else
                    //{
                    //    MessageBox.Show(valStr.Split(':')[1].ToString(), "����");
                    //}
                }
                else
                {
                    MessageBox.Show("�������м��ʧ��,��������������.", "��ʾ");
                }
            }
        }

        #endregion


    }
}