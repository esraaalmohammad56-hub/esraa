using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Data.sqlclient;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



public class FORM	
	Dim cmd As SqlCommand
	Dim con As SqlConnection 
	Dim da As SqlDataAdapter
	private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click

	
		// ربط البرنامج بقاعدة البيانات 
		SqlConnection con = new SqlConnection();
		string server_Name = @"DESKTOP-34POKBM";
		string Database_Name = "TEST2";
		con.ConnectionString = @"DataSource" + server_Name + ";Initial Catalog=" + Database_Name + ";Integrated Security";
		con.Open();
		// جلب البيانات من الجدول 
		SqlCommand cnd = new SqlCommand("select * from User where name=" + txtUsername.Text + "and password=" + txtPassword.Text);
		SqlDataAdapter da = new SqlDataAdapter(cnd);
		DataTable dt = new DataTable();
		da.Fill(dt);
		// اختبار هل هذه البيانات مطابقة ام لا 
		if (dt.Rows.Count > 0)
		{
			frmMain frm = new frmMain();
			frm.ShowDialog();
		}
		else
			MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة ");
		con.close();


	End sub 
