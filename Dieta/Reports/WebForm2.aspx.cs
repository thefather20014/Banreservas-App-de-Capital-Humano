using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dieta.Reports
{
	public partial class WebForm2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		private void ShowReport()
		{
			ReportViewer1.Reset();

			DataTable dt = getData(TextBox1.Text);
			ReportDataSource rds = new ReportDataSource("DataSet", dt);

			ReportViewer1.LocalReport.DataSources.Add(rds);
			ReportViewer1.LocalReport.ReportPath = "Reports/Report2.rdlc";

			ReportParameter rptParam = new ReportParameter("ReportParameter", TextBox1.Text);
			ReportViewer1.LocalReport.SetParameters(rptParam);

			ReportViewer1.LocalReport.Refresh();
		}

		private DataTable getData(string paramatro)
		{
			DataTable dt = new DataTable();
			string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ProcesosDAConnectionString"].ConnectionString;
			using( SqlConnection cn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand("REPORT", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PARAMETRO", SqlDbType.VarChar).Value = paramatro;

				SqlDataAdapter adp = new SqlDataAdapter(cmd);
				adp.Fill(dt);
			}
			return dt;
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			ShowReport();
		}
	}
}