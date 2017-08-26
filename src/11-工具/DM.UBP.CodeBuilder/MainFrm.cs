using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Globalization;

namespace DM.UBP.CodeBuilder
{
    public partial class MainFrm : Form
    {
        private string _EntityNS = "DM.UBP.Domain.Entity";

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            tbCodeRootPath.Text = System.Configuration.ConfigurationManager.AppSettings["CodeRootPath"];
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext("default"))
            {
                List<string> tableNameList = new List<string>();

                switch (context.Database.Connection.GetType().Name)
                {
                    case "OracleConnection":
                        tableNameList = context.Database.SqlQuery<string>("SELECT table_name from user_tables").ToList();
                        break;
                    case "SqlConnection":
                        tableNameList = context.Database.SqlQuery<string>("select name from sysobjects where xtype = 'U'").ToList();
                        break;

                }

                if (tableNameList.Count > 0)
                {
                    cbTableName.Items.Clear();
                    cbTableName.Items.AddRange(tableNameList.ToArray());
                }
            }

        }

        private void tbModuleName_TextChanged(object sender, EventArgs e)
        {
            tbEntityNS.Text = _EntityNS + (String.IsNullOrEmpty(tbModuleName.Text) ? "" : "." + tbModuleName.Text)
                                        + (String.IsNullOrEmpty(tbSubModuleName.Text) ? "" : "." + tbSubModuleName.Text);
        }

        private void cbTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var textInfo = new CultureInfo("en-US").TextInfo;
            //tbFileName.Text = textInfo.ToTitleCase(cbTableName.Text.ToLower());
            tbFileName.Text = cbTableName.Text.ToPascalCase();
            LoadDBFields();
        }

        private void LoadDBFields()
        {
            string sql = "";

            using (var context = new MyDbContext("default"))
            {
                List<Field> fieldList = new List<Field>();

                switch (context.Database.Connection.GetType().Name)
                {
                    case "OracleConnection":
                        sql = "select a.COLUMN_NAME name, a.DATA_TYPE type, a.DATA_LENGTH length, a.DATA_SCALE scale, "
                            + " case when a.nullable = 'Y' then 1 else 0 end nullable, 0 IsIdentity, 0 ispk, b.comments "
                            + " from user_TAB_COLUMNS a, user_col_comments b "
                            + " where a.table_name = b.table_name and a.column_name = b.column_name"
                            + " and a.TABLE_NAME ='" + cbTableName.Text + "'";
                        break;
                    case "SqlConnection":
                        sql = @"SELECT col.name AS name, typ.name as type, col.max_length AS length, col.scale AS scale,
                                cast(col.is_nullable as bit) AS nullable, cast(col.is_identity as bit) AS IsIdentity,
                                cast(case when exists (SELECT 1 FROM sys.indexes idx
                                                        join sys.index_columns idxCol
                                                                on(idx.object_id = idxCol.object_id)
                                                        WHERE idx.object_id = col.object_id
                                                                AND idxCol.index_column_id = col.column_id
                                                                AND idx.is_primary_key = 1
                                                    ) THEN 1 ELSE 0 END as bit) AS IsPk,
	                                g.[value] comments
                                FROM sys.columns col left join sys.types typ on(col.system_type_id = typ.system_type_id)
                                     left join sys.extended_properties g on(col.object_id = g.major_id AND g.minor_id = col.column_id)
                                    WHERE col.object_id = (SELECT object_id FROM sys.tables WHERE name = '" + cbTableName.Text + "')";
                        break;

                }

                fieldList = context.Database.SqlQuery<Field>(sql).ToList();
                if (fieldList.Count > 0)
                {
                    gvFields.DataSource = fieldList;
                    //gvFields.Columns[0].DataPropertyName = "NAME";
                    //gvFields.Columns[1].DataPropertyName = "TYPE";
                    //gvFields.Columns[2].DataPropertyName = "LENGTH";
                    //gvFields.Columns[3].DataPropertyName = "SCALE";
                    //gvFields.Columns[4].DataPropertyName = "Nullable";
                    //gvFields.Columns[5].DataPropertyName = "Comments";
                    //gvFields.Columns[6].DataPropertyName = "IsIdentity";
                    //gvFields.Columns[7].DataPropertyName = "IsPk";
                }
            }
        }
    }
}
